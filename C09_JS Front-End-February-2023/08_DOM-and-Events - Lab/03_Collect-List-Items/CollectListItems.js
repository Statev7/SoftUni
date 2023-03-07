function extractText() {
    const itemsElement = document.getElementById('items');
    const areaElement = document.getElementById('result');
    const children = Array.from(itemsElement.children);

    for (const child of children) {
        areaElement.value += `${child.innerText}\n`;
    }
}