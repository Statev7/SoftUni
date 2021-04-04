import java.util.Scanner;

public class P04_VacationBookList {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int numberOfStations = Integer.parseInt(scanner.nextLine());
        int stationsPerHour = Integer.parseInt(scanner.nextLine());
        int numberOfDays = Integer.parseInt(scanner.nextLine());

        int sum = numberOfStations / stationsPerHour;
        int result = sum / numberOfDays;

        System.out.print(result);

    }
}
