function attachEvents() {
    const URL = 'http://localhost:3030/jsonstore/phonebook/';

    const phonebookListElement = document.getElementById('phonebook');
    const personInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');

    document.getElementById('btnLoad').addEventListener('click', loadInformation);
    document.getElementById('btnCreate').addEventListener('click', createNewContact);

    async function loadInformation() {
        phonebookListElement.innerHTML = '';

        try {
            const request = await fetch(URL);
            const data = Object.values(await request.json());

            for (const { person, phone, _id } of data) {
                const liElement = document.createElement('li');
                const deleteBtn = document.createElement('button');

                liElement.textContent = `${person}: ${phone}`;
                deleteBtn.textContent = 'Delete';
                deleteBtn.id = _id;

                deleteBtn.addEventListener('click', deleteContact);

                liElement.appendChild(deleteBtn);
                phonebookListElement.appendChild(liElement);
            }
        } catch (error) {
            console.log(error);
        }
    }

    async function createNewContact() {
        const person = personInput.value;
        const phone = phoneInput.value;
        const headers = {
            method: 'POST',
            body: JSON.stringify({person, phone}),
        }

        try {
            const request = await fetch(URL, headers);
            loadInformation();
        } catch (error) {
            console.log(error);
        }

        personInput.value = '';
        phoneInput.value = '';
    }

    async function deleteContact(e){
        const headers = {
            method: 'DELETE'
        }

        try {
            const request = await fetch(`${URL}${e.target.id}`, headers)
            loadInformation();
        } catch (error) {
            console.log(error);
        }
    }
}

attachEvents();