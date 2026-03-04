namespace Game110a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Угадай число");
            Console.WriteLine("Число от 1 до 100.");

            int secretNumber = GenerateRandomNumber();
            PlayGame(secretNumber);
        }

        /// <summary>
        /// Генерирует случайное число от 1 до 100
        /// </summary>
        static int GenerateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101); // 1 до 100 включительно
        }

        /// <summary>
        /// Запрашивает у пользователя число и проверяет корректность ввода
        /// </summary>
        static int GetUserNumber()
        {
            int userNum = 0;

            for (int attempt = 0; attempt < 3; attempt++)
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out userNum))
                {
                    Console.WriteLine("Ошибка! Нужно ввести число.");
                    continue;
                }

                if (userNum < 1 || userNum > 100)
                {
                    Console.WriteLine("Ошибка! Число должно быть от 1 до 100.");
                    continue;
                }

                return userNum;
            }

            Console.WriteLine("Превышено количество попыток ввода. Программа завершена.");
            Environment.Exit(0);
            return 0;
        }

        /// <summary>
        /// Основной игровой цикл - сравнивает числа и дает подсказки
        /// </summary>
        static void PlayGame(int secretNumber)
        {
            int attempts = 0;

            while (true)
            {
                attempts++;
                int userGuess = GetUserNumber();

                if (userGuess < secretNumber)
                {
                    Console.WriteLine("Загаданное число БОЛЬШЕ!");
                }
                else if (userGuess > secretNumber)
                {
                    Console.WriteLine("Загаданное число МЕНЬШЕ!");
                }
                else
                {
                    Console.WriteLine($"ПОБЕДА! Вы угадали число {secretNumber}!");
                    Console.WriteLine($"Количество попыток: {attempts}");
                    break;
                }
            }
        }
    }
}