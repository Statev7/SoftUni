function solve(data){
    const addressBook = {};

    for(let index = 0; index < data.length; index++){
        let line = data[index];

        const tokens = line.split(':');
        const personName = tokens[0];
        const address = tokens[1];

        if(addressBook[personName] == undefined){
            addressBook[personName] = '';
        }

        addressBook[personName] = address;
    }

    const ordered = Object.keys(addressBook).sort().reduce(
        (obj, key) => { 
          obj[key] = addressBook[key]; 
          return obj;
        }, 
        {}
      );

    for (const key in ordered) {
        console.log(`${key} -> ${addressBook[key]}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);