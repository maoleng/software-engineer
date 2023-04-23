<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Discount extends Model
{

    public $timestamps = false;

    protected $fillable = [
        'need_amount', 'percent', 'product_id',
    ];
}
