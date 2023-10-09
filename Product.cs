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
    int position = 1;
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

        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");
        string? newProduct = Console.ReadLine();


        foreach (string Article in productList)
        {
            //split by the sign ","
            string[] splitLine = Article.Split(",");

            //Parse string[1] to int
            int.TryParse(splitLine[1], out int price);
          
            if (newProduct == splitLine[0])
            {
                product.Add(splitLine[0], price);
                Console.WriteLine("You just added: " + splitLine[0] + " " + splitLine[1] + ":- to your cart.");
            }

        }
        File.AppendAllText("../../../ShoppingCart.txt", newProduct + Environment.NewLine); //E.NewLine, means that the code from file is more plattform independent
        string[] addedProductList = File.ReadAllLines("../../../ShoppingCart.txt");


    }

    //add items to shoppingcart = addedProductList

    public static void appendToList()

    {

        string? inputToShoppingCart = string.Empty;
        inputToShoppingCart = Console.ReadLine();

        File.AppendAllText("../../../addedProductList.txt", inputToShoppingCart + Environment.NewLine); //E.NewLine, means that the code from file is more plattform independent
        string[] addedProductList = File.ReadAllLines("../../../addedProductList.txt");

    }

    //print shoppingCart = addedProductList


    public static void shoppingCart()
    {
        //Dictionary<string, int> product= new Dictionary<string, int>();
        string[] addedProductList = File.ReadAllLines("../../../addedProductList.txt");
        Console.WriteLine("Your Shopping Cart: ");

        foreach (string item in addedProductList)
        {
            Console.WriteLine(item);
        }


        /* Calculate the total price
     
        int totalPrice = 0;

        foreach (string item in addedProductList)
        {
            
                totalPrice += 
            
        }


        cart2.Add(cart[0]); // add first item in product list to cart

            File.WriteAllLines("../../../ShoppingCart.txt", cart2);

            string[] shoppingCart = File.ReadAllLines("../../../ShoppingCart.txt");

        foreach (var item in shoppingCart)
        {
            Console.WriteLine(item); // writes out the shopping cart
        }

        Console.WriteLine("Total Price: " + totalPrice);
        */


    }


}
