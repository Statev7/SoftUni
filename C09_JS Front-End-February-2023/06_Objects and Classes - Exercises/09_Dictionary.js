function solve(dataAsJson){
    const dictionary = {};

    for(let index = 0; index < dataAsJson.length; index++){
        const obj = JSON.parse(dataAsJson[index]);

        const key = Object.keys(obj);
        const value = Object.values(obj);

        if(dictionary[key] == undefined){
            dictionary[key] = '';
        }

        dictionary[key] = value;
    }

    Object.entries(dictionary)
    .sort((a, b) => a[0].localeCompare(b[0]))
    .forEach(e => console.log(`Term: ${e[0]} => Definition: ${e[1]}`))
}