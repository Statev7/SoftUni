import java.util.Scanner;

public class P08_FishTank {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int length = Integer.parseInt(scanner.nextLine());
        int width = Integer.parseInt(scanner.nextLine());
        int height = Integer.parseInt(scanner.nextLine());
        double procent = Double.parseDouble(scanner.nextLine());

        int  capacity = length * width * height;
        double liters = capacity * 0.001;
        double procentResult = procent * 0.01;

        double result = liters * (1-procentResult);

        System.out.printf("%.2f", result);

    }
}
