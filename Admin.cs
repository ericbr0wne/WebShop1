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
            Console.WriteLine("*********** Admin ***********\n");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Check costumer list");
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
                            adminChoice = 7;
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

                    if (adminChoice == 3)
                    {

                    }
                    break;





                    /*



                          case "2":
                              //Console.WriteLine("2. Remove product");
                              Console.WriteLine("Which item would you like to remove?\n");
                              Product.NrAndReadProductList();
                              Console.WriteLine();
                              string? productRemove = Console.ReadLine();
                              foreach (string Article in productList)
                              {
                                  //split by the sign ","
                                  string[] splitLine = Article.Split(",");
                                  if (productRemove == splitLine[0])
                                      product.Remove(Article);

                                  Console.WriteLine(splitLine[0] + " " + splitLine[1] + ":-");
                              }

                              break;
                          case "3":
                              // Console.WriteLine("3. Check costumer list");

                              break;
                          case "4":
                              // Console.WriteLine("4. Edit costumer information");
                              break;
                          case "5":
                              // Console.WriteLine("5. Check costumer shoppingcart");
                              break;
                          case "6":
                              // Console.WriteLine("6. Check costumer transactions");
                              break;
                          case "7":
                              //Console.WriteLine("7. Logout");
                              Console.WriteLine("You have now succesfully logged out from Admin");
                              Console.WriteLine("Please press enter to continue!");
                              Console.ReadKey();
                              adminCheck = false;
                              break;
                          default:
                              Console.Clear();
                              Console.WriteLine("You didn't pick a valid option.");
                              Console.WriteLine("Please press enter to continue!");
                              Console.ReadKey();
                              Console.Clear();
                              break;
                              */

            }
        }
    }



}
