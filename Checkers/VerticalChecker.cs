using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpliSafeTakeHomeAssesment
{
    internal class VerticalChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> _data, out string _winner)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (CheckColumn(i, _data, out _winner))
                {
                    return true;
                }   
            }
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            return false;
        }

        public override bool FullyEvaluateCondition(List<List<Cell>> _data)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (FullyEvaluateColumn(i, _data))
                {
                    return true;
                }
            }
            return false;
        }

        bool FullyEvaluateColumn(int _column, List<List<Cell>> _data)
        {
            string startVal = _data[0][_column]._State;

            //iterate down each column, and if at any point more than one player is found, it is false
            for (int i = 0; i < _data.Count; i++)
            {
                Cell cell = _data[i][_column];

                if (cell._State != startVal && cell._State != CellConfigAccessor.GetCellConfig()._EmptyValue)
                {
                    return false;
                }
            }
            return true;
        }

        bool CheckColumn(int _column, List<List<Cell>> _data, out string _winner)
        {
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            string startVal = _data[0][_column]._State;
            if (startVal == CellConfigAccessor.GetCellConfig()._EmptyValue)
            {
                return false;
            }

            //iterate down each column, and if at any point an item does not match the top point in the column, it is false
            for (int i = 0; i < _data.Count; i++)
            {
                Cell cell = _data[i][_column];

                if (cell._State != startVal)
                {
                    return false;
                }
            }

            _winner = startVal;
            return true;
        }


        public VerticalChecker()
        {
            winConditionName = "Vertical";
        }
    }
}
