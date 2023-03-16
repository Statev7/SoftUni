function getArticleGenerator(articles) {
    const content = document.getElementById('content');

    return function inner(){
        if(articles.length > 0){
            const articleElement = document.createElement('article');
            articleElement.textContent = articles.shift();
            content.appendChild(articleElement);
        }
    }
}
