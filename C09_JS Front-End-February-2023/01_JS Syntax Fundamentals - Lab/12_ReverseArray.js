function solve(n, array){

    let result = [];

    for (let index = 0; index < n; index++) {
        result[index] = array[index];
    }

    result.reverse();

    console.log(result.join(' '));
}
