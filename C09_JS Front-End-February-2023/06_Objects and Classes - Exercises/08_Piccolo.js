function solve(input){
    const cars = {};

    for(let index = 0; index < input.length; index++){
        const tokens = input[index].split(', ');

        let command, number;
        [command, number] = tokens;

        if(cars[number] == undefined){
            cars[number] == '';
        }

        cars[number] = command;
    }

    const entries = Object.entries(cars)
        .sort((x, y) => x[0].localeCompare(y[0]))
        .filter(x => x[1] === 'IN');

    entries.length == 0 ? console.log('Parking Lot is Empty') : entries.forEach(x => console.log(x[0]));
}