<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Discount extends Model
{

    protected $table = 'Discount';
    public $timestamps = false;

    protected $fillable = [
        'need_amount', 'percent', 'product_id',
    ];
}
