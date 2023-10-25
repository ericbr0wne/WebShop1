
using System.Threading.Channels;

namespace WebShop1;

public class NewUser
{

    public static void Create()
    {
        string username = Console.ReadLine() ?? string.Empty;

        string[] users = File.ReadAllLines("users.csv");

        bool exists = false;
        foreach (string user in users)
        {
            if (user.Split(",")[0].Equals(username))
            {
                Console.WriteLine("User already exists");
                exists = true;
            }

            if (!exists)
            {
                string password = Console.ReadLine() ?? string.Empty;
                string newUser = $"{username}, {password}{Environment.NewLine}";
                File.AppendAllText("users.csv", newUser);
            }
        }
    }

    public static void Setup()
    {
        if (!File.Exists("users.csv"))
        {
            File.Create("users.csv").Close();
        }
    }


    public static void CreateFile()
    {
        string username = Console.ReadLine() ?? string.Empty;

        string[] users = File.ReadAllLines("users.csv");

        bool exists = false;
        foreach (string user in users)
        {
            if (user.Split(",")[0].Equals(username))
            {
                Console.WriteLine("User already exists");
                exists = true;
            }

            if (!exists)
            {

                string password = Console.ReadLine() ?? string.Empty;
                string newUser = $"{username}, {password}{Environment.NewLine}";
                File.AppendAllText("users.csv", newUser);
            }
        }
    }
}
