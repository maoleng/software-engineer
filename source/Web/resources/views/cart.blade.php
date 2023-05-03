@extends('theme.master')

@section('vendor_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/vendors.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/forms/wizard/bs-stepper.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/forms/spinner/jquery.bootstrap-touchspin.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/toastr.min.css') }}">
@endsection

@section('page_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/core/menu/menu-types/horizontal-menu.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/pages/app-ecommerce.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/forms/pickers/form-pickadate.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/forms/form-wizard.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-toastr.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/forms/form-number-input.css') }}">
@endsection

@section('content')
<div class="bs-stepper checkout-tab-steps">
    <!-- Wizard starts -->
    <div class="bs-stepper-header">
        <div class="step" data-target="#step-cart" role="tab" id="step-cart-trigger">
            <button type="button" class="step-trigger">
                                <span class="bs-stepper-box">
                                    <i data-feather="shopping-cart" class="font-medium-3"></i>
                                </span>
                <span class="bs-stepper-label">
                                    <span class="bs-stepper-title">Cart</span>
                                    <span class="bs-stepper-subtitle">Products in your cart</span>
                                </span>
            </button>
        </div>
        <div class="line">
            <i data-feather="chevron-right" class="font-medium-2"></i>
        </div>
        <div class="step" data-target="#step-address" role="tab" id="step-address-trigger">
            <button type="button" class="step-trigger">
                                <span class="bs-stepper-box">
                                    <i data-feather="home" class="font-medium-3"></i>
                                </span>
                <span class="bs-stepper-label">
                                    <span class="bs-stepper-title">Address</span>
                                    <span class="bs-stepper-subtitle">Your receiving address</span>
                                </span>
            </button>
        </div>
        <div class="line">
            <i data-feather="chevron-right" class="font-medium-2"></i>
        </div>
        <div class="step" data-target="#step-payment" role="tab" id="step-payment-trigger">
            <button type="button" class="step-trigger">
                                <span class="bs-stepper-box">
                                    <i data-feather="credit-card" class="font-medium-3"></i>
                                </span>
                <span class="bs-stepper-label">
                                    <span class="bs-stepper-title">Payment</span>
                                    <span class="bs-stepper-subtitle">Choose payment method</span>
                                </span>
            </button>
        </div>
    </div>
    <!-- Wizard ends -->

    <div class="bs-stepper-content">
        <!-- Checkout Place order starts -->
        <div id="step-cart" class="content" role="tabpanel" aria-labelledby="step-cart-trigger">
            <div id="place-order" class="list-view product-checkout">
                <!-- Checkout Place Order Left starts -->
                <div class="checkout-items">
                    @foreach ($products as $product)
                    <div class="card ecommerce-card">
                        <div class="item-img">
                            <a href="{{ route('product.show', $product['information']->slugName) }}">
                                <img src="{{ $product['information']->image }}" alt="img-placeholder" />
                            </a>
                        </div>
                        <div class="card-body">
                            <div class="item-name">
                                <h6 class="mb-0"><a href="{{ route('product.show', $product['information']->slugName) }}" class="text-body">{{ $product['information']->name }}</a></h6>
                                <span class="item-company">By <a href="{{ route('index', ['category' => $product['information']->categoryName]) }}" class="company-name">{{ $product['information']->categoryName }}</a></span>
                                <div class="item-rating">
                                    <ul class="unstyled-list list-inline">

                                    </ul>
                                </div>
                            </div>
                            <div class="item-quantity">
                                <span class="quantity-title">Amount:</span>
                                <div data-id="{{ $product['information']->id }}" data-price="{{ $product['information']->price }}" class="quantity-counter-wrapper">
                                    @if (authed()->is_agent)
                                        <div class="input-group input-group-lg">
                                            <input id="i-quantity-{{ $product['information']->id }}" type="number" class="i-quantity touchspin-min-max" data-price="{{ $product['information']->price }}" value="{{ $product['amount'] }}" />
                                        </div>
                                    @else
                                        <div class="input-group">
                                            <input id="i-quantity-{{ $product['information']->id }}" type="number" class="i-quantity quantity-counter" data-price="{{ $product['information']->price }}" value="{{ $product['amount'] }}" />
                                        </div>
                                    @endif
                                </div>
                            </div>
                        </div>
                        <div class="item-options text-center">
                            <div class="item-wrapper">
                                <div class="item-cost">
                                    <h4 id="h4-price-{{ $product['information']->id }}" class="item-price">{{ prettyPrice($product['sum_price']) }}</h4>
                                    @if (authed()->is_agent)
                                        <p class="card-text shipping">
                                            @foreach ($product['information']->discounts as $discount)
                                                <span class="">Buy <b>{{ $discount->need_amount }} </b> reduce <b> {{ $discount->percent }}%</b></span><br>
                                            @endforeach
                                        </p>
                                    @endif
                                </div>
                            </div>
                            <button type="button" data-id="{{ $product['information']->id }}" class="btn-remove_cart btn btn-light mt-1 remove-wishlist">
                                <i data-feather="x" class="align-middle me-25"></i>
                                <span>Delete</span>
                            </button>
                        </div>
                    </div>
                    @endforeach
                </div>
                <!-- Checkout Place Order Left ends -->

                <!-- Checkout Place Order Right starts -->
                <div class="checkout-options">
                    <div class="card">
                        <div class="card-body">
                            <div class="price-details">
                                <h6 class="price-title">Order Value</h6>
                                <ul class="list-unstyled">
                                    <li class="price-detail">
                                        <div class="detail-title">Sub total</div>
                                        <div id="div-price_products" class="detail-amt">{{ prettyPrice($price_products) }}</div>
                                    </li>
                                    <li class="price-detail">
                                        <div class="detail-title">Discount</div>
                                        <div id="div-price_discount" class="detail-amt">{{ prettyPrice($price_discount) }}</div>
                                    </li>
                                </ul>
                                <hr />
                                <ul class="list-unstyled">
                                    <li class="price-detail">
                                        <div class="detail-title detail-total">Total</div>
                                        <div id="div-total" class="detail-amt fw-bolder">{{ prettyPrice($total) }}</div>
                                    </li>
                                </ul>
                                <button type="button" class="btn btn-primary w-100 btn-next place-order">Continue</button>
                            </div>
                        </div>
                    </div>
                    <!-- Checkout Place Order Right ends -->
                </div>
            </div>
            <!-- Checkout Place order Ends -->
        </div>
        <!-- Checkout Customer Address Starts -->
        <div id="step-address" class="content" role="tabpanel" aria-labelledby="step-address-trigger">
            <form id="checkout-address" class="list-view product-checkout">
                <!-- Checkout Customer Address Left starts -->
                <div class="card">
                    <div class="card-header flex-column align-items-start">
                        <h4 class="card-title">Receiver address</h4>
                        <p class="card-text text-muted mt-25">Ensure that your address is correct</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            @php ($info = session()->get('info'))
                            <div class="col-md-12 col-sm-12">
                                <div class="mb-2">
                                    <label class="form-label" cfor="checkout-name">Name:</label>
                                    <input id="i-name" value="{{ $info['name'] ?? null }}" type="text" class="form-control" name="fname" placeholder="{{ env('OWNER_NAME') }}" />
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="mb-2">
                                    <label class="form-label" cfor="checkout-number">Phone:</label>
                                    <input id="i-phone" value="{{ $info['phone'] ?? null }}" type="text" class="form-control" name="mnumber" placeholder="0123456789" />
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="mb-2">
                                    <label class="form-label" cfor="checkout-number">Email:</label>
                                    <input id="i-email" value="{{ $info['email'] ?? null }}" type="email" class="form-control" name="mnumber" placeholder="abc@example.com" />
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="mb-2">
                                    <label class="form-label" cfor="checkout-apt-number">Address detail:</label>
                                    <input id="i-address1" value="{{ $info['district'] ?? null }}" type="text" class="form-control" name="apt-number" placeholder="123 CMT8" />
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="mb-2">
                                    <label class="form-label" cfor="checkout-landmark">City:</label>
                                    <input id="i-address2" value="{{ $info['province'] ?? null }}" type="text" class="form-control" name="landmark" placeholder="Hồ Chí Minh" />
                                </div>
                            </div>
                            <div class="col-12">
                                <button id="btn-address" type="button" class="btn btn-primary btn-next delivery-address">Continue</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <!-- Checkout Customer Address Ends -->
        <!-- Checkout Payment Starts -->
        <div id="step-payment" class="content" role="tabpanel" aria-labelledby="step-payment-trigger">
            <form id="form-checkout" class="list-view product-checkout" onsubmit="return false;">
                <div class="payment-type">
                    <div class="card">
                        <div class="card-header flex-column align-items-start">
                            <h4 class="card-title">Payment method</h4>
                            <p class="card-text text-muted mt-25">Ensure that you choose a correct payment method</p>
                        </div>
                        <div class="card-body">
                            <ul class="other-payment-options list-unstyled">
                                <li class="py-50">
                                    <div class="form-check">
                                        <input value="VNPAYQR" type="radio" id="customColorRadio2" name="paymentOptions" class="form-check-input" />
                                        <label class="form-check-label" for="customColorRadio2"> Cổng thanh toán VNPAYQR </label>
                                    </div>
                                </li>
                                <li class="py-50">
                                    <div class="form-check">
                                        <input value="VNBANK" type="radio" id="customColorRadio3" name="paymentOptions" class="form-check-input" />
                                        <label class="form-check-label" for="customColorRadio3"> Thanh toán qua thẻ ATM/Tài khoản nội địa </label>
                                    </div>
                                </li>
                                <li class="py-50">
                                    <div class="form-check">
                                        <input value="INTCARD" type="radio" id="customColorRadio4" name="paymentOptions" class="form-check-input" />
                                        <label class="form-check-label" for="customColorRadio4"> Thanh toán qua thẻ quốc tế </label>
                                    </div>
                                </li>
                            </ul>
                            <div class="col-12">
                                <button id="btn-pay" type="button" class="btn btn-primary btn-next delivery-address">Continue</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="amount-payable checkout-options">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Order Value</h4>
                        </div>
                        <div class="card-body">
                            <ul class="list-unstyled price-details">
                                <li class="price-detail">
                                    <div class="details-title">Sub total</div>
                                    <div class="detail-amt">
                                        <strong>{{ prettyPrice($price_products) }}</strong>
                                    </div>
                                </li>
                                <li class="price-detail">
                                    <div class="details-title">Discount</div>
                                    <div class="detail-amt">
                                        <strong>{{ prettyPrice($price_discount) }}</strong>
                                    </div>
                                </li>
                                <li class="price-detail">
                                    <div class="details-title">Ship</div>
                                    <div class="detail-amt">
                                        <strong id="s-ship">{{ prettyPrice($price_ship) }}</strong>
                                    </div>
                                </li>
                            </ul>
                            <hr />
                            <ul class="list-unstyled price-details">
                                <li class="price-detail">
                                    <div class="details-title">Total</div>
                                    <div class="detail-amt fw-bolder">{{ prettyPrice($total) }}</div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <!-- Checkout Payment Ends -->
        <!-- </div> -->
    </div>
</div>
@endsection

@section('vendor_script')
    <script src="{{ asset('app-assets/vendojquery.sticky.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/forms/wizard/bs-stepper.min.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/forms/spinner/jquery.bootstrap-touchspin.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/extensions/toastr.min.js') }}"></script>
@endsection

@section('script')
    <script src="{{ asset('app-assets/js/scripts/pages/app-ecommerce-checkout.js') }}"></script>
    <script src="{{ asset('app-assets/js/scripts/forms/form-number-input.js') }}"></script>
    <script>
        $(document).ready(function() {
            $('.i-quantity').on('keyup', function () {
                let amount = $(this).val()
                if (amount < 1) {
                    amount = 1
                } else if (amount > 500) {
                    amount = 500
                }
                const price = $(this).data('price')
                const product_id = $(this).attr('id').substring(11)
                const pretty_money = prettyMoney(amount * price)
                $('#h4-price-' + product_id).text(pretty_money)
                $.ajax({
                    url: '{{ route('cart.update_amount') }}',
                    type: 'PUT',
                    data: {
                        _token: '{{ csrf_token() }}',
                        product_id: product_id,
                        amount: amount,
                    }
                }).done(function() {
                    updateCartSummarize()
                })
            })

            $('#btn-address').on('click', function () {
                $.ajax({
                    url: '{{ route('cart.update_address') }}',
                    type: 'PUT',
                    data: {
                        _token: '{{ csrf_token() }}',
                        name: $('#i-name').val(),
                        phone: $('#i-phone').val(),
                        email: $('#i-email').val(),
                        district: $('#i-address1').val(),
                        province: $('#i-address2').val(),
                    }
                }).done(function (data) {
                    $('#s-ship').html(prettyMoney(data))
                })
            })

            $('#btn-pay').on('click', function() {
                let payment_method = $('input[name=paymentOptions]:checked', '#form-checkout').val()

                $.ajax({
                    url: '{{ route('payment.pay') }}',
                    type: 'POST',
                    data: {
                        _token: '{{ csrf_token() }}',
                        bank_code: payment_method,
                        amount: '{{ $total }}',
                        name: $('#i-name').val(),
                        phone: $('#i-phone').val(),
                        address1: $('#i-address1').val(),
                        address2: $('#i-address2').val(),
                    }
                }).done(function(url) {
                    localStorage.setItem('show', '1');
                    window.location.href = url;
                })
            })

            $('.btn-remove_cart').on('click', function() {
                $.ajax({
                    url: '{{ route('cart.remove_product') }}',
                    type: 'DELETE',
                    data: {
                        _token: '{{ csrf_token() }}',
                        product_id: $(this).data('id'),
                    }
                }).done(function() {
                    updateCartSummarize()
                })
            })
            $('.btn.btn-primary.bootstrap-touchspin-up').on('click', function () {
                cartChange($(this).parent().parent().parent())

            })
            $('.btn.btn-primary.bootstrap-touchspin-down').on('click', function () {
                cartChange($(this).parent().parent().parent(), 'decrease')
            })

            function updateCartSummarize() {
                $.ajax({
                    url: '{{ route('cart.summarize') }}'
                }).done(function (data) {
                    $('#div-price_products').text(prettyMoney(data.price_products))
                    $('#div-price_discount').text(prettyMoney(data.price_discount))
                    $('#div-total').text(prettyMoney(data.total))
                })
            }

            function cartChange(product, type = 'increase') {
                const product_id = product.data('id')
                const price = product.data('price')
                const quantity = $('#i-quantity-' + product_id).val()
                const pretty_money = prettyMoney(quantity * price)

                $('#h4-price-' + product_id).text(pretty_money)
                $.ajax({
                    url: '{{ route('cart.update') }}',
                    type: 'PUT',
                    data: {
                        _token: '{{ csrf_token() }}',
                        product_id: product_id,
                        type: type,
                    }
                }).done(function() {
                    updateCartSummarize()
                })
            }

            function prettyMoney(price)
            {
                return price.toLocaleString('it-IT', {style : 'currency', currency : 'VND'})
            }
        })
    </script>
@endsection
