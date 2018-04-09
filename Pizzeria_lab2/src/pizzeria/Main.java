package pizzeria;

import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class Main {
    public static void main(String args[]){
        System.out.println("Start");

        Pizzeria pizzeria = new Pizzeria();



        // najta�sza ostra pizza
        System.out.println("Najtansza i najostrzejsza: " + pizzeria.findCheapestSpicy());
        System.out.println();

        // droga i vege
        System.out.println("Najdrozsza i bezmiesna: " + pizzeria.findMostExpensiveVegetarian());
        System.out.println();

        // pizze mi�sne, posortowane malej�co po liczbie sk�adnik�w mi�snych
        System.out.println("Lista z pizzami mi�snymi posortowanymi po ilo�ci sk�adnikow mi�snych: ");
        pizzeria.iLikeMeat().stream()
                .forEach(System.out::println);
        System.out.println();

        // pizze pogrupowane po cenie (wy�wietlanie ca�ej mapy)
        System.out.println("Pizze pogrupowane po cenie: ");
        Map<Integer, List<Pizza>> groupedByPrice = pizzeria.groupByPrice();
        Set<Map.Entry<Integer, List<Pizza>>> entrySet = groupedByPrice.entrySet();

        for(Map.Entry<Integer, List<Pizza>> entry : entrySet){
            System.out.print(entry.getKey() + "z��: ");
            String pizzas = entry.getValue().stream()
                    .map(Pizza::getName)
                    .collect(Collectors.joining(", "));
            System.out.println(pizzas);
        }
        System.out.println();

        // sk�adniki ka�dej pizzy
        System.out.println("MENU:");
        System.out.println(pizzeria.formatedMenu());


    }



}
