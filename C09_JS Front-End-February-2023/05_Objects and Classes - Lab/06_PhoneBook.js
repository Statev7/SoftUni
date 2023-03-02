function solve(phoneBook){

    const result = {};

    for (const index in phoneBook) {
        let line = phoneBook[index];

        const tokens = line.split(' ');
        const name = tokens[0];
        const phone = tokens[1];

        if(result[name] == undefined){
            result[name] = '';
        }

        result[name] = phone;
    }

    for (const key in result) {
        console.log(`${key} -> ${result[key]}`);
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);