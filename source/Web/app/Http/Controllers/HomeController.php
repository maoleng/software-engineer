<?php

namespace App\Http\Controllers;

use App\Enums\ProductCategory;
use App\Models\Product;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Str;

class HomeController extends Controller
{

    public function index(Request $request)
    {
        $query = $request->all();
        $q = $query['q'] ?? null;
        $sort = $query['sort'] ?? null;
        $price = $query['price'] ?? null;
        $category = $query['category'] ?? null;

        $builder = Product::query();
        if ($q !== null) {
            $builder->where(function ($query) use ($q) {
                $query->orWhere('name', 'LIKE', "%$q%")
                    ->orWhere('description', 'LIKE', "%$q%");
            });
        }
        if ($price) {
            $builder->where(function ($query) use ($price) {
                switch ($price) {
                    case '1':
                        $query->where('price', '<=', $price);
                        break;
                    case '2':
                        $query->orWhere('price', '>=', 1000000)->where('price', '<=', 4000000);
                        break;
                    case '3':
                        $query->orWhere('price', '>=', 4000000)->where('price', '<=', 10000000);
                        break;
                    case '4':
                        $query->where('price', '>=', 10000000);
                        break;
                }
            });
        }
        if ($category !== null) {
            $builder->where('category', array_search(Str::title($category), ProductCategory::getDescriptions(), false));
        }
        if (in_array($sort, ['acs', 'desc'])) {
            $builder->orderBy('price', $sort);
        }
        $products = $builder->paginate(9);

        $categories = Product::query()->select(DB::raw('category, count(*) as count'))
            ->groupBy('category')->get()->map(function ($category) {
                return [
                    'name' => ProductCategory::getDescription($category->category),
                    'count' => $category->count,
                ];
            })->toArray();

        return view('index', [
            'products' => $products,
            'categories' => $categories,
        ]);
    }

}
