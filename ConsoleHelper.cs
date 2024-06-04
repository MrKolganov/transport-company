using System;

namespace PPMenu
{
    public static class ConsoleHelper                                              
    {
        public static void ClearLines(int startIndex, int lastIndex)               
        {
            for (int lineIndex = startIndex; lineIndex < lastIndex; lineIndex++)   
            {
                Console.SetCursorPosition(0, lineIndex);                           
                Console.Write(new string(' ', Console.WindowWidth));                
            }

            Console.SetCursorPosition(0, startIndex);                               
        }
    }
}
