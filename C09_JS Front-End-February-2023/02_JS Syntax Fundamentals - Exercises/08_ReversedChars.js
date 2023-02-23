function reverse(a, b, c){
    let str = `${a} ${b} ${c}`;
    let reversedStr = str.split(' ').reverse();

    console.log(reversedStr.join(' '));
}
