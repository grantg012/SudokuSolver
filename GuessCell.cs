using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class GuessCell
    {
        private int _guess;
        private CellIndices cell;
        private int _step;
        private SudokuCell[,] grid;
        private int _cellsLeft;

        public GuessCell(int guess, CellIndices _cell, int step, SudokuCell[,] saved, int cellsLeft) {
            _guess = guess;
            cell = _cell;
            _step = step;
            grid = saved;
            _cellsLeft = cellsLeft;
        }

        public int guess {
            get { return _guess; }
        }

        public CellIndices indices {
            get { return cell; }
        }

        public int step {
            get { return _step; }
        }

        public SudokuCell[,] saved {
            get { return grid; }
        }

        public int cellsLeft{
            get { return _cellsLeft; }
        }
    }
}
