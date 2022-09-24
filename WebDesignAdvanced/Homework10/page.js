const API_URL = 'http://dummyjson.com/products';
const API_IMG = 'http://dummyjson.com/image/i/products';
const API_SEARCH = 'http://dummyjson.com/products/search?q=';
let categories = [];
let mainProducts = [];
let currentProducts = [];
let cart = [];
let cartSum = 0;
let showAll = false;
let selectedCategory = '';

//SHOW CATEGORIES
function loadCategories() {
    $.ajax({
        url: `${API_URL}/categories`,
        type: 'GET',
        success: function (response) {
            categories = response;
            showCategories(categories);
        }
    });
}

function showCategories(categories) {

    $('.category-container').html('');

    let cnt = showAll == true ? categories.length : 6;
    let showBtn = showAll == true ? 'Show Less' : 'Show More';
    let showBtnId = showAll == true ? 'less' : 'more';
    let showOffset = showAll == true ? '6' : '10';

    for (let i = 0; i < cnt; i++) {
        let html = '<div class="col-sm-6 col-md-2" >';
        html += '<div class="box">';
        html += `<a href="/" class="btn btn-primary category-select" data-category="${categories[i]}">${categories[i]}</a>`;
        html += '</div>';
        html += '</div>';
        $('.category-container').append(html);
    }

    $('.category-container').append(`<div class="col-sm-6 col-md-2 offset-sm-0 offset-md-${showOffset}"><div class="box"><a href="#" id="${showBtnId}" class="btn btn-outline-primary">${showBtn}</a></div></div>`);
}
//SHOW CATEGORIES END
//PRODUCTS
function loadProducts(page) {
    $.ajax({
        url: `${API_URL}?limit=100`,
        type: 'GET',
        success: function (response) {
            mainProducts = response.products;
            currentProducts = mainProducts;
            showProducts(mainProducts, page);
            paginate(mainProducts, page);
        }
    });
}

function showProducts(products, page) {
    let perPage = 10;
    let skip = (page - 1) * perPage;
    let pageProducts = products.slice(skip, perPage + skip);
    let html = '';

    $('.listings-container').html(html);

    for (let i = 0; i < pageProducts.length; i++) {
        html += `<div class="col-sm-12 col-md-3">`;
        html += `<div class="card d-flex justify-content-center align-items-center listing" data-id="${pageProducts[i].id}">`;
        html += `<img class="img-fluid card-img-top p-3 border mt-3" src="${API_IMG}/${pageProducts[i].id}/1.jpg" alt="Image not found" style="width: 200px; height: 150px;">`;
        html += `<div class="card-body w-100 d-flex flex-column align-items-center justify-content-center">`;
        html += `<h6 class="card-title">${pageProducts[i].title}</h6>`;
        html += `<ul>`;
        html += `<li>Rating: ${pageProducts[i].rating}<span>★</span></li>`;
        html += `<li>Price: ${pageProducts[i].price}$</li>`;
        html += `<li>Discount: ${pageProducts[i].discountPercentage}%</li>`;
        html += `</ul>`;
        html += '</div>';
        html += '</div>';
        html += '</div>';
    }

    $('.listings-container').html(html);
}

function paginate(products, page) {
    let perPage = 10;

    let totalPages = Math.ceil(products.length / perPage);

    let html = '';
    for (let i = 0; i < totalPages; i++) {
        if (i + 1 == page) {
            html += `<li class="page-item active" data-page="${i + 1}"><a class="page-link" href="#">${i + 1}</a></li>`;
        } else {
            html += `<li class="page-item" data-page="${i + 1}"><a class="page-link" href="#">${i + 1}</a></li>`;
        }
    }

    $('.pagination').html(html);
}

function filterProducts(priceRange, order) {

    let filtered = [];

    if (!isNaN(priceRange.from) && !isNaN(priceRange.to)) {
        filtered = currentProducts.filter(p => p.price >= priceRange.from && p.price <= priceRange.to);
        filtered = sortProducts(filtered, order);
        return filtered;
    }
    else if (!isNaN(priceRange.from)) {
        filtered = currentProducts.filter(p => p.price >= priceRange.from);
        filtered = sortProducts(filtered, order);
        return filtered;
    }
    else if (!isNaN(priceRange.to)) {
        filtered = currentProducts.filter(p => p.price <= priceRange.to);
        filtered = sortProducts(filtered, order);
        return filtered;
    }
    else {
        filtered = sortProducts(currentProducts, order);
        return filtered;
    }
}

function sortProducts(products, order) {

    let sorted = [];

    if (order == 0) {
        return products;
    }
    else if (order == 1) {
        sorted = products.sort((a, b) => {
            return a.price - b.price;
        });
        return sorted;
    }
    else if (order == 2) {
        sorted = products.sort((a, b) => {
            return b.price - a.price;
        });
        return sorted;
    }
    else if (order == 3) {
        sorted = products.sort((a, b) => {
            return b.discountPercentage - a.discountPercentage;
        });
        return sorted;
    }
}
//PRODUCTS END
//CART
function showCart(products) {
    let html = '';

    if (cart.length == 0) {
        $('#cart-quantity').html('');
    } else {
        $('#cart-quantity').html(cart.length);
    }

    for (let i = 0; i < cart.length; i++) {
        html += `<li class="cart-item p-1 border-bottom" data-item-id="${i}" data-product="${cart[i].id}">`;
        html += `<div class="w-100 d-flex justify-content-between">`;
        html += `<div>${cart[i].title} - ${cart[i].price}$</div>`;
        html += `<button data-id="${i}" class="btn-close cart-remove"></button>`;
        html += `</div>`;
        html += `</li>`;
    }

    $('#cart-price').html(`<div class="me-auto">Total: ${cartSum}$</div>`);

    $('#cart-products').html(html);
}
//CART END
$(function () {
    loadCategories();
    loadProducts(1);

    $('body').on('click', '#more', function (event) {
        event.preventDefault();

        showAll = true;
        showCategories(categories);
    });

    $('body').on('click', '#less', function (event) {
        event.preventDefault();

        showAll = false;
        showCategories(categories);
    });

    $('body').on('click', '.listing', function (event) {
        event.preventDefault();
        $('#product-modal').modal('show');

        let productId = parseInt($(this).data('id'));
        let product = mainProducts[productId - 1];

        $('#product-name').html(product.title);
        $('#product-img').attr('src', product.thumbnail);
        $('#product-description').html(`<p class="mt-3">${product.description}</p>`);
        $('#product-price').after(`<button class="btn btn-success" id="add2-cart" data-id="${product.id}">Add to cart</button>`);

        $('#product-price').html('Price: ' + product.price + '$');
        $('#product-price').addClass('me-auto');
    });

    $('body').on('click', '.close-modal', function () {
        $('#product-modal').modal('hide');
        debugger;
        $('#add2-cart').remove();

        $('#product-name').html('');
        $('#product-img').attr('src', '');
        $('#product-description').html('');
        $('#product-price').after('');

        $('#product-price').html('');
    });

    $('#product-modal').on('hidden.bs.modal', function () {
        $('#product-modal').modal('hide');

        $('#add2-cart').remove();

        $('#product-name').html('');
        $('#product-img').attr('src', '');
        $('#product-description').html('');
        $('#product-price').after('');

        $('#product-price').html('');
    });

    $('body').on('click', '.page-item', function (event) {
        event.preventDefault();
        let page = $(this).data('page');
        showProducts(currentProducts, page);

        let pageElements = $('.page-item');

        $(pageElements).each(function (index, value) {
            $(value).removeClass('active');
        })

        $(this).toggleClass('active');
    });

    $('body').on('click', '.category-select', function (event) {
        event.preventDefault();

        selectedCategory = $(this).data('category');
        let categoryProducts = [];
        $(mainProducts).each((index, value) => {
            if (value.category == selectedCategory) {
                categoryProducts.push(value);
            }
        });
        currentProducts = categoryProducts;
        showProducts(currentProducts, 1);
        paginate(currentProducts, 1);
    });

    $('body').on('click', '#filter', function () {
        let priceRange = { from: parseFloat($('input[name=price-from]').val()), to: parseFloat($('input[name=price-to]').val()) };

        if (priceRange.from > priceRange.to) {
            $('#price-error-msg').addClass('text-danger');
            $('#price-error-msg').html('Invalid price filter');
            return;
        }
        else if (priceRange.to < priceRange.from) {
            $('#price-error-msg').addClass('text-danger');
            $('#price-error-msg').html('Invalid price filter');
            return;
        }

        let order = parseInt($('#order-by').val());

        let filtered = [];

        if (selectedCategory != '') {

            filtered = filterProducts(priceRange, order);
            showProducts(filtered, 1);
            paginate(filtered, 1);

        } else {
            currentProducts = mainProducts;
            filtered = filterProducts(priceRange, order);
            currentProducts = filtered;
            showProducts(currentProducts, 1);
            paginate(currentProducts, 1);
        }
    });

    $('body').on('click', '#reset', function () {
        selectedCategory = '';
        $('input[name=price-from]').val('');
        $('input[name=price-to]').val('');
        $('input[name=search]').val('');
        $('#order-by').prop('selectedIndex', 0);
        currentProducts = mainProducts;
        showProducts(currentProducts, 1);
        paginate(mainProducts, 1);
    });

    $('body').on('click', '#search', function (event) {
        event.preventDefault();
        let search = $('input[name=search]').val();

        if (search == '') {
            currentProducts = mainProducts;
            showProducts(mainProducts, 1);
            paginate(mainProducts, 1);
            return;
        }

        let requestUrl = `${API_SEARCH}${search}`;

        $.ajax({
            url: requestUrl,
            type: 'GET',
            success: function (response) {
                currentProducts = response.products;
                showProducts(currentProducts, 1);
                paginate(currentProducts, 1);
            }
        });
    });

    $('body').on('click', '#add2-cart', function () {
        let productId = $(this).data('id');
        product = mainProducts[productId - 1];
        cart.push(product);
        cartSum += product.price;
        $('#cart-quantity').html(cart.length);
    });

    $('body').on('click', '#cart', function (event) {
        event.preventDefault();
        $('#cart-modal').modal('show');
        showCart(cart);
    });

    $('#cart-modal').on('click', '.cart-remove', function () {
        let id = $(this).data('id');
        let element = $(`li[data-item-id=${id}]`);
        let productId = $(element).data('product');
        let product = mainProducts[productId - 1];
        cartSum -= product.price;
        cart.splice(id, 1);
        element.remove();
        showCart(cart);
    });
});