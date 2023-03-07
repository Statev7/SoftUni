function addItem() {
    const itemsElement = document.getElementById('items');
    const newItemText = document.getElementById('newItemText').value;

    const newItem = document.createElement('li');
    newItem.innerText = newItemText;

    itemsElement.appendChild(newItem);
}