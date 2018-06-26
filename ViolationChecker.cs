using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class ViolationChecker
    {
        // This may be an improper use of OccurenceSet
        // I think that's supposed to count possibilities, but it's used to count written in occurences in actual. 
        private OccurenceSet actual;
        private OccurenceSet possible;

        public ViolationChecker() {
            actual = new OccurenceSet();
            possible = new OccurenceSet();
        }

        public void addValue(int value) {
            if(value >= 1)
                actual.addNumber(value);
        }

        public void addPossibilities(DictionaryPossible dp) {
            possible.addDictionary(dp);
        }

        public void addOccurences(OccurenceSet otherActual, OccurenceSet otherPossible) {
            actual.join(otherActual);
            possible.join(otherPossible);
        }

        public ViolationInfo isValid {
            get {
                int[] actualCounts = actual.occurenceCount;
                int[] possibleCounts = possible.occurenceCount;
                for(int i = 1; i <= 9; i++)
                    if(actualCounts[i] > 1)
                        // Invalid if a number is written > 1. 
                        return new ViolationInfo(true, i);
                    else if(actualCounts[i] == 0 && possibleCounts[i] == 0)
                        // The numebr is neither written nor possible
                        return new ViolationInfo(false, i);

                // Valid otherwise
                return null;
            }
        }
    }
}
