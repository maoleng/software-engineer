<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class ImportProduct extends Model
{

    public $timestamps = false;

    protected $fillable = [
        'import_id', 'product_id', 'amount', 'price',
    ];
}
