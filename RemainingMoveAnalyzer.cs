﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public static class RemainingMoveAnalyzer
    {
        /*Simply iterate through and stop upon reaching an empty space, since that means at least one move can still be made*/
        public static bool anyMovesLeft(List<List<Cell>> _data)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                List<Cell> row = _data[i];
                for (int j = 0; j < _data.Count; j++)
                {
                    Cell cell = row[j];
                    if (cell._State == CellConfigAccessor.GetCellConfig()._EmptyValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
