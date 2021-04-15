import java.util.Scanner;

public class P05_PasswordGuess {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String password = scanner.nextLine();
        String result = "Wrong password!";

        if (password.equals("s3cr3t!P@ssw0rd"))
        {
            result = "Welcome";
        }

        System.out.print(result);

    }
}
