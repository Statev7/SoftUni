function sumOfOrders(product, quantity){
    let prices = { 'coffee': 1.50, 'water': 1.00, 'coke': 1.40, 'snacks': 2.00 };

    let productPrice = prices[product.toLowerCase()];
    let sum = productPrice * quantity;

    console.log(sum.toFixed(2));
}