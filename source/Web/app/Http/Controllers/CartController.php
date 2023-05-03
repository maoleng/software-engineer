<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Http\Request;

class CartController extends Controller
{

    public function update()
    {
        $products = Product::all();

        return view('index', [
            'products' => $products,
        ]);
    }
}
