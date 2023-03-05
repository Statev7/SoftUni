function solve(products){
    const obj = products
        .map(line => line.split(' : '))
        .sort((x, y) => x[0].localeCompare(y[0]))
        .reduce((obj, currentLine) => {
            obj[currentLine[0]] = Number(currentLine[1]);
            return obj;
        }, {});

    let previusGroup = '';
    for (const key in obj) {
        if(previusGroup !== key[0]){
            previusGroup = key[0];
            console.log(key[0]);
        }

        console.log(`  ${key}: ${obj[key]}`);
    }
}