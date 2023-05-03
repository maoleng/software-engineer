<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class ProductController extends Controller
{

    public function show($name)
    {
        $product = Product::query()->whereRaw("REPLACE(REPLACE(LOWER(name), ' ', '-'), '.', '') = '$name'")
            ->with('discounts')
            ->first();
        $products = Product::query()->where('category', $product->category)->limit(5)->get();


        return view('show', [
            'product' => $product,
            'products' => $products,
        ]);
    }
}
