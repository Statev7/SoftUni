function solve(...nums){
    let result = 'Negative';

    let negativeNums = nums.filter(x => x < 0);
    if(negativeNums.length % 2 == 0){
        result = 'Positive';
    }

    console.log(result);
}