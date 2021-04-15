import java.util.Scanner;

public class P02_GreaterNumber {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int firstNumber = Integer.parseInt(scanner.nextLine());
        int secondNumber = Integer.parseInt(scanner.nextLine());

        int biggestNumber = firstNumber;

        if (secondNumber > firstNumber){
            biggestNumber = secondNumber;
        }

        System.out.print(biggestNumber);

    }
}
