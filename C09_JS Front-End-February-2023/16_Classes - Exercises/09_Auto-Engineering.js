function solve(input){
    const carsCompany = {};

    for (const line of input) {
        let brand, model, producedCars;
        [brand, model, producedCars] = line.split(' | ');

        if(!carsCompany.hasOwnProperty(brand)){
            carsCompany[brand] = {};
        }
        
        if(!carsCompany[brand].hasOwnProperty(model)){
            carsCompany[brand][model] = 0;
        }

        carsCompany[brand][model] += Number(producedCars);
    }

    for (const [brand, model] of Object.entries(carsCompany)) {
        console.log(brand);

        for (const [key, value] of Object.entries(model)) {
            console.log(`###${key} -> ${value}`);
        }
    }
}