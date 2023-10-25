using WebShop1;
Menu menu = Menu.Main;

while (true)
{
    if (menu.Equals(Menu.Main))
    {
        Console.Clear();
        Console.WriteLine("=============================================");
        Console.WriteLine("              Welcome to WebShop1");
        Console.WriteLine("=============================================");
        Console.WriteLine("Please choose from the options below:");
        Console.WriteLine("=============================================");
        Console.WriteLine("1. Products");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Register");
        Console.WriteLine("4. Exit");
        Console.WriteLine("=============================================");
    }

    if (menu.Equals(Menu.Main))
    {
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                menu = Menu.Products;
                break;
            case "2":
                menu = Menu.Login;
                break;
            case "3":
                menu = Menu.Register;
                break;
            case "4":
                menu = Menu.Exit;
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to break!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }

    if (menu.Equals(Menu.Products)) 
    {
        Console.Clear();
        Console.WriteLine("These are the available products: ");
        Product.Catalogue();
        Console.WriteLine();
        Console.WriteLine("If you want to add products to your cart \nPlease login first");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Return to Main menu");
        Console.WriteLine("3. Exit WebShop1");

        switch (Console.ReadLine())
        {
            case "1":
                menu = Menu.Login; 
                break;
            case "2":
                menu = Menu.Main;
                break;
            case "3":
                menu = Menu.Exit; 
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }

    if (menu.Equals(Menu.Login))
    {
        Console.Clear();
        Console.WriteLine("Welcome to our login page.\n");
        Login.Page();
        menu = Menu.Main; 
    }

    if (menu.Equals(Menu.Register))  
    {
        Console.Clear();
        Console.WriteLine("Welcome to our register page.\n");
        Console.WriteLine("Do you want to: ");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Return to main page");
        switch (Console.ReadLine())
        {
            case "1":
                Register.Customer();
                break;
            case "2":
                menu = Menu.Main;
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                break;
        }
    }

    if (menu.Equals(Menu.Exit)) 
    {
        Console.Clear();
        Console.WriteLine("Thank you for shopping at WebShop1. Please come again!");
        break;
    }
}

