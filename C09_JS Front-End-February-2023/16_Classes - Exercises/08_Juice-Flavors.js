function solve(input){
    const products = {};
    const bottles = {};

    for (const line of input) {
        let productName, quantity;
        [productName, quantity] = line.split(' => ');

        if(!products.hasOwnProperty(productName)){
            products[productName] = 0;
        }
        products[productName] += Number(quantity);

        if(products[productName] >= 1000){
            const bottlesCount = Math.floor(products[productName] / 1000);
            products[productName] -= 1000 * bottlesCount;

            if(!bottles.hasOwnProperty(productName)){
                bottles[productName] = 0;
            }
            bottles[productName] += bottlesCount;
        }
    }

    Object.entries(bottles)
        .forEach(x => console.log(`${x[0]} => ${x[1]}`));
}