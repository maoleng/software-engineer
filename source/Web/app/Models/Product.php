<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Product extends Model
{

    protected $table = 'Product';
    public $timestamps = false;

    protected $fillable = [
        'category', 'name', 'price', 'description', 'image', 'created_at',
    ];
}
