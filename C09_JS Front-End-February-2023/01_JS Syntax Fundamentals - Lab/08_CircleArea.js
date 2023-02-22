function area(number){

    let type = typeof(number);
    let result = `We can not calculate the circle area, because we receive a ${type}.`;

    if(type === 'number'){
        result = (number ** 2 * Math.PI).toFixed(2);
    }

    console.log(result);
}