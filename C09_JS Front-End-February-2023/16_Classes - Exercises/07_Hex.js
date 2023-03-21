class Hex {
    #value;

    constructor(value){
        this.#value = value;
    }

    valueOf () {
        return this.#value;
    }

    toString () {
        return `0x${this.#value.toString(16).toLocaleUpperCase()}`;
    }

    plus(number) {
        if(typeof number === Number){
            return new Hex(this.#value + number);
        } else {
            return new Hex(this.#value + number.valueOf());
        }
    }

    minus(number) {
        if(typeof number === Number){
            return new Hex(this.#value - number);
        } else {
            return new Hex(this.#value - number.valueOf());
        }
    }

    parse(string) {
        return parseInt(string, 16);
    }
}