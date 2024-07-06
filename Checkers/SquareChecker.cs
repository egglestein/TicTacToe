using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment.Checkers
{
    public class SquareChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> _data, out CELL_STATE _winner)
        {
            if (_data.Count < 2)
            {
                _winner = CELL_STATE._;
                return false;
            }
            for (int i = 0; i < _data.Count - 1; i++)
            {
                for (int j = 0; j < _data.Count - 1; j++)
                {
                    if (CheckSquare(i, j, _data, out _winner))
                    {
                        _winner = CELL_STATE._;
                        return true;
                    }                    
                }
            }

            _winner = CELL_STATE._;
            return false;
        }

        public bool CheckSquare(int _ulRow, int _ulCol, List<List<Cell>> _data, out CELL_STATE _winner)
        {
            _winner = CELL_STATE._;
            Cell UL = _data[_ulCol][_ulRow];

            Cell UR = _data[_ulCol][_ulRow + 1];
            if (UR._State != UL._State)
                return false;

            Cell LL = _data[_ulCol + 1][_ulRow];
            if (LL._State != UL._State)
                return false;

            Cell LR = _data[_ulCol + 1][_ulRow + 1];
            if (LR._State != UL._State)
                return false;

            _winner = UL._State;
            return true;

        }
    }
}
