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
    public static void Page()
    {
        Console.Clear();
        string[] loginList = File.ReadAllLines("../../../customer.txt");
        string[] adminList = File.ReadAllLines("../../../Admin.txt");
               
        Console.WriteLine("**********LOGIN************");
        Console.WriteLine("Leave empty to exit");
        Console.WriteLine();
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("\nPassword: ");
        string? password = Console.ReadLine();

        bool customerCheck = true;
        bool adminCheck = true;
        
        if (customerCheck)
        {

            foreach (string login in loginList)
            {
                List<string> customer = new List<string>(login.Split(","));
                if (customer[0] == username && customer[1] == password)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome " + username);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadKey();
                    File.WriteAllText("../../../LoggedIn.txt", username + "," + password);

                    Customer.LoginMenu();
                    customerCheck = false;
                    break;
                }
                else if (customer[0] != username && customer[1] != password)
                {
                    continue;
                }
            }

        }
        if (adminCheck)
        {
            foreach (string adminLine in adminList)
            {
                List<string> adminInfo = new List<string>(adminLine.Split(","));

                if (adminInfo[0] == username && adminInfo[1] == password)
                {

                    File.WriteAllText("../../../LoggedIn.txt", username + "," + password);
                    Admin.AdminLogin();
                    adminCheck = false;
                    break;
                }
                else if (adminInfo[0] != username && adminInfo[1] != password)
                {
                    continue;
                }

            }
            if (customerCheck && adminCheck)
            {
                Console.Clear();
                Console.WriteLine("Your username or password is incorrect\n");
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();

            }
        }

    }
  
}


