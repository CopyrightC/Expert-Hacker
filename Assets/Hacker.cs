using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hacker : MonoBehaviour
{  
    const string x4 = "You can type 'menu' at instance to get back here :)";
    string[] Lvl1passw = {"Books","Librarian","Shakespeare","Novels","Stories"};
    string[] Lvl2passw = {"Password132","Policeman","Culprit","Handcuffs"};
    string[] Lvl3passw = {"Mischievous","dictionary","Terminal","Pronunciation"};
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowMainMenu() 
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Library (Easy)");
        Terminal.WriteLine("Press 2 for Police Station (Medium)");
        Terminal.WriteLine("Press 3 for Tesla (Hard)");
        Terminal.WriteLine(x4);
        Terminal.WriteLine("Enter your selection : ");
    }
    void OnUserInput(string input)
    {
        if (input == "menu"){
            
            ShowMainMenu();
            password = "";
        }
        else if (currentScreen == Screen.MainMenu){
            MainMenuInput(input);
        }
        else if(currentScreen == Screen.Password){
            checkPassword(input);

        }

    }
    void MainMenuInput(string input){
        bool ValidLvl = (input == "1" || input == "2" || input == "3");
        if (ValidLvl){
           level = int.Parse(input);
        }
        HandleInp(input);
         
    }    

    void HandleInp(string input)
    {
        if (input == "1"){
            choselevel();
            } 
            else if (input == "2"){
                choselevel();
            }
            else if (input == "3"){
                choselevel();
            }
            else if (input == "007"){
                Terminal.WriteLine("Please choose a level Mr. Bond");
            }
            else{
                Terminal.WriteLine("Please enter a valid level");
            }

    }
    void choselevel(){
        setPassw();
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password (hint:"+password.Anagram()+"):");
        currentScreen = Screen.Password;
        
    }
    void setPassw(){
        switch (level){
            case 1:
                password = Lvl1passw[Random.Range(0,Lvl1passw.Length)];
                break;
            case 2:
                password = Lvl2passw[Random.Range(0,Lvl2passw.Length)];
                break;
            case 3:
                password = Lvl3passw[Random.Range(0,Lvl3passw.Length)];
                break;
            default:
                Debug.LogError("Error!");
                break;
        }
    }
    void checkPassword(string input){
        if (input==password){
            DisplayWinSc();
        }
        else {
            Terminal.WriteLine("Sorry, that's the incorrect password   try again!");
        }
    }
    
    void DisplayWinSc(){
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        Terminal.WriteLine("You Win!");
        RewardUsr();
    }
    
    void RewardUsr(){
        
        switch (level)
        {
            case 1:
                //ascii art 
                Terminal.WriteLine(@"
Have a book you library expert...
                     _______
                    /      //
                   /      //
                  /______//
                 (______(/
                ");
                break;
            case 2:
                Terminal.WriteLine(@"
                             _ _        
You received a police badge!.          There you go :)  

            | (_)         
 _ __   ___ | |_  ___ ___ 
| '_ \ / _ \| | |/ __/ _ \
| |_) | (_) | | | (_|  __/
| .__/ \___/|_|_|\___\___|
| |                       
|_|   
                ");
                break;
            case 3:
                Terminal.WriteLine(@"
                            
You're a genius, welcome to Tesla!
 
| |          | |      
| |_ ___  ___| | __ _ 
| __/ _ \/ __| |/ _` |
| ||  __/\__ \ | (_| |
 \__\___||___/_|\__,_|
                ");
                break;
            default:
                Debug.LogError("Might be an bug!");
                break;
        }
    }
}

