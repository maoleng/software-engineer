<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class OrderProduct extends Model
{

    protected $table = 'OrderProduct';
    public $timestamps = false;

    protected $fillable = [
        'order_id', 'product_id', 'name', 'amount', 'price', 'discount_price', 'original_price',
    ];
}
