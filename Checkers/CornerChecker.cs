using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public class CornerChecker : WinConditionChecker
    {
        public override bool CheckCondition(List<List<Cell>> data, out CELL_STATE _winner)
        {
            _winner = CELL_STATE._;
            CELL_STATE ULCheck = data[0][0]._State;

            if (data[0][data.Count - 1]._State != ULCheck)
            {
                return false;
            }
            else if (data[data.Count - 1][0]._State != ULCheck)
            {
                return false;
            }
            else if (data[data.Count - 1][data.Count - 1]._State != ULCheck)
            {
                return false;
            }

            _winner = ULCheck;
            return true;
        }
    }
}
