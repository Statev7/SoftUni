function solve(areaFunc, vol, input) {
    return result = JSON.parse(input)
        .reduce((array, currentObject) => {
            array.push(obj = {
                area: areaFunc.call(currentObject),
                volume: vol.call(currentObject),
            });
            return array;
        }, [])
}

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};