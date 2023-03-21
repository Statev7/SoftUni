class Circle{
    constructor(radius){
        this.radius = Number(radius);
    }

    get diameter(){
        return this.radius * 2;
    }

    set diameter(value){
        this.radius = value / 2;
    }

    get area() {
        return Math.PI * Math.pow(this.radius, 2);
    }
}