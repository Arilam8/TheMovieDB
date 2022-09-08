using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Utils.ConsoleUtils;
using Utils.TextUtils;

namespace GenerateDB.Utils
{
    static class MenuConsole
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        static public int Menu(List<string> options)
        {
            int select = 0;
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                DisplayMenu(options, select);
                consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.LeftArrow || consoleKeyInfo.Key == ConsoleKey.RightArrow)
                    select = Select(consoleKeyInfo.Key, select, options.Count - 1);
                if (consoleKeyInfo.Key != ConsoleKey.Enter)
                    ConsoleUtils.ClearLine(TextUtils.GetTextListLength(options) + (4 * options.Count), false);
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
            Console.Write("\n");
            return select;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="select"></param>
        /// <param name="maxSelect"></param>
        /// <returns></returns>
        static private int Select(ConsoleKey key, int select, int maxSelect)
        {
            if (key == ConsoleKey.RightArrow && select < maxSelect)
                select++;
            if (key == ConsoleKey.LeftArrow && select > 0)
                select--;
            return select;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="select"></param>
        static private void DisplayMenu(List<string> options, int select)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (i == select)
                    ConsoleUtils.DisplayWithColor(options[i], false, ConsoleColor.Black, ConsoleColor.White);
                else
                    ConsoleUtils.DisplayWithColor(options[i], false, ConsoleColor.White, ConsoleColor.Black);
                if(i != options.Count - 1)
                    Console.Write("\t");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        static public bool ChoiceYesNo(int choice)
        {
            return choice == 0 ? true : false;
        }
    }
}
