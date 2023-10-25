using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebShop1;

public class Customer
{
    public static void ReadCustInfo()
    {

        Console.Clear();
        Console.WriteLine("*********** USER INFORMATION ***********");
        Dictionary<string, int> customerList = new Dictionary<string, int>();
        string[] custList = File.ReadAllLines("../../../Customer.txt");
        int x = 1;

        foreach (string line in custList)
        {
            string[] splitLine = line.Split(",");
            Console.WriteLine("User" + x + ": " + splitLine[0] + "\nPassword: " + splitLine[1]);
            Console.WriteLine("\n");
            x++;
        }
        Console.WriteLine("Press enter to return");
        Console.ReadKey();

    }

    public static void EditCust()
    {

        string? adminEditCustomer = Console.ReadLine();
        int editCustomer = 0;

        while (editCustomer == 0)
            Console.WriteLine("Do you want to:");
        Console.WriteLine("1. Change username");
        Console.WriteLine("2. Change password");
        Console.WriteLine("3. Remove user");
        switch (Console.ReadLine())
        {
            case "1":
                editCustomer = 1;
                break;

            case "2":
                editCustomer = 2;
                break;

            case "3":
                editCustomer = 3;
                break;

            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
        if (editCustomer == 1) //Change username
        {

        }

        if (editCustomer == 2) //Change password
        {

        }

        if (editCustomer == 3) //remove user
        {

        }


    }

    public static void CustomerLoginMenu()
    {


        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");

        bool CustomerCheck = true;
        while (CustomerCheck)
        {
            Console.Clear();
            Console.WriteLine("Please choose from below:\n");
            Console.WriteLine("1. Browse products");
            Console.WriteLine("2. Shopping cart");
            Console.WriteLine("3. Transaction history");
            Console.WriteLine("4. Logout");



            int customerChoice = 0;
            string? customerInput = Console.ReadLine();
            Console.Clear();
            switch (customerChoice)
            {
                case 0:
                    switch (customerInput)
                    {
                        case "1":
                            customerChoice = 1;
                            break;
                        case "2":
                            customerChoice = 2;
                            break;
                        case "3":
                            customerChoice = 3;
                            break;
                        case "4":
                            CustomerCheck = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No valid option, Try again.\n");
                            break;

                    }


                    if (customerChoice == 1) // read in product list
                    {
                        Console.Clear();
                        Product.Catalogue();
                        //menu för vill du adda till cart eller gå tillbaka till meny
                        ShoppingCart.AddCart();


                        bool addCustCart = true;   //Samma som == customerChoice 2? Ska vi kombinera detta med den eller låta vara?
                        while (addCustCart)  
                        {
                           
                            Console.WriteLine("What do you want to do now?\n");
                            Console.WriteLine("1. Open your shopping cart");
                            Console.WriteLine("2. Add more producs to your cart");
                            Console.WriteLine("3. Remove product(s) from your cart");
                            Console.WriteLine("4. Do you want to checkout");
                            Console.WriteLine("5. Return to customer menu");

                            customerInput = Console.ReadLine();
                            switch (customerInput)
                            {
                                case "1":
                                    ShoppingCart.ReadCart();
                                    Console.WriteLine("Press any key to go back to the menu");
                                    Console.ReadKey();
                                    //call shopping cart menu
                                    continue;
                                case "2":
                                    ShoppingCart.ReadCart();
                                    ShoppingCart.AddCart();
                                    continue;
                                case "3":
                                    ShoppingCart.ReadCart();
                                    ShoppingCart.RemoveCart();
                                    continue;
                                case "4":
                                    ShoppingCart.CheckoutCart();
                                    customerChoice = 0;
                                    break;
                                case "5":
                                    addCustCart = false;
                                    continue;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("No valid option, Try again.");
                                    break;
                            }
                        }
                    }

                    if (customerChoice == 2) // check shoppingcart
                    {
                        while (customerChoice == 2)
                        {
                            ShoppingCart.ReadCart();
                            Console.WriteLine();
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("1. Do you want to checkout");
                            Console.WriteLine("2. Do you want to add products");
                            Console.WriteLine("3. Do you want to remove products");
                            Console.WriteLine("4. Return to customer menu");
                            customerInput = Console.ReadLine();
                            switch (customerInput)
                            {
                                case "1":
                                    ShoppingCart.CheckoutCart();
                                    customerChoice = 0;
                                    break;
                                case "2":
                                    ShoppingCart.ReadCart();
                                    ShoppingCart.AddCart();
                                    continue;
                                case "3":
                                    ShoppingCart.ReadCart();
                                    ShoppingCart.RemoveCart();
                                    continue;
                                case "4":
                                    customerChoice = 0;
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("No valid option, Try again.\n");
                                    break;
                            }
                        }




                    }
                    if (customerChoice == 3)
                    {

                        Receipt.ReadReceipt();
                    }
                    break;
            }
        }
    }
}
