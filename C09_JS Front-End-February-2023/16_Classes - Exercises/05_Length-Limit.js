class Stringer {
    constructor(innerString, innerLength){
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    decrease(value){
        this.innerLength -= value;

        if(this.innerLength < 0){
            this.innerLength = 0;
        }
    }

    increase(value){
        this.innerLength += value;
    }

    toString(){
        if (this.innerLength < this.innerString.length) {
            return this.innerString.substring(0, this.innerLength) + '...';
          } else {
            return this.innerString;
          }
    }
}