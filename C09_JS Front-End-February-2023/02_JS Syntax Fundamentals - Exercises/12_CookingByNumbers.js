function solve(numberAsString, ...operations){

    let number = Number(numberAsString);

    for(let index = 0; index < operations.length; index++){

        let currentOpeation = operations[index];

        switch(currentOpeation){
            case 'chop': number /= 2; break;
            case 'dice': number = Math.sqrt(number); break;
            case 'spice': number += 1; break;
            case 'bake': number *= 3; break;
            case 'fillet': number -= number * 0.20; break;
        }

        console.log(number);
    }
}