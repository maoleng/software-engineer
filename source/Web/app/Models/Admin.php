<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Admin extends Model
{

    protected $table = 'Admin';
    public $timestamps = false;

    protected $fillable = [
        'name', 'email', 'password', 'is_admin_master', 'active', 'created_at',
    ];
}
