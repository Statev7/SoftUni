import java.util.Scanner;

public class P07_ToyShop {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double puzzle = 2.60;
        double doll = 3;
        double bear = 4.10;
        double minion = 8.20;
        double truck = 2;

        double excursion = Double.parseDouble(scanner.nextLine());
        int numberOfPuzzles = Integer.parseInt(scanner.nextLine());
        int numberOfDoll = Integer.parseInt(scanner.nextLine());
        int numberOfBear = Integer.parseInt(scanner.nextLine());
        int numberOfMinion = Integer.parseInt(scanner.nextLine());
        int numberOfTruck = Integer.parseInt(scanner.nextLine());

        double sumOfPuzzles = numberOfPuzzles * puzzle;
        double sumOfDoll = numberOfDoll * doll;
        double sumOfBear = numberOfBear * bear;
        double sumOfMinion = numberOfMinion * minion;
        double sumOfTruck = numberOfTruck * truck;

        int numberOfToys = numberOfPuzzles + numberOfDoll + numberOfBear + numberOfMinion + numberOfTruck;
        double sum = sumOfPuzzles + sumOfDoll + sumOfBear + sumOfMinion + sumOfTruck;

        if (numberOfToys >= 50)
        {
            sum -= sum * 0.25;
        }

        sum -= (sum * 0.10) + excursion;

        if(sum >= excursion){
            System.out.printf("Yes! %.2f lv left.", sum);
        }
        else{
            System.out.printf("Not enough money! %.2f lv needed.", Math.abs(sum));
        }


    }
}
