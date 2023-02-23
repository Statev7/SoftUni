function solve(number){

    let sum = 0;
    let isAllDigitsEqual = true;
    let digit = number % 10;

    while(number > 0){

        let currentDigit = Math.floor(number % 10);

        sum += currentDigit;
        number /= 10;

        if(digit !== currentDigit && currentDigit !== 0 && isAllDigitsEqual){
            isAllDigitsEqual = false;
        }

    }

    console.log(isAllDigitsEqual);
    console.log(sum);

}
