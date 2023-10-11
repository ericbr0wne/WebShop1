namespace WebShop1;

public class ShoppingCart
{
    public static void ReadCart() //Reads cart + calculate and show total cost
    {
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
        int cartSum = 0;
        int x = 1;

        foreach (var line in shoppingCartList)
        {
            string[] splitLine = line.Split(",");
            int.TryParse(splitLine[1], out int price);
            cartSum += price;
        }
        Console.WriteLine("This is in your cart: ");
        foreach (string line in shoppingCartList)
        {
            string[] splitLine = line.Split(",");
            Console.WriteLine(x + ". " + splitLine[0]);
            x++;
        }
        Console.WriteLine();
        Console.WriteLine("Total sum: " + cartSum + ":-");
    }


    public static void AddCart() //add shoppingCartList

    {
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");

        Console.WriteLine("This is the product list:");
        Product.NrAndReadProductList(); //read productList
        Console.WriteLine();
        Console.WriteLine("Choose the number of product to add to Shopping Cart: ");
        Console.WriteLine();
        string? input = Console.ReadLine();
        Console.Clear();

        for (int i = 0; i <= productList.Length; i++)
        {
            if (input == i.ToString())
            {
                File.AppendAllText("../../../ShoppingCart.txt", productList[i - 1] + Environment.NewLine);
            }
        }
    }

    public static void RemoveCart()

    {
        ReadCart();


    }

}