class Laptop{
    constructor(info, quality){
        this.info = info;
        this.isOn = false;
        this.quality = quality;
    }

    get price() {
        return (800 - (Number(this.info.age) * 2) + (Number(this.quality) * 0.5));
    }

    turnOn(){
        this.isOn = true;
        this.quality--;
    }

    turnOff(){
        this.isOn = false;
        this.quality--;
    }

    showInfo(){
        return JSON.stringify(this.info);
    }
}