using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public abstract class WinConditionChecker
    {
        public string winConditionName;
        /*will check for condition and stop at earliest sign of failure or success, returning the winner if succesful or blank space if failure*/
        public abstract bool CheckCondition(List<List<Cell>> _data, out string _winner);
        /*will see if condition could possibly be finished, by seeing if more than one player occupies space needed to complete it*/
        public abstract bool FullyEvaluateCondition(List<List<Cell>> _data);
    }
}
