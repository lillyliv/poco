using System;
using System.Threading;

namespace poco
{
    class Program
    {
        public static bool alt = false;
        public static bool shift = false;
        public static bool control = false;
        /*
        mode: 0 = type
        mode: 1 = normal
        */
        //public static byte mode = 1;
        public static bool toQuit = false;

        public static ushort width;
        public static ushort height;
        public static ushort cursorx = 0;
        public static ushort cursory = 0;

        public static char key;
        public static ConsoleKeyInfo cki = new ConsoleKeyInfo();
        public static ConsoleKeyInfo keyInfo;

        public static string[] currentFileData;

        static void Main(string[] args)
        {
            //consoleStuff.writeAt("hello world", 0, 0);
            width = (ushort)Console.WindowWidth;
            height = (ushort)Console.WindowHeight;

            //ConsoleFuncs.writeLine("hello world", 1);
            //Console.SetCursorPosition(cursorx, cursory);

            Files.loadFile(args[0]);
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