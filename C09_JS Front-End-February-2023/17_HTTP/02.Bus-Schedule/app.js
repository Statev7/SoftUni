function solve() {
    const infoElement = document.querySelector('#info .info');
    const departElement = document.getElementById('depart');
    const arriveElement =  document.getElementById('arrive');

    const BASE_URL = 'http://localhost:3030/jsonstore/bus/schedule/';

    const bus = {stopId: 'depot', stopName: ''}

    function depart() {
        fetch(`${BASE_URL}${bus.stopId}`)
        .then((res) => res.json())
        .then((data) => {
            infoElement.textContent = `Next stop ${data.name}`;
            bus.stopId = data.next;
            bus.stopName = data.name;

            departElement.disabled = true;
            arriveElement.disabled = false;
        })
        .catch((err) => displayError());
    }

    async function arrive() {
        infoElement.textContent = `Arriving at ${bus.stopName}`;

        departElement.disabled = false;
        arriveElement.disabled = true;
    }

    function displayError(){
        infoElement.textContent = 'Error';
        departElement.disabled = true;
        arriveElement.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();