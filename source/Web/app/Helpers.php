<?php

use Illuminate\Support\Facades\App;
use App\Lib\JWT\JWT;

if (!function_exists('c')) {
    function c(string $key)
    {
        return App::make($key);
    }
}

if (!function_exists('prettyPrice')) {
    function prettyPrice($price): string
    {
        return number_format($price, 0, '').' VND';
    }
}

if (!function_exists('authed')) {
    function authed()
    {
        $token = session()->get('token');
        if (empty($token)) {
            return null;
        }

        return c(JWT::class)->match($token);
    }
}

if (!function_exists('errorAlert')) {
    function errorAlert(): string
    {
        $message = session()->get('error');
        if ($message === null) {
            return '';
        }

        return "
            Swal.fire({
                title: 'Error!',
                text: '$message',
                icon: 'error',
                customClass: {
                    confirmButton: 'btn btn-primary'
                },
                buttonsStyling: false
            })
        ";
    }
}

if (!function_exists('successAlert')) {
    function successAlert(): string
    {
        $message = session()->get('success');
        if ($message === null) {
            return '';
        }

        return "
            Swal.fire({
                icon: 'success',
                title: 'Successfully!',
                text: '$message',
                customClass: {
                    confirmButton: 'btn btn-success'
                }
            })
        ";
    }
}
