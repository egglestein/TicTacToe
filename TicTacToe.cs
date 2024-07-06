using SimpliSafeTakeHomeAssesment.Checkers;
using System;

namespace SimpliSafeTakeHomeAssesment
{
    internal class TicTacToeSolver
    {
        static bool anyMovesLeft(List<List<Cell>> _data)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                List<Cell> row = _data[i];
                for (int j = 0; j < _data.Count; j++)
                {
                    Cell cell = row[j];
                    if (cell._State == CELL_STATE._)
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        static void Main(string[] args)
        {
            Board board = new Board();

            VictoryReport report = GameWinAnalyzer.checkWinner(board._Cells);

            if (report.winner != CELL_STATE._)
            {
                Console.WriteLine(string.Format("The winner of the game was {0}, and they won by {1}", report.winner.ToString(), report.type.ToString()));
                Console.ReadLine();
                return;
            }

            else
            {
                if (!anyMovesLeft(board._Cells))
                {
                    Console.WriteLine("There were no available moves left, so the game is over with no winner");
                }
                else
                {
                    Console.WriteLine("There were some available spaces. Checking if win is possible or game is over");
                }

            }


            Console.ReadLine();
        }

        
    }
}