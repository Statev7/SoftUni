function toggle() {
    const btnElement = document.getElementsByClassName('button')[0]; 
    const extraElement = document.getElementById('extra');

    extraElement.style.display == 'none' ? showMore(btnElement, extraElement) 
                                        : showLess(btnElement, extraElement);

    function showMore(btnElement, extraElement){
        btnElement.innerText = 'Less';
        extraElement.style.display = 'block';
    }

    function showLess(btnElement, extraElement){
        btnElement.innerText = 'More';
        extraElement.style.display = 'none';
    }
}