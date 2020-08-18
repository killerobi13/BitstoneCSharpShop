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
                $('#cartRow_'+id).remove();
            }
        }
    });
}