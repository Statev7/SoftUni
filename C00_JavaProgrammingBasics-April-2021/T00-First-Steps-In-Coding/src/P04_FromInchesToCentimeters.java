import java.util.Scanner;

public class P04_FromInchesToCentimeters {
    public static void main(String[] args) {

        final double inch = 2.54;

        Scanner scanner = new Scanner(System.in);

        double centimeters = Double.parseDouble(scanner.nextLine());

        double inches = centimeters * inch;

        System.out.print(inches);
    }
}
