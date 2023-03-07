function deleteByEmail() {
    const tableBodyTrElements = document.querySelectorAll('table tbody tr');
    const inputValue = document.querySelector('label input').value;
    const result = document.getElementById('result');

    for(let index = 0; index < tableBodyTrElements.length; index++){
        const currentRow = tableBodyTrElements[index];
        const emailValue = currentRow.children[1].innerText;
        
        if(emailValue === inputValue){
            currentRow.remove();
            result.innerText = 'Deleted.';

            break;
        }
        else {
            result.innerText = 'Not found.';
        }
    }
}