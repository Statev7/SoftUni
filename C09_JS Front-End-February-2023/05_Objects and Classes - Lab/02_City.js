function printCityInfo(city){
    for (const property in city) {
        console.log(`${property} -> ${city[property]}`);
    }
}