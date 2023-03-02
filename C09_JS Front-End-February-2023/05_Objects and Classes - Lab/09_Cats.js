function solve(data){
    class Cat {
        constructor(name, age){
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    const cats = [];

    for(let index = 0; index < data.length; index++){
        const tokens = data[index].split(' ');

        let name, age;
        [name, age] = [tokens[0], tokens[1]];

        cats.push(new Cat(name, age));
    }

    for (const cat of cats) {
        cat.meow();
    }
}