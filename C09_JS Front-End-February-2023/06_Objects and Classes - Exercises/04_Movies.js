function solve(input){

    const addMovieCommand = 'addMovie';
    const directorCommand = 'directedBy';
    const dateCommand = 'onDate';

    const movies = [];

    for(let index = 0; index < input.length; index++){
        let line = input[index];

        if(line.includes(addMovieCommand)){
            const index = line.indexOf(' ');
            const movieName = line.substring(index + 1, line.length);

            const movie = {
                name: movieName
            }
            movies.push(movie);
        } else if(line.includes(directorCommand)){
            const indexOfCommand = line.indexOf(directorCommand);
            const movieName = line.substring(0, indexOfCommand - 1);

            const movie = getMovie(movieName);
            if(movie !== undefined){
                const startIndex = indexOfCommand + directorCommand.length + 1;
                const director = line.substring(startIndex, line.length);
                
                movie.director = director;
            }
        } else if(line.includes(dateCommand)){
            const indexOfCommand = line.indexOf(dateCommand);
            const movieName = line.substring(0, indexOfCommand - 1);

            const movie = getMovie(movieName);
            if(movie !== undefined){
                const startIndex = indexOfCommand + dateCommand.length + 1;
                const date = line.substring(startIndex, line.length);
                
                movie.date = date;
            }
        }
    }

    movies
    .filter(x => x.name !== undefined && x.director !== undefined && x.date !== undefined)
    .forEach(x => console.log(JSON.stringify(x)));

    function getMovie(movieName){
        return movies.find(m => m.name === movieName);
    }
}

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]
    
    );