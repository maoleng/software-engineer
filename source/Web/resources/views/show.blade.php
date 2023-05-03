@extends('theme.master')

@section('vendor_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/vendors.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/forms/spinner/jquery.bootstrap-touchspin.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/swiper.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/toastr.min.css') }}">
@endsection

@section('page_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/core/menu/menu-types/horizontal-menu.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/pages/app-ecommerce-details.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/forms/form-number-input.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-toastr.css') }}">
@endsection

@section('content')
    <section class="app-ecommerce-details">
        <div class="card">
            <!-- Product Details starts -->
            <div class="card-body">
                <div class="row my-2">
                    <div class="col-12 col-md-5 d-flex align-items-center justify-content-center mb-2 mb-md-0">
                        <div class="d-flex align-items-center justify-content-center">
                            <img src="{{ asset($product->image) }}" class="img-fluid product-img" alt="product image" />
                        </div>
                    </div>
                    <div class="col-12 col-md-7">
                        <h4>{{ $product->name }}</h4>
                        <span class="card-text item-company">By <a href="{{ route('index', ['category' => $product->categoryName]) }}" class="company-name">{{ $product->categoryName }}</a></span>
                        <div class="ecommerce-details-price d-flex flex-wrap mt-1">
                            <h4 class="item-price me-1">{{ prettyPrice($product->price) }}</h4>
                            <ul class="unstyled-list list-inline ps-1 border-start">

                            </ul>
                        </div>
                        <p class="card-text">
                            {{ $product->description }}
                        </p>
                        <hr />
                        <ul class="product-features list-unstyled">
                            <li><i data-feather="shopping-cart"></i><span>Discounts</span></li>
                            @foreach ($product->discounts as $discount)
                                <li>Buy &nbsp; <b>{{ $discount->need_amount }} &nbsp; </b> reduce <b> &nbsp; {{ $discount->percent }}%</b></li>
                            @endforeach
                        </ul>
                        <hr />
                        <div class="d-flex flex-column flex-sm-row pt-1">
                            <a href="#" data-id="{{ $product->id }}" class="btn-add_to_cart btn btn-primary btn-cart me-0 me-sm-1 mb-1 mb-sm-0">
                                <i data-feather="shopping-cart" class="me-50"></i>
                                <span class="add-to-cart">Add to cart</span>
                            </a>
                            <div class="btn-group dropdown-icon-wrapper btn-share">
                                <button type="button" class="btn btn-icon hide-arrow btn-outline-secondary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i data-feather="share-2"></i>
                                </button>
                                <div class="dropdown-menu dropdown-menu-end">
                                    <a href="#" class="dropdown-item">
                                        <i data-feather="facebook"></i>
                                    </a>
                                    <a href="#" class="dropdown-item">
                                        <i data-feather="twitter"></i>
                                    </a>
                                    <a href="#" class="dropdown-item">
                                        <i data-feather="youtube"></i>
                                    </a>
                                    <a href="#" class="dropdown-item">
                                        <i data-feather="instagram"></i>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Product Details ends -->

            <!-- Item features starts -->
            <div class="item-features">
                <div class="row text-center">
                    <div class="col-12 col-md-4 mb-4 mb-md-0">
                        <div class="w-75 mx-auto">
                            <i data-feather="award"></i>
                            <h4 class="mt-2 mb-1">100% Original</h4>
                            <p class="card-text">Chocolate bar candy canes ice cream toffee. Croissant pie cookie halvah.</p>
                        </div>
                    </div>
                    <div class="col-12 col-md-4 mb-4 mb-md-0">
                        <div class="w-75 mx-auto">
                            <i data-feather="clock"></i>
                            <h4 class="mt-2 mb-1">10 Day Replacement</h4>
                            <p class="card-text">Marshmallow biscuit donut dragée fruitcake. Jujubes wafer cupcake.</p>
                        </div>
                    </div>
                    <div class="col-12 col-md-4 mb-4 mb-md-0">
                        <div class="w-75 mx-auto">
                            <i data-feather="shield"></i>
                            <h4 class="mt-2 mb-1">1 Year Warranty</h4>
                            <p class="card-text">Cotton candy gingerbread cake I love sugar plum I love sweet croissant.</p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Item features ends -->

            <!-- Related Products starts -->
            <div class="card-body">
                <div class="mt-4 mb-2 text-center">
                    <h4>Relate products</h4>
                    <p class="card-text">People also like</p>
                </div>
                <div class="swiper-responsive-breakpoints swiper-container px-4 py-2">
                    <div class="swiper-wrapper">
                        @foreach ($products as $product)
                        <div class="swiper-slide">
                            <a href="{{ route('product.show', ['name' => $product->slugName]) }}">
                                <div class="item-heading">
                                    <h5 class="text-truncate mb-0">{{ $product->name }}</h5>
                                    <small class="text-body">by {{ $product->companyName }}</small>
                                </div>
                                <div class="img-container w-50 mx-auto py-75">
                                    <img src="{{ asset($product->image) }}" class="img-fluid" alt="image" />
                                </div>
                                <div class="item-meta">
                                    <ul class="unstyled-list list-inline mb-25">

                                    </ul>
                                    <p class="card-text text-primary mb-0">{{ prettyPrice($product->price) }}</p>
                                </div>
                            </a>
                        </div>
                        @endforeach
                    </div>
                    <!-- Add Arrows -->
                    <div class="swiper-button-next"></div>
                    <div class="swiper-button-prev"></div>
                </div>
            </div>
            <!-- Related Products ends -->
        </div>
    </section>
    <!-- app e-commerce details end -->

@endsection

@section('vendor_script')
    <script src="{{ asset('app-assets/vendojquery.sticky.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/forms/spinner/jquery.bootstrap-touchspin.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/extensions/swiper.min.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/extensions/toastr.min.js') }}"></script>
@endsection

@section('script')
    <script src="{{ asset('app-assets/js/scripts/pages/app-ecommerce-details.js') }}"></script>
    <script src="{{ asset('app-assets/js/scripts/forms/form-number-input.js') }}"></script>
    <script>

        $('.btn-add_to_cart').on('click', function () {
            $.ajax({
                url: '{{ route('cart.update') }}',
                type: 'PUT',
                data: {
                    _token: '{{ csrf_token() }}',
                    product_id: $(this).data('id'),
                }
            }).done(function(e) {
                window.location.href = e
                console.log(e)
            });
        })
    </script>
@endsection
