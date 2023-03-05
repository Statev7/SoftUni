function solve(input){
    const flights = converToObject(input[0]);
    const cancelledFlights = converToObject(input[1]);
    const filter = input[2][0];

    const result = [];

    for (const key in flights) {
        const flight = {};
        const destination = 'Destination';
        const status = 'Status';

        flight[destination] = flights[key];

        cancelledFlights
            .hasOwnProperty(key) ? flight[status] = 'Cancelled' 
                                 : flight[status] = 'Ready to fly';
        result.push(flight);
    }

    result
        .filter(f => f.Status === filter)
        .forEach(f => console.log(f));

    function converToObject(input){
        return input.map(x => {
            const indexOf = x.indexOf(' ');

            const firstArg = x.substring(0, indexOf);
            const secondArg = x.substring(indexOf + 1);
            
            return [firstArg, secondArg];
        })
        .reduce((object, currentFlight) => {
            object[currentFlight[0]] = currentFlight[1];
            return object;
        }, {});
    }
}