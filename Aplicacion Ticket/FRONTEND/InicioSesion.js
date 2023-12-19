document.getElementById('inicioSesion').addEventListener('submit', function(event) {
    event.preventDefault(); 

    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    fetch(`https://localhost:7023/Validar?username=${username}&password=${password}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
       
    })
    .then(response => response.text())
    .then(data => {
        window.location.href = 'home.html'
    })
    .catch((error) => {
        console.error('Error:', error);
    })
})

    