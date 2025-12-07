using System;
using System.IO;
using System.Text;

class Program
{
    static char[,] LoadMapFromFile(string filePath)
    {        
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не знайдено.");
            return null; 
        }

        string[] lines = File.ReadAllLines(filePath);

        int rows = lines.Length;
        int cols = lines[0].Length;

        char[,] loadedMap = new char[rows, cols];

        for (int y = 0; y < rows; y++)
        {

            for (int x = 0; x < cols; x++)
            {

                loadedMap[y, x] = lines[y][x];
            }
        }
        return loadedMap;
        
    }
    
    static void Main()
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string path = @"C:\Users\lovem\OneDrive\Desktop\maze.txt";

        
        char[,] map = LoadMapFromFile(path);

        Console.WriteLine($"{map.GetLength(0)} рядків x {map.GetLength(1)} стовпців.");

        /*int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int y = 0; y < rows; y++) 
        {
            for (int x = 0; x < cols; x++) 
            {
                Console.Write(map[y, x]);
            }
            Console.WriteLine();
        }*/
        
    }

}