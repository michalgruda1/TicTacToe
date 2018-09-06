using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {


            // we restart the game, after winning or truce, by breaking from the loop
            while (true)
            {

                // initialize board
                Board myBoard = new Board();

                // which pass of the program is in, starting with 1
                int pass = 1;

                // is it player 1 or 2
                int playerNumber = 1;

                // player 1 plays with O, player 2 with X
                string mark = "O";

                // tell why we are here and what to do
                Console.Clear();
                Console.WriteLine("Let's play a tic-tac-toe. \nType in a number 1-9 to place your mark.\n");

                // initialize info whether user tried to fill in field which already has mark in it
                bool isTryingToOverwrite = false;

                // initialize info is user input was incorrect - NaN, number out of bounds
                bool userInputIncorrect = false;

                // play, until somebody wins or truce
                while (!(myBoard.CheckWin(playerNumber, mark) || myBoard.CheckTruce()))
                {
                    // odd pass is Player 1 and even is Player 2
                    if (pass % 2 == 1)
                    {
                        playerNumber = 1;
                        mark = "O";
                    }
                    else
                    {
                        playerNumber = 2;
                        mark = "X";
                    }

                    // here we start - show board and instructions
                    Console.Clear();
                    myBoard.RenderBoard();
                    Console.WriteLine("\nPlayer {0}, choose where to put your {1}", playerNumber, mark);

                    // initialize scoreboard
                    Score scoreBoard = Score.Instance;

                    // user tried to ovewrite already set field in previous pass?
                    if (isTryingToOverwrite)
                    {
                        Console.WriteLine("\nThis field already has mark in it. Try with different.");
                        // reset this to false, now when you nagged the user
                        isTryingToOverwrite = false;
                    }

                    // user provided invalid input in previous pass?
                    if (userInputIncorrect)
                    {
                        Console.WriteLine("\nInput NOT correct. Should be a number between 1 and 9.");
                        // reset this to false, now when you nagged the user
                        userInputIncorrect = false;
                    }

                    // take input
                    string rawInput = Console.ReadLine();

                    // validate
                    if (Int32.TryParse(rawInput, out int input) && myBoard.IsInputCorrect(input))
                    {
                        switch (input)
                        {
                            case 1:
                                if (myBoard.IsFieldChangeable(0, 0))
                                {
                                    myBoard.SetField(0, 0, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 2:
                                if (myBoard.IsFieldChangeable(0, 1))
                                {
                                    myBoard.SetField(0, 1, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 3:
                                if (myBoard.IsFieldChangeable(0, 2))
                                {
                                    myBoard.SetField(0, 2, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 4:
                                if (myBoard.IsFieldChangeable(1, 0))
                                {
                                    myBoard.SetField(1, 0, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 5:
                                if (myBoard.IsFieldChangeable(1, 1))
                                {
                                    myBoard.SetField(1, 1, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 6:
                                if (myBoard.IsFieldChangeable(1, 2))
                                {
                                    myBoard.SetField(1, 2, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 7:
                                if (myBoard.IsFieldChangeable(2, 0))
                                {
                                    myBoard.SetField(2, 0, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 8:
                                if (myBoard.IsFieldChangeable(2, 1))
                                {
                                    myBoard.SetField(2, 1, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            case 9:
                                if (myBoard.IsFieldChangeable(2, 2))
                                {
                                    myBoard.SetField(2, 2, mark);
                                }
                                else
                                {
                                    isTryingToOverwrite = true;
                                    continue;
                                }
                                break;
                            default:
                                userInputIncorrect = true;
                                continue;
                        }

                        // do we have a winner?
                        if (myBoard.CheckWin(playerNumber, mark))
                        {
                            Console.Clear();
                            myBoard.RenderBoard();
                            Console.WriteLine("****************************************** \nPlayer {0}, using {1} has won!!!", playerNumber, mark);
                            // count win for player
                            if (playerNumber == 1)
                            {
                                scoreBoard.ConcludeGame(1);
                            }
                            else
                            {
                                scoreBoard.ConcludeGame(2);
                            }

                            // display score
                            scoreBoard.Draw();

                            // exit the do loop
                            break;
                        }
                        else if (myBoard.CheckTruce())
                        // do we have a truce?
                        {
                            Console.Clear();
                            myBoard.RenderBoard();
                            Console.WriteLine("__________________________________________ \nWe have a truce, no winner here!!!");
                            // record the draw in score, and exit the do loop
                            scoreBoard.ConcludeGame(0);
                            // drawscoreboard
                            scoreBoard.Draw();
                            break;
                        }
                        else
                        {
                            // nothing to do, so redraw the board with input from user
                            Console.Clear();
                            myBoard.RenderBoard();
                            Console.WriteLine("\nPlayer {0}, choose where to put your {1}", playerNumber, mark);
                            // drawscoreboard
                            scoreBoard.Draw();

                        }
                    }
                    else
                    {
                        userInputIncorrect = true;
                        continue;
                    }
                    pass++;
                }

                // rerun entire thingy, if main do loop ends by winning or draw
                Console.WriteLine("Press a key to reset the game");
                Console.ReadKey();
                Main(null);
                Console.Read();
            }

        }
    }
}
