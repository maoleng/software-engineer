<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class User extends Model
{

    protected $table = 'User';
    public $timestamps = false;

    protected $fillable = [
        'name', 'phone', 'email', 'address', 'password', 'is_agent', 'created_at',
    ];
}
