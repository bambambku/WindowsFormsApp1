
Logging newLogging = new();

User userMichu = new User("Michal", "mich", "michu");
User userJamie = new User("Jamie", "jim", "mim");
User userLaurie = new User("Laurie", "laur", "lau");


List<User>? newUsers = new() { userMichu, userJamie, userLaurie };

MenuCLI newCLI = new MenuCLI(newUsers, newLogging);
newCLI.DisplayCLI();

interface IMenu
{
    public void Display();
}

class MenuCLI
{
    private Logging CLILogging { get; init; }
    public User? CurrentUser { get; set; }

    public MenuCLI(List<User>? users, Logging logging)
    {
        CLILogging = logging;
    }

    public void DisplayCLI()
    {
        Welcome();
        Login();
        Options();
    }

    

    private void Options()
    {
        Console.Clear();
        Console.WriteLine("Please choose one of the following options.");
        Console.WriteLine(@"
1) ");
    }

    public void Welcome()
    {
        RegularActions.PromptEnter("Welcome to Stock Management 3000 and half");
    }

    private void Login()
    {
        bool ifPasswordCorrect;
        do
        {
            Console.WriteLine("Please eneter password: ");
            string inputPassword = Console.ReadLine();
            ifPasswordCorrect = CLILogging.CheckPassword(inputPassword);
            if (!ifPasswordCorrect) RegularActions.PromptEnter("Wrong password. Please try again...");
        } while (!ifPasswordCorrect);
        RegularActions.PromptEnter($"Great stuff. You are now logged in as {CurrentUser.UserName}");
        
    }
}




static class RegularActions
{
    public static void PromptEnter(string comment)
    {
        Console.WriteLine(comment);
        Console.WriteLine("Press [Enter] to continue.\n");
        Console.ReadLine();
    }
}


class Logging
{
    private string _password = "asd123";

    public bool CheckPassword(string password)
    {
        return _password == password;
    }

    public void ChangePassword(string newPassword)
    {
        _password = newPassword;
    }
}





/* NOT USED FEATURES:
 
######################################################################################
------Logging feature for various users

private void Login(List<User> users)
{
    bool ifLoginCorrect;
    do
    {
        Console.WriteLine("Please enter your login: ");
        var login = Console.ReadLine();
        ifLoginCorrect = Logging.ValidateUserName(login, users);
        if (!ifLoginCorrect)
        {
            RegularActions.PromptEnter("Wrong user. Please try again.");
        }
        else
        {
            CurrentUser = users.Single(user => user.Login == login);
        }
    } while (!ifLoginCorrect);
    bool ifPasswordCorrect;
    do
    {
        Console.Clear();
        Console.WriteLine("Enter your password: ");
        var password = Console.ReadLine();
        ifPasswordCorrect = Logging.ValidatePassword(CurrentUser, password);
        if (!ifPasswordCorrect)
        {
            RegularActions.PromptEnter("\nWrong password. Please try again.");
            continue;
        }
        else
        {
            RegularActions.PromptEnter($"Great. You are logged in as {CurrentUser.UserName}.");
        }
    } while (!ifPasswordCorrect);
}

class Logging
{
    
    public static bool ValidateUserName(string userName, List<User> users)
    {
        return users.Any(user => user.Login == userName);
    }

    public static bool ValidatePassword(User user, string password)
    {
        return user.Password == password;
    }
}

#######################################################################################################



*/