function division(numOne, numTwo){

    let numOneFactorialSum = factorialSum(numOne);
    let numTwoFactorialSum = factorialSum(numTwo);

    let result = numOneFactorialSum / numTwoFactorialSum;
    console.log(result.toFixed(2));

    function factorialSum(num){
        let sum = 1;
        for(let i = num; i >= 1; i--){
            sum *= i;
        }

        return sum;
    }
}