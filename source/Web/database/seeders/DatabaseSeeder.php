<?php

namespace Database\Seeders;

use App\Enums\AdminRole;
use App\Enums\OrderStatus;
use App\Models\Admin;
use App\Models\Import;
use App\Models\Order;
use App\Models\Product;
use App\Models\User;
use Faker\Factory as Faker;
use Faker\Generator;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        $this->createAdmins();
        $this->createUsers(20);
        $this->createProducts(25);
        $this->createDiscounts();
        $this->createImports();
        $this->createOrders(200);

    }

    private function createOrders($count): void
    {
        $user_ids = User::query()->inRandomOrder()->get()->pluck('id')->toArray();
        $faker = Faker::create();

        for ($i = 1; $i <= $count; $i++) {
            $is_paid = random_int(0 , 1);
            $bank_code = $is_paid ? $this->faker()->creditCardType : null;
            $transaction_code = $is_paid ? $this->faker()->iban : null;


            $order = Order::query()->create([
                'name' => $faker->name,
                'address' => $faker->address,
                'phone' => $faker->phoneNumber,
                'email' => $faker->email,
                'status' => OrderStatus::getRandomValue(),
                'is_paid' => $is_paid,
                'product_price' => 0,
                'ship_price' => random_int(30, 100) * 1000,
                'user_id' => $this->faker()->randomElement($user_ids),
                'admin_id' => 1,
                'bank_code' => $bank_code,
                'transaction_code' => $transaction_code,
                'created_at' => $faker->dateTimeBetween('-12 months'),
            ]);

            $total = 0;
            $products = Product::query()->get()->take(random_int(1, 5));
            $data = [];
            foreach ($products as $product) {
                $original_price = Import::query()->with('importProducts')->whereHas('importProducts', function ($q) use ($product) {
                    return $q->where('product_id', $product->id);
                })->orderByDesc('created_at')->first()->importProducts->where('id', $product->id)->first()->pivot->price;

                $amount = $faker->numberBetween(1, 5);
                $total += $product->price * $amount;
                $data[] = [
                    'order_id' => $order->id,
                    'product_id' => $product->id,
                    'name' => $product->name,
                    'amount' => $amount,
                    'price' => $product->price,
                    'discount_price' => 0,
                    'original_price' => $original_price,
                ];
            }
            DB::table('OrderProduct')->insert($data);
            $order->update(['product_price' => $total]);
        }
    }

    private function createImports(): void
    {
        $faker = Faker::create();
        $import = Import::query()->create([
            'product_price' => 0,
            'ship_price' => 200000,
            'created_at' => now()->subMonths(15),
        ]);

        $total = 0;
        $products = Product::all();
        $data = [];
        foreach ($products as $product) {
            $price = (int) ($product->price - ($product->price / random_int(5, 10)));
            $amount = $faker->numberBetween(50, 200);
            $total += $price * $amount;
            $data[] = [
                'import_id' => $import->id,
                'product_id' => $product->id,
                'amount' => $amount,
                'price' => $price,
            ];
        }
        DB::table('ImportProduct')->insert($data);
        $import->update(['product_price' => $total]);
    }

    private function createDiscounts(): void
    {
        $data = [];
        $products = Product::all();
        foreach ($products as $product) {
            for ($i = 1; $i <= 4; ++$i) {
                $data[] = [
                    'need_amount' => 50 * $i,
                    'percent' => 5 * $i,
                    'product_id' => $product->id,
                ];
            }
        }
        DB::table('Discount')->insert($data);
    }

    private function createProducts($amount): void
    {
        $data = [];
        for ($i = 1; $i <= $amount; ++$i) {
            $data[] = [
                'category' => random_int(1, 10),
                'name' => 'Film '.$this->faker()->sentence(4),
                'price' => random_int(1000, 10000) * 1000,
                'description' => $this->faker()->text(),
                'image' => $this->faker()->imageUrl,
                'created_at' => $this->faker()->dateTimeBetween('-1 year'),
            ];
        }
        DB::table('Product')->insert($data);
    }

    private function createUsers($amount): void
    {
        $data = [];
        for ($i = 1; $i <= $amount; ++$i) {
            $data[] = [
                'name' => $this->faker()->name,
                'phone' => $this->faker()->phoneNumber,
                'email' => $this->faker()->email,
                'address' => $this->faker()->address,
                'password' => password_hash('1234', PASSWORD_DEFAULT),
                'is_agent' => $this->faker()->randomElement([0, 0,0, 1]),
                'created_at' => $this->faker()->date.' '.$this->faker()->time,
            ];
        }
        DB::table('User')->insert($data);
    }

    private function createAdmins(): void
    {
        $data = [
            [
                'name' => 'The Administrator',
                'email' => 'admin',
                'password' => password_hash('1234', PASSWORD_DEFAULT),
                'is_admin_master' => true,
                'created_at' => now()->toDateTimeString(),
            ],
            [
                'name' => 'The Accountant',
                'email' => 'accountant',
                'password' => password_hash('1234', PASSWORD_DEFAULT),
                'is_admin_master' => false,
                'created_at' => now()->toDateTimeString(),
            ],
        ];
        Admin::query()->insert($data);
    }

    private function faker(): Generator
    {
        return Faker::create('vi');
    }

}
