import java.util.Scanner;

public class P05_GreetingByName {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();

        System.out.print("Hello, " + name + "!");
    }
}
