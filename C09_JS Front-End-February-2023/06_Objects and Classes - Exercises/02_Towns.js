function solve(data){
    const obj = {};
    
    for(let index = 0; index < data.length; index++){
        let name, latitude, longitude;
        [name, latitude, longitude] = data[index].split(' | ');

        obj['town'] = name;
        obj['latitude'] = Number(latitude).toFixed(2);
        obj['longitude'] = Number(longitude).toFixed(2);

        console.log(obj);
    }
}