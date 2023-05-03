<?php

namespace App\Models;

use App\Enums\ProductCategory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Support\Str;

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

    public function getSlugNameAttribute(): string
    {
        return Str::slug($this->name);
    }

    public function getCategoryNameAttribute(): string
    {
        return ProductCategory::getKey($this->category);
    }

    public function discounts(): HasMany
    {
        return $this->hasMany(Discount::class);
    }


}
