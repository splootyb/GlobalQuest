using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class UiTools
    {
        static string Title = "██╗      ██████╗  ██████╗ █████╗ ██╗      ██████╗ ██╗   ██╗███████╗███████╗████████╗\r\n██║     ██╔═══██╗██╔════╝██╔══██╗██║     ██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝\r\n██║     ██║   ██║██║     ███████║██║     ██║   ██║██║   ██║█████╗  ███████╗   ██║   \r\n██║     ██║   ██║██║     ██╔══██║██║     ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   \r\n███████╗╚██████╔╝╚██████╗██║  ██║███████╗╚██████╔╝╚██████╔╝███████╗███████║   ██║   \r\n╚══════╝ ╚═════╝  ╚═════╝╚═╝  ╚═╝╚══════╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝";
        static string SillyTitle = "   ██████╗      ██████╗ ██╗   ██╗███████╗███████╗████████╗\r\n██╗╚════██╗    ██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝\r\n╚═╝ █████╔╝    ██║   ██║██║   ██║█████╗  ███████╗   ██║   \r\n██╗ ╚═══██╗    ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   \r\n╚═╝██████╔╝    ╚██████╔╝╚██████╔╝███████╗███████║   ██║   \r\n   ╚═════╝      ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝";
        public static void WriteTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if(!Config.GetBool("FirstTitle"))
            {
                Config.SetBool("FirstTitle", true);
                Console.WriteLine(Title);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Random R = new Random();
            if(R.Next(0, 250) == 1)
            {
                Console.WriteLine(SillyTitle);
            }
            else
            {
                Console.WriteLine(Title);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string WriteControls(List<string> Controls)
        {
            int TopHeight = Console.CursorTop;
            int Selected = 0;
            bool Complete = false;
            bool ReControl = Config.GetBool("ReControl");
            while(!Complete)
            {
                Console.CursorTop = TopHeight;
                Console.CursorLeft = 0;
                for(int i = 0; i < Controls.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if(i == Selected && !ReControl)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("> ");
                    }
                    else if(ReControl)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if(ReControl && i < 11)
                    {
                        if(i == 10)
                        {
                            Console.Write($"[{0}] ");
                        }
                        else
                        {
                            Console.Write($"[{i+1}] ");
                        }
                    }
                    Console.WriteLine(Controls[i] + "  ");
                }
                ConsoleKeyInfo Key = Console.ReadKey();
                if(Console.CursorLeft > 0)
                    Console.CursorLeft -= 1;
                Console.Write(" ");
                switch(Key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveSound();
                        if(Selected > 0)
                        {
                            Selected -= 1;
                        }
                        else
                        {
                            Selected = Controls.Count - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSound();
                        if(Selected < Controls.Count - 1)
                        {
                            Selected += 1;
                        }
                        else
                        {
                            Selected = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        InteractSound();
                        return Controls[Selected];

                    default:
                        if(char.IsDigit(Key.KeyChar))
                        {
                            Selected = int.Parse(Key.KeyChar.ToString()) - 1;
                            if(Selected > Controls.Count - 1)
                            {
                                Selected = Controls.Count - 1;
                            }
                            else
                            {
                                return Controls[Selected];
                            }
                        }
                        break;
                }
            }
            return Controls[Selected];
        }

        public static void ShowBanner(string Message)
        {
            bool Light = Config.GetBool("LightMode");
            Console.ForegroundColor = ConsoleColor.Cyan;

            int Width = Console.WindowWidth - 2;
            string Top = "┏";
            string Mid = "┃";
            string Low = "┗";

            Message = " " + Message;
            Mid += Message;

            for (int i = 0; i < Width - Message.Length - 1; i++)
            {
                Mid += " ";
            }

            for (int i = 0; i < Width - 1; i++)
            {
                Top += "━";
                Low += "━";
            }
            Top += "┓\n";
            Mid += "┃\n";
            Low += "┛\n";
            Console.Write(Top + Mid + Low);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowBanner(string Message, ConsoleColor Color)
        {
            bool Light = Config.GetBool("LightMode");
            Console.ForegroundColor = Color;

            int Width = Console.WindowWidth - 2;
            string Top = "┏";
            string Mid = "";
            string Low = "┗";

            for (int i = 0; i < Width - 1; i++)
            {
                Top += "━";
                Low += "━";
            }
            Top += "┓\n";
            Low += "┛\n";

            int li = 0;
            for(int i = 0; i < Message.Length - 1;)
            {
                if (li == 0)
                {
                    Mid += "┃ ";
                    li++;
                }
                else if (li == 1)
                {
                    li++;
                }
                else if (li == Console.WindowWidth - 3)
                {
                    Mid += " ┃\n";
                    li = 0;
                }
                else
                {
                    Mid += Message[i];
                    i++;
                    li++;
                }
            }
            if(li < Console.WindowWidth - 1)
            {
                for(int i = 0; i < Console.WindowWidth - li - 2; i++)
                {
                    Mid += " ";
                }
            }
            Mid += "┃\n";
            Console.Write(Top + Mid + Low);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MoveSound()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Beep(200, 50);
            }
        }

        public static void InteractSound()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Beep(500, 50);
                Console.Beep(900, 75);
            }
        }
    }

}
