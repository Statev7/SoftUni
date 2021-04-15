import java.util.Scanner;

public class P04_NumberFrom100To200 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int digit = Integer.parseInt(scanner.nextLine());
        String result = "Greater than 200";

        if (digit < 100)
        {
            result = "Less than 100";
        }
        else if(digit >= 100 && digit <= 200)
        {
            result = "Between 100 and 200";
        }

        System.out.print(result);
    }
}
