function solve() {
    const moviesUlElement = document.querySelector('#movies ul');
    const arhiveUlElement = document.querySelector('#archive ul');

    document.querySelector('#add-new #container button').addEventListener('click', addMovie);
    document.querySelector('#archive button').addEventListener('click', clearArhive);

    function addMovie(){
        const inputs = Array.from(document.querySelectorAll('#add-new #container input'));

        if(inputs.some(i => i.value === '') || isNaN(inputs[inputs.length - 1].value)){
            console.log('Validation test!');
            return;
        }

        const values = inputs.map(i => i.value);
        createMovie(values);

        inputs.forEach(x => x.value = '');
    }

    function createMovie(arguments){
        const liElement = document.createElement('li');
        const ticketPrice = Number(arguments[2]).toFixed(2);

        liElement.innerHTML = `<span>${arguments[0]}</span>
        <strong>Hall: ${arguments[1]}</strong>
        <div>
        <strong>${ticketPrice}</strong>
        <input placeholder="Tickets Sold">
        <button>Archive<button>`;

        moviesUlElement.appendChild(liElement);
        liElement.querySelector('button').addEventListener('click', archiveMovie);
    }

    function archiveMovie(e){
        const divParentElement = e.target.parentElement;

        const pricePerTicket = Number(divParentElement.getElementsByTagName('strong')[0].textContent);
        let ticketsSoldValue = divParentElement.getElementsByTagName('input')[0].value;

        if(isNaN(ticketsSoldValue) || ticketsSoldValue === ''){
            return;
        }

        const totalPrice = (pricePerTicket * Number(ticketsSoldValue)).toFixed(2);

        const liParentElement = divParentElement.parentElement;
        const movieName = liParentElement.getElementsByTagName('span')[0].textContent;

        liParentElement.innerHTML = `<span>${movieName}</span>
        <strong>Total amount: ${totalPrice}</strong>
        <button>Delete</button>`;

        arhiveUlElement.appendChild(liParentElement);
        arhiveUlElement.querySelector('button').addEventListener('click', deleteArhive);
    }

    function deleteArhive(e){
        e.target.parentElement.remove();
    }

    function clearArhive(e){
        Array.from(e.target.parentElement.querySelectorAll('li'))
            .forEach(li => li.remove());
    }
}