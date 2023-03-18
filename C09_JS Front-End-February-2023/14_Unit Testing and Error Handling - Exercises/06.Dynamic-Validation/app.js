function validate() {
    const emailPatter = /^[a-z]+\@[a-z]+\.[a-z]+$/; 
    
    document.getElementById('email').addEventListener('change', function(e) {
        if(emailPatter.test(e.target.value)){
            e.target.classList.remove('error');
            return;
        }

        e.target.classList.add('error');
    });
}