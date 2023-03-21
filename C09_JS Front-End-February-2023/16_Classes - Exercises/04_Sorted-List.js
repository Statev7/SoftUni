class List {
    #data;

    constructor(){
        this.#data = [];
        this.size = 0;
    }

    add(value){
        this.#data.push(value);
        this.sortData();
        this.size++;
    }

    remove(index){
        this.validateIndexs(index);
        this.#data.splice(index, 1);
        this.sortData();
        this.size--;
    }

    get(index){
        this.validateIndexs(index);
        return this.#data[index];
    }

    sortData(){
        this.#data = this.#data.sort((a, b) => a - b);
    }

    validateIndexs(index){
        if(index < 0 || index >= this.#data.length){
            throw new Error('Index out of range!');
        }
    }
}

let list = new List();

console.log(list.hasOwnProperty('size'))