function solve(ticketInfo, sortingCritetion){
    class Ticket {
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    return ticketInfo.map(line => {
        let name, price, status;
        [name, price, status] = line.split('|');

        return new Ticket(name, Number(price), status);
    })
    .sort((a, b) => sortingCritetion === 'price'
        ? a[sortingCritetion] - b[sortingCritetion] 
        : a[sortingCritetion].localeCompare(b[sortingCritetion]));
}