namespace WebShop1;

public class ShoppingCart
{
    public static void ReadCart()

    {
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");

        foreach (var line in shoppingCartList)
        {
            string[] splitLine = line.Split(",");
            if (int.TryParse(splitLine[1], out int price))
            {

                cartList.Add(splitLine[0], price);
            }
            Console.WriteLine(splitLine[0] + " " + splitLine[1] + ":-");
        }
    }


    public static void AddCart() //add shoppingCartList

    {
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");


        Console.WriteLine("This is the product list:");
        Product.NrAndReadProductList(); //read productList
        Console.WriteLine();
        Console.WriteLine("Choose the number of product to add to Shopping Cart: ");
        Console.WriteLine();
        string? input = Console.ReadLine();

        for (int i = 0; i < productList.Length; i++)
        {
            string[] splitLine = productList[i].Split(",");

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