function attachEvents() {
    const POSTS_URL = 'http://localhost:3030/jsonstore/blog/posts';
    const COMMENTS_URL = 'http://localhost:3030/jsonstore/blog/comments';

    const postsSelectElement = document.getElementById('posts');
    const postTitleElement = document.getElementById('post-title');
    const postBodyElement = document.getElementById('post-body');
    const postCommentsListElement = document.getElementById('post-comments');

    let posts;

    document.getElementById('btnLoadPosts').addEventListener('click', async () => {
        postsSelectElement.innerHTML = '';

        const request = await fetch(POSTS_URL);
        posts = Object.values(await request.json());

        for (const post of posts) {
            const optionElement = document.createElement('option');
            optionElement.text = post.title;
            optionElement.value = post.id;

            postsSelectElement.appendChild(optionElement);
        }
    })

    document.getElementById('btnViewPost').addEventListener('click', async () => {
        postTitleElement.textContent = '';
        postBodyElement.textContent = '';
        postCommentsListElement.innerHTML = '';

        const request = await fetch(COMMENTS_URL);
        const commentsData = Object.values(await request.json());

        const postId = postsSelectElement.options[postsSelectElement.selectedIndex].value;

        const post = posts.find(p => p.id === postId);
        const comments = commentsData.filter(c => c.postId === postId);

        postTitleElement.textContent = post.title;
        postBodyElement.textContent = post.body;
        for (const comment of comments) {
            const liElement = document.createElement('li');
            liElement.textContent = comment.text;

            postCommentsListElement.appendChild(liElement);
        }
    })
}

attachEvents();