(num1, num2, operation) => {
    let mathFunction = {
        'multiply': (num1, num2) => num1 * num2,
        'divide': (num1, num2) => num1 / num2,
        'add': (num1, num2) => num1 + num2,
        'subtract': (num1, num2) => num1 - num2,
    }

    console.log(mathFunction[operation](num1, num2));
}