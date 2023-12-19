

    fetch('https://localhost:7023/ObtenerInterfaz')
        .then(response => response.text())
        .then(data => {
            console.log(data)
            
            document.getElementById('menu').textContent = data 
        })
        .catch(error => {
            console.error("Error al consumir la API:", error);
        });


