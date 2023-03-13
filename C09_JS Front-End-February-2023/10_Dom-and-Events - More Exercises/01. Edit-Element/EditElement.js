function editElement(element, match, replacer) {
    
    let indexOf = element.innerText.indexOf(match);

    while(indexOf !== -1){
        element.innerText = element.innerText.replace(match, replacer);
        indexOf = element.innerText.indexOf(match);
    }
}