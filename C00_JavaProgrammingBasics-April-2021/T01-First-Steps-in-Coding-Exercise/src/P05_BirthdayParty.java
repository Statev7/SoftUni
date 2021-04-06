import java.util.Scanner;

public class P05_BirthdayParty {
    public static void main(String[] args) {

        final double PROCENT_FOR_CAKE = 0.2;
        final double PROCENT_FOR_DRINK = 0.45;
        final int PROCENT_FOR_ANIMATOR = 3;

        Scanner scanner = new Scanner(System.in);

        int priceForHall = Integer.parseInt(scanner.nextLine());

        double cake = priceForHall * PROCENT_FOR_CAKE;
        double drinks = cake - cake * PROCENT_FOR_DRINK;
        double animator = priceForHall / PROCENT_FOR_ANIMATOR;

        double result = priceForHall + cake + drinks + animator;

        System.out.printf("%.1f", result);

    }
}
