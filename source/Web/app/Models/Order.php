<?php

namespace App\Models;

use App\Enums\OrderStatus;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\BelongsToMany;

class Order extends Model
{

    protected $table = 'Order';
    public $timestamps = false;

    protected $fillable = [
        'name', 'address', 'email', 'phone', 'status', 'is_paid', 'product_price', 'ship_price', 'user_id', 'admin_id', 'bank_code', 'transaction_code', 'created_at',
    ];

    protected $casts = [
        'status' => 'int',
    ];

    public function orderProducts(): BelongsToMany
    {
        return $this->belongsToMany(Product::class, 'OrderProduct')->withPivot([
            'name',
            'amount',
            'price',
            'discount_price',
            'original_price',
        ]);
    }

    public function user(): BelongsTo
    {
        return $this->belongsTo(User::class);
    }

    public function getStatusDescriptionAttribute(): string
    {
        return OrderStatus::getDescription($this->status);
    }

    public function getPrettyIsPaidAttribute(): string
    {
        return $this->is_paid ? 'Yes' : 'No';
    }


}
