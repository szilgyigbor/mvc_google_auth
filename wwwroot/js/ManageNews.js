document.getElementById('newsForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const title = document.getElementById('title');
    const content = document.getElementById('content');
    const imageUrl = document.getElementById('imageurl');

    if (title.value.trim() === '' || content.value.trim() === '') {
        alert('Title and content cannot be empty!');
        event.preventDefault();
        return;
    }

    event.preventDefault();

    fetch("https://localhost:44335/api/createnews", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ title: title.value, content: content.value, imageUrl: imageUrl.value })
    })
        .then(response => response.json())
        .then(data => {
            fetchNews();
            title.value = '';
            content.value = '';
            imageUrl.value = '';
        });
    
});

function fetchNews() {
    fetch("https://localhost:44335/api/getnews")
        .then(response => response.json())
        .then(data => {
            const newsList = document.getElementById('newsList');
            newsList.innerHTML = '';

            data.forEach(news => {
                const newsItem = document.createElement('div');
                newsItem.innerHTML = `<p>
                Id: ${news.id}
                <h5>${news.title} <button class="delete-button" data-id="${news.id}">Delete</button></h5>
                Content: ${news.content}
                <br>
                Image: ${news.imageUrl}
                <br>
                Created: ${news.dateCreated}
                <br>
                Modified: ${news.dateModified}
                <br>
                Author: ${news.author}</p>`;
                newsList.appendChild(newsItem);
            });
        });
}

function deleteNews(id) {
    fetch(`https://localhost:44335/api/deletenews/${id}`, {
        method: 'DELETE',
    })
        .then(response => response.json())
        .then(data => {
            console.log('Deleted:', data);
            fetchNews()
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

document.addEventListener('click', function (e) {
    if (e.target && e.target.classList.contains('delete-button')) {
        const id = e.target.getAttribute('data-id');
        deleteNews(id);
        ;
    }
});

fetchNews();