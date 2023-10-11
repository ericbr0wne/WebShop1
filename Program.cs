
// <product list CSV or txt>
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WebShop1;
// <customer list csv or txt>
List<string> customer = new List<string>();

int menuChoice = 0;
         
while (true)
{
    if (menuChoice == 0)
    {
        Console.Clear();
        ShoppingCart.AddCart();
        ShoppingCart.ReadCart();
        Console.WriteLine("Hello and welcome to the BEST shop in the world\n");
        Console.WriteLine("Please choose from below:\n");
        Console.WriteLine("1. Products");
        Console.WriteLine("2. Login/Register");
        Console.WriteLine("3. Exit");
    }

    if (menuChoice == 1) //Product menu
    {
        Console.Clear();
        Console.WriteLine("This is our avaiable products: ");
        Product.NrAndReadProductList();
        Console.WriteLine();
        Console.WriteLine("If you want to add products to your cart,");
        Console.WriteLine("Please login first.");
        Console.WriteLine();
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Return to main menu");
        Console.WriteLine("3. Exit");

        switch (Console.ReadLine())
        {
            case "1":
                menuChoice = 2;
                continue;
            case "2":
                menuChoice = 0;
                continue;
            case "3":
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please choose 1, 2 or 3.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
  
    if (menuChoice == 2)
    {
        Console.Clear();
        Console.WriteLine("Welcome to our login page.\n");
        Console.WriteLine("Do you want to: ");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Return to main page");
        switch (Console.ReadLine())
        {
            case "1": 
                //go to login class
                Console.Clear();
                Console.WriteLine("case 1");
                Console.ReadKey();
                Console.Clear();
                break;

            case "2":
                //go to register class
                Console.Clear();
                Console.WriteLine("Register");
                Register.Insert();
                Console.ReadKey();
                Console.Clear();
                break;

            case "3":
                break;

            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please choose 1, 2 or 3.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                continue;
        }
        menuChoice = 0;
    }

    if (menuChoice == 3)
    {
        Console.Clear();
        Console.WriteLine();
        break;

    }

    string? input = Console.ReadLine();

    switch (menuChoice)
    {
        case 0:
            switch (input)
            {
                case "1":
                    menuChoice = 1;
                    break;
                case "2":
                    menuChoice = 2;
                    break;
                case "3":
                    menuChoice = 3;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You didn't pick a valid option.");
                    Console.WriteLine("Please choose 1, 2 or 3.");
                    Console.WriteLine("Please press enter to continue!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            break;
    }
}

Console.WriteLine("Thank you for shopping at WebShop1. Please come again!");