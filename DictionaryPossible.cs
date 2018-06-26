using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class DictionaryPossible {
        private bool[] numberIsPossible;
        private int calculatedValue;
        private int _possibilityCount;

        public DictionaryPossible(bool defaultValue = true) {
            numberIsPossible = new bool[10];
            for(int i = 1; i <= 9; i++)
                numberIsPossible[i] = defaultValue;

            calculatedValue = -1;
            _possibilityCount = defaultValue ? 9 : 0;
        }

        public DictionaryPossible(DictionaryPossible dP1, DictionaryPossible dP2, DictionaryPossible dP3) {
            numberIsPossible = new bool[10];
            _possibilityCount = 0;
            int lastPossible = -1;
            for(int i = 1; i <= 9; i++) {
                numberIsPossible[i] = dP1.isPossible(i) && dP2.isPossible(i) && dP3.isPossible(i);
                if(numberIsPossible[i]) {
                    lastPossible = i;
                    _possibilityCount++;
                }
            }

            if(_possibilityCount == 1)
                calculatedValue = lastPossible;
            else
                calculatedValue = -1;
        }

        public DictionaryPossible(DictionaryPossible dp) {
            calculatedValue = dp.calculatedValue;
            _possibilityCount = dp._possibilityCount;
            numberIsPossible = new bool[10];
            dp.numberIsPossible.CopyTo(numberIsPossible, 0);
        }

        public int value {
            get {
                if(calculatedValue != -1) {
                    return calculatedValue;
                } else {
                    if(_possibilityCount == 1) // calculate when there is 1 possibility
                        for(int i = 1; i <= 9; i++)
                            if(numberIsPossible[i]) {
                                calculatedValue = i;
                                break;
                            }

                    return calculatedValue;
                }
            }
        }

        public int valueRaw {
            get { return calculatedValue; }
        }

        public int possibilityCount {
            get { return _possibilityCount; }
        }

        public int[] possibleNumbers {
            get {
                int[] array = new int[_possibilityCount];
                int usedIndex = 0;
                for(int number = 1; number <= 9; number++)
                    if(numberIsPossible[number])
                        array[usedIndex++] = number;
                return array;
            }
        }

        public bool remove(int number) {
            // True is number was present (dictionary changed)
            if(number != -1) {
                bool present = numberIsPossible[number];
                if(present) {
                    numberIsPossible[number] = false;
                    _possibilityCount--;
                }
                return present;
            } else
                return false;
        }

        public bool isPossible(int number) {
            return numberIsPossible[number];
        }

        private StringBuilder sbPossibleNumbers(StringBuilder sb) {
            for(int i = 1; i <= 9; i++) {
                if(numberIsPossible[i])
                    sb.Append(i).Append(", ");
            }
            if(sb.Length >= 2)
                sb.Length -= 2;
            return sb;
        }

        public override string ToString() {
            return sbPossibleNumbers(new StringBuilder("Possible Values: ")).ToString();
        }

        public string stringPossibleNumbers {
            get {
                return sbPossibleNumbers(new StringBuilder()).ToString();
            }
        }

        public void activateNumber(int number) {
            calculatedValue = number;
            _possibilityCount = 1;
            for(int i = 1; i < number; i++)
                numberIsPossible[i] = false;
            for(int i = number + 1; i <= 9; i++)
                numberIsPossible[i] = false;
        }

        public void addPossibles(DictionaryPossible dp) {
            for(int number = 1; number <= 9; number++)
                if(!numberIsPossible[number] && dp.numberIsPossible[number]) {
                    numberIsPossible[number] = true;
                    _possibilityCount++;
                }
        }

        public DictionaryPossible copy() {
             return new DictionaryPossible(this);
        }

        public static bool operator ==(DictionaryPossible dp1, DictionaryPossible dp2) {
            if(dp1._possibilityCount != dp2._possibilityCount)
                return false;

            for(int number = 1; number <= 9; number++)
                if(dp1.numberIsPossible[number] != dp2.numberIsPossible[number])
                    return false;

            return true;
        }

        public static bool operator !=(DictionaryPossible dp1, DictionaryPossible dp2) {
            return !(dp1 == dp2);
        }

        public override bool Equals(object o) {
            return o is DictionaryPossible && (DictionaryPossible)o == this;
        }
    }
}
