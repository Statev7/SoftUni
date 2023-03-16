function solve(...input){
    const typesCount = {};

    for (const value of input) {
        const type = typeof value;
        console.log(`${type}: ${value}`);

        if(!typesCount.hasOwnProperty(type)){
            typesCount[type] = 0;
        }
        typesCount[type]++;
    }

    Object.entries(typesCount)
        .sort((a, b) => b[1] - a[1])
        .forEach(x => console.log(`${x[0]} = ${x[1]}`));
}
