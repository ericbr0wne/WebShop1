using WebShop1;

int menuChoice = 0;
while (true)
{

    if (menuChoice == 0)
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

    if (menuChoice == 1) //Product menu
    {
        Console.Clear();
        Console.WriteLine("This is our available products: ");
        Product.NrAndReadProductList();
        Console.WriteLine();
        Console.WriteLine("If you want to add products to your cart \nPlease login first");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Return to Main menu");
        Console.WriteLine("3. Exit WebShop1");

        switch (Console.ReadLine())
        {
            case "1":
                menuChoice = 2; //Login menu
                continue;
            case "2":
                menuChoice = 0; //Main menu
                continue;
            case "3":
                menuChoice = 4; //Exit
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
  
    if (menuChoice == 2) //Login menu
    {
        Console.Clear();
        Console.WriteLine("Welcome to our login page.\n");
        
        if(true)
        {
            Login.LoginCustomerAdmin();
            menuChoice = 0; //Main menu if costumer/admin login is incorrect 
            continue;  //continue back to the while loop start
        }
        
        
    }

    if (menuChoice == 3)  //Register menu
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
                menuChoice = 2;
                continue;
            case "2":
                menuChoice = 0;
                continue;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                continue;
        }
    }


    if (menuChoice == 4) //Exit WebShop1
    {
        Console.Clear();
        Console.WriteLine();
        break;

    }

    string? input = Console.ReadLine();

    switch (menuChoice)
    {
        case 0:
            switch (input)
            {
                case "1":
                    menuChoice = 1;
                    break;
                case "2":
                    menuChoice = 2;
                    break;
                case "3":
                    menuChoice = 3;
                    break;
                case "4":
                    menuChoice = 4;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You didn't pick a valid option.");
                    Console.WriteLine("Please choose 1, 2, 3 or 4.");
                    Console.WriteLine("Please press enter to continue!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            break;
    }
}

Console.WriteLine("Thank you for shopping at WebShop1. Please come again!");