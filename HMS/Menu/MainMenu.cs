using HMS.Context;

namespace HMS.Menu
{
    public class MainMenu
    {
        private bool Flag = true;
        private readonly UserMenu userMenu;
        private readonly CustomerMenu customerMenu;
        public MainMenu(HMSDbContext dbContext)
        {
            userMenu = new UserMenu(dbContext);
            customerMenu = new CustomerMenu(dbContext);
        }
        public void Menu()
        {
            while (Flag)
            {
                PrintCustomerMenu();
                var option = HandleSelection(Console.ReadLine());
                HandleCustomerMenu(option);
            }
            Console.WriteLine("Thank you for using our application");
        }

        public void PrintMainMenu()
        {
            Console.WriteLine("Enter 1 To Register");
            Console.WriteLine("Enter 2 To Login");
            Console.WriteLine("Enter 0 To Quit");
        }

        public void HandleMainMenu(int option)
        {
            switch (option)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

        public void HandleUserMenu(int option)
        {
            switch (option)
            {
                case 1:
                    userMenu.Register();
                    break;
                case 2:
                    userMenu.Update();
                    break;
                case 3:
                    userMenu.List();
                    break;
                case 4:
                    userMenu.Find();
                    break;
                default:
                    Flag = false;
                    break;
            }
        }

        public void HandleCustomerMenu(int option)
        {
            switch (option)
            {
                case 1:
                    customerMenu.Register();
                    break;
                case 2:
                    customerMenu.Update();
                    break;
                case 3:
                    customerMenu.List();
                    break;
                case 4:
                    customerMenu.Find();
                    break;
                default:
                    Flag = false;
                    break;
            }
        }

        public void PrintUserMenu()
        {
            Console.WriteLine("Enter 1 To Register User");
            Console.WriteLine("Enter 2 To Edit User");
            Console.WriteLine("Enter 3 To List User");
            Console.WriteLine("Enter 4 To Find User");
            Console.WriteLine("Enter 0 To Go Back");
        }

        public void PrintCustomerMenu()
        {
            Console.WriteLine("Enter 1 To Register Customer");
            Console.WriteLine("Enter 2 To Edit Customer");
            Console.WriteLine("Enter 3 To List Customer");
            Console.WriteLine("Enter 4 To Find Customer");
            Console.WriteLine("Enter 0 To Go Back");
        }

        public int HandleSelection(string selection)
        {
            int option;
            while(!int.TryParse(selection, out option))
            {
                Console.WriteLine("Enter option again: ");
                selection = Console.ReadLine();
            }
            return option;
        }
    }
}
