fetch("https://localhost:44335/api/getnews")
    .then(response => response.json())
    .then(data => {
        console.log(data);
    });