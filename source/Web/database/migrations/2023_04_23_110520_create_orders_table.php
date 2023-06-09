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
        Schema::create('Order', function (Blueprint $table) {
            $table->id();
            $table->string('name')->nullable();
            $table->string('address')->nullable();
            $table->string('email')->nullable();
            $table->string('phone')->nullable();
            $table->integer('status');
            $table->boolean('is_paid')->default(0);
            $table->double('product_price');
            $table->double('ship_price')->default(0);
            $table->foreignId('user_id')->nullable()->constrained('User');
            $table->foreignId('admin_id')->nullable()->constrained('Admin');
            $table->string('bank_code')->nullable();
            $table->string('transaction_code')->nullable();
            $table->dateTime('created_at');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('Order');
    }
};
