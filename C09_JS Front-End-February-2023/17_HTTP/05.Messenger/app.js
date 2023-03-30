function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/messenger';

    const messageBox = document.getElementById('messages');
    const authorInputElement = document.getElementsByName('author')[0];
    const contentInputElement = document.getElementsByName('content')[0];

    document.getElementById('submit').addEventListener('click', async () => {
        const author = authorInputElement.value;
        const content = contentInputElement.value;
        const headers = {
            method: 'POST',
            body: JSON.stringify({author, content})
        }

        console.log(headers.body);

        try {
            const request = await fetch(BASE_URL, headers);

            authorInputElement.value = '';
            contentInputElement.value = '';
        } catch (error) {
            
        }
    })

    document.getElementById('refresh').addEventListener('click', async () => {
        messageBox.textContent = '';
        try {
            const request = await fetch(BASE_URL);
            const messages = Object.values(await request.json());
            const output = [];

            for (const {author, content} of messages) {
                const message = `${author}: ${content}`;

                output.push(message);
            }
            messageBox.textContent = output.join('\n');
        } catch (error) {
            
        }
    })
}

attachEvents();