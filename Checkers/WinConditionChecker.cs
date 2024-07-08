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
        public abstract bool CheckCondition(List<List<Cell>> _data, out string _winner);
        public abstract bool FullyEvaluateCondition(List<List<Cell>> _data);
    }
}
