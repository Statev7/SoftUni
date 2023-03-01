function isNumberPerfect(number){
    let result = 'It\'s not so perfect.';
    let divisors = [];

    for(let divisor = 1; divisor < number; divisor++){
        if(number % divisor === 0){
            divisors.push(divisor);
        }
    }

    let divisorsSum = divisors.reduce((accumulator, value) => accumulator + value, 0);
    if(divisorsSum === number){
        result = 'We have a perfect number!';
    }

    console.log(result);
}