using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop1;

public class Register
{   public static void RegisterCustomer()
    {
        Console.Clear();
        Console.WriteLine("Register\n");
        Console.Write("New Username: ");
        string username = Console.ReadLine();

        while (username.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Register");
            Console.WriteLine();
            Console.WriteLine("You CAN NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Register");
            Console.WriteLine();
            Console.Write("New Username: ");
            username = Console.ReadLine();

        }


        Console.WriteLine();
        Console.Write("New Password (min. 6 characters): ");
        string password = Console.ReadLine();

        if (password.Length < 6)
        {
            Console.Clear();
            Console.WriteLine("Register");
            Console.WriteLine();
            Console.WriteLine("Password CAN NOT be less than 6 characters, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Register");
            Console.WriteLine();
            Console.WriteLine("New Username: " + username);    
            Console.WriteLine();
            Console.Write("New Password: ");
            password = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Register");
        Console.WriteLine();
        Console.WriteLine("Thank you for signing up " + username + "\nPress any key to continue\n");
        Console.ReadKey();

        
        File.AppendAllText("../../../Register.txt", $"{username}+{password}" + Environment.NewLine);
        string[] registerList = File.ReadAllLines("../../../Register.txt");
    }
    
}
