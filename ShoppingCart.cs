using System.Collections.Generic;
using System.IO;

namespace WebShop1;

public class ShoppingCart : Login
{
    public static void ReadCart() //Reads cart + calculate and show total cost
    {


        Console.Clear();
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
        //save from login username,password+product,price-time&date


        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../Product.txt");
        Console.Clear();

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
        Console.WriteLine();
        Console.WriteLine("What product do you wish to remove?");
        Console.WriteLine();

        {
            List<string> cartList = File.ReadAllLines("../../../ShoppingCart.txt").ToList(); //To be able to remove from list
            string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt"); //To be able to count

            Console.WriteLine();
            string? input = Console.ReadLine();

            for (int i = 0; i <= shoppingCartList.Length; i++)
            {
                if (input == i.ToString())
                {
                    cartList.RemoveAt(i - 1);
                    File.WriteAllLines("../../../ShoppingCart.txt", cartList);
                }
            }
        }
    }
}




