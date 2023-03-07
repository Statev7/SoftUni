function addItem() {
    const selectMenu = document.getElementById('menu');
    const newItemTextElement = document.getElementById('newItemText');
    const valueElement = document.getElementById('newItemValue');

    const option = document.createElement('option');
    option.innerText = newItemTextElement.value;
    option.value = valueElement.value;

    selectMenu.add(option);

    newItemTextElement.value = '';
    valueElement.value = '';
}