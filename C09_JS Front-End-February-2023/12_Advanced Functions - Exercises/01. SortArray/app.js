function solve(data, sortType){
    let sortedArray = [];
    const sortCommander = {
        asc: () => ( sortedArray = data.sort((a, b) => a - b)),
        desc: () => ( sortedArray = data.sort((a, b) => b - a)),
    }

    sortCommander[sortType]();
    return sortedArray;
}