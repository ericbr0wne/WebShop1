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
            if (admin.Equals(Choice.Main))
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
                            Console.ReadKey();
                            break;
                    }

                    if (admin.Equals(Choice.AddProduct))
                    {
                        Product.AddProduct();
                        admin = Choice.Main;
                    }

                    if (admin.Equals(Choice.RemoveProduct))
                    {
                        Product.RemoveProduct();
                        admin = Choice.Main;
                    }

                    if (admin.Equals(Choice.CheckCustomer))
                    {
                        Customer.ReadInfo();
                        admin = Choice.Main;
                    }

                    if (admin.Equals(Choice.EditCustomer))
                    {
                        Customer.Edit();
                        admin = Choice.Main;
                    }

                    if (admin.Equals(Choice.CustomerCart))
                    {
                        ShoppingCart.AdminCheck();
                        admin = Choice.Main;
                    }

                    if (admin.Equals(Choice.Transactions))
                    {
                        Receipt.AdminCheck();
                        admin = Choice.Main;
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
