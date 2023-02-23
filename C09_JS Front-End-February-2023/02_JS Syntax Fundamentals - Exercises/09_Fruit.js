function solve (fruitType, weight, pricePerKilogram){

    const weightToKilograms = weight / 1000;

    let price = weightToKilograms * pricePerKilogram;
    let resultAsString = `I need $${price.toFixed(2)} to buy ${weightToKilograms.toFixed(2)} kilograms ${fruitType}.`

    console.log(resultAsString)
}
