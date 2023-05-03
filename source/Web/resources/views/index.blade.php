@extends('theme.master')

@section('vendor_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/vendors.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/nouislider.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/toastr.min.css') }}">
@endsection

@section('page_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/core/menu/menu-types/horizontal-menu.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-sliders.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/pages/app-ecommerce.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-toastr.css') }}">
@endsection

@section('content')

    <div class="sidebar-detached sidebar-left">
        <div class="sidebar">
            <!-- Ecommerce Sidebar Starts -->
            <div class="sidebar-shop">
                <div class="row">
                    <div class="col-sm-12">
                        <h6 class="filter-heading d-none d-lg-block">Filters</h6>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <!-- Price Filter starts -->
                        <div class="multi-range-price">
                            <h6 class="filter-title mt-0">Multi Range</h6>
                            <ul class="list-unstyled price-range" id="price-range">
                                <li>
                                    <div class="form-check">
                                        <input type="radio" id="priceAll" name="price-range" class="form-check-input" checked />
                                        <label class="form-check-label" for="priceAll">All</label>
                                    </div>
                                </li>
                                <li>
                                    <div class="form-check">
                                        <input type="radio" id="priceRange1" name="price-range" class="form-check-input" />
                                        <label class="form-check-label" for="priceRange1">&lt;=1,000,000</label>
                                    </div>
                                </li>
                                <li>
                                    <div class="form-check">
                                        <input type="radio" id="priceRange2" name="price-range" class="form-check-input" />
                                        <label class="form-check-label" for="priceRange2">1,000,000 - 4,000,000</label>
                                    </div>
                                </li>
                                <li>
                                    <div class="form-check">
                                        <input type="radio" id="priceARange3" name="price-range" class="form-check-input" />
                                        <label class="form-check-label" for="priceARange3">4,000,000 - 10,000,000</label>
                                    </div>
                                </li>
                                <li>
                                    <div class="form-check">
                                        <input type="radio" id="priceRange4" name="price-range" class="form-check-input" />
                                        <label class="form-check-label" for="priceRange4">&gt;= 10,000,000</label>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!-- Price Filter ends -->

                        <!-- Brands starts -->
                        <div class="brands">
                            <h6 class="filter-title">Category</h6>
                            <ul class="list-unstyled brand-list">
                                @foreach ($categories as $key => $category)
                                <li>
                                    <div class="form-check">
                                        <input type="checkbox" class="form-check-input" id="{{ $key }}" checked/>
                                        <label class="form-check-label" for="productBrand1">{{ $category }}</label>
                                    </div>
                                    <span>746</span>
                                </li>
                                @endforeach
                            </ul>
                        </div>
                        <!-- Brand ends -->

                        <!-- Clear Filters Starts -->
                        <div id="clear-filters">
                            <button type="button" class="btn w-100 btn-primary">Clear All Filters</button>
                        </div>
                        <!-- Clear Filters Ends -->
                    </div>
                </div>
            </div>
            <!-- Ecommerce Sidebar Ends -->

        </div>
    </div>
    <div class="content-detached content-right">
        <div class="content-body">
            <!-- E-commerce Content Section Starts -->
            <section id="ecommerce-header">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="ecommerce-header-items">
                            <div class="result-toggler">
                                <button class="navbar-toggler shop-sidebar-toggler" type="button" data-bs-toggle="collapse">
                                    <span class="navbar-toggler-icon d-block d-lg-none"><i data-feather="menu"></i></span>
                                </button>
                                <div class="search-results">{{ $products->total() }} results found</div>
                            </div>
                            <div class="view-options d-flex">
                                <div class="btn-group dropdown-sort">
                                    <button type="button" class="btn btn-outline-primary dropdown-toggle me-1" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="active-sorting">Featured</span>
                                    </button>
                                    <div class="dropdown-menu">
                                        <a class="dropdown-item" href="#">Lowest</a>
                                        <a class="dropdown-item" href="#">Highest</a>
                                    </div>
                                </div>
                                <div class="btn-group" role="group">
                                    <input type="radio" class="btn-check" name="radio_options" id="radio_option1" autocomplete="off" checked />
                                    <label class="btn btn-icon btn-outline-primary view-btn grid-view-btn" for="radio_option1"><i data-feather="grid" class="font-medium-3"></i></label>
                                    <input type="radio" class="btn-check" name="radio_options" id="radio_option2" autocomplete="off" />
                                    <label class="btn btn-icon btn-outline-primary view-btn list-view-btn" for="radio_option2"><i data-feather="list" class="font-medium-3"></i></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- E-commerce Content Section Starts -->

            <!-- background Overlay when sidebar is shown  starts-->
            <div class="body-content-overlay"></div>
            <!-- background Overlay when sidebar is shown  ends-->

            <!-- E-commerce Search Bar Starts -->
            <section id="ecommerce-searchbar" class="ecommerce-searchbar">
                <div class="row mt-1">
                    <div class="col-sm-12">
                        <div class="input-group input-group-merge">
                            <input type="text" class="form-control search-product" id="shop-search" placeholder="Search Product" aria-label="Search..." aria-describedby="shop-search" />
                            <span class="input-group-text"><i data-feather="search" class="text-muted"></i></span>
                        </div>
                    </div>
                </div>
            </section>
            <!-- E-commerce Search Bar Ends -->

            <!-- E-commerce Products Starts -->
            <section id="ecommerce-products" class="grid-view">
                @foreach ($products as $product)
                    <div class="card ecommerce-card">
                    <div class="item-img text-center">
                        <a href="{{ route('product.show', ['product' => $product]) }}">
                            <img class="img-fluid card-img-top" src="{{ $product->image }}" alt="img-placeholder" /></a>
                    </div>
                    <div class="card-body">
                        <div class="item-wrapper">
                            <div class="item-rating">

                            </div>
                            <div>
                                <h6 class="item-price">{{ prettyPrice($product->price) }}</h6>
                            </div>
                        </div>
                        <h6 class="item-name">
                            <a class="text-body" href="{{ route('product.show', ['product' => $product]) }}">{{ $product->name }}</a>
                            <span class="card-text item-company">By <a href="#" class="company-name">{{ $product->categoryName }}</a></span>
                        </h6>
                        <p class="card-text item-description">
                            {{ $product->description }}
                        </p>
                    </div>
                    <div class="item-options text-center">
                        <div class="item-wrapper">
                            <div class="item-cost">
                                <h4 class="item-price">{{ prettyPrice($product->price) }}</h4>
                            </div>
                        </div>
                        <a href="#" class="btn btn-primary btn-cart">
                            <i data-feather="shopping-cart"></i>
                            <span class="add-to-cart">Add to cart</span>
                        </a>
                    </div>
                </div>
                @endforeach
            </section>
            <!-- E-commerce Products Ends -->

            <!-- E-commerce Pagination Starts -->
            <section id="ecommerce-pagination">
                <div class="row">
                    <div class="col-sm-12 pagination justify-content-center mt-2">
                        {{ $products->links('vendor.pagination') }}
                    </div>
                </div>
            </section>
            <!-- E-commerce Pagination Ends -->

        </div>
    </div>


@endsection

@section('vendor_script')
    <script src={{ asset('app-assets/vendojquery.sticky.js') }}></script>
    <script src={{ asset('app-assets/vendors/js/extensions/wNumb.min.js') }}></script>
    <script src={{ asset('app-assets/vendors/js/extensions/nouislider.min.js') }}></script>
    <script src={{ asset('app-assets/vendors/js/extensions/toastr.min.js') }}></script>

@endsection

@section('script')
    <script src={{ asset('app-assets/js/scripts/pages/app-ecommerce.js') }}></script>
    <script>
        $(document).ready(function() {
            if (localStorage.getItem('show') === '1') {


                localStorage.removeItem('show')

            }


            $('.btn-add_to_cart').on('click', function () {
                $.ajax({
                    url: '{{ route('cart.update') }}',
                    type: 'POST',
                    data: {
                        _token: '{{ csrf_token() }}',
                        product_id: $(this).data('id'),
                    }
                }).done(function(e) {
                    window.location.href = e
                    console.log(e)
                });
            })
        })
    </script>
@endsection
