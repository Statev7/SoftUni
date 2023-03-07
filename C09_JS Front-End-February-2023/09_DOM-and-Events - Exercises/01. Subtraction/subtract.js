function subtract() {
    const firstNumElement = document.getElementById('firstNumber');
    const secondNumElement = document.getElementById('secondNumber');
    
    const resultElement = document.getElementById('result');

    const resultValue = Number(firstNumElement.value) - Number(secondNumElement.value);
    resultElement.innerText = resultValue;
}