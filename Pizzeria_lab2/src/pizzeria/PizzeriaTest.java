package pizzeria;

import static org.junit.jupiter.api.Assertions.*;

import java.util.Arrays;
import java.util.List;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class PizzeriaTest {

    private List<Pizza> pizzas;
    private Pizzeria pizzeria;

    // tworzenie nowych obiektów
    @BeforeEach
    public void initPizzas(){
        pizzas = Arrays.asList(Pizza.values());
        pizzeria = new Pizzeria();
    }

    // czy znaleziona pizza jest ostra
    @Test
    public void cheapSpicy_isSpicy_test(){
        Pizza testPizza = pizzeria.findCheapestSpicy();
        boolean spicy = false;
        for (Ingredient ing : testPizza.getIngredients()) {
            if(ing.isSpicy()) spicy = true;
        }
        assertEquals(true, spicy);
    }

    // czy znaleziona pizza jest bez miêsa
    @Test
    public void expensiveVegetarian_isVege_test(){
        Pizza testPizza = pizzeria.findMostExpensiveVegetarian();
        boolean vegetarian = true;
        for (Ingredient ing : testPizza.getIngredients()) {
            if(ing.isMeat()) vegetarian = false;
        }
        assertEquals(true, vegetarian);
    }
    
    // czy w liœcie z pizzami jest jakaœ bez miêsa (jak tak, to test nie przejdzie)
    @Test
    public void iLikeMeat_containsMeatPizza_test() {
    	boolean allHasMeat = true;
    	for(Pizza p : pizzeria.iLikeMeat()) {
    		boolean pizzaHasMeat = false;
    		for(Ingredient i : p.getIngredients()) {
    			if(i.isMeat()){
    				pizzaHasMeat = true; break;
    			}
    		}
    		if(pizzaHasMeat == false) {
    			allHasMeat = false;
    			break;
    		}
    	}
    	
    	assertTrue(allHasMeat);
    }

}
