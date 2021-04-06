import java.util.Scanner;

public class P01_USBToBGN {
    public static void main(String[] args) {

        final double USB_TO_BGN_VALUE = 1.79549;

        Scanner scanner = new Scanner(System.in);

        double bgn = Double.parseDouble(scanner.nextLine());

        double result = bgn * USB_TO_BGN_VALUE;

        System.out.print(result);
    }
}
