import java.util.Scanner;

public class P07_FruitMarket {
    public static void main(String[] args) {

        final int PROCENT_PER_RASPBERRIES = 2;
        final double PROCENT_PER_ORANGES = 0.4;
        final  double PROCENT_PER_BANANAS = 0.8;

        Scanner scanner = new Scanner(System.in);

        double berriesPrice = Double.parseDouble(scanner.nextLine());
        double amountOfBananas = Double.parseDouble(scanner.nextLine());
        double amountOfOranges = Double.parseDouble(scanner.nextLine());
        double amountOfRaspberries  = Double.parseDouble(scanner.nextLine());
        double amountOfBerries  = Double.parseDouble(scanner.nextLine());

        double raspberriesPrice = berriesPrice / PROCENT_PER_RASPBERRIES;
        double orangesPrice = raspberriesPrice - (raspberriesPrice * PROCENT_PER_ORANGES);
        double bananasPrice = raspberriesPrice - (raspberriesPrice * PROCENT_PER_BANANAS);

        double berriesSum = berriesPrice * amountOfBerries;
        double bananasSum = amountOfBananas * bananasPrice;
        double orangesSum = amountOfOranges * orangesPrice;
        double respberriesSum = raspberriesPrice * amountOfRaspberries;

        double finalSum = berriesSum + bananasSum + orangesSum + respberriesSum;

        System.out.printf("%.2f", finalSum);
    }
}
