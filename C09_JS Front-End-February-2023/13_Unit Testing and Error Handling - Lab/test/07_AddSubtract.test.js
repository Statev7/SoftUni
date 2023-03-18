const expect = require('chai').expect;
const {createCalculator} = require('../07_AddSubtract');

describe('createCalculator function', () => {

    it('Fuction need to return a object', () => {
        const object = createCalculator();

        expect(typeof object).to.be.equal(typeof {});
    })

    it('Add property with parameter of type Number should increase the value', () => {
        const obj = createCalculator();

        obj.add(5);
        const result = obj.get();

        expect(result).to.be.equal(5);
    })

    it('Add property with parameter of type String should increase the value', () => {
        const obj = createCalculator();

        obj.add('5');
        const result = obj.get();

        expect(result).to.be.equal(5);
    })

    it('Subtract property with parameter of type Number should decrease the value', () => {
        const obj = createCalculator();

        obj.subtract(5);
        const result = obj.get();

        expect(result).to.be.equal(-5);
    })

    it('Subtract property with parameter of type String should decrease the value', () => {
        const obj = createCalculator();

        obj.subtract('5');
        const result = obj.get();

        expect(result).to.be.equal(-5);
    })

    it('Get should return the value', () => {
        const obj = createCalculator();

        const result = obj.get();
        expect(result).to.be.equal(0);
    })

})