function encodeAndDecodeMessages() {
    document.getElementsByTagName('button')[0].addEventListener('click', encode);
    document.getElementsByTagName('button')[1].addEventListener('click', decode);
    const textAreas = document.getElementsByTagName('textarea');

    function encode(){
        const encodeElement = textAreas[0];
        const messageToEncode = encodeElement.value;
        
        encodeElement.value = '';
        textAreas[1].value = convert(messageToEncode, '+');
    }

    function decode(){
        const decodeElement = textAreas[1];
        const messageToDecode = decodeElement.value;

        decodeElement.value = convert(messageToDecode, '-');
    }

    function convert(message, convertType){
        let result = '';
        for(let index = 0; index < message.length; index++){
            const ascii = eval(`${message.charCodeAt(index)} ${convertType} 1`);
            result += String.fromCharCode(ascii);
        };

        return result;
    }
}