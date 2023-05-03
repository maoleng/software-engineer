<?php

namespace App\Models;

use App\Enums\ProductCategory;
use Illuminate\Database\Eloquent\Model;

class Product extends Model
{

    protected $table = 'Product';
    public $timestamps = false;

    protected $fillable = [
        'category', 'name', 'price', 'description', 'image', 'created_at',
    ];

    protected $casts = [
        'category' => 'int',
    ];

    public function getCategoryNameAttribute(): string
    {
        return ProductCategory::getKey($this->category);
    }

}
