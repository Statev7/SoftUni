function solve(nums){
    nums.forEach(element => {
        let elementAsString = element.toString();
        let reversedElement = elementAsString.split('').reverse().join('');
        let isPalindrome = elementAsString === reversedElement;
        console.log(isPalindrome);
    });
}