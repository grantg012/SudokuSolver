using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class OccurenceSet
    {
        protected internal int[] occurenceCount;

        public OccurenceSet() {
            occurenceCount = new int[10];
        }

        public OccurenceSet(DictionaryPossible dp) {
            occurenceCount = new int[10];
            for(int i = 1; i <= 9; i++)
                if(dp.isPossible(i))
                    occurenceCount[i] = 1;
        }

        public OccurenceSet(DictionaryPossible[] dpArray) {
            occurenceCount = new int[10];
            for(int i = 1; i <= 9; i++)
                foreach(DictionaryPossible dp in dpArray)
                    if(dp.isPossible(i))
                        occurenceCount[i]++;
        }

        public static OccurenceSet operator +(OccurenceSet o1, OccurenceSet o2) {
            OccurenceSet result = new OccurenceSet();
            for(int i = 1; i <= 9; i++)
                result.occurenceCount[i] = o1.occurenceCount[i] + o2.occurenceCount[i];
            return result;
        }

        public void join(OccurenceSet other) {
            for(int i = 1; i <= 9; i++)
                occurenceCount[i] += other.occurenceCount[i];
        }

        public void addDictionary(DictionaryPossible dp) {
            for(int i = 1; i <= 9; i++)
                if(dp.isPossible(i))
                    occurenceCount[i]++;
        }

        public void addDictionaries(DictionaryPossible[] dpa) {
            foreach(DictionaryPossible dp in dpa) {
                addDictionary(dp);
            }
        }

        public void addNumber(int number) {
            occurenceCount[number]++;
        }

        public List<int> oneOfs {
            get {
                List<int> result = new List<int>(3);
                for(int i = 1; i <= 9; i++)
                    if(occurenceCount[i] == 1)
                        result.Add(i);

                return result;
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder("Occurences: ");
            for(int number = 1; number <= 9; number++)
                sb.Append(number).Append("-").Append(occurenceCount[number]).Append(", ");
            return sb.ToString();
        }

        //public int nOccurencesOf(int number) {
        //    return occurenceCount[number];
        //}
    }
}
