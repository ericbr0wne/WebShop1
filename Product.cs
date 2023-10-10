using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop1;

public class Product
{
    public static void NrAndReadProductList() //add nr. and print productList
    {
        Dictionary<string, int> cartList = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");
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

}

/* Calculate the total price - DETTA FIXAR VI!!
int totalPrice = 0;

foreach (string item in addedProductList)
{

        totalPrice += 

}



*/
