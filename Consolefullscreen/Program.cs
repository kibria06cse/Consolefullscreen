using System;
using System.Runtime.InteropServices;

namespace Consolefullscreen
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        static void Main(string[] args)
        {
            var isFullScreen = CheckIfFullScreen();
            if (isFullScreen)
                Console.WriteLine("You screen is full screen mode.");
            else
                Console.WriteLine("You screen is not full screen mode.");
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            ShowWindow(ThisConsole, MAXIMIZE);
            Console.ReadLine();
        }

        private static bool CheckIfFullScreen()
        {
            var windowHeight = Console.WindowHeight;
            var windowWidth = Console.WindowWidth;

            if (windowWidth == Console.LargestWindowWidth && windowHeight == Console.LargestWindowHeight)
                return true;

            return false;
        }
    }
}
