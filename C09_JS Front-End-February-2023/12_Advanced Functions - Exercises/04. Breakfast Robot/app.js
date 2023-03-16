function solve(){
    const ingredients = { 'protein': 0, 'carbohydrate': 0, 'fat': 0, 'flavour': 0}
    const mealsRecipe = {
        'apple': {'carbohydrate': 1, 'flavour': 2},
        'lemonade': {'carbohydrate': 10, 'flavour': 20},
        'burger': {'carbohydrate': 5, 'fat': 7, 'flavour': 3},
        'eggs': {'protein': 5, 'fat': 1, 'flavour': 1},
        'turkey': {'protein': 10, 'carbohydrate': 10, 'fat': 10, 'flavour': 10},
    }

    return function logic(input){
        const commander = {
            'restock': function (microElement, quantity){
                ingredients[microElement] += quantity;
                return 'Success';
            },
            'prepare': function (recipe, quantity){
                const ingredientsForRecipe = Object.entries(mealsRecipe[recipe]);

                for (const [key, value] of ingredientsForRecipe) {
                    const neededQuantity = value * quantity;
                    if(ingredients[key] < neededQuantity){
                        return `Error: not enough ${key} in stock`;
                    }
                }

                ingredientsForRecipe.forEach(x => {
                    const microElement = x[0];
                    const quantityToRemove = x[1] * quantity;

                    ingredients[microElement] -= quantityToRemove;
                });

                return 'Success';
            },
            'report': () => {
                let result = '';
                for (const key of Object.keys(ingredients)) {
                    result += `${key}=${ingredients[key]} `
                }

                return result.trim();
            },
        }
    
        let command, name, quantity;
        [command, name, quantity] = input.split(' ');

        const result = commander[command](name, Number(quantity));
        return result;
    }
}