function attachEvents() {
  const URL = 'http://localhost:3030/jsonstore/collections/books/';

  const loadAllBooksBtn = document.getElementById('loadBooks');
  const submitBtn = document.querySelector('#form button');

  const tableBodyElement = document.querySelector('table tbody');
  const formTitle = document.querySelector('#form h3');
  const titleInput = document.querySelector('#form input[name="title"]');
  const authorInput = document.querySelector('#form input[name="author"]');

  loadAllBooksBtn.addEventListener('click', loadBooks);
  submitBtn.addEventListener('click', (e) => {
    if(titleInput.value === '' || authorInput.value === ''){
      return;
    }

    if(e.target.textContent === 'Submit'){
      addBook();
    } else if(e.target.textContent === 'Save'){
      updateBook();
    }

    titleInput.value = '';
    authorInput.value = '';
  })

  let allBooks;
  let updateId;

  async function loadBooks(){
    tableBodyElement.innerHTML = '';
    try {
      const getAllBooksRequest = await fetch(URL);
      const data = await getAllBooksRequest.json();
      allBooks = data;

      for (const [id, book] of Object.entries(data)) {
        console.log(book);
        const tableRow = document.createElement('tr');
        const tdTitle = document.createElement('td');
        const tdAuthor = document.createElement('td');
        const tdActions = document.createElement('td');
        const editBtn = document.createElement('button');
        const deleteBtn = document.createElement('button');

        tdTitle.textContent = book.title;
        tdAuthor.textContent = book.author;

        editBtn.textContent = 'Edit';
        editBtn.id = id;
        editBtn.addEventListener('click', changeForm);

        deleteBtn.textContent = 'Delete';
        deleteBtn.id = id;
        deleteBtn.addEventListener('click', deleteBook);

        tdActions.appendChild(editBtn);
        tdActions.appendChild(deleteBtn);

        tableRow.appendChild(tdTitle);
        tableRow.appendChild(tdAuthor);
        tableRow.appendChild(tdActions);

        tableBodyElement.appendChild(tableRow);
      }
    } catch (error) {
      
    }
  }

  async function addBook(){
    const title = titleInput.value;
    const author = authorInput.value;

    const headers = {
      method: 'POST',
      body: JSON.stringify({author, title})
    }

    try {
      const request = await fetch(URL, headers);
      loadBooks();
    } catch (error) {
    }
  }

  async function deleteBook(e){
    try {
      const request = await fetch(`${URL}${e.target.id}`, {method: 'DELETE'});
      loadBooks();
    } catch (error) {
    }
  }

  function changeForm(e){
    formTitle.textContent = 'Edit FORM';
    submitBtn.textContent = 'Save';

    const book = allBooks[e.target.id];
    updateId = e.target.id;

    titleInput.value = book.title;
    authorInput.value = book.author;
  }

  async function updateBook(){
    const title = titleInput.value;
    const author = authorInput.value;

    const headers = {
      method: 'PUT',
      body: JSON.stringify({author, title})
    }

    try {
      const request = await fetch(`${URL}${updateId}`, headers);
      formTitle.textContent = 'FORM';
      submitBtn.textContent = 'Submit';
      loadBooks();
    } catch (error) {
    }
  }
}

attachEvents();