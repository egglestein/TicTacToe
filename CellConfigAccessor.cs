using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    //Access the cell config through an interface so that if any changes need to be made to the cell config no changes have to be made elsewhere
    public static class CellConfigAccessor
    {
        static CellConfigInterface cellConfig;

        public static void InitializeCellConfig()
        {
            cellConfig = CellConfigLoader.Load();
        }

        public static CellConfigInterface GetCellConfig()
        {
            return cellConfig;
        }
    }
}
