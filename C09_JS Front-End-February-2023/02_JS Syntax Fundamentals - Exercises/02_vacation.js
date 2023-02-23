function solve(groupCount, groupType, dayOfWeek){

    const studentGroupPercentageDiscount = 0.15;
    const businessGroupDiscout = 10;
    const regularGroupPercentageDiscount = 0.05;

    let price;

    let pricesForStudent = { 'Friday': 8.45, 'Saturday': 9.80, 'Sunday': 10.46 };
    let pricesForBusines = { 'Friday': 10.90, 'Saturday': 15.60, 'Sunday': 16 };
    let pricesForRegular = { 'Friday': 15, 'Saturday': 20, 'Sunday': 22.50 };

    if(groupType === 'Students') {
        price = groupCount * pricesForStudent[dayOfWeek];

        if(groupCount >= 30) {
            price -= price * studentGroupPercentageDiscount;
        }
    } else if (groupType === 'Business') {
        price = groupCount * pricesForBusines[dayOfWeek];

        if(groupCount >= 100){
            price -= pricesForBusines[dayOfWeek] * businessGroupDiscout;
        }
    } else if (groupType === 'Regular') {
        price = groupCount * pricesForRegular[dayOfWeek];

        if(groupCount >= 10 && groupCount <= 20){
            price -= price * regularGroupPercentageDiscount;
        }
    }

    console.log(`Total price: ${price.toFixed(2)}`);
}

solve(30,
    "Students",
    "Sunday"
    );

solve(40,
    "Regular",
    "Saturday"
    );