let cart = []; // Inicializa el carrito como un array vacío

// Función para agregar productos al carrito
function addToCartButtonClick(button) {
    console.log("Botón de agregar al carrito clicado");
    const ID_Personaje = button.getAttribute("data-ID_Personaje");
    const Nombre = button.getAttribute("data-Nombre");
    const Precio = parseFloat(button.getAttribute("data-Precio"));
    console.log(`ID: ${ID_Personaje}, Nombre: ${Nombre}, Precio: ${Precio}`);
    const item = cart.find(item => item.ID_Personaje === ID_Personaje);
    console.log(`Producto encontrado en el carrito: ${item ? 'Sí' : 'No'}`);
    if (item) {
        item.Cantidad++;
        console.log(`Cantidad actualizada de ${Nombre}: ${item.Cantidad}`);
    } else {
        cart.push({ ID_Personaje, Nombre, Precio, Cantidad: 1 });
        console.log(`Producto agregado al carrito: ${Nombre}`);
    }
    console.log('Carrito actualizado:', cart);
    updateCart();
}

// Función para actualizar el contenido del carrito
function updateCart() {
    const cartTableBody = $("#cartTable tbody");
    cartTableBody.empty();
    let total = 0;
    cart.forEach((item) => {
        const itemTotal = item.Precio * item.Cantidad;
        total += itemTotal;
        const row = `
            <tr>
                <td>${item.Nombre}</td>
                <td>${item.Precio.toFixed(2)} €</td>
                <td>${item.Cantidad}</td>
                <td>${itemTotal.toFixed(2)} €</td>
                <td><button onclick="removeFromCart('${item.ID_Personaje}')">Eliminar</button></td>
            </tr>
        `;
        cartTableBody.append(row);
    });
    cartTableBody.append(`
        <tr>
            <td colspan="3">Total</td>
            <td colspan="2">${total.toFixed(2)} €</td>
        </tr>
    `);
    console.log('Vista del carrito actualizada', cart);
    $("#cartContainer").toggle(cart.length > 0);
}

// Función para eliminar productos del carrito
function removeFromCart(ID_Personaje) {
    cart = cart.filter((item) => item.ID_Personaje !== ID_Personaje);
    updateCart(); // Actualiza la vista del carrito
    alert(`Se ha eliminado el producto con ID: ${ID_Personaje} del carrito.`);
}

// Función para mostrar/ocultar el carrito al hacer clic en el ícono del carrito
$(document).ready(function () {
    $("#checkoutButton").click(function () {
        console.log("Botón de Confirmar Compra clicado");
        if (cart.length === 0) {
            alert("El carrito está vacío.");
        } else {
            // Almacena el carrito en la sesión de forma sencilla
            const carritoJSON = JSON.stringify(cart);
            // Aquí, podrías usar un campo oculto o simplemente pasar el carrito como parámetro en la URL
            window.location.href = "ConfirmarCompra.aspx?carritoData=" + encodeURIComponent(carritoJSON);
        }
    });
});














