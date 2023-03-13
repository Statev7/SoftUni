function generateReport() {
    const rows = Array.from(document.querySelectorAll('table tbody tr'));
    const inputIndexes = getBoxesIndexes();
    const selectedBoxes = getSelectedBoxesAsArray();
    const textArea = document.getElementById('output');

    const result = [];
    for (const row of rows) {
        const obj = {};

        for (const boxName of selectedBoxes) {
            const index = inputIndexes[boxName];
            obj[boxName] = row.children[index].textContent;
        }
        result.push(obj);
    }

    textArea.value = JSON.stringify(result, null, 2);

    function getBoxesIndexes(){
        return Array.from(document.querySelectorAll('table thead tr th input'))
        .reduce((object, currentValue, index) => {
            object[currentValue.getAttribute('name')] = index;
            return object;
        }, {});
    }

    function getSelectedBoxesAsArray(){
        return Array.from(document
            .querySelectorAll('input[type="checkbox"]:checked'))
            .map(x => x.getAttribute('name'));
    }
}