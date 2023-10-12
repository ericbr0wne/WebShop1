using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace WebShop1;

public class Product
{
    public static void NrAndReadProductList() //add nr. and print productList
    {
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../Product.txt");
        int x = 1;

        for (int y = 0; y < productList.Length; y++)
        {
            string[] splitLine = productList[y].Split(",");
            if (int.TryParse(splitLine[1], out int price))
            {

                cartList.Add(splitLine[0], price);
            }
            Console.WriteLine(x + ". " + splitLine[0] + " " + splitLine[1] + ":-");
            x++;
        }
    }

    public static void AddProduct() //add Product to list
    {
        Console.Clear();
        Console.WriteLine("This is the product list:");
        NrAndReadProductList(); //read productList
        Console.WriteLine();
        Console.WriteLine("*********** Add Product *********** ");
        Console.WriteLine();
        Console.WriteLine("Enter the product name:");
        string? product = Console.ReadLine();   //Prodname
        Console.WriteLine();
        Console.WriteLine("Enter the product price:");
        string? price = Console.ReadLine();     //Prodprice
        string? prodAndPrice = product + "," + price;   //Temp hold PN "," and PP
        Console.WriteLine();
        Console.WriteLine("*********** NEW PRODUCT ***********");
        Console.WriteLine("Product: " + product + "\nPrice: " + price + ":- ");
        Console.WriteLine("\nPress enter to continue");
        File.AppendAllText("../../../Product.txt", prodAndPrice + Environment.NewLine);
        Console.ReadKey();

    }

    public static void RemoveProduct()

    {
        Console.Clear();
        Console.WriteLine("This is the product list:");
        NrAndReadProductList();
        Console.WriteLine();
        Console.WriteLine("What product do you wish to remove?");
        Console.WriteLine();

        {
            List<string> prodList = File.ReadAllLines("../../../Product.txt").ToList(); //To be able to remove from list
            string[] shoppingCartList = File.ReadAllLines("../../../Product.txt"); //To be able to count
            Console.WriteLine();
            string? input = Console.ReadLine();

            for (int i = 0; i <= shoppingCartList.Length; i++)
            {
                if (input == i.ToString())
                {
                    prodList.RemoveAt(i - 1);
                    File.WriteAllLines("../../../Product.txt", prodList);
                }
            }
        }
    }

}