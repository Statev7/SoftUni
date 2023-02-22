function printPriceOfATicket(typeOfDay, ageOfPerson){

    let resultMessage = 'Error!';

    let ticketPriceForChild = {'Weekday': '12$', 'Weekend': '15$', 'Holiday': '5$'};
    let ticketPriceForMiddleAged = {'Weekday': '18$', 'Weekend': '20$', 'Holiday': '12$'};
    let ticketPriceForPensioners = {'Weekday': '12$', 'Weekend': '15$', 'Holiday': '10$'};

    if(ageOfPerson >= 0 && ageOfPerson <= 18){

        resultMessage = ticketPriceForChild[typeOfDay];

    } else if (ageOfPerson > 18 && ageOfPerson <= 64){

        resultMessage = ticketPriceForMiddleAged[typeOfDay];

    } else if (ageOfPerson > 64 && ageOfPerson <= 122){

        resultMessage = ticketPriceForPensioners[typeOfDay];
    }

    console.log(resultMessage);
}