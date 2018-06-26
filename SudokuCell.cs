namespace SudokuSolver
{
    public abstract class SudokuCell
    {
        public abstract int value { get; }

        public abstract int valueRaw { get; }

        // public abstract void eliminateNumber(int number);

        public abstract bool isPossible(int number);

        public abstract void activateNumber(int number);

        public abstract bool eliminateNumber(int number);

        public virtual SudokuCellSolve asSCS {
            get {
                if(this is SudokuCellSolve)
                    return (SudokuCellSolve)this;
                else
                    throw new System.Exception("Error: tried converting a non-SudokuCellSolve object to that type. ");
            }
        }

        public abstract SudokuCell copy();
    }
}
