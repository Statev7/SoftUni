function solve(text, word){
    let textAsArr = text.split(' ');
    let count = 0;

    for(let i = 0; i < textAsArr.length; i++){
        let currentElement = textAsArr[i];

        if(currentElement === word){
            count++;
        }
    }
    
    console.log(count);
}

solve('This is a word and it also is a sentence',
'is'
);