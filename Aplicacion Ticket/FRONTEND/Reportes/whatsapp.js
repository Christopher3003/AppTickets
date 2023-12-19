document.getElementById("formWhatsapp").addEventListener("submit", function (event) {
    event.preventDefault();
    const Whatsapp = document.getElementById("whatsapp").value;
    const valor = 'Whatsapp'

fetch(`https://localhost:7023/enviar?metodo=${Whatsapp}&opcion=${valor}`)
    .then(response => response.text())
    .then(data => {
        alert(data)
        window.location.href = '../inicioSesion.html'
    })
    .catch(error => {
        console.error('Error al llamar a la API de suma:', error);
    });
});