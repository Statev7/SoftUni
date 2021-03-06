import java.util.Scanner;

public class P03_DepositCalculator {
    public static void main(String[] args) {

        final int NUMBER_OF_MONTHS = 12;

        Scanner scanner = new Scanner(System.in);

        Double depositAmount = Double.parseDouble(scanner.nextLine());
        int month = Integer.parseInt(scanner.nextLine());
        double interest = Double.parseDouble(scanner.nextLine());


        Double accruedInterest = depositAmount * (interest / 100 );
        Double interestPerMonth = accruedInterest / NUMBER_OF_MONTHS;

        Double finalResult = depositAmount + (month * interestPerMonth);

        System.out.print(finalResult);

    }
}
