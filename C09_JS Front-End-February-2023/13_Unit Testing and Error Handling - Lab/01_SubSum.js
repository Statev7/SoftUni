function solve(array, startIndex, endIndex){

    if(!Array.isArray(array)){
        return NaN;
    }

    if(array.some(x => isNaN(x))){
        return NaN;
    }

    if(startIndex < 0){
        startIndex = 0;
    }

    if(endIndex > array.length - 1){
        endIndex = array.length - 1;
    }

    return array
    .slice(startIndex, endIndex + 1)
    .reduce((sum, currentValue) => {
        sum += currentValue;
        return sum;
    }, 0)
}