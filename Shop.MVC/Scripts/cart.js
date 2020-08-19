function modifyQuantity(response) {
    var quantities = document.getElementsByClassName("qty");
    var productIds = document.getElementsByClassName("prods_id");


    for (var i = 0; i < quantities.length; i++) {
        if (productIds[i].innerHTML == response.prod_id) {
            quantities[i].innerHTML = response.quantity;
        }
    }
}



function addInCart(id) {
    $.ajax({
        type: "POST",
        url: '/Cart/AddProduct',
        data: { id: id },
        success: function (response) {
            modifyQuantity(response);
            calculateTotal();
        }
    });
}

function subFromCart(id) {
    $.ajax({
        type: "POST",
        url: '/Cart/SubProduct',
        data: { id: id },
        success: function (response) {
            modifyQuantity(response);
            calculateTotal();

        }
    });
}

function deleteFromCart(id) {
    $.ajax({
        type: "POST",
        url: '/Cart/DeleteProduct',
        data: { id: id },
        success: function (response) {
            if (!response.error) {
                $('#cartRow_' + id).remove();
                calculateTotal();

            }
        }
    });
}

function postOrder() {

    let quantities = document.getElementsByClassName("qty");
    let productIds = document.getElementsByClassName("prods_id");
    let list = [];

    for (var i = 0; i < quantities.length; i++) {
        list.push({ ProductId: productIds[i].innerHTML, Quantity: quantities[i].innerHTML });
    }

    orderItemAdds = JSON.stringify({ 'orderItemAdds': list });

    $.ajax({
        type: "POST",
        url: '/Order/Create',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: orderItemAdds ,
        success: function (response) {
            alert("good");
        }
    });
}


function calculateTotal() {
    let quantities = document.getElementsByClassName("qty");
    let prices = document.getElementsByClassName("price");
    let total = 0;

    for (var i = 0; i < quantities.length; i++) {
        total += quantities[i].innerHTML * prices[i].innerHTML;
    }

    document.getElementById("totalPrice").innerHTML = "Total price: " + total;
}


    calculateTotal();
