using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral
{
    internal class Program
    {
        enum move
        {
            LEFT = 1, RIGHT = 2, UP = 3, DOWN = 4
        }
        static void Main(string[] args)
        {
            Console.Write("Введите нечетное количество столбцов массива: ");
            int columns = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите нечетное количество строк массива: ");
            int lines = Convert.ToInt32(Console.ReadLine());
                        
            int[,] ar = new int[lines, columns];
            int num = lines * columns;
            int step = 1;
            int x = lines / 2;
            int y = columns / 2;
            ar[x, y] = step++;
            int go = (int)move.RIGHT;
            
            while (step <= num)
            {
                switch (go)
                {
                    case (int)move.RIGHT:
                        y++;
                        if (y < columns)
                            ar[x, y] = step;
                        else
                        {
                            for (int i = (x - 1); i >= 0; i--)
                            {
                                if (ar[i, y - 1] == 0)
                                {
                                    x = i;
                                    y--;
                                    ar[x, y] = step;
                                    go = (int)move.LEFT;                                    
                                    break;
                                }
                            }
                            break;
                        }
                        if (ar[x-1, y] == 0)
                            go = (int)move.UP;
                        break;
                    case (int)move.UP:
                        x--;
                        if (x >= 0)
                            ar[x, y] = step;
                        else
                        {
                            for (int i = (y - 1); i >= 0; i--)
                            {
                                if (ar[x + 1, i] == 0)
                                {
                                    y = i;
                                    x++;
                                    ar[x, y] = step;
                                    go = (int)move.DOWN;                                    
                                    break;
                                }
                            }
                            break;
                        }                            
                        if (ar[x, y - 1] == 0)
                            go = (int)move.LEFT;
                        break;
                    case (int)move.LEFT:
                        y--; 
                        if (y >= 0)
                            ar[x, y] = step;
                        else
                        {
                            for (int i = x; i < lines; i++)
                            {
                                if (ar[i, y + 1] == 0)
                                {
                                    x = i;
                                    y++;
                                    ar[x, y] = step;
                                    go = (int)move.RIGHT;                                    
                                    break;
                                }
                            }
                            break;
                        }
                        if (ar[x + 1, y] == 0)
                            go = (int)move.DOWN;
                        break;
                    case (int)move.DOWN:
                        x++;
                        if (x < lines)
                            ar[x, y] = step;
                        else
                        {
                            for (int i = y; i < columns; i++)
                            {
                                if (ar[x - 1, i] == 0)
                                {
                                    y = i;
                                    x--;
                                    ar[x, y] = step;
                                    go = (int)move.UP;                                    
                                    break;
                                }
                            }
                            break;
                        }
                        if (ar[x, y + 1] == 0)
                            go = (int)move.RIGHT;
                        break;
                }                
                step++;
                
            }  
            
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(ar[i, j] + "\t");
                }
                Console.WriteLine();
            }            
        }
    }
}
