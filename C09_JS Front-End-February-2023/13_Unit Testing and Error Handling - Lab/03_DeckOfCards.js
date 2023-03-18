function solve(cards){
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const validSuits = ['S', 'H', 'D', 'C'];
    const suits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    const result = [];

    for (const card of cards) {
        const face = card.substring(0, card.length - 1);
        const suit = card.substring(card.length - 1);

        const isInvalidCard = !validFaces.includes(face) || !validSuits.includes(suit);
        if(isInvalidCard){
            console.log(`Invalid card: ${face}${suit}`);
            return;
        }

        result.push(`${face}${suits[suit]}`);
    }

    console.log(result.join(' '));
}