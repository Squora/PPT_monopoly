using System;
using PPT_monopoly;

namespace monopoly
{
    class Program
    {
        private static Dice s_dice = new Dice(6);
        private static Board s_board = new Board();

        private static string s_userInput;

        private static int s_numbersOfTakes = 0;
        private static int s_numberOfRepetitions = 0;

        private static double s_hitProbability = 0;
        private static double s_averageMoves = 0;
        private static double s_doubleDropChance = 0;

        static void Main(string[] args)
        {
            do
            {
                Start:
                int move;
                int dice1;
                int dice2;
                s_numbersOfTakes = 0;
                Console.Clear();
                s_board.RefreshValues();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Введите количество повторений симуляции: ");
                s_userInput = Console.ReadLine();
                if (s_userInput == "q")
                {
                    break;
                }
                else if (s_userInput == "show fields")
                {
                    s_board.NumFields();
                    s_board.ShowBoard();
                    Console.ReadKey();
                    goto Start;
                }
                else
                {
                    s_numberOfRepetitions = Int32.Parse(s_userInput);
                }
                Console.Clear();
                for (int i = 0; i < s_numberOfRepetitions; i++)
                {
                    dice1 = s_dice.Roll();
                    dice2 = s_dice.Roll();
                    move = dice1 + dice2;
                    if (dice1 == dice2)
                    {
                        s_numbersOfTakes++;
                    }
                    s_board.PlayTurn(move);
                }
                s_board.ShowBoard();
                s_hitProbability = s_board.GetMaxValue / (double)s_numberOfRepetitions;
                s_averageMoves = s_board.GetSumOfMoves / (double)s_numberOfRepetitions;
                s_doubleDropChance = s_numbersOfTakes / (double)s_numberOfRepetitions;
                Console.Write('\n');
                Console.Write('\n');
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Стартовое поле");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Интерактивное поле");
                Console.Write('\n');
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Пройдено кругов: {s_board.GetLapCounter}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Поле на которое попадались больше всего раз: {s_board.GetMaxValue}" +
                    $"(вероятность попадания на это поле { Math.Round(s_hitProbability, 2)}" +
                    $" или {Math.Round(s_hitProbability * 100)}%)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Среднее ходов: {Math.Round(s_averageMoves)}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Количество дублей: {s_numbersOfTakes} (шанс выпадения дубля: " + 
                    $"{ Math.Round(s_doubleDropChance, 2)} или {Math.Round(s_doubleDropChance * 100)}%)");
                Console.ReadKey();
            } while (true);
        }
    }
}