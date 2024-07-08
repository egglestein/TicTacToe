using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Reflection;
using SimpliSafeTakeHomeAssesment;

namespace SimpliSafeTakeHomeAssesment
{

    public class BoardLoadParams
    {
        public List<List<int>> cellInfo;

        public BoardLoadParams()
        {
            cellInfo = new List<List<int>>();
        }
    }

    public class Board
    {
        List<List<Cell>> cells = new List<List<Cell>>();

        public List<List<Cell>> _Cells
        {
            get
            {
                return cells;
            }
        }

        public Board()
        {
            LoadCellConfig();
            LoadBoardState();
        }

        void LoadCellConfig()
        {
            CellConfigAccessor.InitializeCellConfig();
        }


        public void InitBoard(int _boardSize)
        {
            cells = new List<List<Cell>>();

            for (int i = 0; i < _boardSize; i++)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < _boardSize; j++)
                {
                    Cell cell = new Cell();
                    row.Add(cell);
                }
                cells.Add(row);
            }
        }

        public void LoadBoardState()
        {
            CellConfigInterface cellConfig = CellConfigAccessor.GetCellConfig();
            BoardLoadParams boardParams = BoardLoader.LoadBoard(cellConfig);

            InitBoard(boardParams.cellInfo.Count);

            Console.WriteLine("Writing out board");

            for (int i = 0; i < boardParams.cellInfo.Count; i++)
            {
                List<int> row = boardParams.cellInfo[i];
                for (int j = 0; j < row.Count; j++)
                {
                    cells[i][j]._State = cellConfig[row[j]];
                    Console.Write(cells[i][j]._State.ToString());
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
