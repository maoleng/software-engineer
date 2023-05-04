<?php

namespace App\Http\Controllers;

use App\Models\Product;
use GuzzleHttp\Client;
use Illuminate\Http\Request;

class CartController extends Controller
{

    public function update(Request $request): void
    {
        $data = $request->all();
        $product_id = $data['product_id'];
        $type = $data['type'] ?? 'increase';

        $count_product = session()->get("cart.$product_id");
        if ($type === 'increase') {
            if ($count_product === null) {
                session()->put("cart.$product_id", 1);
            } elseif ($count_product === 10 && ! authed()->is_agent) {
                session()->put("cart.$product_id", 10);
            } else {
                session()->increment("cart.$product_id");
            }
        } else {
            $count_product === 1 ?
                session()->put("cart.$product_id", 1) :
                session()->decrement("cart.$product_id");
        }
    }

    public function updateAmount(Request $request): void
    {
        $data = $request->all();
        if ($data['amount'] > 500) {
            $amount = 500;
        } elseif ($data['amount'] < 1) {
            $amount = 1;
        } else {
            $amount = $data['amount'];
        }
        session()->put("cart.{$data['product_id']}", $amount);
    }

    public function updateAddress(Request $request): string
    {
        $data = $request->all();
        session()->put('info', [
            'name' => $data['name'],
            'phone' => $data['phone'],
            'email' => $data['email'],
            'district' => $data['district'],
            'province' => $data['province'],
        ]);

        $summarize = $this->getCartSummarize();
        $headers = [
            'Token' => env('GHTK_TOKEN'),
            'Content-Type' => 'application/json'
        ];
        $body = [
            "pick_province" => 'Hồ Chí Minh',
            "pick_district" => "Quận 7",
            "province" => $data['province'],
            "district" => $data['district'],
            "weight" => $summarize['count'] * 200,
            "value" => $summarize['total'],
            "transport" => "fly",
            "deliver_option" => "none",
            "tags" => [1, 7],
        ];
        $client = new Client();
        $response = $client->get('https://services.giaohangtietkiem.vn/services/shipment/fee', [
            'headers' => $headers,
            'json' => $body,
        ])->getBody()->getContents();
        $ship = json_decode($response)->fee->ship_fee_only;
        session()->put('order.fee.ship', $ship);

        return prettyPrice($ship);
    }

    public function removeProduct(Request $request): void
    {
        session()->remove("cart.{$request->get('product_id')}");
    }

    public function index()
    {
        $cart = session()->get('cart') ?? [];
        $products = Product::query()->whereIn('id', array_keys($cart))->with('discounts')->get();
        $result = [];
        foreach ($cart as $product_id => $amount) {
            $product = $products->where('id', $product_id)->first();
            $sum_price = $amount * $product->price;
            $result[$product_id]['amount'] = $amount;
            $result[$product_id]['sum_price'] = $sum_price;
            $result[$product_id]['information'] = $product;
        }
        $cart_summarize = $this->getCartSummarize();

        return view('cart', [
            'products' => $result,
            'price_products' => $cart_summarize['price_products'],
            'price_discount' => $cart_summarize['price_discount'],
            'price_ship' => $cart_summarize['price_ship'],
            'total' => $cart_summarize['total'],
        ]);
    }

    public function getCartSummarize(): array
    {
        $cart = session()->get('cart') ?? [];
        $products = Product::query()->whereIn('id', array_keys($cart))->with('discounts')->get();
        $price_products = 0;
        $price_discount = 0;
        $count = 0;
        foreach ($cart as $product_id => $amount) {
            $product = $products->where('id', $product_id)->first();
            $sum = $amount * $product->price;
            $price_products += $sum;
            $price_discount += ($product->discounts->where('need_amount', '<=', $amount)->sortByDesc('need_amount')
                ->first()->percent ?? 0) * $sum / 100;
            $count += $amount;
        }
        $price_ship = session()->get('order.fee.ship') ?? 0;

        return [
            'price_products' => $price_products,
            'price_discount' => $price_discount,
            'price_ship' => $price_ship,
            'total' => $price_products - $price_discount + $price_ship,
            'count' => $count,
        ];
    }

}
