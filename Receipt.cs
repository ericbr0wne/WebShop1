using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop1;

public class Receipt
{

    //transaction
    //listofPurchasedProducts

    //totalCost
    public static void TotalCost() //calculate and show total cost
    {
        

        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] shoppingCartList = File.ReadAllLines("../../../ShoppingCart.txt");
        int cartSum = 0;
        int x = 1;

        foreach (var line in shoppingCartList)
        {
            string[] splitLine = line.Split(",");
            int.TryParse(splitLine[1], out int price);
            cartSum += price;
        }
        Console.WriteLine("This is in your receipt: ");
        foreach (string line in shoppingCartList)
        {
            string[] splitLine = line.Split(",");
            Console.WriteLine(x + ". " + splitLine[0]);
            x++;
        }
        Console.WriteLine();
        Console.WriteLine("Total sum: " + cartSum + ":-");
    }

    //timeDateStamp


    public static void ThreeWaySplit()
    {
        Console.WriteLine("** MEGA 3WAY SPLIT **");
        Console.Clear();
        Dictionary<string, int> customerList = new Dictionary<string, int>();
        string[] custList = File.ReadAllLines("../../../Customer.txt");

        foreach (string line in custList)
        {
            string[] splitLineOne = line.Split("+");
            string[] splitOne = splitLineOne[0].Split(",");
            Console.WriteLine();
            Console.WriteLine("User: " + splitOne[0]);

            string split2 = splitLineOne[1];
            string[] splitLineTwo = split2.Split("-");
            string[] splitTwo = splitLineTwo[0].Split(",");
            Console.WriteLine();
            Console.WriteLine("prod : " + splitTwo[0] + "\nprice : " + splitTwo[1]);

            string split3 = splitLineTwo[1];
            string[] splitThree = split3.Split(",");
            Console.WriteLine();
            Console.WriteLine("Date: " + splitThree[0] + "\nTime: " + splitThree[1]);

            Console.WriteLine("\n");
            Console.WriteLine("Press enter to return");
            Console.ReadKey();

        }

    }



}
