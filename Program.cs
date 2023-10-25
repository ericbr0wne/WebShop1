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

    if (menu.Equals(Menu.Products)) //Product menu
    {
        Console.Clear();
        Console.WriteLine("These are the available products: ");
        Product.NrAndReadProductList();
        Console.WriteLine();
        Console.WriteLine("If you want to add products to your cart \nPlease login first");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Return to Main menu");
        Console.WriteLine("3. Exit WebShop1");

        switch (Console.ReadLine())
        {
            case "1":
                menu = Menu.Login; //Login menu
                continue;
            case "2":
                menu = Menu.Main; //Main menu
                continue;
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

    if (menu.Equals(Menu.Login)) //Login menu
    {
        Console.Clear();
        Console.WriteLine("Welcome to our login page.\n");

        if (true)
        {
            Login.LoginCustomerAdmin();
            menu = Menu.Main; //Main menu if costumer/admin login is incorrect 
            continue;  //continue back to the while loop start
        }


    }

    if (menu.Equals(Menu.Register))  //Register menu
    {
        Console.Clear();
        Console.WriteLine("Welcome to our register page.\n");
        Console.WriteLine("Do you want to: ");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Return to main page");
        switch (Console.ReadLine())
        {
            case "1":
                //go to register class
                Register.RegisterCustomer();
                menu = Menu.Register;
                continue;
            case "2":
                menu = Menu.Main;
                continue;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                continue;
        }
    }

    if (menu.Equals(Menu.Exit)) //Exit WebShop1
    {
        Console.Clear();
        Console.WriteLine();
        break;

    }

    string? input = Console.ReadLine();

    if (menu.Equals(Menu.Main))
    {
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
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
}

Console.WriteLine("Thank you for shopping at WebShop1. Please come again!");
