function createCard(face, suit){
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const validSuits = ['S', 'H', 'D', 'C'];

    if(!validFaces.some(x => x === face)){
        throw new Error('Error');
    }

    if(!validSuits.some(x => x === suit)){
        throw new Error('Error');
    }
    
    const suits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    const card = {
        face,
        suit,
        toString (){
            return this.face + suits[this.suit];
        }
    }

    return card.toString();
}