using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebShop1;

public class Customer : Product
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

    public static void CustomerLogin()
    {


        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");
        bool CustomerCheck = true;

        while (CustomerCheck)
        {
            Console.Clear();
            Console.WriteLine("Please choose from below:\n");
            Console.WriteLine("1. Browse products");
            Console.WriteLine("2. Check your shoppingcart");
            Console.WriteLine("3. Check your finished transactions");
            Console.WriteLine("4. Logout");



            int customerChoice = 0;
            string? customerInput = Console.ReadLine();
            switch (customerChoice)
            {
                case 0:
                    switch (customerInput)
                    {
                        case "1":
                            customerChoice = 1;
                            break;
                        case "2":
                            customerChoice = 2;
                            break;
                        case "3":
                            customerChoice = 3;
                            break;
                        case "4":
                            customerChoice = 6;
                            CustomerCheck = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No valid option, Try again.\n");
                            break;
                    }



                    if (customerChoice == 1) // read in product list
                    {
                        Console.Clear();
                        NrAndReadProductList();
                        //menu för vill du adda till cart eller gå tillbaka till meny
                        ShoppingCart.AddCart();
                        

                        bool addCustCart = true;
                        while (addCustCart)
                        {
                            ShoppingCart.LastCart();
                            string[] Latest = File.ReadAllLines("../../../Latest.txt");
                            Console.Clear();
                            Console.WriteLine("You added " + Latest[Latest.Length -1] + " to your list");
                            Console.WriteLine("What do you want to do now?\n");
                            Console.WriteLine("1. Open your shopping cart");
                            Console.WriteLine("2. Add more producs to your cart");
                            Console.WriteLine("3. Remove product(s) from your cart");
                            Console.WriteLine("4. Return to customer menu");

                            customerInput = Console.ReadLine();
                            switch (customerInput)
                            {
                                case "1":
                                    ShoppingCart.ReadCart();
                                    Console.WriteLine("Press any key to go back to the menu");
                                    Console.ReadKey();
                                    //call shopping cart menu
                                    continue;
                                case "2":
                                    ShoppingCart.ReadCart();
                                    ShoppingCart.AddCart();
                                    continue;
                                case "3":
                                    ShoppingCart.ReadCart();
                                    ShoppingCart.RemoveCart();
                                    continue;
                                case "4":
                                    addCustCart = false;
                                    continue;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("No valid option, Try again.");
                                    break;
                            }
                        }
                    }

                    if (customerChoice == 2) // check shoppingcart
                    {
                        while (customerChoice == 2)
                        {
                            ShoppingCart.ReadCart();
                            Console.WriteLine();
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("1. Do you want to checkout");
                            Console.WriteLine("2. Do you want to add products");
                            Console.WriteLine("3. Do you want to remove products");
                            customerInput = Console.ReadLine();
                            switch (customerInput)
                            {
                                case "1":
                                    customerChoice = 7;
                                    break;
                                case "2":
                                    customerChoice = 8;
                                    break;
                                case "3":
                                    customerChoice = 3;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("No valid option, Try again.\n");
                                    break;

                        

                            }
                            if (customerChoice == 3)
                            {
                                ShoppingCart.ReadCart();
                                ShoppingCart.RemoveCart();
                            }
                            if (customerChoice == 8)
                            {
                                ShoppingCart.ReadCart();
                                ShoppingCart.AddCart();
                            }
                            if (customerChoice == 7)
                            {
                                Console.Clear();
                                Console.WriteLine("You payed!\nGOOD JOB");
                                Console.ReadKey();
                            }
                        }
                        if (customerChoice == 6)
                        {

                        }
                        break;
                    }
                    break;
            }
        }
    }
}


/*
read shoppingcartCSV(if already existing, read and continue to add in previous file)
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











// Namn = username 
//foreach(cehck if each [] has Namn)
//then we know who is loged in and who we are suppsoed to gife transaction history to
//txt.txt = trans history = Namn,äpple,äpple,vodka,12.20.05.10
//add split and write it out and we have trnas history