function calculator() {
    return {
        firstElement: {},
        secondElement: {},
        resultElement: {},
        init: function (selector1, selector2, resultSelector){
            this.firstElement = document.querySelector(selector1);
            this.secondElement = document.querySelector(selector2);
            this.resultElement = document.querySelector(resultSelector);
        },
        add: function () {
            this.resultElement.value = Number(this.firstElement.value) + Number(this.secondElement.value);
        },
        subtract: function () {
            this.resultElement.value = Number(this.firstElement.value) - Number(this.secondElement.value);
        }
    }
}