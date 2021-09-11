using System;
using System.Collections.Generic;
using System.Text;

namespace poco
{
    class HandleInput
    {
        public static void main()
        {
            checkModifiers();
            if (specialKeys() == true) return;
            if (arrowKeys() == true) return;

            consoleStuff.writeAt(Program.key.ToString(), Program.cursorx, Program.cursory);
            Program.cursorx++;
        }
        private static void checkModifiers()
        {
            if ((Program.cki.Modifiers & ConsoleModifiers.Alt) != 0)
            {
                Program.alt = true;
            }
            else
            {
                Program.alt = false;
            }
            if ((Program.cki.Modifiers & ConsoleModifiers.Shift) != 0)
            {
                Program.shift = true;
            }
            else
            {
                Program.shift = false;
            }
            if ((Program.cki.Modifiers & ConsoleModifiers.Control) != 0)
            {
                Program.control = true;
            }
            else
            {
                Program.control = false;
            }
        }
        private static bool specialKeys()
        {
            if (Program.keyInfo.Key == ConsoleKey.Backspace && Program.cursorx != 0)
            {
                consoleStuff.writeAt(" ", Program.cursorx - 1, Program.cursory);
                Program.cursorx -= 1;
                Console.SetCursorPosition(Program.cursorx, Program.cursory);
                return true;
            }
            else if (Program.keyInfo.Key == ConsoleKey.Backspace && Program.cursorx == 0 && Program.cursory != 0)
            {
                consoleStuff.writeAt(" ", Program.cursorx, Program.cursory + 1);
                Program.cursory -= 1;
                return true;

            }
            else if (Program.keyInfo.Key == ConsoleKey.Enter)
            {
                consoleStuff.writeAt("\n", Program.cursorx, Program.cursory);
                Program.cursorx = 0;
                Program.cursory += 1;
                return true;
            }
            return false;
        }
        private static bool arrowKeys()
        {
            if (Program.keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (Program.cursorx == 0) { }
                else
                {
                    Console.SetCursorPosition(Program.cursorx - 1, Program.cursory);
                    Program.cursorx--;
                    return true;
                }

            }
            else if (Program.keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (Program.cursorx == Program.height - 1) { }
                else
                {
                    Console.SetCursorPosition(Program.cursorx, Program.cursory + 1);
                    Program.cursory++;
                    return true;
                }

            }
            else if (Program.keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (Program.cursory == 0) { }
                else
                {
                    Console.SetCursorPosition(Program.cursorx, Program.cursory - 1);
                    Program.cursory--;
                    return true;
                }

            }
            else if (Program.keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (Program.cursorx == Program.width - 1) { }
                else
                {
                    Console.SetCursorPosition(Program.cursorx + 1, Program.cursory);
                    Program.cursorx++;
                    return true;
                }

            }
            return false;
        }
    }
}
