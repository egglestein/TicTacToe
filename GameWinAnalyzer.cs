using SimpliSafeTakeHomeAssesment.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public struct VictoryReport
    {
        public string winner;
        public string victoryType;

        public VictoryReport()
        {
            victoryType = "";
            winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
        }
    }


    public static class GameWinAnalyzer
    {
        static List<WinConditionChecker> winConditionChecks = new List<WinConditionChecker>();
        //organize check conditions in order of least to most demanding. this way you only need to do the expensive operations if necessary.

        //since conditions are set up as extensions of a base class, it is extremely easy to add and remove new conditions without changing
        //any code aside from having to write them out and then add them to the active conditions to check for
        public static void InitializeWinConditions()
        {
            winConditionChecks = new List<WinConditionChecker>
            {
                new CornerChecker(),
                new DiagonalChecker(),
                new HorizontalChecker(),
                new VerticalChecker(),
                new SquareChecker()
            };
        }

        public static VictoryReport checkWinner(List<List<Cell>> _data)
        {
            VictoryReport victoryReport = new VictoryReport();

            for (int i = 0; i < winConditionChecks.Count; i++)
            {
                string winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
                winConditionChecks[i].CheckCondition(_data, out winner);
                if (winner != CellConfigAccessor.GetCellConfig()._EmptyValue)
                {
                    victoryReport.winner = winner;
                    victoryReport.victoryType = winConditionChecks[i].winConditionName;
                    return victoryReport;
                }
            }

            return victoryReport;
           
        }

        public static bool isGameOver(List<List<Cell>> _data)
        {
            for (int i = 0; i < winConditionChecks.Count; i++)
            {
                if (winConditionChecks[i].FullyEvaluateCondition(_data))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
