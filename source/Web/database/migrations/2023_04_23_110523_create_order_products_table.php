<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('OrderProduct', function (Blueprint $table) {
            $table->foreignId('order_id')->constrained('Order');
            $table->foreignId('product_id')->constrained('Product');
            $table->string('name');
            $table->integer('amount');
            $table->double('price');
            $table->double('discount_price')->default(0);
            $table->double('original_price');
            $table->primary(['order_id', 'product_id']);
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('OrderProduct');
    }
};
