function charactersInRange(start, end){

    if(start > end){
        let temp = start;
        start = end;
        end = temp;
    }

    let result = '';

    for(let index = start.charCodeAt(0) + 1; index < end.charCodeAt(0); index++){
        result += `${String.fromCharCode(index)} `;
    }

    console.log(result);
}
