namespace SudokuSolver
{
    class SudokuCellFixed : SudokuCell
    {
        private int initialValue;

        public SudokuCellFixed(int prmValue) {
            initialValue = prmValue;
        }

        public SudokuCellFixed(object prmValue) : this(int.Parse((string)prmValue)) {}

        public override int value {
            get { return initialValue; }
        }

        public override int valueRaw {
            get { return initialValue; }
        }

        public override bool isPossible(int number) {
            return false;
        }

        public override void activateNumber(int number) {}

        public override bool eliminateNumber(int number) { return false; }

        public override SudokuCell copy() {
            // Pretty sure this object can't be modified so ok to keep using is itself. 
            return this;
        }
    }
}
