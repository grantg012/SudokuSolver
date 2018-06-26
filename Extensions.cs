using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class Extensions
    {
        public static string arrayToString<T>(this T[] array) {
            if(array.Length == 0)
                return "";

            StringBuilder sb = new StringBuilder("[");
            for(int i = 0; i < array.Length - 1; i++)
                sb.Append(array[i]).Append(", ");

            return sb.Append(array.Last()).Append(']').ToString();
        }

        public static string elementsToString<T>(this List<T> list) {
            if(list.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < list.Count - 1; i++)
                sb.Append(list[i]).Append(", ");

            return sb.Append("and ").Append(list.Last()).ToString();
        }

        public static int toInt(this bool b) {
            return b ? 1 : 0;
        }
    }
}
