function printMatrix(n){
    let nAsString = `${n} `;
    for(let row = 0; row < n; row++){
        console.log(`${nAsString.repeat(n)}`)
    }
}