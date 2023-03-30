function getInfo() {
    const inputElement = document.getElementById('stopId');
    const stopNameElement = document.getElementById('stopName');
    const busesListElement = document.getElementById('buses');

    const busId = Number(inputElement.value);

    busesListElement.innerHTML = '';

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${busId}`)
        .then((res) => res.json())
        .then((data) => {
            stopNameElement.textContent = data.name;
            for (const [busId, time] of Object.entries(data.buses)) {
                let li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${time} minutes`;
                busesListElement.appendChild(li);
            }
        })
        .catch(stopNameElement.textContent = 'Error')
        .finally(inputElement.value = '');
}