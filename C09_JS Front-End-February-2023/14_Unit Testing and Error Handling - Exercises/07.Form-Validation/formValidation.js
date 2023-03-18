function validate() {
    const usernameElement = document.getElementById('username');
    const emailElement = document.getElementById('email');
    const passwordElement = document.getElementById('password');
    const confPasswordElement = document.getElementById('confirm-password');

    const usernamePattern = /^[A-Za-z0-9]{3,20}$/;
    const emailPattern = /^[^@.]+@[^@]*\.[^@]*$/;
    const passwordPattern = /^[\w]{5,15}$/;

    document.getElementById('submit').addEventListener('click', validateForm);
    document.getElementById('company').addEventListener('change', function() {
        const companyInfo = document.getElementById('companyInfo');
        if(companyInfo.style.display === 'none'){
            companyInfo.style.display = 'block';
        } else {
            companyInfo.style.display = 'none';
        }
    });

    function validateForm(e){
        Array.from(document.getElementsByTagName('input'))
            .forEach(x => x.style.border = 'none');

        const invalidElements = [];

        if(!usernamePattern.test(usernameElement.value)){
            invalidElements.push(usernameElement);
        }

        if(!emailPattern.test(emailElement.value)){
            invalidElements.push(emailElement);
        }
        
        const isPasswordInvalid = passwordPattern.exec(passwordElement.value) === null || 
                                  passwordPattern.exec(confPasswordElement.value) === null || 
                                  passwordElement.value !== confPasswordElement.value;

        if(isPasswordInvalid){
            invalidElements.push(passwordElement);
            invalidElements.push(confPasswordElement);
        }

        const companyInfo = document.getElementById('companyInfo');
        if(companyInfo.style.display === 'block'){
            const companyNumberElement = document.getElementById('companyNumber');
            const companyNumber = Number(companyNumberElement.value);

            if(companyNumber < 1000 || companyNumber > 9999){
                invalidElements.push(companyNumberElement);
            }
        }

        const validElement = document.getElementById('valid');

        if(invalidElements.length === 0){
            validElement.style.display = 'block';
        } else {
            validElement.style.display = 'none';
            invalidElements.forEach(x => x.style.border = 'red');
        }
    }
}