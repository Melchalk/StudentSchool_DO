namespace HW1;

internal class Bag
{
    private const double pizzaInLiters = 0.3;
    private const double beerInLiters = 0.5;

    public int PizzaPieces { get; set; }
    public int BeerBottles { get; set; }
    public double Capacity { get; set; }

    public bool AddPizza(int pizzaPieces, Bag bag)
    {
        double countPizzaLiters = pizzaPieces * pizzaInLiters;
        if (bag.Capacity - countPizzaLiters >= 0)
        {
            bag.Capacity -= countPizzaLiters;
            PizzaPieces = pizzaPieces;
            return true;
        }

        return false;
    }

    public bool AddBeer(int beerBottles, Bag bag)
    {
        double countBeerLiters = beerBottles * beerInLiters;
        if (bag.Capacity - countBeerLiters >= 0)
        {
            bag.Capacity -= countBeerLiters;
            BeerBottles = beerBottles;
            return true;
        }

        return false;
    }
}