function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/forecaster/';
    const contentElement = document.getElementById('forecast');
    const currentWeatherElement = document.getElementById('current');
    const upcomingWeatherElement = document.getElementById('upcoming');

    document.getElementById('submit').addEventListener('click', getForecast);

    async function getForecast() {
        contentElement.style.display = 'block';

        const locationElement = document.getElementById('location');
        const locationName = locationElement.value.toLowerCase();

        try {
            const response = await fetch(`${BASE_URL}locations`);
            const data = await response.json();

            const code = data.find(x => x.name.toLowerCase() === locationName).code;
            if (code === null) {
                throw new Error();
            }

            setTimeToday(code);
            setUpcomingTime(code);
        } catch (error) {
            contentElement.textContent = 'Error';
        }

        locationElement.value = '';
    }

    async function setTimeToday(code) {

        const response = await fetch(`${BASE_URL}today/${code}`);
        const data = await response.json();

        const symbol = getSymbol(data.forecast.condition);

        const forecastsElement = document.createElement('div');
        forecastsElement.classList.add('forecasts');

        forecastsElement.innerHTML = `<span class="condition symbol">${symbol}</span>
            <span class="condition">
            <span class="forecast-data">${data.name}</span>
            <span class="forecast-data">${data.forecast.low}°/${data.forecast.high}°</span>
            <span class="forecast-data">${data.forecast.condition}</span>
            </span>`

        currentWeatherElement.appendChild(forecastsElement);
    }

    async function setUpcomingTime(code){
        const response = await fetch(`${BASE_URL}/upcoming/${code}`);
        const data = await response.json();

        const forecastInfoElement = document.createElement('div');
        forecastInfoElement.classList.add('forecast-info');

        for (const day of data.forecast) {
            const upcomingElement = document.createElement('span');
            upcomingElement.classList.add('upcoming');

            upcomingElement.innerHTML = `<span class="symbol">${getSymbol(day.condition)}</span>
            <span class="forecast-data">${day.low}°/${day.high}°</span>
            <span class="forecast-data">${day.condition}</span>`

            forecastInfoElement.appendChild(upcomingElement);
        }

        upcomingWeatherElement.appendChild(forecastInfoElement);
    }

    function getSymbol(condition) {
        const symbols = {
            'Sunny': '&#x2600',
            'Partly sunny': '&#x26C5',
            'Overcast': '&#x2601',
            'Rain': '&#x2614',
            'Degrees': '&#176'
        }

        return symbols[condition];
    }
}

attachEvents();