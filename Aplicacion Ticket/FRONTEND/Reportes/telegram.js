document.getElementById("formTelegram").addEventListener("submit", function (event) {
    event.preventDefault();
    const telegram = document.getElementById("telegram").value;
    const valor = 'Telegram'

fetch(`https://localhost:7023/enviar?metodo=${telegram}&opcion=${valor}`)
    .then(response => response.text())
    .then(data => {
        alert(data)

        window.location.href = '../inicioSesion.html'
    })
    .catch(error => {
        console.error('Error al llamar a la API de suma:', error);
    });
});