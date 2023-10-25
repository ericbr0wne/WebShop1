using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebShop1;

namespace WebShop1;

public class ShoppingCart
{
    public static void Read() 
    {
        List<string> cartList = File.ReadAllLines("../../../TempCart.txt").ToList();
        File.WriteAllText("../../../TempCart.txt", "");

        string loggedIn = string.Empty;
        
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
        int cartSum = 0;
        int x = 1;
        List<string> tempLogin = File.ReadAllLines("../../../LoggedIn.txt").ToList();
        loggedIn = tempLogin[0];

        Console.WriteLine("This is in your cart: ");
        Console.WriteLine();

        foreach (var line in shoppingCartList)
        {
            if (line.Contains( loggedIn))
            {
                string[] splitLine = line.Split("+"); 
                string prodAndPrice = splitLine[1];

                string[] prodSplit = splitLine[1].Split(",");
                int.TryParse(prodSplit[1], out int price);
                cartSum += price;
                Console.WriteLine(x + ". " + prodSplit[0]);
                x++;
                File.AppendAllText("../../../TempCart.txt", prodSplit[0] + Environment.NewLine);
            }
            else if (!line.Contains(loggedIn))
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


    public static void Add() 
    {
       
        string[] productList = File.ReadAllLines("../../../Product.txt");
        Console.Clear();

        Console.WriteLine("This is the product list:");
        Product.Catalogue(); 
        Console.WriteLine();
        Console.WriteLine("Choose the number of product to add to Shopping Cart: ");
        Console.WriteLine();
        Console.WriteLine("Type exit to return to customer menu.");
        string? input = Console.ReadLine().ToLower();
        Console.Clear();
        string[] loginList = File.ReadAllLines("../../../customer.txt");
        string loggedIn = string.Empty;
        foreach (string usepass in loginList)
        {
            loggedIn = usepass;
        }

        for (int i = 0; i <= productList.Length; i++)
        {
            if (input == i.ToString())
            {
                File.AppendAllText("../../../ShoppingCart.txt", loggedIn + "+");
                File.AppendAllText("../../../ShoppingCart.txt", productList[i - 1] + Environment.NewLine);
                ShoppingCart.Latest();
                string[] Latest = File.ReadAllLines("../../../Latest.txt"); 
                Console.Clear();
                Console.WriteLine("You added " + Latest[Latest.Length - 1] + " to your list");
                Console.WriteLine();
            }
            else if (input == "exit")
            {
                continue;
            }
        }
    }

    public static void Remove()  

    {
        Console.Clear();
        Read();

        Console.WriteLine();
        Console.WriteLine("What product do you wish to remove?");
        Console.WriteLine();

        {
            List<string> cartList = File.ReadAllLines("../../../ShoppingCart.txt").ToList(); 
            string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt"); 

            Console.WriteLine();
            string? input = Console.ReadLine();
            string[] loginList = File.ReadAllLines("../../../customer.txt");
            string loggedIn = string.Empty; 
            foreach (string usepass in loginList)
            {
                loggedIn = usepass;
            }

            
            for (int i = 0; i < shoppingCartList.Length; i++)
            {
                if (input != null)
                {
                }
            }
        }

    }


    public static void Latest()  
    {

        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
        List<string> list = new List<string>();
        list.Clear();
        foreach (string line in shoppingCartList)
        {
            string[] splitall = line.Split("+");
            string prod = splitall[1];
            string[] splitLine = prod.Split(",");
            list.Add(splitLine[0]);
            File.WriteAllLines("../../../Latest.txt", list);
        }

    }

    public static void Checkout()  
    {

        Console.Clear();
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
        int cartSum = 0;
        string[] loginList = File.ReadAllLines("../../../customer.txt");
        string loggedIn = string.Empty;
        foreach (string usepass in loginList)
        {
            loggedIn = usepass;
        }

        File.AppendAllText("../../../Receipt.txt", loggedIn + "+");
        foreach (var line in shoppingCartList)
        {
            if (line.Contains(loggedIn))
            {
                string[] splitLine = line.Split("+"); 
                string prodAndPrice = splitLine[1];

                string[] prodSplit = prodAndPrice.Split(",");
                int.TryParse(prodSplit[1], out int price);
                cartSum += price;
                File.AppendAllText("../../../Receipt.txt", prodAndPrice + "_");

            }
            else if (!line.Contains(loggedIn))
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
        File.AppendAllText("../../../Receipt.txt", "/"+ cartSum + "*");
        File.AppendAllText("../../../Receipt.txt", DateTime.Now.ToString() + Environment.NewLine);

        Console.WriteLine("You have now completed your transaction, thank you for shopping.");
        Console.WriteLine("Press enter to continue.");
        Console.ReadKey();
                                 
    }
    public static void AdminCheck()
    {
        Console.Clear();

        Console.WriteLine("Customer username: ");
        string? CustomerName = Console.ReadLine();

        string CustomerCheck = File.ReadAllText("../../../customer.txt");

        if (CustomerCheck.Contains(CustomerName))
        {
            string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
            int cartSum = 0;
            int x = 1;
            Console.Clear();
            Console.WriteLine("This is in " + CustomerName + "'s cart: ");
            Console.WriteLine();

            foreach (var line in shoppingCartList)
            {
                string[] user = line.Split(",");

                if (user[0] == CustomerName)
                {
                    string[] splitLine = line.Split("+");
                    string prodAndPrice = splitLine[1];

                    string[] prodSplit = splitLine[1].Split(",");
                    int.TryParse(prodSplit[1], out int price);
                    cartSum += price;
                    Console.WriteLine(x + ". " + prodSplit[0]);
                    x++;

                }
                else if (user[0] != CustomerName)
                {
                    continue;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("The cart is empty!");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total sum: " + cartSum + ":-");

            Console.WriteLine();
            Console.WriteLine("Press any key to go back to Admin menu");
            Console.ReadKey();
        }

        else
        {
            Console.WriteLine();
            Console.WriteLine("This user does not exist \n");
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }

    

}





