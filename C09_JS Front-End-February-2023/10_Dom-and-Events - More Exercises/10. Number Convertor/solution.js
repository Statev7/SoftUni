function solve() {
    const selelectElement = document.getElementById('selectMenuTo');
    const resultElement = document.getElementById('result');

    addValuesToSelect();

    document.getElementsByTagName('button')[0].addEventListener('click', () => {
        let number = Number(document.getElementById('input').value);
        const covertFormat = selelectElement.value;

        covertFormat === 'binary' ? covertToBinary(number) : convertToHexa(number);
    });

    function addValuesToSelect(){
        const optionsAsObj = {'Binary': 'binary', 'Hexadecimal': 'hexadecimal'};
        
        for (const [key, value] of Object.entries(optionsAsObj)) {
            const option = document.createElement('option');
            option.textContent = key;
            option.value = value;
            selelectElement.appendChild(option);
        }
    }

    function covertToBinary(number){
        resultElement.value = (number >>> 0).toString(2);
    }

    function convertToHexa(number){
        resultElement.value = number.toString(16).toUpperCase();
    }
}