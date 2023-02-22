function printMonth(n){

    let resultMessage = 'Error!';
    let monthAsIndex = n - 1;
    let months = 
    [
        'January', 'February', 'March', 
        'April', 'May', 'June', 'July', 
        'August', 'September', 'October', 
        'November', 'December'
    ];

    if(n <= 12 && n >= 1){
        resultMessage = months[monthAsIndex];
    }

    console.log(resultMessage);
}
