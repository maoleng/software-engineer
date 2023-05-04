<?php

namespace App\Http\Controllers;

use App\Enums\OrderStatus;
use App\Models\Order;
use App\Models\Product;
use Illuminate\Contracts\View\View;
use Illuminate\Http\RedirectResponse;
use Illuminate\Http\Request;

class OrderController extends Controller
{

    public function index(Request $request)
    {
        $data = $request->all();

        $builder = Order::query();
        if (isset($data['status'])) {
            $builder->where('status', $data['status']);
        }
        if (isset($data['created_at'])) {
            $split = explode(',', $data['created_at']);
            $builder->whereBetween('created_at', [$split[0], $split[1]]);
        }
        if (isset($data['q'])) {
            $builder->where(function ($q) use ($data) {
                $q->orWhere('name', 'LIKE', "%{$data['q']}%")
                    ->orWhere('address', 'LIKE', "%{$data['q']}%")
                    ->orWhere('email', 'LIKE', "%{$data['q']}%")
                    ->orWhere('phone', 'LIKE', "%{$data['q']}%")
                    ->orWhere('ship_price', 'LIKE', "%{$data['q']}%")
                    ->orWhere('product_price', 'LIKE', "%{$data['q']}%")
                    ->orWhere('created_at', 'LIKE', "%{$data['q']}%");
            });
        }

        $orders = $builder->where('user_id', authed()->id)->with('user')
            ->orderBy('status')->orderByDesc('created_at')->paginate(10);

        return view('history', [
            'orders' => $orders,
            'order_status' => OrderStatus::getDescriptions(),
        ]);
    }

    public function show(): array
    {
        $order_id = request()->get('order_id');
        $order = Order::query()->with('orderProducts')->find($order_id);

        $products = [];
        $product_price = 0;
        foreach ($order->orderProducts as $product) {
            $price = $product->pivot->price;
            $amount = $product->pivot->amount;
            $discount_price = $product->pivot->discount_price;
            $total = ($price - $discount_price) * $amount;
            $product_price += $total;
            $products[] = [
                'name' => $product->pivot->name,
                'price' => prettyPrice($price),
                'amount' => $amount,
                'discount_price' => prettyPrice($discount_price),
                'total' => prettyPrice($total),
            ];
        }
        $total = $order->product_price + $order->ship_price;

        return [
            'order_id' => $order->id,
            'products' => $products,
            'fee' => [
                'product_price' => prettyPrice($product_price),
                'discount' => prettyPrice($product_price - $order->product_price),
                'ship' => prettyPrice($order->ship_price),
                'total' => prettyPrice($total),
            ],
            'user' => [
                'name' => $order->name,
                'address' => $order->address,
                'phone' => $order->phone,
                'email' => $order->email,
            ],
            'created_at' => $order->created_at,
            'sales' => $order->admin->name ?? null,
            'status' => $order->statusDescription,
            'is_paid' => $order->prettyIsPaid,
        ];
    }

    public function print(): View
    {
        $data = $this->show();

        return view('print', $data);
    }

}
