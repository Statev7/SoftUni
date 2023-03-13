function extract(content) {
    const contentElement = document.getElementById(content);

    const regex = /\(([A-z\s]+)\)/g;
    let result = contentElement.innerText.match(regex);
    result = result.map(e => {
        e = e.replace('(', '');
        e = e.replace(')', '');

        return e;
    });

   return result.join('; ');
}