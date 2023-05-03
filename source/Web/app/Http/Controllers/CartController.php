<?php

namespace App\Http\Controllers;

use App\Models\Product;
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

    public function removeProduct(): void
    {
        session()->remove("cart.{$request->get('product_id')}");
    }

}
