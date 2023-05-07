using System;

class Program
{
    static void Main(string[] args)
    {
        var userData = GetUserDataFromKeyboard(); // Вызываем метод для заполнения данных с клавиатуры

        DisplayUserData(userData); // Выводим данные на экран
    }

    static (string firstName, string lastName, int age, string[] petNames, string[] favoriteColors) GetUserDataFromKeyboard()
    {
        // Запрашиваем данные у пользователя
        Console.Write("Введите имя:");
        string firstName = Console.ReadLine();

        Console.Write("Введите фамилию:");
        string lastName = Console.ReadLine();

        int age;
        while (true)
        {
            Console.Write("Введите возраст:");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                break;
            else
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
        }

        bool hasPets;
        while (true)
        {
            Console.WriteLine("Есть ли у вас питомцы? (Да/Нет)");
            string hasPetsInput = Console.ReadLine().ToLower();

            if (hasPetsInput == "да")
            {
                hasPets = true;
                break;
            }
            else if (hasPetsInput == "нет")
            {
                hasPets = false;
                break;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
            }
        }

        string[] petNames = null;
        if (hasPets)
        {
            int petCount;
            while (true)
            {
                Console.Write("Введите количество питомцев:");
                if (int.TryParse(Console.ReadLine(), out petCount) && petCount > 0)
                    break;
                else
                    Console.WriteLine("Некорректный ввод. Повторите попытку.");
            }

            petNames = GetPetNamesFromKeyboard(petCount);
        }

        int favoriteColorsCount;
        while (true)
        {
            Console.Write("Введите количество любимых цветов:");
            if (int.TryParse(Console.ReadLine(), out favoriteColorsCount) && favoriteColorsCount > 0)
                break;
            else
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
        }

        string[] favoriteColors = GetFavoriteColorsFromKeyboard(favoriteColorsCount);

        return (firstName, lastName, age, petNames, favoriteColors);
    }

    static string[] GetPetNamesFromKeyboard(int count)
    {
        string[] petNames = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите кличку питомца {i + 1}:");
            petNames[i] = Console.ReadLine();
        }

        return petNames;
    }

    static string[] GetFavoriteColorsFromKeyboard(int count)
    {
        string[] favoriteColors = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите любимый цвет {i + 1}:");
            favoriteColors[i] = Console.ReadLine();
        }

        return favoriteColors;
    }

    static void DisplayUserData((string firstName, string lastName, int age, string[] petNames, string[] favoriteColors) userData)
    {
        Console.WriteLine("Данные пользователя:");
        Console.WriteLine($"Имя: {userData.firstName}");
        Console.WriteLine($"Фамилия: {userData.lastName}");
        Console.WriteLine($"Возраст: {userData.age}");

        if (userData.petNames != null && userData.petNames.Length > 0)
        {
            Console.WriteLine("Питомцы:");
            for (int i = 0; i < userData.petNames.Length; i++)
            {
                Console.WriteLine($"Питомец {i + 1}: {userData.petNames[i]}");
            }
        }

        if (userData.favoriteColors != null && userData.favoriteColors.Length > 0)
        {
            Console.WriteLine("Любимые цвета:");
            for (int i = 0; i < userData.favoriteColors.Length; i++)
            {
                Console.WriteLine($"Цвет {i + 1}: {userData.favoriteColors[i]}");
            }
        }
    }
}