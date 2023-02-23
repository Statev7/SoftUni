function solve(array){

    result = [];
    array.sort((x, y) => x - y);

    for(let index = 0; index < array.length / 2; index++){
        let firstNum = array[index];
        let secondNum = array[(array.length - 1) - index];

        if(index !== (array.length - 1) - index){
            result.push(firstNum);
            result.push(secondNum);
        } else{
            result.push(firstNum);
        }
    }

    return result;
}