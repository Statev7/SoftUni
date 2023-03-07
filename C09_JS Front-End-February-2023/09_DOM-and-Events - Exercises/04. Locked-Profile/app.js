function lockedProfile() {
    const submitBtns = document.getElementsByTagName('button');

    const submitBtsAsArray = Array.from(submitBtns);

    submitBtsAsArray.forEach(b => b.addEventListener('click', function() {
        const parent = b.parentElement;

        const infoBlock = parent.getElementsByTagName('div')[0];
        const lockStatus = parent.querySelector('input[type="radio"]:checked').value;

        if(lockStatus === 'unlock'){
            if(b.innerText === 'Show more'){
                infoBlock.style.display = 'block';
                b.innerText = 'Hide it';
            } else {
                infoBlock.style.display = 'none';
                b.innerText = 'Show more';
            }
        }
    }));
}