@extends('theme.master')

@section('vendor_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/vendors.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/nouislider.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/toastr.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/animate/animate.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/extensions/sweetalert2.min.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/vendors/css/pickers/flatpickr/flatpickr.min.css') }}">

@endsection

@section('page_css')
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/core/menu/menu-types/horizontal-menu.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-sliders.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/pages/app-ecommerce.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-toastr.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/extensions/ext-component-sweet-alerts.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('app-assets/css/plugins/forms/pickers/form-flat-pickr.css') }}">

@endsection

@section('content')

    <div class="content-body">
        <div class="row" id="basic-table">
            <div class="col-12">
                <div class="card">
                    <div class="row d-flex justify-content-between align-items-center m-1">
                        <div class="col-lg-6 d-flex align-items-start">
                        </div>
                        <div class="col-lg-6 d-flex align-items-center justify-content-lg-end flex-lg-nowrap flex-wrap pe-lg-1 p-0">
                            <div style="padding-right: 25px; width: 50%">
                                <input value="{{ implode(' to ', explode(',', request()->get('created_at'))) }}" id="i-created_at" type="text" class="form-control flatpickr-range flatpickr-input active" placeholder="Filter order time range" readonly="readonly">
                            </div>
                            <div class="btn-group" style="padding-right: 25px">
                                <button type="button" class="btn btn-outline-primary dropdown-toggle waves-effect" data-bs-toggle="dropdown" aria-expanded="false">
                                    @php ($status = request()->get('status'))
                                    {{ $status === null ? 'All' : $order_status[$status] }}
                                </button>
                                <div class="dropdown-menu">
                                    <a class="dropdown-item" href="?status=">All</a>
                                    @foreach ($order_status as $key => $each)
                                        <a class="dropdown-item" href="?status={{ $key }}">{{ $each }}</a>
                                    @endforeach
                                </div>
                            </div>
                            <div>
                                <input type="search" id="i-search" name="q" value="{{ request()->get('q') }}" class="form-control" placeholder="Search">
                            </div>
                            <div class="invoice_status ms-sm-2"></div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                            <tr>
                                <th>Address</th>
                                <th>Status</th>
                                <th>Is Paid</th>
                                <th>Product Price</th>
                                <th>Ship Price</th>
                                <th>Bank</th>
                                <th>Transaction Code</th>
                                <th>Ordered At</th>
                                <th>Actions</th>
                            </tr>
                            </thead>
                            <tbody>
                            @foreach ($orders as $order)
                                <tr>
                                    <td>{{ $order->address }}</td>
                                    <td>{{ $order->statusDescription }}</td>
                                    <td>
                                        <div class="form-check form-check-success">
                                            <input type="checkbox" class="form-check-input" @if ($order->is_paid) checked @endif disabled>
                                        </div>
                                    </td>
                                    <td>{{ prettyPrice($order->product_price) }}</td>
                                    <td>{{ prettyPrice($order->ship_price) }}</td>
                                    <td>{{ $order->bank_code }}</td>
                                    <td>{{ $order->transaction_code }}</td>
                                    <td>{{ $order->created_at }}</td>
                                    <td>
                                        <div class="dropdown">
                                            <button type="button" class="btn btn-sm dropdown-toggle hide-arrow py-0 waves-effect waves-float waves-light" data-bs-toggle="dropdown">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-more-vertical"><circle cx="12" cy="12" r="1"></circle><circle cx="12" cy="5" r="1"></circle><circle cx="12" cy="19" r="1"></circle></svg>
                                            </button>
                                            <div class="dropdown-menu dropdown-menu-end">
                                                <a data-order_id="{{ $order->id }}" class="a-view dropdown-item">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-eye"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>
                                                    <span>View</span>
                                                </a>
                                                <a data-order_id="{{ $order->id }}" class="a-print dropdown-item" href="{{ route('order.print', ['order_id' => $order->id]) }}" target="_blank">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-printer"><polyline points="6 9 6 2 18 2 18 9"></polyline><path d="M6 18H4a2 2 0 0 1-2-2v-5a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v5a2 2 0 0 1-2 2h-2"></path><rect x="6" y="14" width="12" height="8"></rect></svg>
                                                    <span>Print</span>
                                                </a>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            @endforeach
                            </tbody>
                        </table>
                    </div>
                    <div class="m-3">{{ $orders->withQueryString()->links('vendor.pagination') }}</div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade text-start" id="xlarge" tabindex="-1" aria-labelledby="myModalLabel16" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel16">Invoice details</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="card invoice-preview-card">
                        <div class="card-body invoice-padding pb-0">
                            <!-- Header starts -->
                            <div class="d-flex justify-content-between flex-md-row flex-column invoice-spacing mt-0">
                                <div>
                                    <div class="logo-wrapper">
                                        <svg viewBox="0 0 139 95" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" height="24">
                                            <defs>
                                                <linearGradient id="invoice-linearGradient-1" x1="100%" y1="10.5120544%" x2="50%" y2="89.4879456%">
                                                    <stop stop-color="#000000" offset="0%"></stop>
                                                    <stop stop-color="#FFFFFF" offset="100%"></stop>
                                                </linearGradient>
                                                <linearGradient id="invoice-linearGradient-2" x1="64.0437835%" y1="46.3276743%" x2="37.373316%" y2="100%">
                                                    <stop stop-color="#EEEEEE" stop-opacity="0" offset="0%"></stop>
                                                    <stop stop-color="#FFFFFF" offset="100%"></stop>
                                                </linearGradient>
                                            </defs>
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <g transform="translate(-400.000000, -178.000000)">
                                                    <g transform="translate(400.000000, 178.000000)">
                                                        <path class="text-primary" d="M-5.68434189e-14,2.84217094e-14 L39.1816085,2.84217094e-14 L69.3453773,32.2519224 L101.428699,2.84217094e-14 L138.784583,2.84217094e-14 L138.784199,29.8015838 C137.958931,37.3510206 135.784352,42.5567762 132.260463,45.4188507 C128.736573,48.2809251 112.33867,64.5239941 83.0667527,94.1480575 L56.2750821,94.1480575 L6.71554594,44.4188507 C2.46876683,39.9813776 0.345377275,35.1089553 0.345377275,29.8015838 C0.345377275,24.4942122 0.230251516,14.560351 -5.68434189e-14,2.84217094e-14 Z" style="fill: currentColor"></path>
                                                        <path d="M69.3453773,32.2519224 L101.428699,1.42108547e-14 L138.784583,1.42108547e-14 L138.784199,29.8015838 C137.958931,37.3510206 135.784352,42.5567762 132.260463,45.4188507 C128.736573,48.2809251 112.33867,64.5239941 83.0667527,94.1480575 L56.2750821,94.1480575 L32.8435758,70.5039241 L69.3453773,32.2519224 Z" fill="url(#invoice-linearGradient-1)" opacity="0.2"></path>
                                                        <polygon fill="#000000" opacity="0.049999997" points="69.3922914 32.4202615 32.8435758 70.5039241 54.0490008 16.1851325"></polygon>
                                                        <polygon fill="#000000" opacity="0.099999994" points="69.3922914 32.4202615 32.8435758 70.5039241 58.3683556 20.7402338"></polygon>
                                                        <polygon fill="url(#invoice-linearGradient-2)" opacity="0.099999994" points="101.428699 0 83.0667527 94.1480575 130.378721 47.0740288"></polygon>
                                                    </g>
                                                </g>
                                            </g>
                                        </svg>
                                        <h3 class="text-primary invoice-logo">The Coffee</h3>
                                    </div>
                                    <p class="card-text mb-25">19 Nguyen Huu Tho street</p>
                                    <p class="card-text mb-25">Tan Phong ward, District 7, Ho Chi Minh City, Vietnam</p>
                                    <p class="card-text mb-0">(028) 37 755 035, (028) 37 755 055</p>
                                </div>
                                <div class="mt-md-0 mt-2">
                                    <h4 class="invoice-title">
                                        Ordered At:
                                        <span class="invoice-number" id="span-created_at"></span>
                                    </h4>
                                </div>
                            </div>
                            <!-- Header ends -->
                        </div>
                        <hr class="invoice-spacing" />
                        <!-- Address and Contact starts -->
                        <div class="card-body invoice-padding pt-0">
                            <div class="row invoice-spacing">
                                <div class="col-xl-8 p-0">
                                    <h6 class="mb-2">Invoice To:</h6>
                                    <h6 class="mb-25" id="h6-name"></h6>
                                    <p class="card-text mb-25" id="p-address"></p>
                                    <p class="card-text mb-25" id="p-phone"></p>
                                    <p class="card-text mb-0" id="p-email"></p>
                                </div>
                                <div class="col-xl-4 p-0 mt-xl-0 mt-2">
                                    <h6 class="mb-2">Payment Details:</h6>
                                    <table>
                                        <tbody>
                                        <tr>
                                            <td class="pe-1">Total:</td>
                                            <td><span class="fw-bold" id="span-total"></span></td>
                                        </tr>
                                        <tr>
                                            <td class="pe-1">Is paid:</td>
                                            <td id="td-is_paid"></td>
                                        </tr>
                                        <tr>
                                            <td class="pe-1">Status:</td>
                                            <td id="td-status"></td>
                                        </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- Address and Contact ends -->
                        <!-- Invoice Description starts -->
                        <div class="table-responsive">
                            <table class="table">
                                <thead>
                                <tr>
                                    <th class="py-1 ps-4">Product's name</th>
                                    <th class="py-1">Amount</th>
                                    <th class="py-1">Price</th>
                                    <th class="py-1">Discount</th>
                                    <th class="py-1">Total</th>
                                </tr>
                                </thead>
                                <tbody id="body-products"></tbody>
                            </table>
                        </div>
                        <div class="card-body invoice-padding pb-0">
                            <div class="row invoice-sales-total-wrapper">
                                <div class="col-md-6 order-md-1 order-2 mt-md-0 mt-3">
                                </div>
                                <div class="col-md-6 d-flex justify-content-end order-md-2 order-1">
                                    <div class="invoice-total-wrapper">
                                        <div class="invoice-total-item">
                                            <p class="invoice-total-title">Product price: <b id="b-product_price"></b></p>
                                        </div>
                                        <div class="invoice-total-item">
                                            <p class="invoice-total-title">Discount: <b id="b-discount"></b></p>
                                        </div>
                                        <div class="invoice-total-item">
                                            <p class="invoice-total-title">Ship: <b id="b-ship"></b></p>
                                        </div>
                                        <hr class="my-50" />
                                        <div class="invoice-total-item">
                                            <p class="invoice-total-title">Total: <b id="b-total"></b></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Invoice Description ends -->
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btn-print" type="button" class="btn btn-success waves-effect waves-float waves-light" data-bs-dismiss="modal">Print</button>
                    <button type="button" class="btn btn-primary waves-effect waves-float waves-light" data-bs-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>

@endsection

@section('vendor_script')
    <script src={{ asset('app-assets/vendojquery.sticky.js') }}></script>
    <script src={{ asset('app-assets/vendors/js/extensions/wNumb.min.js') }}></script>
    <script src={{ asset('app-assets/vendors/js/extensions/nouislider.min.js') }}></script>
    <script src={{ asset('app-assets/vendors/js/extensions/toastr.min.js') }}></script>
    <script src="{{ asset('app-assets/vendors/js/extensions/sweetalert2.all.min.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/extensions/polyfill.min.js') }}"></script>
    <script src="{{ asset('app-assets/vendors/js/pickers/flatpickr/flatpickr.min.js') }}"></script>

@endsection

@section('script')
    <script src={{ asset('app-assets/js/scripts/pages/app-ecommerce.js') }}></script>
    <script src="{{ asset('app-assets/js/scripts/extensions/ext-component-sweet-alerts.js') }}"></script>
    <script src="{{ asset('app-assets/js/scripts/forms/pickers/form-pickers.js') }}"></script>
    <script src="{{ asset('assets/js/handle_search.js') }}"></script>

    <script>

        $('.a-view').on('click', function () {
            const order_id = $(this).data('order_id')
            $.ajax({
                url: '{{ route('order.show') }}',
                data: {
                    order_id: order_id,
                }
            }).done(function (data) {
                const fee = data.fee
                $('#b-product_price').text(fee.product_price)
                $('#b-discount').text(fee.discount)
                $('#b-ship').text(fee.ship)
                $('#b-total').text(fee.total)

                const user = data.user
                $('#h6-name').text(user.name)
                $('#p-address').text(user.address)
                $('#p-phone').text(user.phone)
                $('#p-email').text(user.email)

                $('#span-created_at').text(data.created_at)
                $('#span-sales_person').text(data.sales)

                $('#span-total').text(fee.total)
                $('#td-is_paid').text(data.is_paid)
                $('#td-status').text(data.status)

                const body_products = $('#body-products')
                body_products.empty()
                data.products.forEach(function (product) {
                    body_products.append(`
                            <tr class="border-bottom">
                                <td class="py-1">
                                    <span class="fw-bold">${product.name}</span>
                                </td>
                                <td class="py-1">
                                    <span class="fw-bold">${product.amount}</span>
                                </td>
                                <td class="py-1">
                                    <span class="fw-bold">${product.price}</span>
                                </td>
                                <td class="py-1">
                                    <span class="fw-bold">${product.discount_price}</span>
                                </td>
                                <td class="py-1">
                                    <span class="fw-bold">${product.total}</span>
                                </td>
                            </tr>
                        `)
                })
                $('#xlarge').modal('show')
                $('#btn-print').attr('data-order_id', data.order_id)
            })


        })

    </script>
@endsection
