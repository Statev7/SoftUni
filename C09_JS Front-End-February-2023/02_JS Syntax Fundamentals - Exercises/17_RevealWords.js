function solve(words, text){

    let wordsAsArray = words.split(', ');

    for(let index = 0; index < wordsAsArray.length; index++){

        let currentWord = wordsAsArray[index];
        let wordToReplace = '*'.repeat(currentWord.length);

        text = text.replace(wordToReplace, currentWord);
    }

    console.log(text);
}
