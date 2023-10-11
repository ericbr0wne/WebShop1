using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop1;

public class Admin : Product
{

    //Hardcode adminUsername + password

    // Foreach customer in customerCSV, writeline
    // edit costumerInformation
    // Possibility to read shoppingcartCSV
    // possibility to read transactionsCSV

    // <add remove customerlist>



    public static void AdminLogin(string[] args)
    {
        bool adminCheck = true;

        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../Product.txt");

        while (adminCheck)
        {

            Console.WriteLine("Hello Admin\n");
            Console.WriteLine("Please choose from below:\n");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Check costumer list");
            Console.WriteLine("4. Edit costumer information");
            Console.WriteLine("5. Check costumer shoppingcart");
            Console.WriteLine("6. Check costumer transactions");
            Console.WriteLine("7. Logout");

            switch (Console.ReadLine())
            {
                case "1":
                    // Console.WriteLine("1. Add product");
                    Console.Clear();
                    Console.WriteLine("What product would you like to add?\n");
                    string? newProd = Console.ReadLine() + ",";
                    Console.WriteLine("\nAnd what price should it have?\n");
                    int newPrice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("You have now added: \n");
                    Console.WriteLine(newProd + newPrice);
                    product.Add(newProd, newPrice);

                    break;

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

            }
            break;
        }
    }



}
