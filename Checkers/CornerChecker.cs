using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpliSafeTakeHomeAssesment
{
    public class CornerChecker : WinConditionChecker
    {
        /*Simply check all 4 corners and see if they match, but return as soon as an empty or a non match hits*/
        public override bool CheckCondition(List<List<Cell>> _data, out string _winner)
        {
            _winner = CellConfigAccessor.GetCellConfig()._EmptyValue;
            string ULCheck = _data[0][0]._State;

            if (_data[0][_data.Count - 1]._State != ULCheck)
            {
                return false;
            }
            else if (_data[_data.Count - 1][0]._State != ULCheck)
            {
                return false;
            }
            else if (_data[_data.Count - 1][_data.Count - 1]._State != ULCheck)
            {
                return false;
            }

            _winner = ULCheck;
            return true;
        }

        /*Check all 4 corners and return false if more than one player is present*/
        public override bool FullyEvaluateCondition(List<List<Cell>> _data)
        {
            string ULCheck = _data[0][0]._State;
            string URCheck = _data[0][_data.Count - 1]._State;
            string LLCheck = _data[_data.Count - 1][0]._State;
            string LRCheck = _data[_data.Count - 1][_data.Count - 1]._State;

            string emptyValue = CellConfigAccessor.GetCellConfig()._EmptyValue;

            if (URCheck != ULCheck && URCheck != emptyValue)
            {
                return false;
            }
            else if (LLCheck != ULCheck && LLCheck != emptyValue)
            {
                return false;
            }
            else if (LRCheck != ULCheck && LRCheck != emptyValue)
            {
                return false;
            }

            return true;
        }


        public CornerChecker()
        {
            winConditionName = "Corner";
        }
    }
}
