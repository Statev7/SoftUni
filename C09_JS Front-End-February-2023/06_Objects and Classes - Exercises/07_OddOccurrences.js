function solve(text){
    const words = text.split(' ');
    const dictionary = {};

    for(let index = 0; index < words.length; index++){
        const currentWord = words[index].toLowerCase();

        if(dictionary[currentWord] == undefined){
            dictionary[currentWord] = 0;
        }

        dictionary[currentWord]++;
    }

    let sortable = [];
    for (const key in dictionary) {
        sortable.push([key, dictionary[key]]);
    }

    sortable = sortable
        .sort((a, b) => b[1] - a[1])
        .filter(e => e[1] % 2 !== 0);

    let result = '';
    for(let i = 0; i < sortable.length; i++){
        const currentObj = sortable[i];
        result += `${currentObj[0]} `;
    }
    
    console.log(result);
}
