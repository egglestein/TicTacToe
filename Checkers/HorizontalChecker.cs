using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    internal class HorizontalChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> _data, out CELL_STATE _winner)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (CheckRow(i, _data, out _winner)) ;
                {
                    return true;
                }
            }
            _winner = CELL_STATE._;
            return false;
        }

        bool CheckRow(int _row, List<List<Cell>> _data, out CELL_STATE _winner)
        {
            _winner = CELL_STATE._;
            CELL_STATE startVal = _data[_row][0]._State;
            if (startVal == CELL_STATE._)
            {
                return false;
            }

            for (int i = 0; i < _data.Count; i++)
            {
                Cell cell = _data[_row][i];

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
