using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    internal class DiagonalChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> _data, out CELL_STATE _winner)
        {
            if (CheckDiagonal(true, _data, out _winner))
            {
                return true;
            }
            else if (CheckDiagonal(false, _data, out _winner))
            {
                return true;
            }

            _winner = CELL_STATE._;
            return false;
        }

        public bool CheckDiagonal(bool _goingLeft, List<List<Cell>> _data, out CELL_STATE _winner)
        {
            _winner = CELL_STATE._;
            int startVal = _goingLeft ? _data.Count - 1 : 0;
            int directionVal = _goingLeft ? -1 : 1;

            CELL_STATE startState = _data[0][startVal]._State;
            if (startState == CELL_STATE._)
            {
                return false;
            }

            for (int i = 0; i < _data.Count; i++)
            {
                Cell cell = _data[i][startVal + (i * directionVal)];
                if (cell._State != startState)
                {
                    return false;
                }
            }
            _winner = startState;
            return true;
        }

    }
}
