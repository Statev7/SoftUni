function convertToJson(name, lastName, hairColor){
    const person = {
        name,
        lastName,
        hairColor
    };

    const objAsJson = JSON.stringify(person);
    console.log(objAsJson);
}