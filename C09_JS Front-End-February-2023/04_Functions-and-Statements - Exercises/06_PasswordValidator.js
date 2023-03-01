function passwordValidator(password){

    const invalidLengthErrorMessage = 'Password must be between 6 and 10 characters';
    const invalidSymbolErrorMessage = 'Password must consist only of letters and digits';
    const invalidCountOfDigits = 'Password must have at least 2 digits';

    let result = '';

    if(!isLengthValid(password)){
        result += `${invalidLengthErrorMessage} \n`;
    }

    if(!isOnlyLettersAndNumbers(password)){
        result += `${invalidSymbolErrorMessage} \n`;
    }

    if(!isDigitsCountValid(password)){
        result += `${invalidCountOfDigits}`;
    }

    if(result === ''){
        result = 'Password is valid';
    }

    console.log(result.trim());

    function isLengthValid(str) {
        return str.length >= 6 && str.length <= 10;
    }

    function isOnlyLettersAndNumbers(str) {
        return /^[A-Za-z0-9]*$/.test(str);
    } 

    function isDigitsCountValid(str){
        return /[0-9]{2,}/.test(str);
    }
}

passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');