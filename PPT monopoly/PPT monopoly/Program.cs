using System;

namespace monopoly
{
    class Program
    {
        static Random rnd = new Random();

        static int[,] playingField = new int[10, 10];

        static string userInput;

        static bool isStartField = true;

        static long sumOfMoves = 0;

        static int side = 0;
        static int maxValue = -1;
        static int numbersOfTakes = 0;
        static int lapCounter = 1;
        static int numberOfRepetitions = 0;

        static double hitProbability = 0;
        static double averageMoves = 0;
        static double doubleDropChance = 0;

        static void updatePlayingField()
        {
            int rowCounter = 0;
            int columnCounter = 0;
            foreach (var item in playingField)
            {
                if (isStartField == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    isStartField = false;
                }
                else if ((columnCounter == 0 || columnCounter == 9) || (rowCounter == 0 || rowCounter == 9))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (rowCounter != 0 && rowCounter != 9 && numberOfRepetitions < 1000)
                {
                    Console.Write("");
                }
                else if (rowCounter != 0 && rowCounter != 9 && numberOfRepetitions < 9999)
                {
                    Console.Write(" ");
                }
                else if (rowCounter != 0 && rowCounter != 9 && numberOfRepetitions > 9999 && numberOfRepetitions < 100000)
                {
                    Console.Write("  ");
                }
                else if (rowCounter != 0 && rowCounter != 9 && numberOfRepetitions > 99999 && numberOfRepetitions < 1000000)
                {
                    Console.Write("   ");
                }
                else if (rowCounter != 0 && rowCounter != 9 && numberOfRepetitions > 999999)
                {
                    Console.Write("    ");
                }
                if (item == maxValue)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(item + "   ");
                Console.ForegroundColor = ConsoleColor.Black;
                columnCounter += 1;
                if (columnCounter == 10)
                {
                    Console.Write('\n');
                    Console.Write('\n');
                    Console.Write('\n');
                    rowCounter += 1;
                    columnCounter = 0;
                }
            }
            isStartField = true;
        }

        static int[,] makeMove(int[,] playingField)
        {
            int firstDue = rnd.Next(1, 7);
            int secondDue = rnd.Next(1, 7);
            if (firstDue == secondDue)
            {
                numbersOfTakes += 1;
            }
            int move = firstDue + secondDue;
            sumOfMoves += move;
            if (move > 9)
            {
                side += 1;
                move -= 10;
            }
            if (side > 3)
            {
                side = 0;
                lapCounter += 1;
            }
            switch (side)
            {
                case 0:
                    playingField[0, move] += 1;
                    break;
                case 1:
                    playingField[move, 9] += 1;
                    break;
                case 2:
                    playingField[9, move] += 1;
                    break;
                case 3:
                    playingField[move, 0] += 1;
                    break;

            }
            return playingField;
        }

        static int findMaxValue(int[,] playingField)
        {
            int value = -1;
            foreach (var item in playingField)
            {
                if (value < item)
                {
                    value = item;
                }
            }
            return value;
        }

        static void refreshValues()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    playingField[i, j] = 0;
                }
            }
            isStartField = true;
            side = 0;
            maxValue = -1;
            lapCounter = 1;
            sumOfMoves = 0;
            numbersOfTakes = 0;
            hitProbability = 0;
            averageMoves = 0;
            doubleDropChance = 0;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                refreshValues();
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
                    makeMove(playingField);
                }
                maxValue = findMaxValue(playingField);
                hitProbability = (double)maxValue / numberOfRepetitions;
                averageMoves = sumOfMoves / numberOfRepetitions;
                doubleDropChance = (double)numbersOfTakes / numberOfRepetitions;
                updatePlayingField();
                Console.Write('\n');
                Console.Write('\n');
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Стартовое поле");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Интерактивное поле");
                Console.Write('\n');
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Пройдено кругов: " + lapCounter);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Поле на которое попадались больше всего раз: " + maxValue + " (вероятность попадания на это поле " +
                    Math.Round(hitProbability, 2) + " или " + Math.Round(hitProbability * 100) + "%)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Среднее ходов: " + Math.Round(averageMoves));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Количество дублей: " + numbersOfTakes + " (шанс выпадения дубля: " + 
                    Math.Round(doubleDropChance, 2) + " или " + Math.Round(doubleDropChance * 100) + "%)");
                Console.ReadKey();
            } while (true);
        }
    }
}
