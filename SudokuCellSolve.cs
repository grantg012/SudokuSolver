using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class SudokuCellSolve : SudokuCell
    {
        protected internal DictionaryPossible numbers;
        protected internal CellIndices cellIndicies;

        public SudokuCellSolve(int row, int col) {
            numbers = new DictionaryPossible();
            cellIndicies = new CellIndices(row, col);
        }

        protected internal SudokuCellSolve(CellIndices ci, DictionaryPossible dp) {
            numbers = dp.copy();
            cellIndicies = new CellIndices(ci.row, ci.col);
        }

        public override int value {
            get { return numbers.value; }
        }

        public override int valueRaw {
            get { return numbers.valueRaw; }
        }

        public int possibilities {
            get { return numbers.possibilityCount; }
        }

        public int row {
            get {
                return cellIndicies.row;
            }
        }

        public int col {
            get {
                return cellIndicies.col;
            }
        }

        public CellIndices getCellIndicies {
            get {
                return cellIndicies;
            }
        }

        public override bool eliminateNumber(int number) {
            bool result = numbers.remove(number);
            // If there is now 1 possibility (cell is solved), then queue it
            if(result && numbers.possibilityCount == 1)
                frmMain.cellsToRender.Enqueue(cellIndicies);

            return result;
        }

        public override bool isPossible(int number) {
            return numbers.isPossible(number);
        }

        public void setNumbers(DictionaryPossible newNumbers) {
            numbers = newNumbers;
        }

        public DictionaryPossible getPossible {
            get { return numbers; }
        }

        public override void activateNumber(int number) {
            numbers.activateNumber(number);
        }

        public override SudokuCellSolve asSCS {
            // Just reduces that checks that occur bc of polymorphism. The base class method shouldn't be called
            get { 
                return this;
            }
        }

        public override SudokuCell copy() {
            return (SudokuCell)(new SudokuCellSolve(cellIndicies, numbers));
        }

        public override string ToString() {
            return "" + value;
        }
    }

    // Probably should name this class better. It compares moreso the possibilities of the cell that it's location. 
    // It's used to sort when solving for "mutually exclusive" elements. 
    class SudokuCellSolveCompare : IComparer<SudokuCellSolve>
    {
        public int Compare(SudokuCellSolve c1, SudokuCellSolve c2) {
            // c1 can be less than c2 if it has fewer potential numbers. Vice Versa too
            if(c1.possibilities != c2.possibilities)
                return c1.possibilities - c2.possibilities;
    
            // Check for a potential number that differs between the cells. 
            int[] d1 = c1.getPossible.possibleNumbers;
            int[] d2 = c2.getPossible.possibleNumbers;
            for(int i = 0; i < d1.Length; i++)
                if(d1[i] != d2[i])
                    // If a potential number differs, the lesser cell is the one with the lower potential number
                    return d1[i] - d2[i]; 

            // Otherwise their possibilities are equal. 
            return 0;
        }
    }
}
