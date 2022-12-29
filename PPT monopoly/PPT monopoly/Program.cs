using System;
using PPT_monopoly;

namespace monopoly
{
    class Program
    {
        private static Dice _dice = new Dice(6);

        private static Board _board = new Board();

        static string userInput;

        static int numbersOfTakes = 0;
        static int numberOfRepetitions = 0;

        static double hitProbability = 0;
        static double averageMoves = 0;
        static double doubleDropChance = 0;

        static void Main(string[] args)
        {
            do
            {
                int move;
                int dice1;
                int dice2;
                numbersOfTakes = 0;
                Console.Clear();
                _board.RefreshValues();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Введите количество повторений симуляции: ");
                userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    break;
                }
                else
                {
                    numberOfRepetitions = Int32.Parse(userInput);
                }
                Console.Clear();
                for (int i = 0; i < numberOfRepetitions; i++)
                {
                    dice1 = _dice.Roll();
                    dice2 = _dice.Roll();
                    move = dice1 + dice2;
                    if (dice1 == dice2)
                    {
                        numbersOfTakes++;
                    }
                    _board.PlayTurn(move);
                }
                _board.ShowBoard();
                hitProbability = _board.getMaxValue / (double)numberOfRepetitions;
                averageMoves = _board.getSumOfMoves / (double)numberOfRepetitions;
                doubleDropChance = numbersOfTakes / (double)numberOfRepetitions;
                Console.Write('\n');
                Console.Write('\n');
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Стартовое поле");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Интерактивное поле");
                Console.Write('\n');
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Пройдено кругов: {_board.getLapCounter}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Поле на которое попадались больше всего раз: {_board.getMaxValue}" +
                    $"(вероятность попадания на это поле { Math.Round(hitProbability, 2)}" +
                    $" или {Math.Round(hitProbability * 100)}  %)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Среднее ходов: {Math.Round(averageMoves)}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Количество дублей: {numbersOfTakes} (шанс выпадения дубля: " + 
                    $"{ Math.Round(doubleDropChance, 2)} или {Math.Round(doubleDropChance * 100)} %)");
                Console.ReadKey();
            } while (true);
        }
    }
}