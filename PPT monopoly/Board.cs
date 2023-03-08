using System;
using System.Collections.Generic;
using System.Text;

namespace PPT_monopoly
{
    class Board
    {
        private int[] board = new int[40];

        private ConsoleColor _startFieldColor = ConsoleColor.Red;
        private ConsoleColor _fieldColor = ConsoleColor.White;
        private ConsoleColor _maxValueColor = ConsoleColor.Yellow;

        private string _bigSpace = "                                       ";

        private int _side = 0;
        private int _currentField = 0;
        private int _maxValue = 0;
        private int _sumOfMoves = 0;
        private int _lapCounter = 0;

        public int GetMaxValue { get { return _maxValue; } }
        public int GetLapCounter { get { return _lapCounter; } }
        public int GetSumOfMoves { get { return _sumOfMoves; } }

        public int[] PlayTurn(int move)
        {
            _sumOfMoves += move;
            _currentField += move;
            if (_currentField > 39)
            {
                _currentField -= 40;
                _lapCounter++;
            }
            board[_currentField]++;
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
            _side = 0;
            _maxValue = -1;
            _lapCounter = 0;
            _sumOfMoves = 0;
            _currentField = 0;
        }

        public void NumFields()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = i;
            }
        }
        public void ShowBoard()
        {
            _maxValue = FindMaxValue();
            int rowCounter = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (_side)
                {
                    case 0:
                        for (int j = 0; j < 11; j++)
                        {
                            if (j == 0)
                            {
                                Console.ForegroundColor = _startFieldColor;
                            }
                            else if (board[j] == _maxValue)
                            {
                                Console.ForegroundColor = _maxValueColor;
                            }
                            Console.Write(board[j] + "   ");
                            Console.ForegroundColor = _fieldColor;
                            rowCounter++;
                            if (rowCounter > 10)
                            {
                                _side++;
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
                            if (board[j] == _maxValue)
                            {
                                Console.Write(board[l] + _bigSpace);
                                Console.ForegroundColor = _maxValueColor;
                                Console.Write(board[j]);
                                Console.ForegroundColor = _fieldColor;
                                Console.WriteLine();
                            }
                            else if (board[l] == _maxValue)
                            {
                                Console.ForegroundColor = _maxValueColor;
                                Console.Write(board[l] + _bigSpace);
                                Console.ForegroundColor = _fieldColor;
                                Console.Write(board[j]);
                                Console.WriteLine();
                            }
                            else if (board[j] == _maxValue && board[l] == _maxValue)
                            {
                                Console.ForegroundColor = _maxValueColor;
                                Console.WriteLine(board[l] + _bigSpace + board[j]);
                                Console.ForegroundColor = _fieldColor;
                            }
                            else
                            {
                                Console.WriteLine(board[l] + _bigSpace + board[j]);
                            }
                            Console.WriteLine();
                            rowCounter++;
                            if (rowCounter > 8)
                            {
                                _side++;
                                rowCounter = 0;
                                break;
                            }
                        }
                        break;
                    case 2:
                        for (int j = 30; j > 19; j--)
                        {
                            if (board[j] == _maxValue)
                            {
                                Console.ForegroundColor = _maxValueColor;
                            }
                            Console.Write(board[j] + "   ");
                            Console.ForegroundColor = _fieldColor;
                            rowCounter++;
                            if (rowCounter > 10)
                            {
                                _side++;
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
