<?php

namespace App\Http\Controllers;

use App\Lib\JWT\JWT;
use App\Models\Admin;
use App\Models\User;
use Illuminate\Http\Request;
use Laravel\Socialite\Facades\Socialite;
use Symfony\Component\HttpFoundation\RedirectResponse;

class AuthController extends Controller
{

    public function login()
    {
        return view('login');
    }

    public function processLogin(Request $request)
    {
        $data = $request->all();
        if (! isset($data['email'], $data['password'])) {
            return redirect()->back()->with('error', 'Wrong email or password');
        }
        $user = User::query()->where('email', $data['email'])->first();
        if ($user === null) {
            return redirect()->back()->with('error', 'Wrong email or password');
        }
        if (! $user->verify($data['password'])) {
            return redirect()->back()->with('error', 'Wrong email or password');
        }

        $token = $this->generateToken($user);
        session()->put('token', $token);

        return redirect()->route('index');
    }

    public function redirect(): RedirectResponse
    {
        return Socialite::driver('google')->redirect();
    }

    public function callback()
    {
        $g_user = Socialite::driver('google')->stateless()->user();
        $user = User::query()->where('email', $g_user->email)->first();
        if (empty($user)) {
            $user = User::query()->create([
                'name' => $g_user->name,
                'email' => $g_user->email,
                'is_agent' => false,
                'active' => true,
                'created_at' => now(),
            ]);
        }
        $user->avatar = $g_user->avatar;
        $token = $this->generateToken($user);
        session()->put('token', $token);

        return redirect()->route('index');
    }

    public function logout(): \Illuminate\Http\RedirectResponse
    {
        session()->forget('token');
        session()->flush();
        session()->save();

        return redirect()->route('index');
    }

    private function generateToken($user)
    {
        return c(JWT::class)->encode([
            'id' => $user->id,
            'name' => $user->name,
            'email' => $user->email,
            'avatar' => $user->avatar ?? asset('app-assets/images/portrait/small/avatar-s-11.jpg'),
            'active' => $user->active,
            'is_agent' => $user->is_agent,
            'created_at' => $user->created_at,
        ]);
    }

}
