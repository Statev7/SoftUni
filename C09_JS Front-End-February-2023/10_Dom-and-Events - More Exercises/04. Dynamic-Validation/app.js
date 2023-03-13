function validate() {
    const inputElement = document.getElementById('email');
    const regex = /^[a-z]+\@[a-z]+\.[a-z]+$/;
    inputElement.addEventListener("change", validateInput);
    
    function validateInput(){
       if(regex.test(inputElement.value)){
            inputElement.classList.remove('error');
            return;
       };

       inputElement.classList.add('error');
    }
}