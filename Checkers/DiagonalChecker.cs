using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    internal class DiagonalChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> _data, out string _winner)
        {
            if (CheckDiagonal(true, _data, out _winner))
            {
                return true;
            }
            else if (CheckDiagonal(false, _data, out _winner))
            {
                return true;
            }

            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            return false;
        }

        public bool CheckDiagonal(bool _goingLeft, List<List<Cell>> _data, out string _winner)
        {
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            int startVal = _goingLeft ? _data.Count - 1 : 0;
            int directionVal = _goingLeft ? -1 : 1;

            string startState = _data[0][startVal]._State;
            if (startState == CellConfigAccessor.GetCellConfig()._EmptyValue)
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


        public override bool FullyEvaluateCondition(List<List<Cell>> _data)
        {
            if (FullyEvaluateDiagonal(false, _data))
            {
                return true;
            }
            else if (FullyEvaluateDiagonal(true, _data))
            {
                return true;
            }
            return false;
        }

        public bool FullyEvaluateDiagonal(bool _goingLeft, List<List<Cell>> _data)
        {
            int startVal = _goingLeft ? _data.Count - 1 : 0;
            int directionVal = _goingLeft ? -1 : 1;

            string startState = _data[0][startVal]._State;

            for (int i = 0; i < _data.Count; i++)
            {
                Cell cell = _data[i][startVal + (i * directionVal)];
                if (cell._State != startState && cell._State != CellConfigAccessor.GetCellConfig()._EmptyValue)
                {
                    return false;
                }
            }
            return true;
        }

        public DiagonalChecker()
        {
            winConditionName = "Diagonal";
        }

    }
}
