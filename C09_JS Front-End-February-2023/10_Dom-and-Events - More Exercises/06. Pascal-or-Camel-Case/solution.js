function solve() {
  let input = document.getElementById('text').value;
  const inputCase = document.getElementById('naming-convention').value;
  const result = document.getElementById('result');

  const words = input.split(' ').map(w => w.toLowerCase());
  
  if(inputCase !== 'Camel Case' && inputCase !== 'Pascal Case'){
    result.textContent = 'Error!';
    return;
  }

  let resultMessage = '';
  inputCase === 'Camel Case' ? transformToCamelCase(words) : transformToPascalCase(words);

  result.textContent = resultMessage;

  function transformToCamelCase(array){
    resultMessage = array.reduce((finalWord, currentWord, index) => {
      if(index === 0){
        finalWord += currentWord;
        return finalWord;
      }

      finalWord += firstLetterToUpper(currentWord);
      return finalWord;
    }, '');
  }

  function transformToPascalCase(array){
    resultMessage = array.reduce((finalWord, currentWord) => {
      finalWord += firstLetterToUpper(currentWord);
      return finalWord;
    }, '');
  }

  function firstLetterToUpper(word){
    word = word.charAt(0).toUpperCase() + word.slice(1);
    return word;
  }
}