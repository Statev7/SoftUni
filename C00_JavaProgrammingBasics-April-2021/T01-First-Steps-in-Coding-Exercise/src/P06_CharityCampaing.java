import java.util.Scanner;

public class P06_CharityCampaing {
    public static void main(String[] args) {

        final int CAKE_PRICE = 45;
        final double WAFFLE_PRICE = 5.80;
        final double PANCAKES_PRICE = 3.20;

        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        int confectioners = Integer.parseInt(scanner.nextLine());
        int numbersOfCakes = Integer.parseInt(scanner.nextLine());
        int numbersOfWaffles = Integer.parseInt(scanner.nextLine());
        int numbersOfPancakes = Integer.parseInt(scanner.nextLine());

        double cakesSum = numbersOfCakes * CAKE_PRICE;
        double wafflesSum = numbersOfWaffles * WAFFLE_PRICE;
        double pancakesSum = numbersOfPancakes * PANCAKES_PRICE;

        double sumPerOneDay = (cakesSum + wafflesSum + pancakesSum) * confectioners;
        double sum = sumPerOneDay * days;

        double result = sum - (sum * 1/8);

        System.out.printf("%.2f", result);

    }
}
