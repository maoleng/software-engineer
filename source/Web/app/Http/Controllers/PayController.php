<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Contracts\View\View;
use Illuminate\Http\Request;

class PayController extends Controller
{

    public function pay(Request $request): string
    {
        $cart = session()->get('cart') ?? [];
        $products = Product::query()->whereIn('id', array_keys($cart))->with('discounts')->get();
        $price_products = 0;
        $price_discounts = 0;
        $data = [];
        foreach ($cart as $product_id => $amount) {
            $product = $products->where('id', $product_id)->first();
            $percent_discount = $product->discounts->where('need_amount', '<=', $amount)->sortByDesc('need_amount')
                ->first()->percent ?? 0;
            $price_discount = $product->price * $percent_discount / 100;
            $price_discounts += $price_products * $amount;
            $sum = $amount * $product->price;
            $price_products += $sum;
            $data[] = [
                'product_id' => $product->id,
                'name' => $product->name,
                'amount' => $amount,
                'price' => $product->price,
                'discount_price' => $price_discount,
                'original_price' => $product->originalPrice,
            ];
        }
        session()->put('order.fee.product_price', $price_products - $price_discounts);
        session()->put('order.products', $data);

        $price_ship = session()->get('order.fee.ship') ?? 0;
        $total = $price_products - $price_discounts + $price_ship;

        return $this->createPaymentUrl($total, route('payment.ipn'), $request->get('bank_code'));
    }


    public function ipn(Request $request)
    {
        $data = $request->all();
        $inputData = [];
        foreach ($data as $key => $value) {
            if (str_starts_with($key, "vnp_")) {
                $inputData[$key] = $value;
            }
        }
        $vnp_SecureHash = $inputData['vnp_SecureHash'];
        unset($inputData['vnp_SecureHash']);
        ksort($inputData);
        $i = 0;
        $hashData = "";
        foreach ($inputData as $key => $value) {
            if ($i === 1) {
                $hashData .= '&'.urlencode($key)."=".urlencode($value);
            } else {
                $hashData .= urlencode($key)."=".urlencode($value);
                $i = 1;
            }
        }
        $secureHash = hash_hmac('sha512', $hashData, env('VNP_HASH_SECRET'));
        if ($secureHash !== $vnp_SecureHash) {
            abort(403);
        }
        $data = $request->all();
        if (! isset($data['vnp_TxnRef'], $data['vnp_BankCode'])) {
            abort(403);
        }
    }

    public function createPaymentUrl($total, $return_url, $bank_code): string
    {
        $vnp_TmnCode = env('VNP_TMNCODE');
        $vnp_HashSecret = env('VNP_HASH_SECRET');
        $vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        $vnp_Returnurl = $return_url;
        $startTime = date("YmdHis");
        $expire = date('YmdHis',strtotime('+15 minutes',strtotime($startTime)));

        $vnp_TxnRef = rand(1,10000);
        $vnp_Amount = $total;
        $vnp_Locale = 'vn';
        $vnp_BankCode = $bank_code;
        $vnp_IpAddr = $_SERVER['REMOTE_ADDR'];

        $inputData = array(
            "vnp_Version" => "2.1.0",
            "vnp_TmnCode" => $vnp_TmnCode,
            "vnp_Amount" => $vnp_Amount* 100,
            "vnp_Command" => "pay",
            "vnp_CreateDate" => date('YmdHis'),
            "vnp_CurrCode" => "VND",
            "vnp_IpAddr" => $vnp_IpAddr,
            "vnp_Locale" => $vnp_Locale,
            "vnp_OrderInfo" => "Thanh toan GDnh toan GDnh toan GDnh toan GD:" . $vnp_TxnRef,
            "vnp_OrderType" => "other",
            "vnp_ReturnUrl" => $vnp_Returnurl,
            "vnp_TxnRef" => $vnp_TxnRef,
            "vnp_ExpireDate"=>$expire
        );

        if (isset($vnp_BankCode) && $vnp_BankCode !== "") {
            $inputData['vnp_BankCode'] = $vnp_BankCode;
        }

        ksort($inputData);
        $query = "";
        $i = 0;
        $hashdata = "";
        foreach ($inputData as $key => $value) {
            if ($i === 1) {
                $hashdata .= '&' . urlencode($key) . "=" . urlencode($value);
            } else {
                $hashdata .= urlencode($key) . "=" . urlencode($value);
                $i = 1;
            }
            $query .= urlencode($key) . "=" . urlencode($value) . '&';
        }

        $vnp_Url .= "?".$query;
        $vnpSecureHash =   hash_hmac('sha512', $hashdata, $vnp_HashSecret);//
        $vnp_Url .= 'vnp_SecureHash=' . $vnpSecureHash;

        return $vnp_Url;
    }

}
