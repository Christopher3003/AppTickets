document.getElementById("form").addEventListener("submit", function (event) {
    event.preventDefault();
    const descripcion = document.getElementById("desc").value;
    
    

    fetch(`https://localhost:7023/pedirInfo?descripcion=${descripcion}`)
    .then(response => response.text())
    .then(data => {
        alert(data)

        
    })
    .catch(error => {
        console.error('Error al llamar a la API de suma:', error);
    });

})
