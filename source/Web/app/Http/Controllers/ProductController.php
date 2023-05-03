<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Contracts\View\View;

class ProductController extends Controller
{

    public function show($name): View
    {
        $product = Product::query()->whereRaw("REPLACE(REPLACE(LOWER(name), ' ', '-'), '.', '') = '$name'")
            ->with('discounts')
            ->firstOrFail();
        $products = Product::query()->where('category', $product->category)->limit(5)->get();

        return view('show', [
            'product' => $product,
            'products' => $products,
        ]);
    }
}
