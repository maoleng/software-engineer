<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsToMany;

class Import extends Model
{

    public $timestamps = false;

    protected $fillable = [
        'product_price', 'ship_price', 'created_at',
    ];

    public function importProducts(): BelongsToMany
    {
        return $this->belongsToMany(Product::class, 'import_products')->withPivot([
            'amount',
            'price',
        ]);
    }

}
