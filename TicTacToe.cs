using SimpliSafeTakeHomeAssesment.Checkers;
using System;

namespace SimpliSafeTakeHomeAssesment
{
    internal class TicTacToeSolver
    {
        static void Main(string[] args)
        {
            //load initialize the cell config and board state, along with the win conditions
            Board board = new Board();
            GameWinAnalyzer.InitializeWinConditions();

            //start by checking if we have a winner
            VictoryReport report = GameWinAnalyzer.checkWinner(board._Cells);

            if (report.winner != CellConfigAccessor.GetCellConfig()._EmptyValue)
            {
                Console.WriteLine(string.Format("The winner of the game was {0}, and they won by {1}", report.winner.ToString(), report.victoryType.ToString()));
                Console.ReadLine();
                return;
            }

            else
            {
                //if there are any empty spaces, we have remaining moves
                if (!RemainingMoveAnalyzer.anyMovesLeft(board._Cells))
                {
                    Console.WriteLine("There were no available moves left, so the game is over with no winner");
                }
                else
                {
                    //if there were any remaining moves, check if any win conditions are still possible, if not, game is over
                    Console.WriteLine("There were some available spaces. Checking if win is possible or game is over");
                    if (GameWinAnalyzer.isGameOver(board._Cells))
                    {
                        Console.WriteLine("There are still some potential win conditions remaining, game is not over");
                    }
                    else
                    {
                        Console.WriteLine("No win conditions are possible. Game is over");
                    }
                }

            }


            Console.ReadLine();
        }

        
    }
}