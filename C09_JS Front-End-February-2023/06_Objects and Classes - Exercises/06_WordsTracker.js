function solve(text){
    const result = {};

    const words = text.shift().split(' ');

    for (let i = 0; i < words.length; i++) {
        const currentWord = words[i];

        const count = countMatches(text, currentWord);
        result[currentWord] = count;
    }

    const sorted = Object.fromEntries(
        Object.entries(result).sort(([, a], [, b]) => b - a)
    )

    for (const key in sorted) {
        console.log(`${key} - ${sorted[key]}`);
    }

    function countMatches(text, word){
        return text.filter(e => e === word).length;
    }
}

solve([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    
    );