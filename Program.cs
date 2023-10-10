
// <product list CSV or txt>
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WebShop1;

// <customer list csv or txt>
List<string> customer = new List<string>();


int position = 0;


         
while (true)

{

    if (position == 0)
    {
        Console.Clear();
        Console.WriteLine("Hello and welcome to the BEST shop in the world\n");
        Console.WriteLine("Please choose from below:\n");
        Console.WriteLine("1. Products");
        Console.WriteLine("2. Login/Register");
        Console.WriteLine("3. Exit");
    }

    if (position == 10)
    {
        Console.Clear();
        Console.WriteLine("Here is the list of available items for sale:\n");
        Product.NrAndReadProductList();
        Console.WriteLine("\nWhat would you like to add to your cart?\n");
        switch (Console.ReadLine())
        {
            case "1": // pick first product 

                ShoppingCart.AddCart();
                break;
        }

        Console.ReadKey();

        Console.Clear();
        break;
    }
  
    if (position == 20)
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
        position = 0;
    }

    if (position == 30)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Thank you for shopping in the BEST shop.");
        Console.WriteLine("Please come again!");
        break;

    }

    string? input = Console.ReadLine();

    switch (position)
    {
        case 0:
            switch (input)
            {
                case "1":
                    position = 10;
                    break;
                case "2":
                    position = 20;
                    break;
                case "3":
                    position = 30;
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

   