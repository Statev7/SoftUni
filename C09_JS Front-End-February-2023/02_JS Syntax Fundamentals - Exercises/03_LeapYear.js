function isLeapYear(year){

    let isLeap = year % 4 === 0 && 
                 year % 100 !== 0 ||
                 year % 400 === 0;

    let result = isLeap ? 'yes' : 'no';
    console.log(result);
}
