var cartEl = document.getElementById("cart");
var inputNameEl = document.getElementById("Nombre_Producto");
var Nombre_Producto_val = document.getElementById("Nombre_Producto_val");
var inputPriceEl = document.getElementById("Id_Producto");
var totalEl = document.getElementById("total-price");
var currentIndex = 0;
var total = 0;

function addToCart() {
    if (inputNameEl.value !== "" && inputPriceEl.value !== "") {
        cartEl.innerHTML +=
            '<li id="' +
            currentIndex +
        '"><label class="control ">' +
        Nombre_Producto_val.val +
            '</label> <span class="price">' +
            inputPriceEl.value +
            ' pesos <button class="removeBtn" onclick="removeFromCart(' +
            currentIndex +
            ')">x</button></span></li>';
        currentIndex += 1;
        total += parseInt(inputPriceEl.value);
        totalEl.innerHTML = total + " Pesos";
        inputNameEl.value = "";
        inputPriceEl.value = "";
    }
}

function removeFromCart(index) {
    console.log(index);
    var liEl = document.getElementById(index.toString()).remove();
}
