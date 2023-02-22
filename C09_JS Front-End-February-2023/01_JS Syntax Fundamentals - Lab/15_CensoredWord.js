function replace(text, wordToCenore){

    let censore = '*'.repeat(wordToCenore.length);
    let result = text;
    let indexOfWord = result.indexOf(wordToCenore);

    while(indexOfWord !== -1){
        result = result.replace(wordToCenore, censore);
        indexOfWord = result.indexOf(wordToCenore);
    }

    console.log(result);
}
