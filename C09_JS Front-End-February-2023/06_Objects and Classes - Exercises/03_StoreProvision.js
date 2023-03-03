function solve(localStock, stockForDelivery){
    const stocks = {};

    addStock(localStock);
    addStock(stockForDelivery);

    for (const key in stocks) {
        console.log(`${key} -> ${stocks[key]}`);
    }

    function addStock(stockToAdd){
        for(let index = 0; index < stockToAdd.length; index+= 2){
            const currentStock = stockToAdd[index];
            const quantity = Number(stockToAdd[index + 1]);

            if(stocks[currentStock] == undefined){
                stocks[currentStock] = 0;
            }

            stocks[currentStock] += quantity;
        }
    }
}