using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop1;

public class Admin : Product
{
    public static void AdminLogin()
    {

        Dictionary<string, int> product = new Dictionary<string, int>();

        bool adminCheck = true;
        while (adminCheck)
        {
            Console.Clear();
            Console.WriteLine("*********** Welcome Admin ***********\n");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Check costumer information");
            Console.WriteLine("4. Edit costumer information");
            Console.WriteLine("5. Check costumer shoppingcart");
            Console.WriteLine("6. Check costumer transactions");
            Console.WriteLine("7. Logout\n");

            int adminChoice = 0;
            string? adminInput = Console.ReadLine();
            switch (adminChoice)
            {
                case 0:
                    switch (adminInput)
                    {
                        case "1":
                            adminChoice = 1;
                            break;
                        case "2":
                            adminChoice = 2;
                            break;
                        case "3":
                            adminChoice = 3;
                            break;
                        case "4":
                            adminChoice = 4;
                            break;
                        case "5":
                            adminChoice = 5;
                            break;
                        case "6":
                            adminChoice = 6;
                            break;
                        case "7":
                            adminCheck = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No valid option, Try again.\n");
                            break;
                    }



                    if (adminChoice == 1) //add product to list
                    {
                        AddProduct();
                        adminChoice = 0;
                        continue;
                    };

                    if (adminChoice == 2) //remove product from list
                    {
                        RemoveProduct();
                        adminChoice = 0;
                        continue;
                    }

                    if (adminChoice == 3) //("3. Check costumer information");
                    {
                        Customer.readAllInfo();
                        adminChoice = 0;
                        continue;
                    }

                    if (adminChoice == 4) //("4. Edit costumer information");
                    {
                        int editCustomer = 0;
                        Console.WriteLine("Do you want to:");
                        Console.WriteLine("1. Change username");
                        Console.WriteLine("2. Change password");
                        Console.WriteLine("3. Remove customer"); 
                        //IF TIME
                        //Includes to remove the customer shoppingcart.
                        switch (Console.ReadLine())
                        {
                            case "1":
                                editCustomer = 1;
                                continue;
                            case "2":
                                editCustomer = 2;
                                continue;
                          //  case "3":
                            //    editCustomer = 3;
                            //    break;
                            default:
                                Console.Clear();
                                Console.WriteLine("You didn't pick a valid option.");
                                Console.WriteLine("Please press enter to continue!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }


                    if (adminChoice == 5) //Check costumer shoppingcart
                    {
                        
                        Console.Clear();
                        // Customer.readAllInfo(); (extra?)
                        Console.WriteLine("Customer username: ");
                        string CustomerName = Console.ReadLine();

                        string CustomerCheck = File.ReadAllText("../../../customer.txt");

                        if (CustomerCheck.Contains(CustomerName)) //check if customer is in customer text file
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
                                    string[] splitLine = line.Split("+"); //usernamepassword =splitline[0] + produktpris = splitline[1]
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

                    if (adminChoice == 6) //("6. Check costumer transactions");
                    {

                        continue;
                    }

                    break;

            }
                    break;
            if (adminCheck == false)
            {
                break;
            }
        }
    }

}
