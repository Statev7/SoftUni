function playlist(data){
    class Song {
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const songs = [];

    const songsCount = Number(data.shift());
    const typeList = data.pop();

    for(let index = 0; index < songsCount; index++){
        const tokens = data[index].split('_');

        let type, name, time;
        [type, name, time] = tokens;

        songs.push(new Song(type, name, time));
    }

    let filtredSongs = songs;
    if(typeList !== 'all'){
        filtredSongs = songs.filter(s => s.typeList === typeList)
    }

    filtredSongs.forEach(s => console.log(s.name));
}