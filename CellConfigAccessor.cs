using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
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
