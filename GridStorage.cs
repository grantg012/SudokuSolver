using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class GridStorage
    {
        private CellStorage[,] stored;

        public GridStorage(SudokuCell[,] grid) {
            stored = new CellStorage[9, 9];
            for(int row = 0; row < 9; row++) {
                for(int col = 0; col < 9; col++) {
                    stored[row, col] = new CellStorage(grid[row, col].value, grid[row, col] is SudokuCellFixed);
                }
            }
        }

        public int storedAt(int row, int col) {
            return stored[row, col].getValue;
        }

        public bool fixedAt(int row, int col) {
            return stored[row, col].getFixed;
        }
    }

    class CellStorage {
        protected int value;
        protected bool isFixed;

        public CellStorage(int value, bool isFixed) {
            this.value = value;
            this.isFixed = isFixed;
        }

        public int getValue {
            get { return value; }
        }

        public bool getFixed {
            get { return isFixed; }
        }
    }
}
