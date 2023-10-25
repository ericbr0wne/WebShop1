using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop1;

public class Register
{


    public static void Customer()
    {
        Console.Clear();
        Console.WriteLine("Register\n");
        Console.Write("New Username(Only English letters): ");
        string username = Console.ReadLine();

        while (username.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Register\n");
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Register\n");
            Console.Write("New Username: ");
            username = Console.ReadLine();
        }
        while (!Regex.IsMatch(username, @"^[a-zA-Z-0-9]+$"))
            {
            Console.Clear();
            Console.WriteLine("Register\n");
            Console.WriteLine("Username can ONLY use English letters, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Register\n");
            Console.Write("New Username(Only English letters): ");
            username = Console.ReadLine();
        }

        
        Console.Write("\nNew Password (min. 6 characters & Only English letters): ");
        string password = Console.ReadLine();

        while (password.Length < 6 || !Regex.IsMatch(password, @"^[a-zA-Z-0-9]+$"))
        {
            Console.Clear();
            Console.WriteLine("Register\n");
            Console.WriteLine("Password can NOT be less than 6 characters & can ONLY use English letters, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Register\n");
            Console.WriteLine("New Username: " + username);
            Console.Write("\nNew Password(min. 6 characters & Only English letters): ");
            password = Console.ReadLine();
        }
        
       

        Console.Clear();
        Console.WriteLine("Register\n");
        Console.WriteLine("Thank you for signing up " + username + "\nPress any key to continue\n");
        Console.ReadKey();


        File.AppendAllText("../../../customer.txt", $"{username},{password}" + Environment.NewLine);

    }

}
