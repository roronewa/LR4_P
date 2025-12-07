using System;
using System.IO;

public class MapLoader
{
    // Метод для завантаження мапи лабіринту з файлу
    // filePath - шлях до файлу
    // Повертає: двовимірний масив символів (char[,]) або null, якщо файл не знайдено
    public static char[,] LoadMapFromFile(string filePath)
    {
        // Крок 3: Перевірити наявність файлу
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Помилка: Файл {filePath} не знайдено.");
            return null;
        }

        // Крок 5: Прочитати файл
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            Console.WriteLine($"Помилка: Файл {filePath} порожній.");
            return null;
        }

        // Крок 7: Визначити розміри масиву
        int rows = lines.Length;
        int cols = lines[0].Length;

        // Крок 6: Створити двовимірний масив char[,]
        char[,] loadedMap = new char[rows, cols];

        // Крок 8: Сформувати масив через два цикли
        for (int y = 0; y < rows; y++)
        {
            // Додаткова перевірка формату
            if (lines[y].Length != cols)
            {
                Console.WriteLine($"Помилка: Рядок {y} має іншу довжину ({lines[y].Length} замість {cols}). Лабіринт має бути прямокутним.");
                return null;
            }

            for (int x = 0; x < cols; x++)
            {
                loadedMap[y, x] = lines[y][x];
            }
        }

        // Крок 9: Повернути масив
        return loadedMap;
    }
}

// Приклад використання з вашим шляхом до файлу:
class Program
{
    static void Main(string[] args)
    {
        // Ваш конкретний шлях до файлу:
        string filePath = @"C:\Users\lovem\OneDrive\Desktop\maze.txt";

        // Виклик методу
        char[,] map = MapLoader.LoadMapFromFile(filePath);

        if (map != null)
        {
            Console.WriteLine($"Мапа лабіринту успішно завантажена з: {filePath}");

            // Виведення завантаженої мапи в консоль для перевірки
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Не вдалося завантажити мапу лабіринту.");
        }

        // Console.ReadKey(); // Можна додати для зупинки консолі, якщо потрібно
    }
}