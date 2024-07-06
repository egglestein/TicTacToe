using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public enum CELL_STATE
    {
        _ = 0,
        X,
        O
    }

    public class Cell
    {
        CELL_STATE state;
        public CELL_STATE _State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public Cell()
        {
            state = CELL_STATE._;
        }
    }
}
