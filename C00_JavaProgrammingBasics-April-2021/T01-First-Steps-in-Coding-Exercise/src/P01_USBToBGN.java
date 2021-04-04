import java.util.Scanner;

public class P01_USBToBGN {
    public static void main(String[] args) {

        final double oneUsdToBgn = 1.79549;

        Scanner scanner = new Scanner(System.in);

        double bgn = Double.parseDouble(scanner.nextLine());

        double result = bgn * oneUsdToBgn;

        System.out.print(result);
    }
}
