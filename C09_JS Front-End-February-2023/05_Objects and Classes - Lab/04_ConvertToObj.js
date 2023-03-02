function converToObj(objAsJson){
    const object = JSON.parse(objAsJson);

    for (const key in object) {
        console.log(`${key}: ${object[key]}`)
    }
}