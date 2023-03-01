function oddAndEvenSum(number){
    let evenSum = 0;
    let oddSum = 0;

    while(number > 1){
        let digit = Math.floor(number % 10);

        digit % 2 == 0 ? evenSum += digit : oddSum += digit;
        
        number /= 10;
    }

    let resultAsString = `Odd sum = ${oddSum}, Even sum = ${evenSum}`;
    console.log(resultAsString);
}

oddAndEvenSum(1000435);
oddAndEvenSum(3495892137259234);