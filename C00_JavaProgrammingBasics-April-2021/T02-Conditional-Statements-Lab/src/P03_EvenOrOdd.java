import java.util.Scanner;

public class P03_EvenOrOdd {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int digit = Integer.parseInt(scanner.nextLine());
        String result = "odd";

        if (digit % 2 == 0)
        {
            result = "even";
        }

        System.out.print(result);
    }
}
