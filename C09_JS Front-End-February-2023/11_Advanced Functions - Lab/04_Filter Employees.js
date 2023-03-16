function solve(dataAsJson, filterInput){
    let data = JSON.parse(dataAsJson);

    let filterType, filterValue;
    [filterType, filterValue] = filterInput.split('-');

    if(filterValue !== 'all'){
        data = data
            .filter(x => predicate(x))
            .map((x, i) => `${i}. ${x.first_name + ' ' + x.last_name} - ${x.email}`);
    }

    console.log(data.join('\n'));

    function predicate(object){
        return object[filterType] === filterValue;
    }
}