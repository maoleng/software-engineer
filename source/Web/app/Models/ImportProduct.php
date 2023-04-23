<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class ImportProduct extends Model
{

    protected $table = 'ImportProduct';
    public $timestamps = false;

    protected $fillable = [
        'import_id', 'product_id', 'amount', 'price',
    ];
}
