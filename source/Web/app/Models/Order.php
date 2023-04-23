<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Order extends Model
{

    protected $table = 'Order';
    public $timestamps = false;

    protected $fillable = [
        'name', 'phone', 'email', 'address', 'status', 'is_paid', 'product_price', 'ship_price', 'user_id', 'admin_id', 'created_at',
    ];
}
