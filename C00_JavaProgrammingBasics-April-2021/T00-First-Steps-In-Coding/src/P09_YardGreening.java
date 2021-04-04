import java.util.Scanner;

public class P09_YardGreening {
    public static void main(String[] args) {

        final double pricePerOneSquareMeters = 7.61;

        Scanner scanner = new Scanner(System.in);

        double squareMeters = Double.parseDouble(scanner.nextLine());

        double sum = squareMeters * pricePerOneSquareMeters;
        double discount = sum * 0.18;

        sum -= discount;

        System.out.printf("The final price is: %.2f lv.", sum);
        System.out.printf("\nThe discount is: %.2f lv.", discount);
    }
}
