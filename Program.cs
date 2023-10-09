
// <product list CSV or txt>
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WebShop1;


// <customer list csv or txt>
List<string> customer = new List<string>();


/*

LOGIN
userInput creates a new User<list>
username: Password:

*/

while (true)

{
    Console.Clear();
    Console.WriteLine("What product would you like to add?\n");
    string? newProd = Console.ReadLine() + ",";
    Console.WriteLine("\nAnd what price should it have?\n");
    int? newPrice = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(newProd + newPrice);
    // product.Add(newProd+newPrice);

    Console.WriteLine("Hello and welcome to the BEST shop in the world\n");
    Console.WriteLine("Please choose from below:\n");
    Console.WriteLine("1. Products");
    Console.WriteLine("2. Login/Register");
    Console.WriteLine("3. Exit");
    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Here is the list of available items for sale:\n");
            Product.itemList();
            Console.WriteLine("Add item by typing and press Enter:");
            //Append to list
            Product.appendToList();
            Console.WriteLine("Do you wish to add something else? y/n?" );
 
            switch (Console.ReadLine())
            {
                case "y":
                    Console.WriteLine("Add item by typing and press Enter:");
                    Product.appendToList();
                    break;

                case "n":

                    //go to shopping cart menu
                    Product.shoppingCart();
                    break;
            }

            Console.ReadLine();
            Console.Clear();
            break;

        case "2": //Menu2
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

                    Console.WriteLine("case 2");
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

                    //void function return to menu2
                    Console.ReadKey();
                    Console.Clear();
                    continue;
            }
            Console.Clear();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping in the BEST shop.");
            Console.WriteLine("Please come again!");
            break;

            //Det krashar efter denna har visats en gång kvittar om man skriver rätt eller fel igen 
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
    //if option 1
    //foreach
    //Pickoption
    //add to cart -> you need to be on login customerprofile // run option 2
    //go back

    //extra searchfunction!



    //IF option 2
    //switch
    //<login option>
    // login || register
    //Login start customer or admin
    //If register start registerOption







}