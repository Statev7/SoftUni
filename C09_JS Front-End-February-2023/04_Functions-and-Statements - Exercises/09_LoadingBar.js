function loadingBar(number){
    let result = '100% Complete!\n[%%%%%%%%%%]';
    let loadingBar = '[..........]';
    
    let symbolsForLoadbar = number / 10;

    for(let i = 0; i < symbolsForLoadbar; i++){
        loadingBar = loadingBar.replace('.', '%');
    }

    if(symbolsForLoadbar < 10){
        result = `${number}% ${loadingBar}\nStill loading...`;
    }

    console.log(result);
}