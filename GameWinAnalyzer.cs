using SimpliSafeTakeHomeAssesment.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public enum VictoryTypes
    {
        CORNERS,
        DIAGONALS,
        HORIZONTALS,
        VERTICALS,
        SQUARES,
        NONE
    }

    public struct VictoryReport
    {
        public VictoryTypes type;
        public CELL_STATE winner;

        public VictoryReport()
        {
            type = VictoryTypes.NONE;
            winner = CELL_STATE._;
        }
    }


    public static class GameWinAnalyzer
    {
        static List<WinConditionChecker> winConditionChecks = new List<WinConditionChecker>();

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
                CELL_STATE winner = CELL_STATE._;
                winConditionChecks[i].CheckCondition(_data, out winner);
                if (winner != CELL_STATE._)
                {
                    victoryReport.winner = winner;
                    victoryReport.type = (VictoryTypes)i;
                    return victoryReport;
                }
            }

            return victoryReport;
           
        }
    }
}
