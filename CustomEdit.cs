using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebShop1;

public class CustomEdit
{

    public static void Username()
    {
        string[] custList = File.ReadAllLines("../../../customer.txt");

        Console.Clear();
        Console.WriteLine("Edit\n");
        Console.WriteLine("Current Username: \n");
        string oldUsername = Console.ReadLine();

        while (oldUsername.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.Write("Current Username: ");
            oldUsername = Console.ReadLine();
        }

        for (int i = 0; i < custList.Length; i++)
        {
            string line = custList[i];
            List<string> user = new List<string>(line.Split(","));
            if (user[0] == oldUsername) //Admin writes old username //then Admin writes new username // then new username replaces the old username
            {
                Console.WriteLine("\nNew Username(Only English letters): \n");
                string newUsername = Console.ReadLine();
                //line.Replace(oldUsername, newUsername);

                while (newUsername.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Username: ");
                    newUsername = Console.ReadLine();
                }
                while (!Regex.IsMatch(newUsername, @"^[a-zA-Z-0-9]+$"))
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("Username can ONLY use English letters, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Username(Only English letters): ");
                    newUsername = Console.ReadLine();
                }

                custList[i] = newUsername + "," + user[1];
                File.WriteAllLines("../../../customer.txt", custList);

                Console.Clear();
                Console.WriteLine("You have succefully changed your username to: " + newUsername + "\nPress any key to continue\n");
                Console.ReadKey();
                Admin.AdminLogin();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Edit\n");
                Console.WriteLine("The username or password is incorrect\n");
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
            }
            break;
        }
    }

    public static void Password()
    {
        string[] custList = File.ReadAllLines("../../../customer.txt");

        Console.Clear();
        Console.WriteLine("Edit\n");
        Console.WriteLine("Username: \n");
        string username = Console.ReadLine();
        Console.WriteLine("Current Password: \n");
        string oldPassword = Console.ReadLine();

        while (oldPassword.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Edit\n");
            Console.Write("Current Password: ");
            oldPassword = Console.ReadLine();
        }

        for (int i = 0; i < custList.Length; i++)
        {
            string line = custList[i];
            List<string> user = new List<string>(line.Split(","));
            if (user[0] == username && user[1] == oldPassword) //Admin writes old username //then Admin writes new username // then new username replaces the old username
            {
                Console.WriteLine("\nNew Password(min. 6 characters & Only English letters): \n");
                string newPassword = Console.ReadLine();
                //line.Replace(oldUsername, newUsername);

                while (newPassword.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("You can NOT leave this blank, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Password: ");
                    newPassword = Console.ReadLine();
                }
                while (newPassword.Length < 6 || !Regex.IsMatch(newPassword, @"^[a-zA-Z-0-9]+$"))
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.WriteLine("Password can NOT be less than 6 characters & can ONLY use English letters, Press anywhere if you understand");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("New Password(Only English letters): ");
                    newPassword = Console.ReadLine();
                }

                custList[i] = user[0] + "," + newPassword;
                File.WriteAllLines("../../../customer.txt", custList);

                Console.Clear();
                Console.WriteLine("You have succefully changed your username to: " + newPassword + "\nPress any key to continue\n");
                Console.ReadKey();
                Admin.AdminLogin();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Edit\n");
                Console.WriteLine("The username or password is incorrect\n");
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
                break;
            }
        }
    }
}

