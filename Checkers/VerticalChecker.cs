using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    internal class VerticalChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> data, out CELL_STATE _winner)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (CheckColumn(i, data, out _winner))
                {
                    return true;
                }   
            }
            _winner = CELL_STATE._;
            return false;
        }

        bool CheckColumn(int _column, List<List<Cell>> data, out CELL_STATE _winner)
        {
            _winner = CELL_STATE._;
            CELL_STATE startVal = data[0][_column]._State;
            if (startVal == CELL_STATE._)
            {
                return false;
            }

            for (int i = 0; i < data.Count; i++)
            {
                Cell cell = data[i][_column];

                if (cell._State != startVal)
                {
                    return false;
                }
            }

            _winner = startVal;
            return true;
        }
    }
}
