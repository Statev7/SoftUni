function factory(firstName, lastName, age){
    return {
        firstName,
        lastName,
        age: Number(age)
    }
}