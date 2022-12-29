using System;
using System.Collections.Generic;
using System.Text;

namespace PPT_monopoly
{
    class Board
    {
        private int[] board = new int[40];

        private ConsoleColor startFieldColor = ConsoleColor.Red;
        private ConsoleColor fieldColor = ConsoleColor.White;
        private ConsoleColor maxValueColor = ConsoleColor.Yellow;

        private int side = 0;
        private int currentField = 0;
        private int maxValue = 0;
        private int sumOfMoves = 0;

        private int lapCounter = 0;

        public int getMaxValue { get { return maxValue; } }
        public int getLapCounter { get { return lapCounter; } }
        public int getSumOfMoves { get { return sumOfMoves; } }
        public int[] PlayTurn(int move)
        {
            sumOfMoves += move;
            currentField += move;
            if (currentField > 39)
            {
                currentField -= 40;
                lapCounter++;
            }
            board[currentField]++;
            return board;
        }

        int FindMaxValue()
        {
            int value = -1;
            foreach (var item in board)
            {
                if (value < item)
                {
                    value = item;
                }
            }
            return value;
        }

        public void RefreshValues()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = 0;
            }
            side = 0;
            maxValue = -1;
            lapCounter = 0;
            sumOfMoves = 0;
        }

        public void ShowBoard()
        {
            maxValue = FindMaxValue();
            int rowCounter = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (side)
                {
                    case 0:
                        for (int j = 0; j < 11; j++)
                        {
                            if (j == 0)
                            {
                                Console.ForegroundColor = startFieldColor;
                            }
                            else if (board[j] == maxValue)
                            {
                                Console.ForegroundColor = maxValueColor;
                            }
                            Console.Write(board[j] + "   ");
                            Console.ForegroundColor = fieldColor;
                            rowCounter++;
                            if (rowCounter > 10)
                            {
                                side++;
                                rowCounter = 0;
                                break;
                            }
                        }
                        break;
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine();
                        for (int j = 11, l = 39; j < 20 && l > 30; j++, l--)
                        {
                            if (board[j] == maxValue)
                            {
                                Console.Write(board[l] + "                                       ");
                                Console.ForegroundColor = maxValueColor;
                                Console.Write(board[j]);
                                Console.ForegroundColor = fieldColor;
                                Console.WriteLine();
                            }
                            else if (board[l] == maxValue)
                            {
                                Console.ForegroundColor = maxValueColor;
                                Console.Write(board[l] + "                                       ");
                                Console.ForegroundColor = fieldColor;
                                Console.Write(board[j]);
                                Console.WriteLine();
                            }
                            else if (board[j] == maxValue && board[l] == maxValue)
                            {
                                Console.ForegroundColor = maxValueColor;
                                Console.WriteLine(board[l] + "                                       " + board[j]);
                                Console.ForegroundColor = fieldColor;
                            }
                            else
                            {
                                Console.WriteLine(board[l] + "                                       " + board[j]);
                            }
                            Console.WriteLine();
                            rowCounter++;
                            if (rowCounter > 8)
                            {
                                side++;
                                rowCounter = 0;
                                break;
                            }
                        }
                        break;
                    case 2:
                        for (int j = 30; j > 19; j--)
                        {
                            if (board[j] == maxValue)
                            {
                                Console.ForegroundColor = maxValueColor;
                            }
                            Console.Write(board[j] + "   ");
                            Console.ForegroundColor = fieldColor;
                            rowCounter++;
                            if (rowCounter > 10)
                            {
                                side++;
                                rowCounter = 0;
                                break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
