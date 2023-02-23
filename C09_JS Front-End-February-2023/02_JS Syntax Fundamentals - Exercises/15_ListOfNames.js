function solve(names){
    names = names
        .sort((x, y) => x.toLowerCase().localeCompare(y.toLowerCase()))
        .map((name, index) => `${++index}.${name}`);

    console.log(names.join('\t\n'));
}