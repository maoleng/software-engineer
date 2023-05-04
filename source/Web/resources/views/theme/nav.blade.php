<nav class="header-navbar navbar-expand-lg navbar navbar-fixed align-items-center navbar-shadow navbar-brand-center" data-nav="brand-center">
    <div class="navbar-header d-xl-block d-none">
        <ul class="nav navbar-nav">
            <li class="nav-item">
                <a class="navbar-brand" href="{{ route('index') }}">
                    <span class="brand-logo">
                    </span>
                    <h2 class="brand-text mb-0">THE MOBILE SHOP</h2>
                </a>
            </li>
        </ul>
    </div>
    <div class="navbar-container d-flex content">
        <ul class="nav navbar-nav align-items-center ms-auto">
            <li class="nav-item dropdown dropdown-cart me-25"><a class="" href="{{ route('cart.index') }}"><i class="ficon" data-feather="shopping-cart"></i></a></li>
            <li class="nav-item dropdown dropdown-user">
                @if (authed() === null)
                    <a class="nav-link" href="{{ route('auth.login') }}">
                        <span class="avatar">
                            <img class="round" src="{{ asset('assets/images/login.png') }}" alt="avatar" height="40" width="40" style="background-color: white">
                        </span>
                    </a>
                @else
                    <a class="nav-link dropdown-toggle dropdown-user-link" id="dropdown-user" href="#" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <div class="user-nav d-sm-flex d-none">
                            <span class="user-name fw-bolder">{{ authed()->name }}</span>
                            <span class="user-status">{{ authed()->is_agent ? 'Agent' : 'Customer' }}</span>
                        </div>
                        <span class="avatar">
                            <img class="round" src="{{ authed()->avatar }}" alt="avatar" height="40" width="40">
                            <span class="avatar-status-online"></span>
                        </span>
                    </a>
                    <div class="dropdown-menu dropdown-menu-end" aria-labelledby="dropdown-user">
                        <a class="dropdown-item" href="{{ route('auth.logout') }}"><i class="me-50" data-feather="power"></i>Logout</a>
                    </div>
                @endif
            </li>
        </ul>
    </div>
</nav>
