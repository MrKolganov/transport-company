using System;
using System.Collections.Generic;

namespace PPMenu
{
    public class Menu                                                   
    {
        public List<IMenuItem> MenuItems = new List<IMenuItem>();       

        private void DrawMenu()                                         
        {
            foreach (IMenuItem menuItem in MenuItems)                   
            {
                Console.WriteLine($"{menuItem.GetActivationComand()} - {menuItem.GetTitle()}");
            }

            Console.WriteLine("0 - Выход/назад");                      
        }

        public void StartMenuHandle()                                   
        {
            DrawMenu();                                                 
            Console.WriteLine("---------------------");

            string userInput = null;                                   
            int drawMenuLastLineIndex = Console.CursorTop;              

            while (userInput != "0")                                    
            {
                userInput = Console.ReadLine();                        

                foreach (IMenuItem menuItem in MenuItems)               
                {
                    if (menuItem.GetActivationComand() == userInput)
                    { 
                        Console.WriteLine("(Menu) Пользователь выбрал существующий пункт меню, управление передано Item'у");
                        Console.WriteLine("---------------------");
                        menuItem.Action();                              
                    }
                }

                int actionLastLineIndex = Console.CursorTop + 1;       
                ConsoleHelper.ClearLines(drawMenuLastLineIndex, actionLastLineIndex);
            }
        }
    }
}