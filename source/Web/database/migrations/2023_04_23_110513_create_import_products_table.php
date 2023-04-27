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
        Schema::create('ImportProduct', function (Blueprint $table) {
            $table->foreignId('import_id')->constrained('Import');
            $table->foreignId('product_id')->constrained('Product');
            $table->integer('amount');
            $table->double('price');
            $table->primary(['import_id', 'product_id']);
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('ImportProduct');
    }
};
