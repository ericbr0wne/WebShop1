using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop1;

public class Customer
{
    public static void readAllInfo()
    {

        Console.WriteLine("*********** USER INFORMATION ***********");
        Console.Clear();
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

    /*
    read shoppingcartCSV(if already existing, read and continue to add in preious file)
    add to shoppingcartCSV
    if in shoppingcart mode:
    Do you want to exit or continue to checkout?
    1. Checkout - add to customerReceiptCSV
    2. Remove line
    3. Exit

    
    admit purchase, transfer items from shoppingcartCSV to transactionsCSV
    add individual timestamp for transactionsCSV
    save shoppingcartCSV add userName
    able to read yourCustomerReceiptCSV

    (EXAMPEL)
    äpple 2:- köpt 5/10 2023.
    <list>
    add customerName to purchase
    Benny Ahlin, äpple 2:- 5/10
    possibility to search Benny Ahlin transactions
    Admin possibility to search - Benny Ahlin transactions
    Admin possibility to search - All transactions

    

    Övrigt:
Varje transaktion ska innehålla produkter som köpts, totalsumma, tid och datum.
Använd textfiler för att läsa in initialdata och för att spara transaktionsloggar samt inloggningsinformation.

    Päron 5:-
    Apelsin 2:-
    Öl 25:-
    chips
    vodka
    ölkorv

    totalt pris: 32:-
    (date) + (timestamp) || Date&Timestamp


    */
}
