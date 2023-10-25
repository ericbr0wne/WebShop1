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
    private enum Choice
    {
        Menu,
        Products,
        Cart,
        Transactions,
        Exit
    }

    public static void ReadInfo()
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

    public static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Do you want to:");
        Console.WriteLine("1. Change username");
        Console.WriteLine("2. Change password");
        switch (Console.ReadLine())
        {
            case "1":
                ChangeUsername();
                break;
            case "2":
                ChangePassword();
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                break;

        }


    }
    public static void LoginMenu()
    {


        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");
        Choice Customer = Choice.Menu;
        bool CustomerCheck = true;
        while (CustomerCheck)
        {
            if (Customer.Equals(Choice.Menu))
            {
                Console.Clear();
                Console.WriteLine("Please choose from below:\n");
                Console.WriteLine("1. Browse products");
                Console.WriteLine("2. Shopping cart");
                Console.WriteLine("3. Transaction history");
                Console.WriteLine("4. Logout");
            }



            int customerChoice = 0;
            string? customerInput = Console.ReadLine();
            Console.Clear();

            switch (customerChoice)
            {
                case 0:
                    switch (customerInput)
                    {
                        case "1":
                            Customer = Choice.Products;
                            break;
                        case "2":
                            Customer = Choice.Cart;
                            break;
                        case "3":
                            Customer = Choice.Transactions;
                            break;
                        case "4":
                            Customer = Choice.Exit;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No valid option, Try again.\n");
                            break;

                    }


                    if (Customer.Equals(Choice.Products))
                    {
                        Console.Clear();
                        Product.Catalogue();
                        ShoppingCart.Add();


                        while (Customer.Equals(Choice.Products))
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
                                    ShoppingCart.Read();
                                    Console.WriteLine("Press any key to go back to the menu");
                                    Console.ReadKey();
                                    continue;
                                case "2":
                                    ShoppingCart.Read();
                                    ShoppingCart.Add();
                                    continue;
                                case "3":
                                    ShoppingCart.Read();
                                    ShoppingCart.Remove();
                                    continue;
                                case "4":
                                    ShoppingCart.Checkout();
                                    Customer = Choice.Menu;
                                    break;
                                case "5":
                                    Customer = Choice.Menu;
                                    continue;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("No valid option, Try again.");
                                    break;
                            }
                        }
                    }

                    if (Customer.Equals(Choice.Cart))
                    {
                        while (Customer.Equals(Choice.Cart))
                        {
                            ShoppingCart.Read();
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
                                    ShoppingCart.Checkout();
                                    Customer = Choice.Menu;
                                    break;
                                case "2":
                                    ShoppingCart.Read();
                                    ShoppingCart.Add();
                                    Customer = Choice.Menu;
                                    continue;
                                case "3":
                                    ShoppingCart.Read();
                                    ShoppingCart.Remove();
                                    Customer = Choice.Menu;
                                    continue;
                                case "4":
                                    Customer = Choice.Menu;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("No valid option, Try again.\n");
                                    break;
                            }
                        }




                    }
                    if (Customer.Equals(Choice.Transactions))
                    {
                        Receipt.ReadReceipt();
                        Customer = Choice.Menu;
                    }
                    break;
            }
            if (Customer.Equals(Choice.Exit))
            {
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
            if (user[0] == oldUsername) 
            {
                Console.WriteLine("\nNew Username(Only English letters): \n");
                string newUsername = Console.ReadLine();

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
            if (user[0] == username && user[1] == oldPassword) 
            {
                Console.WriteLine("\nNew Password(min. 6 characters & Only English letters): \n");
                string newPassword = Console.ReadLine();

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
