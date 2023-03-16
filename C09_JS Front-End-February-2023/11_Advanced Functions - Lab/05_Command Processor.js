function solution(){
    let message = '';

    return {
        append: (text) => message += text,
        removeStart: (n) => message = message.substring(n),
        removeEnd: (n) => message = message.substring(0, message.length - n),
        print: () => console.log(message),
    };
}