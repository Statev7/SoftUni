const expect = require('chai').expect;
const {isOddOrEven} = require('./02_EvenOrOdd/evenOrOdd');
const {lookupChar} = require('./03.LookupChar/LookupChar');
const {mathEnforcer} = require('./04.MathEnforcer/MathEnforces');

describe('Even or Odd', () => {

    it('The function should return undefined if the passed input is not a string', () => {
        expect(isOddOrEven(true)).to.be.undefined;
        expect(isOddOrEven(1)).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
    })

    it('The function should return correct result if the passed input has an even length', () => {
        expect(isOddOrEven('Test')).to.be.equal('even');
    })

    it('The function should return correct result if the passed input has an odd length', () => {
        expect(isOddOrEven('Test1')).to.be.equal('odd');
    })

    it('The function should return correct result if the passed input is empty', () => {
        expect(isOddOrEven('')).to.be.equal('even');
    })
});

describe('LookupChar function', () => {

    it('The function should return undefined if the passed inputs are not of the correct type', () => {
        expect(lookupChar(true, 1)).to.be.undefined;
        expect(lookupChar('str', true)).to.be.undefined;
        expect(lookupChar(true, true)).to.be.undefined;
        expect(lookupChar('str', 1.5)).to.be.undefined;
    })

    it('The function should return an error message if an index is bigger or equals to the string length', () => {
        expect(lookupChar('Str', 3)).to.be.equal('Incorrect index')
        expect(lookupChar('Str', 4)).to.be.equal('Incorrect index')
    })

    it('The function should return an error message if an index is bellow zero', () => {
        expect(lookupChar('Str', -1)).to.be.equal('Incorrect index')
    })

    it('The function should return correct result if passed inputs are valid', () => {
        expect(lookupChar('Test', 0)).to.be.equal('T');
        expect(lookupChar('Test', 1)).to.be.equal('e');
    })
})

describe ('MathEnforcer function', () => {

    it('The addFive function, should return undefined if the passed input is not a number', () => {
        expect(mathEnforcer.addFive('Test')).to.be.undefined;
        expect(mathEnforcer.addFive(true)).to.be.undefined;
        expect(mathEnforcer.addFive({})).to.be.undefined;
    })

    it('The addFive function, should increase the passed value with 5', () => {
        expect(mathEnforcer.addFive(5)).to.be.equal(10);
        expect(mathEnforcer.addFive(0)).to.be.equal(5);
        expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        expect(mathEnforcer.addFive(1.5)).to.be.equal(6.5);
    })

    it('The subtractTen function, should return undefined if the passed input is not a number', () => {
        expect(mathEnforcer.subtractTen('Test')).to.be.undefined;
        expect(mathEnforcer.subtractTen(true)).to.be.undefined;
        expect(mathEnforcer.subtractTen({})).to.be.undefined;
    })

    it('The subtractTen function, should decresse the passed value with 10', () => {
        expect(mathEnforcer.subtractTen(10)).to.be.equal(0);
        expect(mathEnforcer.subtractTen(0)).to.be.equal(-10);
        expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
        expect(mathEnforcer.subtractTen(10.5)).to.be.equal(0.5);
    })

    it('The sum function, should return undefined if any of the passed inputs are not a number', () => {
        expect(mathEnforcer.sum('Test', 5)).to.be.undefined;
        expect(mathEnforcer.sum(5, true)).to.be.undefined;
        expect(mathEnforcer.sum(true, true)).to.be.undefined;
    })

    it('The sum function, should return correct result', () => {
        expect(mathEnforcer.sum(5, 5)).to.be.equal(10);
        expect(mathEnforcer.sum(0, 5)).to.be.equal(5);
        expect(mathEnforcer.sum(-5, 10)).to.be.equal(5);
        expect(mathEnforcer.sum(-15, 10)).to.be.equal(-5);
        expect(mathEnforcer.sum(1.5, 1.5)).to.be.equal(3);
    })
})