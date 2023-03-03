function solve(data){
    class Hero{
        constructor(name, level, items){
            this.name = name;
            this.level = level;
            this.items = items;
        }
        information(){
            return `Hero: ${this.name} \nlevel => ${this.level} \nitems => ${this.items}`;
        }
    }

    const heros = [];

    for(let index = 0; index < data.length; index++){
        let line = data[index];
        const tokens = line.split(' / ');
        
        let heroName, level, items;
        [heroName, level, items] = tokens;

        heros.push(new Hero(heroName, Number(level), items));
    }
    
    heros
    .sort((a, b) => (a.level > b.level) ? 1 : -1)
    .forEach(h => console.log(h.information()));
}

solve([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    );