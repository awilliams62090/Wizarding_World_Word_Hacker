using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Terminal Hacker Game Theme: Harry Potter!!
    // Easy Level: Break Into The Leaky Cauldron 
    // Easy Words: "Wizard", "Hagrid", "Wand", "Spell", "Magic"

    // Medium Level: Break Into Hogwarts 
    // Medium Words: "Potion", "Hermione", "Quidditch", "Rememberall", "Herbology"

    // Hard Level: Break OUT of Azkaban 
    // Hard Words: "Xenophilius", "Bellatrix", "Dementor", "Basilisk", "Acromantula"

    //memberVariables

    //Game Configuration Data
    string menuPrint = "You may type menu at any time";
    string[] level1Passwords = { "wizard", "hagrid", "wand", "spell", "magic" };
    string[] level2Passwords = { "potion", "hermione", "quidditch", "rememberall", "herbology" };
    string[] level3Passwords = { "xenophilius", "bellatrix", "dementor", "basilisk", "acromantula" };

    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        print("Game Init");
        ShowMainMenu("Welcome to the Wizarding World Hacker");

    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where in the wizarding world would you like to break into?");
        Terminal.WriteLine("=================/////=================");
        Terminal.WriteLine("Press 1 to head to the Leaky Cauldron!");
        Terminal.WriteLine("Press 2 to head to Hogwarts!");
        Terminal.WriteLine("Press 3 to escape from Azkaban!");
        Terminal.WriteLine("Enter your selection below");
    }

    //OnUserInput is called whenever the user hits return after having typed character(s)
    void OnUserInput(string input)
    {
        print("The user chose " + input);
        // We can always go directly to the main menu 
        if (input == "menu")
        {
            ShowMainMenu("Welcome to the Wizarding World Hacker");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
            Terminal.WriteLine(menuPrint);
        }
        else if (input == "9.75")
        { //easter egg
            Terminal.WriteLine("Uh oh! Looks like Dobby sealed the platform on you!");
            ShowMainMenu("Try another selection Wizard...");
        }
        else
        {
            Terminal.WriteLine("Even Alohomora won't work where you are trying to go!");
            ShowMainMenu("Try another selection Wizard...");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the Password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                print(password);
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                print(password);
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                print(password);
                break;
            default:
                Debug.LogError("Invalid Level");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuPrint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
  .   *   ..  . *  *
*  * @()Ooc()*   o  .
    (Q@*0CG*O()  ___
   |\_________/|/ _ \
   |  |  |  |  | / | |
   |  |  |  |  | | | |
   |  |  |  |  | \_| |
   |  |  |  |  |\___/
   |\_|__|__|_/|
    \_________/"

                );
                Terminal.WriteLine("You made it! Have a pint!");
                break;
            case 2:
                Terminal.WriteLine("Looks like your ready to head to school!");
                Terminal.WriteLine(@"
            _
      /b_,dM\__,_
    _/MMMMMMMMMMMm(
  `MMMMMM/   /   \   _   ,    
   MMM|  __  / __/  ( |_|
   YMM/_/# \__/# \    | |ogwarts is 
   (.   \__/  \__/       
     )       _,  |    ready for you!
_____/\     _   /       
    \  `._____,'
     `..___(__
              )"

                );
                break;
            case 3:
                Terminal.WriteLine(@"
                
           +          
  \        |         /
   \      / \      /
     \  /_____\  /
     /  |__|__|  \
   /  |;|     |;|  \
 /    \\.    .  /    \
       ||:   , | /`\
       ||: _ . |                             
      _||_| |__|                      
 ____~    |_|  |___"


                );
                Terminal.WriteLine("You've done it! Now get out now, before the dementors find you!!");
                break;
            default:
                Debug.LogError("Invalid Entry");
                break;

        }


    }
}
