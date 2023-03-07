function addItem() {
    const items = document.getElementById('items');
    const newItemText = document.getElementById('newItemText').value;

    const newItem = document.createElement('li');
    newItem.innerText = newItemText;

    items.appendChild(newItem);
    newItem.appendChild(createDeleteBtn());

    function createDeleteBtn(){
        const deleteBtn = document.createElement('a');
        deleteBtn.setAttribute('href', '#');
        deleteBtn.innerText = '[Delete]';
        deleteBtn.addEventListener("click", function() {
            deleteBtn.parentElement.remove();
        })

        return deleteBtn;
    }
}