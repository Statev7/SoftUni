function solve(array, rotationsCount){

    for(let index = 0; index < rotationsCount; index++){
        let firstElement = array.shift();
        array.push(firstElement);
    }

    console.log(array.join(' '));
}
