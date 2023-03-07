function sumTable() {
    const tableRows = document.querySelectorAll('table tbody tr');
    const result = document.getElementById('sum');
    
    let sum = 0;
    for(let index = 1; index < tableRows.length - 1; index++){
        const currentRowChildren = tableRows[index].children;
        const value = Number(currentRowChildren[1].innerText);
        
        sum += value;
    }

    result.innerText = sum;
}