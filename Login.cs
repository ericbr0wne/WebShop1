using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop1;

public class Login
{
    public static void Loginfunction()
    {
        Console.Clear();
        string[] loginList = File.ReadAllLines("../../../customer.txt");

        Console.WriteLine("Login\n");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("\nPassword: ");
        string password = Console.ReadLine();

        while (username.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Login\n");
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Login\n");
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
        }

        foreach (string login in loginList)
        {
            List<string> user = new List<string>(login.Split(","));
            if (user[0] == username && user[1] == password)
            {
                Console.Clear();
                Console.WriteLine("Login\n");
                Console.WriteLine("Welcome " + username);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Login\n");
                Console.WriteLine("Your username or password is incorrect\n");
                Console.WriteLine(username + " or " + password);
            }
        }
    }
}
