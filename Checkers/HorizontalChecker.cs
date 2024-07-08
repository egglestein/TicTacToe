using SimpliSafeTakeHomeAssesment.Checkers;
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
        public override bool CheckCondition(List<List<Cell>> _data, out string _winner)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (CheckRow(i, _data, out _winner))
                {
                    return true;
                }
            }
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            return false;
        }

        bool CheckRow(int _row, List<List<Cell>> _data, out string _winner)
        {
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            string startVal = _data[_row][0]._State;
            if (startVal == CellConfigAccessor.GetCellConfig()._EmptyValue)
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

        public override bool FullyEvaluateCondition(List<List<Cell>> _data)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (FullyEvaluateRow(i, _data))
                {
                    return true;
                }
            }
            return false;
        }

        bool FullyEvaluateRow(int _row, List<List<Cell>> _data)
        {
            string startVal = _data[_row][0]._State;
            if (startVal == CellConfigAccessor.GetCellConfig()._EmptyValue)
            {
                return false;
            }

            for (int i = 0; i < _data.Count; i++)
            {
                Cell cell = _data[_row][i];

                if (cell._State != startVal && cell._State != CellConfigAccessor.GetCellConfig()._EmptyValue)
                {
                    return false;
                }
            }
            return true;
        }

        public HorizontalChecker()
        {
            winConditionName = "Horizontal";
        }
    }
}
