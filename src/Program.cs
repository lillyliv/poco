using System;
using System.Threading;

namespace poco
{
    class consoleStuff
    {

        public static int origRow = 0;
        public static int origCol = 0;

        public static void writeAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
    class Program
    {
        public static bool alt = false;
        public static bool shift = false;
        public static bool control = false;
        /*
        mode: 0 = type
        mode: 1 = normal
        */
        public static byte mode = 1;
        public static bool toQuit = false;

        public static ushort width;
        public static ushort height;
        public static ushort cursorx = 0;
        public static ushort cursory = 0;

        public static char key;
        public static ConsoleKeyInfo cki = new ConsoleKeyInfo();
        public static ConsoleKeyInfo keyInfo;

        static void Main(string[] args)
        {
            //consoleStuff.writeAt("hello world", 0, 0);
            do
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(10); // Loop until input is entered.
                cki = Console.ReadKey(true);

                width = (ushort)Console.WindowWidth;
                height = (ushort)Console.WindowHeight;
                keyInfo = cki;
                key = keyInfo.KeyChar;


                HandleInput.main();

            } while (toQuit == false);
        }
    }
}
