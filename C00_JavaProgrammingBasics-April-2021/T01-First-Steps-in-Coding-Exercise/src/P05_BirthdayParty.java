import java.util.Scanner;

public class P05_BirthdayParty {
    public static void main(String[] args) {

        final double procentForCake = 0.2;
        final double procentForDrinks = 0.45;
        final int procentForAnimator = 3;

        Scanner scanner = new Scanner(System.in);

        int priceForHall = Integer.parseInt(scanner.nextLine());

        double cake = priceForHall * procentForCake;
        double drinks = cake - cake * procentForDrinks;
        double animator = priceForHall / procentForAnimator;

        double result = priceForHall + cake + drinks + animator;

        System.out.printf("%.1f", result);

    }
}
