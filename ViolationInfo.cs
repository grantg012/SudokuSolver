using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class ViolationInfo
    {
        private bool _isDoubleWrite;
        private Grouping _grouping;
        private int _number;
        private int _groupingArea;

        public ViolationInfo(bool isDoubleWrite, int number) : this(isDoubleWrite, Grouping.unknown, number) {
        }

        public ViolationInfo(bool isDoubleWrite, Grouping grouping, int number, int groupingArea = -1) {
            this._isDoubleWrite = isDoubleWrite;
            this._grouping = grouping;
            this._number = number;
            this._groupingArea = groupingArea;
        }

        public Grouping grouping {
            get {
                return _grouping;
            }
            set {
                _grouping = value;
            }
        }

        public bool isDoubleWrite {
            get { return _isDoubleWrite; }
        }

        public int number {
            get { return _number; }
        }

        public int groupingArea {
            get {
                return _groupingArea;
            }
            set {
                _groupingArea = value;
            }
        }

        public enum Grouping { row, column, miniblock, unknown};

        public override string ToString() {
            string s = _number + (_isDoubleWrite ? " was used twice" : " is not possible") + " in ";
            if(grouping == Grouping.row)
                s += "row " + (_groupingArea + 1);
            else if(grouping == Grouping.column)
                s += "column " + (_groupingArea + 1);
            else if(grouping == Grouping.miniblock)
                s += "miniblock [" + (_groupingArea / 3 + 1) + ", " + (groupingArea % 3 + 1) + "]";
            return s;
        }
    }

}
