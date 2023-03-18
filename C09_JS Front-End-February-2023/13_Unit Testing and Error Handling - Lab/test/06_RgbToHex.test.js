const expect = require('chai').expect;
const {rgbToHexColor} = require('../06_RgbToHex');

describe('Rgb to hex func', () => {

    it('If passed values is valid, func should return a correct result', () => {
        const red = 10;
        const green = 10;
        const blue = 10;

        const result = rgbToHexColor(red, green, blue);

        expect(result).to.be.equal('#0A0A0A');
    })

    it('If some of the passed values are not an integer, func should return undefined', () => {
        const red = 'Test';
        const green = 10;
        const blue = 10;

        const result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    })

    it('If some of the passed values are bellow zero, func should return undefined', () => {
        const red =  -1;
        const green = 10;
        const blue = 10;

        const result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    })

    
    it('If some of the passed values are bigger than 255, func should return undefined', () => {
        const red =  256;
        const green = 10;
        const blue = 10;

        const result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    })

    it('If some of the passed values are equals to 0 or 255, func should return correct result', () => {
        const red =  0;
        const green = 10;
        const blue = 255;

        const result = rgbToHexColor(red, green, blue);

        expect(result).to.be.equal('#000AFF');
    })

    it('should return undefined for if a number is a fraction', () => {
        expect(rgbToHexColor(7.77, 0, 0)).to.be.equal(undefined);
        expect(rgbToHexColor(0, 7.77, 0)).to.be.equal(undefined);
        expect(rgbToHexColor(0, 0, 7.77)).to.be.equal(undefined);
    });
});