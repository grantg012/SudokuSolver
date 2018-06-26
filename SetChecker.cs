namespace SudokuSolver
{
    public class SetChecker : OccurenceSet
    {
        private bool hasInvalidEntries;

        public SetChecker() : base() {
            hasInvalidEntries = false;
        }

        public new void addNumber(int number) {
            if(number >= 1 && number <= 9)
                occurenceCount[number]++;
            else {
                hasInvalidEntries = true;
            }
        }

        public bool validSet {
            // Check if each number occurs exactly once, indicating it is a valid row, column or mb. 
            get {
                if(hasInvalidEntries)
                    return false;

                for(int number = 1; number <= 9; number++)
                    if(occurenceCount[number] != 1)
                        return false;

                return true;
            }
        }
    }
}
