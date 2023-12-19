document.getElementById("formEmail").addEventListener("submit", function (event) {
    event.preventDefault();
    const correo = document.getElementById("email").value;
    const valor = 'Email'

fetch(`https://localhost:7023/enviar?metodo=${correo}&opcion=${valor}`)
    .then(response => response.text())
    .then(data => {
        alert(data)

        window.location.href = '../inicioSesion.html'
    })
    .catch(error => {
        console.error('Error al llamar a la API de suma:', error);
    });
});