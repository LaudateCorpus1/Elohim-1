using System;
using System.IO;
using System.Threading;
using System.Reflection;

namespace elohim
{
    class Program
    {

        static ConsoleColor myColor;

        static void Main(string[] args)
        {
            color();//color picking
            Console.ForegroundColor = myColor;//setting color
            int x = 0;
            string numberIn = "";
            do
            {
                Console.Write("Number of blinks: ");
                numberIn = Console.ReadLine();
            } while (Int32.TryParse(numberIn,out x) == false);
            
            Console.Clear();
            for (int i = 0; i < x; i++)
            {
                readfile(elohim.Properties.Resources.eye);
                Thread.Sleep(7000);
                Console.Clear();
                readfile(Properties.Resources.eye2);
                Thread.Sleep(200);
                Console.Clear();
                readfile(Properties.Resources.eye3);
                Thread.Sleep(300);
                Console.Clear();
                readfile(Properties.Resources.eye2);
                Thread.Sleep(200);
                Console.Clear();
            }
        }

        static void readfile(byte[] file)//read from the resource files
        {
            MemoryStream sr = new MemoryStream(file,false);
            int line;
            while ((line = sr.ReadByte()) != 'S')
            {
                Console.Write((char)line);
            }

            sr.Close();
        }

        static void color()//user picks a color
        {
            bool picking = true;
            while (picking)
            {
                Console.Write("Choose a color [Green,Blue,Red,White]:");
                string color = Console.ReadLine().ToLower();
                switch (color)
                {
                    case "green":
                        myColor = ConsoleColor.Green;
                        picking = false;
                        break;
                    case "red":
                        myColor = ConsoleColor.Red;
                        picking = false;
                        break;
                    case "blue":
                        myColor = ConsoleColor.Cyan;
                        picking = false;
                        break;
                    case "white":
                        myColor = ConsoleColor.White;
                        picking = false;
                        break;
                }
            }
            //end of choosing color
        }

    }
}
