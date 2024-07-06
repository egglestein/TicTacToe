using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public abstract class WinConditionChecker
    {
        public abstract bool CheckCondition(List<List<Cell>> data, out CELL_STATE winner);
    }
}
