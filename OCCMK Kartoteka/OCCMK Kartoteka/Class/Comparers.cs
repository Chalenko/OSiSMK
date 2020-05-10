using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OCCMK_Kartoteka
{
    abstract class Comparer : System.Collections.Generic.IComparer<string>
    {
        protected int sortOrderModifier = 1;

        public Comparer()
        {
        }

        public Comparer(ListSortDirection sortOrder)
        {
            if (sortOrder == ListSortDirection.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == ListSortDirection.Ascending)
            {
                sortOrderModifier = 1;
            }
        }

        public abstract int Compare(string x, string y);
    }

    class DateComparer : Comparer
    {
        public DateComparer(ListSortDirection sortOrder) : base(sortOrder)
        {
        }

        public DateComparer() : base()
        {
        }

        public override int Compare(string x, string y)
        {
            int CompareResult = 0;
            if (System.String.Compare(x, y) != 0)
            {
                try
                {
                    Convert.ToDateTime(x);
                    try
                    {
                        Convert.ToDateTime(y);
                        CompareResult = System.DateTime.Compare(Convert.ToDateTime(x), Convert.ToDateTime(y));
                    }
                    catch
                    {
                        CompareResult = 1;
                    }
                }
                catch
                {
                    CompareResult = -1;
                }
                
            }

            return CompareResult * sortOrderModifier;
        }
    }

    class TextComparer : Comparer
    {
        public TextComparer(ListSortDirection sortOrder) : base(sortOrder)
        {
        }

        public TextComparer()
        {
            // TODO: Complete member initialization
        }

        public override int Compare(string x, string y)
        {
            return sortOrderModifier * System.String.Compare(x, y);
        }
    }

    class NumberComparer : Comparer
    {
        public NumberComparer(ListSortDirection sortOrder) : base(sortOrder)
        {
        }

        public NumberComparer()
        {
            // TODO: Complete member initialization
        }

        public override int Compare(string x, string y)
        {
            int CompareResult = 0;
            if (System.String.Compare(x, y) != 0)
            {
                try
                {
                    Convert.ToDouble(x);
                    try
                    {
                        Convert.ToDouble(y);
                        CompareResult = Convert.ToDouble(x).CompareTo(Convert.ToDouble(y));
                    }
                    catch
                    {
                        CompareResult = 1;
                    }
                }
                catch
                {
                    CompareResult = -1;
                }

            }

            return CompareResult * sortOrderModifier;
        }
    }

    class NaturalComparer : Comparer
    {
        //http://www.codeproject.com/Articles/22517/Natural-Sort-Comparer
        private Dictionary<string, string[]> table;

        public NaturalComparer()
        {
            table = new Dictionary<string, string[]>();
        }

        public NaturalComparer(ListSortDirection sortOrder) : base(sortOrder)
        {
            table = new Dictionary<string, string[]>();
        }

        public override int Compare(string x, string y)
        {
            if (x == y)
            {
                return 0;
            }

            string[] x1, y1;
            
            if (!table.TryGetValue(x, out x1))
            {
                x1 = System.Text.RegularExpressions.Regex.Split(x.Replace(" ", ""), "([0-9]+)");
                table.Add(x, x1);
            }

            if (!table.TryGetValue(y, out y1))
            {
                y1 = System.Text.RegularExpressions.Regex.Split(y.Replace(" ", ""), "([0-9]+)");
                table.Add(y, y1);
            }

            for (int i = 0; i < x1.Length && i < y1.Length; i++)
            {
                if (x1[i] != y1[i])
                {
                    return PartCompare(x1[i], y1[i]);
                }
            }

            if (y1.Length > x1.Length)
            {
                return 1;
            }
            else if (x1.Length > y1.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int PartCompare(string left, string right)
        {
            int x, y;

            if (!int.TryParse(left, out x))
            {
                return left.CompareTo(right);
            }

            if (!int.TryParse(right, out y))
            {
                return left.CompareTo(right);
            }

            return x.CompareTo(y);
        }
    } 
}
