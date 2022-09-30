using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int y = 0, x = 0, i = 0, j = 0, n = 0;
            var wall = '█';
            var space = ' ';
            var player = '☺';
            var end = '▲';
            int count = 0;
            int playerY = -1;
            int playerX = -1;
            bool start = true;

            Console.SetWindowPosition(0, 0);
            string[] str = File.ReadAllLines($"maze1.txt");
            int[,] map = new int[str.Length, str[0].Split(' ').Length];
            for (i = 0; i < str.Length; i++)
            {
                string[] str2 = str[i].Split(' '); 
                for (j = 0; j < str2.Length; j++)
                    map[i,j] = Int32.Parse(str2[j]);
                n = str2.Length;
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(x++, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (map[i, j] == 0)
                    {
                        Console.WriteLine(space);
                    }
                    if (map[i, j] == 1)
                    {
                        Console.WriteLine(wall);
                    }
                    if (map[i, j] == 2)
                    {
                        Console.Write(player);
                        playerX = j;
                        playerY = i;
                    }
                    if (map[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(end);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
               x = 0;
               Console.SetCursorPosition(x, ++y);
            }

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(x = playerX, y = playerY);
            Console.Write("☺");

            while (start)
            {
                key = Console.ReadKey(true);

                if (key.KeyChar == 119 || key.KeyChar == 87) // клавиша W
                {
                    if (map[playerY - 1, playerX] != 1)
                    {
                        Console.SetCursorPosition(x, y--); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerY--;
                        count++;
                    }
                }
                else if (key.KeyChar == 115 || key.KeyChar == 83) // клавиша S
                {
                    if (map[playerY + 1, playerX] != 1)
                    {
                        Console.SetCursorPosition(x, y++); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerY++;
                        count++;
                    }
                }
                else if (key.KeyChar == 97 || key.KeyChar == 65) // клавиша A
                {
                    if (map[playerY, playerX - 1] != 1)
                    {
                        Console.SetCursorPosition(x--, y); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerX--;
                        count++;
                    }
                }
                else if (key.KeyChar == 100 || key.KeyChar == 68) // клавиша D
                {
                    if (map[playerY, playerX + 1] != 1)
                    {
                        Console.SetCursorPosition(x, y); Console.Write(" ");
                        Console.SetCursorPosition(++x, y); Console.Write("☺");
                        playerX++;
                        count++;
                    }
                }
                if (playerY == 1 & playerX == 23)
                {
                    start = false;
                }
            }
            Console.Clear();
            Console.SetCursorPosition(x = 50, y = 10);
            Console.WriteLine("Вы прошли лабиринт!");
            Console.SetCursorPosition(x = 52, y = 11);
            Console.WriteLine("Всего шагов: " + count);
            Console.SetCursorPosition(x = 44, y = 12);
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}


