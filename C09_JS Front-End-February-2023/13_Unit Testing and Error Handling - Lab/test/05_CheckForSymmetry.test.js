const expect = require('chai').expect;
const {isSymmetric} = require('../05_CheckForSymmetry');

describe('Symmetric func', () => {

    it('Func should return false if input is not an array', () => {
        const strInput = 'Hello';
        const booleanInput = true;
        const numberInput = 5;

        expect(isSymmetric(strInput)).to.be.false;
        expect(isSymmetric(booleanInput)).to.be.false;
        expect(isSymmetric(numberInput)).to.be.false;
    })

    
    it('Func should return false if the passed array is not a symmetric', () => {
        const arr = [1, 2, 3, 2, 1, 7];

        const result = isSymmetric(arr);

        expect(result).to.be.false;
    })

    it('Func should return true if the passed array is symmetric', () => {
        const arr = [1, 2, 3, 2, 1];

        const result = isSymmetric(arr);

        expect(result).to.be.true;
    })

    it('Func should return false if the passed array is mixed', () => {
        const arr = [1, 2, 2, '1'];

        const result = isSymmetric(arr);

        expect(result).to.be.false;
    })

    
    it('Func should return true if the passed empty array', () => {
        const arr = [];

        const result = isSymmetric(arr);

        expect(result).to.be.true;
    })
})