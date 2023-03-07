function colorize() {
    const evenRows = document.querySelectorAll('table tr:nth-child(even)');
    
    for (const tr of evenRows) {
        tr.style.backgroundColor = 'Teal';
    }
}