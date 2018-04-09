package pizzeria;

import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class Main {
    public static void main(String args[]){
        System.out.println("Start");

        Pizzeria pizzeria = new Pizzeria();



        // najtañsza ostra pizza
        System.out.println("Najtansza i najostrzejsza: " + pizzeria.findCheapestSpicy());
        System.out.println();

        // droga i vege
        System.out.println("Najdrozsza i bezmiesna: " + pizzeria.findMostExpensiveVegetarian());
        System.out.println();

        // pizze miêsne, posortowane malej¹co po liczbie sk³adników miêsnych
        System.out.println("Lista z pizzami miêsnymi posortowanymi po iloœci sk³adnikow miêsnych: ");
        pizzeria.iLikeMeat().stream()
                .forEach(System.out::println);
        System.out.println();

        // pizze pogrupowane po cenie (wyœwietlanie ca³ej mapy)
        System.out.println("Pizze pogrupowane po cenie: ");
        Map<Integer, List<Pizza>> groupedByPrice = pizzeria.groupByPrice();
        Set<Map.Entry<Integer, List<Pizza>>> entrySet = groupedByPrice.entrySet();

        for(Map.Entry<Integer, List<Pizza>> entry : entrySet){
            System.out.print(entry.getKey() + "z³‚: ");
            String pizzas = entry.getValue().stream()
                    .map(Pizza::getName)
                    .collect(Collectors.joining(", "));
            System.out.println(pizzas);
        }
        System.out.println();

        // sk³adniki ka¿dej pizzy
        System.out.println("MENU:");
        System.out.println(pizzeria.formatedMenu());


    }



}
