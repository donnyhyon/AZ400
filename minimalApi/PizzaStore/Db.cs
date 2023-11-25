namespace PizzaStore.DB;

public class Pizza
{
    public int Id { get; set; }
    public string ? Name { get; set; }
    public decimal Price { get; set; }
}

public class PizzaDB
{
    private static List<Pizza> _pizzas = new List<Pizza>()
    {new Pizza{Id=1, Name="Cheese", Price=10.99m},
    new Pizza{Id=2, Name="Pepperoni", Price=12.99m},
    new Pizza{Id=3, Name="Veggie", Price=11.99m},
    new Pizza{Id=4, Name="Meat", Price=13.99m},
    new Pizza{Id=5, Name="Supreme", Price=14.99m},
    new Pizza{Id=6, Name="Hawaiian", Price=12.99m},
    new Pizza{Id=7, Name="BBQ Chicken", Price=13.99m},
    new Pizza{Id=8, Name="Buffalo Chicken", Price=13.99m}};
    
    public static List<Pizza> GetPizzas()
    {
        return _pizzas;
    }

    public static Pizza ? GetPizza(int id)
    {
        return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static Pizza CreatePizza(Pizza pizza){
        _pizzas.Add(pizza);
        return pizza;
    }

    public static Pizza UpdatePizza (Pizza update){
        _pizzas=_pizzas.Select(pizza => {
            if (pizza.Id == update.Id){
                pizza.Name = update.Name;
                pizza.Price = update.Price;
            }
            return pizza;
        }).ToList();
        return update;
    }

    public static void RemovePizza (int id){
        _pizzas = _pizzas.Where(pizza => 
            pizza.Id != id
        ).ToList();
    }

};

