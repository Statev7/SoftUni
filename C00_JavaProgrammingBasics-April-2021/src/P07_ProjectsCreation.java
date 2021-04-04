import java.util.Scanner;

public class P07_ProjectsCreation {
    public static void main(String[] args) {

        final int hours = 3;

        Scanner scanner = new Scanner(System.in);

        String projectName = scanner.nextLine();
        int numberOfProjects = Integer.parseInt(scanner.nextLine());

        int result = numberOfProjects * hours;

        System.out.printf("The architect %s will need %d hours to complete %d project/s.",
                projectName, result, numberOfProjects);

    }
}
