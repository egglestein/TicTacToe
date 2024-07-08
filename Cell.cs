using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public class Cell
    {
        string activeState;

        public string _State
        {
            get
            {
                return activeState;
            }
            set
            {
                activeState = value;
            }
        }

        public Cell()
        {
            activeState = "";
        }
    }
}
