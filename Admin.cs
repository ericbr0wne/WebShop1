using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop1;

public class Admin
{
    private enum Choice
    {
        Main,
        AddProduct,
        RemoveProduct,
        CheckCustomer,
        EditCustomer,
        CustomerCart,
        Transactions,
        Exit,
    }
    public static void AdminLogin()
    {

        Choice admin = Choice.Main;
        while (true)
        {
            if (admin.Equals(Menu.Main))
            {
                Console.Clear();
                Console.WriteLine("*********** Welcome Admin ***********\n");
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. Remove product");
                Console.WriteLine("3. Check costumer information");
                Console.WriteLine("4. Edit costumer information");
                Console.WriteLine("5. Browse costumer shoppingcart");
                Console.WriteLine("6. Browse costumer transactions");
                Console.WriteLine("7. Logout\n");
            }


            switch (admin = Choice.Main)
            {
                case 0:
                    string? adminInput = Console.ReadLine();
                    switch (adminInput)
                    {
                        case "1":
                            admin = Choice.AddProduct;
                            break;
                        case "2":
                            admin = Choice.RemoveProduct;
                            break;
                        case "3":
                            admin = Choice.CheckCustomer;
                            break;
                        case "4":
                            admin = Choice.EditCustomer;
                            break;
                        case "5":
                            admin = Choice.CustomerCart;
                            break;
                        case "6":
                            admin = Choice.Transactions;
                            break;
                        case "7":
                            admin = Choice.Exit;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No valid option, Try again.\n");
                            break;
                    }
                   


                    if (admin.Equals(Choice.AddProduct))
                    {
                        Product.AddProduct();
                        admin = Choice.Main;
                        continue;

                    };

                    if (admin.Equals(Choice.RemoveProduct))
                    {
                        Product.RemoveProduct();
                        admin = Choice.Main;
                        continue;
                    }

                    if (admin.Equals(Choice.CheckCustomer))
                    {
                        Customer.ReadCustInfo();
                        admin = Choice.Main;
                        continue;
                    }

                    if (admin.Equals(Choice.EditCustomer))
                    {
                        int editCustomer = 0;
                        Console.Clear();
                        Console.WriteLine("Do you want to:");
                        Console.WriteLine("1. Change username");
                        Console.WriteLine("2. Change password");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Customer.ChangeUsername();
                                editCustomer = 1;
                                continue;
                            case "2":
                                Customer.ChangePassword();
                                editCustomer = 2;
                                continue;
                            default:
                                Console.Clear();
                                Console.WriteLine("You didn't pick a valid option.");
                                Console.WriteLine("Please press enter to continue!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }


                    if (admin.Equals(Choice.CustomerCart))
                    {

                        Console.Clear();

                        Console.WriteLine("Customer username: ");
                        string CustomerName = Console.ReadLine();

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
                                if (line.Contains(CustomerName))
                                {
                                    string[] splitLine = line.Split("+");
                                    string prodAndPrice = splitLine[1];

                                    string[] prodSplit = splitLine[1].Split(",");
                                    int.TryParse(prodSplit[1], out int price);
                                    cartSum += price;
                                    Console.WriteLine(x + ". " + prodSplit[0]);
                                    x++;

                                }
                                else if (!line.Contains(CustomerName))
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
                            continue;
                        }

                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("This user does not exist \n");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }

                    }

                    if (admin.Equals(Choice.Transactions))
                    {

                        continue;
                    }
                    break;


            }

            if (admin.Equals(Choice.Exit))
            {
                break;
            }
        }
    }

}
