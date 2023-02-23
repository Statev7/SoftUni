function solve(text){

    let startIndex = 0;
    let result = [];

    for(let index = 0; index < text.length; index++){

        if(text[index] === text[index].toUpperCase() && index !== 0){

            let subString = text.substring(startIndex, index);
            result.push(subString);

            startIndex = index;
        } 

        if(index + 1 === text.length){
            let subString = text.substring(startIndex);
            result.push(subString);
        }
    }

    console.log(result.join(', '));
}