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

    public static void ChangeUsername()
    {
        string[] custList = File.ReadAllLines("../../../customer.txt");
        bool notCustomer = true;
        Console.Clear();
        Console.WriteLine("Edit\n");
        Console.WriteLine("Current Username: \n");
        string oldUsername = Console.ReadLine();

        while (oldUsername.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.Write("Current Username: ");
            oldUsername = Console.ReadLine();
        }

        for (int i = 0; i < custList.Length; i++)
        {
            string line = custList[i];
            List<string> user = new List<string>(line.Split(","));
            if (user[0] == oldUsername) //Admin writes old username //then Admin writes new username // then new username replaces the old username
            {
                Console.WriteLine("\nNew Username(Only English letters): \n");
                string newUsername = Console.ReadLine();
                //line.Replace(oldUsername, newUsername);

                while (newUsername.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Username: ");
                    newUsername = Console.ReadLine();
                }
                while (!Regex.IsMatch(newUsername, @"^[a-zA-Z-0-9]+$"))
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("Username can ONLY use English letters, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Username(Only English letters): ");
                    newUsername = Console.ReadLine();
                }

                custList[i] = newUsername + "," + user[1];
                File.WriteAllLines("../../../customer.txt", custList);
                notCustomer = false;
                Console.Clear();
                Console.WriteLine("You have succefully changed your username to: " + newUsername + "\nPress any key to continue\n");
                Console.ReadKey();
                Admin.AdminLogin();
            }

        }
        if (notCustomer)
        {
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.WriteLine("The username or password is incorrect\n");
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
        }

    }

    public static void ChangePassword()
    {
        string[] custList = File.ReadAllLines("../../../customer.txt");
        bool notPassword = true;
        Console.Clear();
        Console.WriteLine("Edit\n");
        Console.WriteLine("Username: \n");
        string username = Console.ReadLine();
        Console.WriteLine("Current Password: \n");
        string oldPassword = Console.ReadLine();

        while (oldPassword.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.Write("Current Password: ");
            oldPassword = Console.ReadLine();
        }

        for (int i = 0; i < custList.Length; i++)
        {
            string line = custList[i];
            List<string> user = new List<string>(line.Split(","));
            if (user[0] == username && user[1] == oldPassword) //Admin writes old username //then Admin writes new username // then new username replaces the old username
            {
                Console.WriteLine("\nNew Password(min. 6 characters & Only English letters): \n");
                string newPassword = Console.ReadLine();
                //line.Replace(oldUsername, newUsername);

                while (newPassword.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Password: ");
                    newPassword = Console.ReadLine();
                }
                while (newPassword.Length < 6 || !Regex.IsMatch(newPassword, @"^[a-zA-Z-0-9]+$"))
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("Password can NOT be less than 6 characters & can ONLY use English letters, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Password(Only English letters): ");
                    newPassword = Console.ReadLine();
                }

                custList[i] = user[0] + "," + newPassword;
                File.WriteAllLines("../../../customer.txt", custList);
                notPassword = false;
                Console.Clear();
                Console.WriteLine("You have succefully changed your username to: " + newPassword + "\nPress any key to continue\n");
                Console.ReadKey();
                Admin.AdminLogin();
            }
            
            
        }
            if (notPassword)
            {
                Console.Clear();
                Console.WriteLine("Edit\n");
                Console.WriteLine("The username or password is incorrect\n");
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
            }
    }

}
