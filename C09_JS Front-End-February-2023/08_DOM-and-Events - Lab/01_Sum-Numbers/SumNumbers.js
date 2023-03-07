function calc() {
    const numOne = document.getElementById('num1').value;
    const numTwo = document.getElementById('num2').value;
    const result = document.getElementById('sum');

    const sum = Number(numOne) + Number(numTwo);
    result.value = sum;
}
