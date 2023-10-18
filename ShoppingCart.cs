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
                string[] splitLine = line.Split("+"); //loggedInword =splitline[0] + produktpris = splitline[1]
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
            List<string> cartList = File.ReadAllLines("../../../ShoppingCart.txt").ToList(); //To be able to remove from list
            string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt"); //To be able to count

            Console.WriteLine();
            string? input = Console.ReadLine();
            string[] loginList = File.ReadAllLines("../../../customer.txt");
            string loggedIn = string.Empty; //contains username and password
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


    public static void LastCart() //Reads cart + calculate and show total cost
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

    public static void CheckoutCart()
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
                string[] splitLine = line.Split("+"); //loggedInword =splitline[0] + produktpris = splitline[1]
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

        /*
        Checkout -
        alla filer från shoppingcart.txt med username+password
        print username + password ONCE                                                 Benny,hejhej+        
        foreach item in shoppingcart.txt med username+password add productname         pear
                                                                                       apple   
                                                                                       banana
        
        add total cost                                                                 total cost: 15:-
        
        When finished add date and time stamp                                          2023-10-16
        
        space for new                                                                  **********************************

        Checkout -
        alla filer från shoppingcart.txt med username+password
        print username + password ONCE                                                 Jonny,hejhej+        
        foreach item in shoppingcart.txt med username+password add productname         pear
                                                                                       apple   
                                                                                       banana
        
        add total cost                                                                 total cost: 15:-
        
        When finished add date and time stamp                                          2023-10-16
        
        space for new                                                                  **********************************


        Jonny,hejhej+pear,apple,banana-15,2023-10-16



        display reciept username + prods + timestamp



        */







    }


}





