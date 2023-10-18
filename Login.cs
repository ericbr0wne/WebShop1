using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop1;

public class Login
{
    public static void LoginCustomerAdmin()
    {
        Console.Clear();
        string[] loginList = File.ReadAllLines("../../../customer.txt");
        string[] adminList = File.ReadAllLines("../../../Admin.txt");

        List<string> cartList = File.ReadAllLines("../../../LoggedIn.txt").ToList();

        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("\nPassword: ");
        string? password = Console.ReadLine(); 

        while (username.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Username: ");
            username = Console.ReadLine();

        }
        bool userfail = true;
        bool adminfail = true;

        Console.WriteLine("**********LOGIN************");
        Console.WriteLine("Leave empty to exit");
        Console.Write("Write your Username:");
        string username = Console.ReadLine();

        Console.WriteLine();
        Console.Write("Write your Password: ");
        string password = Console.ReadLine();




        string? custName = string.Empty;
        string? custPass = string.Empty;
        bool loginAccepted = true;
        if (loginAccepted)
        {

            foreach (string login in loginList)
            {

                List<string> user = new List<string>(login.Split(","));
                if (user[0] == username && user[1] == password)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome " + username);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadKey();
                    File.WriteAllText("../../../LoggedIn.txt", username+","+password);

                    Customer.CustomerLogin();
                    userfail = false;
                    break;
                }
                else if (user[0] != username && user[1] != password)
                {
                    continue;
                }


                Console.Clear();
                Console.WriteLine("Login\n");
                Console.WriteLine("Welcome " + username);
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
                custName = username;
                custPass = password;
                Customer.CustomerLoginMenu();

            }
        }
        if (loginAccepted)
        {

            foreach (string adminLine in adminList)
            {
                List<string> adminCheck = new List<string>(adminLine.Split(","));
                if (adminCheck[0] == username && adminCheck[1] == password)
                {

                    File.WriteAllText("../../../LoggedIn.txt", username + "," + password);
                    Admin.AdminLogin();
                    adminfail = false;
                    break;
                }
                else if (adminCheck[0] != username && adminCheck[1] != password)
                {
                    continue;

                    List<string> adminuser = new List<string>(admin.Split(","));
                    if (adminuser[0] == username && adminuser[1] == password)
                    {
                        custName = username;
                        custPass = password;
                        Admin.AdminLogin();
                    }
                    else
                    {

                        Console.Clear();
                        Console.WriteLine("Your username or password is incorrect\n");
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadKey();
                        break;
                    }

                }

            }
            if (userfail && adminfail)
            {
                Console.Clear();
                Console.WriteLine("Your username or password is incorrect\n");
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
            }
        }


    }
}


