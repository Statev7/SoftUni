function solve(request){
    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const validVerions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const uriPattern =  /^(\*|[a-zA-Z\d\.]+)$/gim;
    const messagePattern =  /^[^<>\\&'"]*$/gim;

    validateHttpMethod();
    validateURI();
    validateVersion();
    validateMessage();

    function validateHttpMethod(){
        if(!request.hasOwnProperty('method') || !validMethods.some(x => x === request.method)){
            throw new Error('Invalid request header: Invalid Method');
        }
    }

    function validateURI(){
        if(!request.hasOwnProperty('uri') || !uriPattern.test(request.uri)){
            throw new Error('Invalid request header: Invalid URI');
        }
    }

    function validateVersion(){
        if(!request.hasOwnProperty('version') || !validVerions.some(x => x === request.version)){
            throw new Error('Invalid request header: Invalid Version');
        }
    }

    function validateMessage(){
        if(!request.hasOwnProperty('message') || !messagePattern.test(request.message)){
            throw new Error('Invalid request header: Invalid Message');
        }
    }

    return request;
}

solve(
    {
        'method': 'GET',
        'version': 'HTTP/0.9',
        'uri': '%dsa%',
        'message': 'dsa'
    }
);