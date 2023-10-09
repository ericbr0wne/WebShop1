using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
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





    public static void cart()
    {
        List<string> cart = new List<string>();
        List<string> cart2 = new List<string>();


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
            cart.Add(splitLine[0]);

        }

        cart2.Add(cart[0]); // add first item in product list to cart

            File.WriteAllLines("../../../ShoppingCart.txt", cart2);

            string[] shoppingCart = File.ReadAllLines("../../../ShoppingCart.txt");

        foreach (var item in shoppingCart)
        {
            Console.WriteLine(item); // writes out the shopping cart
        }

    }

    
}
