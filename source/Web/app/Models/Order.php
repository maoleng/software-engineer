<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Order extends Model
{

    protected $table = 'Order';
    public $timestamps = false;

    protected $fillable = [
        'name', 'address', 'email', 'phone', 'status', 'is_paid', 'ship_fee', 'product_price', 'ship_price', 'user_id', 'admin_id', 'bank_code', 'transaction_code', 'created_at',
    ];
}
