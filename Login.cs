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
        Console.WriteLine("**********LOGIN************");
        Console.WriteLine("Leave blank to exit");
        Console.Write("Write your Username:");
        string username = Console.ReadLine();

        Console.WriteLine();
        Console.Write("Write your Password: ");
        string password = Console.ReadLine();



        string? custName = string.Empty;
        string? custPass = string.Empty;

        foreach (string login in loginList)
        {
            List<string> user = new List<string>(login.Split(","));
            if (user[0] == username && user[1] == password)
            {
                Console.Clear();
                Console.WriteLine("Login\n");
                Console.WriteLine("Welcome " + username);
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
                custName = username;
                custPass = password;
                Customer.CustomerLoginMenu();
            }
            else if (user[0] != username && user[1] != password)
            {
                foreach (string admin in adminList)
                {
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
                break;
            }
        }
    }
}

