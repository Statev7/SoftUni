import java.util.Scanner;

public class P08_PetShop {
    public static void main(String[] args) {

        final double priceForDogFood = 2.5;
        final int priceForOtherFood = 4;

        Scanner scanner = new Scanner(System.in);

        int numberOfDogs = Integer.parseInt(scanner.nextLine());
        int numberOfOtherAnimals = Integer.parseInt(scanner.nextLine());

        double dogsFoodSum = numberOfDogs * priceForDogFood;
        double otherAnimalsFoodSum = numberOfOtherAnimals * priceForOtherFood;

        double result = dogsFoodSum + otherAnimalsFoodSum;

        System.out.printf("%.1f lv.", result);
    }
}
