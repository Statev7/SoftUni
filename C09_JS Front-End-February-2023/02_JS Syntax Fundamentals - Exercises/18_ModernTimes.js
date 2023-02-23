function solve(text){
   const regex = '\#[a-zA-Z]+';

    let array = [...text.matchAll(regex)];

    result = array.map((arr) => arr[0].substring(1));

    console.log(result.join('\n'));
}