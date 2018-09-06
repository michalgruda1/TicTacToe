using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        // member
        private string[,] fields;

        // constructor
        public Board()
        {
            this.fields = new string[3, 3]
            {
                { "1","2","3"},
                { "4","5","6"},
                { "7","8","9"}
            };
        }

        public void RenderBoard()
        {
            Console.WriteLine("\nLet's play a tic-tac-toe. \nType in a number 1-9 to place your mark.\n");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("|         |         |         |");
                Console.Write("|    ");
                if (this.fields[i, 0] == "X" || this.fields[i, 0] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(this.fields[i, 0]);
                Console.ResetColor();
                Console.Write("    |    ");
                if (this.fields[i, 1] == "X" || this.fields[i, 1] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(this.fields[i, 1]);
                Console.ResetColor();
                Console.Write("    |    ");
                if (this.fields[i, 2] == "X" || this.fields[i, 2] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(this.fields[i, 2]);
                Console.ResetColor();
                Console.Write("    |\n");
                Console.WriteLine("|         |         |         |");
                if (i == 2) Console.WriteLine("-------------------------------");
            }
        }

        // argument "mark" is either O or X
        public void SetField(int row, int column, string mark)
        {
            this.fields[row, column] = mark;
        }

        public string GetField(int row, int column)
        {
            // here we simply extract field value for given number of field
            return this.fields[row, column];
        }

        public bool IsFieldChangeable(int row, int column)
        {
            if (this.fields[row, column].Equals("X") || this.fields[row, column].Equals("O"))
            {
                Console.WriteLine("Field already has mark, choose different number", row, column);
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsInputCorrect(int input)
        {
            if (input > 0 && input < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckWin(int playerNumber, string mark)
        {
            bool isWinner = false;

            // check rows
            for (int row = 0; row < 3; row++)
            {
                if (this.fields[row, 0] == mark && this.fields[row, 1] == mark && this.fields[row, 2] == mark)
                {
                    isWinner = true;
                }
            }

            // check columns
            for (int col = 0; col < 3; col++)
            {
                if (this.fields[0, col] == mark && this.fields[1, col] == mark && this.fields[2, col] == mark)
                {
                    isWinner = true;
                }
            }

            //check diagonals
            if (this.fields[0, 0] == mark && this.fields[1, 1] == mark && this.fields[2, 2] == mark)
            {
                isWinner = true;
            }
            else if (this.fields[0, 2] == mark && this.fields[1, 1] == mark && this.fields[2, 0] == mark)
            {
                isWinner = true;
            }

            /*
            // now return
            if (isWinner && playerNumber == 1)
            {
                ++winsPlayer1;
            } else if (isWinner && playerNumber == 2)
            {
                ++winsPlayer2;
            }
            */
            return isWinner;
        }

        public bool CheckTruce()
        {
            foreach (string field in this.fields)
            {
                // if there is any number left in the array (not all are Os and Xs), it's not truce
                if (Int32.TryParse(field, out int number)) return false;
            };
            return true;
        }
    }

    public sealed class Score
    {
        static readonly Score instance = new Score();

        public static Score Instance
        {
            get
            {
                return instance;
            }
        }
        public static int Games { get; set; }
        public static int Draws { get; set; }
        public static int Player1Wins { get; set; }
        public static int Player2Wins { get; set; }

        public Score()
        {
            Games = 0;
            Draws = 0;
            Player1Wins = 0;
            Player2Wins = 0;
        }

        public void ConcludeGame(int gameResult)
        {
            Games++;
            switch (gameResult)
            {
                case 0:
                    Draws++;
                    break;
                case 1:
                    Player1Wins++;
                    break;
                case 2:
                    Player2Wins++;
                    break;
                default:
                    throw new Exception(String.Format("Unrecognized game result - {0}", gameResult));
            }
        }

        public void Draw()
        {
            Console.WriteLine("\n\n---SCORE-----");
            Console.WriteLine("Games:    {0}", Games);
            Console.WriteLine("Player 1: {0}", Player1Wins);
            Console.WriteLine("Player 2: {0}", Player2Wins);
            Console.WriteLine("Draws:    {0}\n", Draws);
        }
    }
}
