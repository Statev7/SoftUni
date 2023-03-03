// function solve(data){
//     class employee{
//         constructor(name){
//             this.name = name;
//             this.personalNumber = name.length;
//         }

//         information(){
//             return `Name: ${this.name} -- Personal Number: ${this.personalNumber}`;
//         }
//     }

//     const employees = [];

//     for(let index = 0; index < data.length; index++){
//         const name = data[index];
//         employees.push(new employee(name));
//     }

//     employees.forEach(e => console.log(e.information()));
// }

function solve(input){
    const data = {};

    for(let index = 0; index < input.length; index++){
        const name = input[index];
        data[name] = name.length;
    }

    for (const key in data) {
        console.log(`Name: ${key} -- Personal Number: ${data[key]}`)
    }
}