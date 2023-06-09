<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class User extends Model
{

    protected $table = 'User';
    public $timestamps = false;

    protected $fillable = [
        'name', 'phone', 'email', 'address', 'password', 'is_agent', 'active', 'created_at',
    ];

    public function verify($password): bool
    {
        return password_verify($password, $this->password);
    }

}
