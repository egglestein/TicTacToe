using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment.Checkers
{
    public class SquareChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> _data, out string _winner)
        {
            if (_data.Count < 2)
            {
                _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
                return false;
            }
            for (int i = 0; i < _data.Count - 1; i++)
            {
                for (int j = 0; j < _data.Count - 1; j++)
                {
                    if (CheckSquare(i, j, _data, out _winner))
                    {
                        return true;
                    }                    
                }
            }

            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            return false;
        }

        public bool CheckSquare(int _ulRow, int _ulCol, List<List<Cell>> _data, out string _winner)
        {
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            Cell UL = _data[_ulCol][_ulRow];
            if (UL._State == CellConfigAccessor.GetCellConfig()._EmptyValue)
            {
                return false;
            }

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

        public override bool FullyEvaluateCondition(List<List<Cell>> _data)
        {
            if (_data.Count < 2)
            {
                return false;
            }
            for (int i = 0; i < _data.Count - 1; i++)
            {
                for (int j = 0; j < _data.Count - 1; j++)
                {
                    if (FullyEvaluateSquare(i, j, _data))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool FullyEvaluateSquare(int _ulRow, int _ulCol, List<List<Cell>> _data)
        {
            Cell UL = _data[_ulCol][_ulRow];
            string emptyVal = CellConfigAccessor.GetCellConfig()._EmptyValue;

            Cell UR = _data[_ulCol][_ulRow + 1];
            if (UR._State != UL._State && UR._State != emptyVal)
                return false;

            Cell LL = _data[_ulCol + 1][_ulRow];
            if (LL._State != UL._State && LL._State != emptyVal)
                return false;

            Cell LR = _data[_ulCol + 1][_ulRow + 1];
            if (LR._State != UL._State && LR._State != emptyVal)
                return false;

            return true;
        }

        public SquareChecker()
        {
            winConditionName = "Square";
        }
    }
}
