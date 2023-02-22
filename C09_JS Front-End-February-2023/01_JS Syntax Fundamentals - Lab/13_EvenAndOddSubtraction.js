function solve(array){

    let sumOfEvenNumbers = array
            .filter(x => x % 2 === 0)
            .reduce((x, y) => x + y, 0);

    let sumOfOddNumbers = array
            .filter(x => x % 2 !== 0)
            .reduce((x, y) => x + y, 0);

    let result = sumOfEvenNumbers - sumOfOddNumbers;

    console.log(result);
}