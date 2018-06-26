using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class CellIndices
    {
        private int rowIndex;
        private int colIndex;

        public CellIndices(int row, int col) {
            rowIndex = row;
            colIndex = col;
        }

        public int row {
            get { return rowIndex; }
        }

        public int col {
            get { return colIndex; }
        }

        public int majorRow {
            get { return rowIndex / 3 * 3; }
        }

        public int majorCol {
            get { return colIndex / 3 * 3; }
        }

        public static bool operator ==(CellIndices ci1, CellIndices ci2) {
            return ci1.row == ci2.row && ci1.col == ci2.col;
        }

        public static bool operator !=(CellIndices ci1, CellIndices ci2) {
            return !(ci1 == ci2);
        }

        public override bool Equals(object o) {
            return o is CellIndices && (CellIndices)o == this;
        }

        public override string ToString() {
            return "[" + (rowIndex + 1) + ", " + (colIndex + 1) + ']';
        }
    }
}
