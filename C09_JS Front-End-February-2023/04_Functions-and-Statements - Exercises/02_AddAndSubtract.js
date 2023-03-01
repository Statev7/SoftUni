function sum(numOne, numTwo, numThree){
    let sum = numOne + numTwo;

    console.log(subtract(sum, numThree));

    function subtract(numOne, numTwo){
        return numOne - numTwo;
    }
}