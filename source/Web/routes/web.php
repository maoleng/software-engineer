<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\CartController;
use App\Http\Controllers\HomeController;
use App\Http\Controllers\OrderController;
use App\Http\Controllers\PayController;
use App\Http\Controllers\ProductController;
use App\Http\Middleware\IfAlreadyLogin;
use Illuminate\Support\Facades\Route;

Route::get('/', [HomeController::class, 'index'])->name('index');

Route::group(['prefix' => 'auth', 'as' => 'auth.', 'middleware' => [IfAlreadyLogin::class]], static function () {
    Route::get('/login', [AuthController::class, 'login'])->name('login');
    Route::post('/login', [AuthController::class, 'processLogin'])->name('process_login');
    Route::get('/google/redirect', [AuthController::class, 'redirect'])->name('redirect');
    Route::get('/google/callback', [AuthController::class, 'callback'])->name('callback');
});
Route::get('/auth/logout', [AuthController::class, 'logout'])->name('auth.logout');

Route::group(['prefix' => 'product', 'as' => 'product.'], function () {
    Route::get('/{name}', [ProductController::class, 'show'])->name('show');
});

Route::group(['prefix' => 'order', 'as' => 'order.'], function () {
    Route::get('/', [OrderController::class, 'index'])->name('index');
    Route::get('/show', [OrderController::class, 'show'])->name('show');
    Route::get('/print', [OrderController::class, 'print'])->name('print');
});

Route::group(['prefix' => 'cart', 'as' => 'cart.'], function () {
    Route::get('/', [CartController::class, 'index'])->name('index');
    Route::get('/summarize', [CartController::class, 'getCartSummarize'])->name('summarize');
    Route::put('/', [CartController::class, 'update'])->name('update');
    Route::put('/update_amount', [CartController::class, 'updateAmount'])->name('update_amount');
    Route::put('/update_address', [CartController::class, 'updateAddress'])->name('update_address');
    Route::delete('/', [CartController::class, 'removeProduct'])->name('remove_product');
});

Route::group(['prefix' => 'payment', 'as' => 'payment.'], function () {
    Route::post('/', [PayController::class, 'pay'])->name('pay');
    Route::get('/', [PayController::class, 'ipn'])->name('ipn');
});

Route::get('/test', function () {
    echo json_encode(session()->all());
});
