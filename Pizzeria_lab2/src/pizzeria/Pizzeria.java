package pizzeria;

import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class Pizzeria {

    private List<Pizza> pizzas;

    Pizzeria(){
        pizzas = Arrays.asList(Pizza.values());
    }

    public Pizza findCheapestSpicy(){
        List<Pizza> spiceAndCheapList = pizzas.stream()
                .filter(i -> i.getIngredients().stream().anyMatch(Ingredient::isSpicy)) // pizze z jakims ostrym skladnikiem
                .sorted(Comparator.comparing(i -> i.getIngredients().stream().mapToInt(p->p.getPrice()).sum())) // posortuj po sumie cen skladnikow
                .limit(1) // tylko jedna, najtansza pizza zostanie zwrócona do listy
                .collect(Collectors.toList());

        if(spiceAndCheapList.isEmpty())
            return null;
        else
            return spiceAndCheapList.get(0);
    }


    public Pizza findMostExpensiveVegetarian(){


        List<Pizza> vegeList = pizzas.stream()
                .filter(i -> i.getIngredients().stream().noneMatch(ii -> ii.isMeat())) // wybierz same pizze bez miesa
                .sorted((p, p1) -> Integer.compare( // jak zamieni sie 'p' i 'p1' miejscami, to bedzie sortowanie rosnace
                        p1.getIngredients().stream().mapToInt(Ingredient::getPrice).sum(),
                        p.getIngredients().stream().mapToInt(Ingredient::getPrice).sum()
                ))
                .limit(1) // zwraca tylko 1 wynik - najdrozsza pizza
                .collect(Collectors.toList()); // dodaj do listy

        if(vegeList.isEmpty())
            return null;
        else
            return vegeList.get(0);
    }


    public List<Pizza> iLikeMeat(){

        List<Pizza> meatList = pizzas.stream()
                .filter(i -> i.getIngredients().stream().anyMatch(Ingredient::isMeat)) // miêsne pizze
                .sorted((p, p1) -> Long.compare(
                        p1.getIngredients().stream().filter(Ingredient::isMeat).count(),
                        p.getIngredients().stream().filter(Ingredient::isMeat).count()
                ))
                .collect(Collectors.toList());

        if(meatList.isEmpty())
            return null;
        else
            return meatList;
    }

    public Map<Integer, List<Pizza>> groupByPrice(){
        Map<Integer, List<Pizza>> groupedByPrice;


        groupedByPrice = pizzas.stream().collect(Collectors.groupingBy(p -> p.getIngredients().stream().mapToInt(Ingredient::getPrice).sum()));


        return groupedByPrice;
    }

    public String formatedMenu() {
        String menu = "";

        //menu = pizzas.stream().map(Pizza::getName).collect(Collectors.joining("\n"));
        menu = pizzas.stream().map(
                p -> p.getName() + ": "
                        + p.getIngredients().stream().map(Ingredient::getName).collect(Collectors.joining(", "))
                        + " - "
                        + p.getIngredients().stream().mapToInt(Ingredient::getPrice).sum() + "z³‚"
        ).collect(Collectors.joining("\n"));
        return menu;
    }
}
