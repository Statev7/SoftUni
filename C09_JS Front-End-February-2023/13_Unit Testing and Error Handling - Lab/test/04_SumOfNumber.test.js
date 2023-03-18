const expect = require('chai').expect;
const {sum} = require('../04_SumOfNumber');

describe ('Sum func', () => {

    it('Should return a correct result if an array have only numbers', () => {
        const arr = [1, 2, 3];

        const result = sum(arr);

        expect(result).to.be.equal(result);
    })

    it('Should return a correct result if an array is mixed', () => {
        const arr = [1, true, '1'];

        const result = sum(arr);

        expect(result).to.be.equal(3);
    })
})