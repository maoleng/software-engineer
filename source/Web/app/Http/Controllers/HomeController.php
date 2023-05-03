<?php

namespace App\Http\Controllers;

use App\Enums\ProductCategory;
use App\Models\Product;
use Illuminate\Http\Request;

class HomeController extends Controller
{

    public function index()
    {
        $products = Product::query()->paginate(9);
        $categories = ProductCategory::getDescriptions();

        return view('index', [
            'products' => $products,
            'categories' => $categories,
        ]);
    }

}
