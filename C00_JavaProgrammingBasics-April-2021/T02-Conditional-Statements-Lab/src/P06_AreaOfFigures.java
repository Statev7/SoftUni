import java.util.Scanner;

public class P06_AreaOfFigures {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String figyres = scanner.nextLine();
        double sum = 0;
        double firstParameter = 0;
        double secondParameter = 0;

        if (figyres.equals("square"))
        {
            firstParameter = Double.parseDouble(scanner.nextLine());
            sum = firstParameter * firstParameter;
        }
        else if(figyres.equals("rectangle"))
        {
            firstParameter = Double.parseDouble(scanner.nextLine());
            secondParameter = Double.parseDouble(scanner.nextLine());
            sum = firstParameter * secondParameter;
        }
        else if(figyres.equals("circle"))
        {
            firstParameter = Double.parseDouble(scanner.nextLine());
            sum = Math.PI * Math.pow(firstParameter, 2);
        }
        else {
            firstParameter = Double.parseDouble(scanner.nextLine());
            secondParameter = Double.parseDouble(scanner.nextLine());
            sum = (firstParameter * secondParameter) / 2;
        }

        System.out.printf("%.3f", sum);
    }
}
