function solve(word, text){

    let result = `${word} not found!`;

    const textAsArray = text.split(' ');
    const isExist = textAsArray.some((x) => x.toLowerCase() === word.toLowerCase());

    if(isExist){
        result = word;
    }

    console.log(result);
}

