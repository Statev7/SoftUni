import java.util.Scanner;

public class P01_ExcellentResult {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());

        if (number >= 5){
            System.out.printf("Excellent!");
        }

    }
}
