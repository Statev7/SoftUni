function solve(numberAsString){
    let number = Number.parseFloat(numberAsString);

    let description = 'Fail';

    if(number >= 3 && number < 3.50){
        description = 'Poor';
    } else if (number >= 3.50 && number < 4.50) {
        description = 'Good';
    } else if (number >= 4.50 && number < 5) {
        description = 'Very good';
    } else if (number >= 5.50) {
        description = 'Excellent';
    }

    let resultAsString = `${description} (${number >= 3 ? number.toFixed(2) : number = 2})`; 

    console.log(resultAsString);
}