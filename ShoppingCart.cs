using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;

namespace WebShop1;

public class ShoppingCart : Login
{
    public static void ReadCart() //Reads cart + calculate and show total cost
    {


        List<string> cartList = File.ReadAllLines("../../../TempCart.txt").ToList();
        File.WriteAllText("../../../TempCart.txt", "");


       // Console.Clear();
       // Dictionary<string, int> cartList = new Dictionary<string, int>();

        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
        int cartSum = 0;
        int x = 1;
        string[] loginList = File.ReadAllLines("../../../Login.txt");
        string usernamepass = string.Empty;
        foreach (string usepass in loginList)
        {
            usernamepass = usepass;
        }
        Console.WriteLine("This is in your cart: ");
        Console.WriteLine();

        foreach (var line in shoppingCartList)
        {
            if (line.Contains(usernamepass))
            {
                string[] splitLine = line.Split("+"); //usernamepassword =splitline[0] + produktpris = splitline[1]
                string prodAndPrice = splitLine[1];

                string[] prodSplit = splitLine[1].Split(",");
                int.TryParse(prodSplit[1], out int price);
                cartSum += price;
                Console.WriteLine(x + ". " + prodSplit[0]);
                x++;
                File.AppendAllText("../../../TempCart.txt", prodSplit[0] + Environment.NewLine);
            }
            else if (!line.Contains(usernamepass))
            {
                continue;
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Your cart is empty!");
                Console.WriteLine();
            }
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
        string[] loginList = File.ReadAllLines("../../../Login.txt");
        string usernamepass = string.Empty;
        foreach (string usepass in loginList)
        {
            usernamepass = usepass;
        }

        for (int i = 0; i <= productList.Length; i++)
        {
            if (input == i.ToString())
            {
                File.AppendAllText("../../../ShoppingCart.txt", usernamepass);
                File.AppendAllText("../../../ShoppingCart.txt", productList[i - 1] + Environment.NewLine);
            }
        }
    }

    public static void RemoveCart()

    {

        Console.Clear();
        ReadCart();

        Console.WriteLine();
        Console.WriteLine("What product do you wish to remove?");
        Console.WriteLine();

        {
            List<string> cartList = File.ReadAllLines("../../../TempCart.txt").ToList(); //To be able to remove from list
            string[] shoppingCartList = File.ReadAllLines("../../../TempCart.txt"); //To be able to count

            Console.WriteLine();
            string? input = Console.ReadLine();
            string[] loginList = File.ReadAllLines("../../../Login.txt");
            string usernamepass = string.Empty; //contains username and password
            foreach (string usepass in loginList)
            {
                usernamepass = usepass;
            }


            for (int i = 0; i <= shoppingCartList.Length; i++)
            {
                if (input != null)
                {
                    cartList.RemoveAt(i - 1);
                }
            }
        }
    }
}




