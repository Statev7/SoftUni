function solve(speed, areaType){

    let areasSpeedLimits = { 'motorway': 130, 'interstate': 90, 'city': 50, 'residential': 20 };
    let limit = areasSpeedLimits[areaType];

    let isSpeedValid = (limit - speed) >= 0;
    let resultMessage = `Driving ${speed} km/h in a ${limit} zone`;

    if(!isSpeedValid){
        let diffrence = speed - limit;
        let status = 'reckless driving';

        if(diffrence <= 20){
            status = 'speeding';
        } else if(diffrence > 20 && diffrence <= 40){
            status = 'excessive speeding';
        }

        resultMessage = `The speed is ${diffrence} km/h faster than the allowed speed of ${limit} - ${status}`;
    }

    console.log(resultMessage);
}
