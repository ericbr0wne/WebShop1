using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop1;

public class Product
{

    public static void itemList()
    {
        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");

        foreach (string Article in productList)
        {
            //split by the sign ","
            string[] splitLine = Article.Split(",");

            //Parse string[1] to int
            if (int.TryParse(splitLine[1], out int price))
            {
                //Add string[0] + int[1] into map
                product.Add(splitLine[0], price);
            }

            Console.WriteLine(splitLine[0] + " " + splitLine[1] + ":-");
        }



    }
    public static void appendToList()

    {

        string? input = string.Empty;
        input = Console.ReadLine();

        File.AppendAllText("../../../addedProductList.txt", input + Environment.NewLine);
        string[] addedProductList = File.ReadAllLines("../../../addedProductList.txt");

        string inputShoppingCart = input;

    }


    public static void shoppingCart()
    {

        string[] addedProductList = File.ReadAllLines("../../../addedProductList.txt");
        Console.WriteLine("Your Shopping Cart: "); 

        foreach (string item in addedProductList)
        {
            Console.WriteLine(item);
        }


    }

}
