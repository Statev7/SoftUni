function solve(array, spets){
    let result = [];

    for(let index = 0; index < array.length; index+=spets){
        result.push(array[index]);
    }

    return result;
}