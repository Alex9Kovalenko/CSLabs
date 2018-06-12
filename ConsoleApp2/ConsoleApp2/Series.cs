using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Series
    {
        private readonly List<Equation> equations;

        public int Size => equations.Count;

        public Series()
        {
            equations = new List<Equation>();
        }

        public void PrintAll()
        {
            Console.WriteLine("Your equations from the series:\n");
            foreach (Equation eq in equations)
            {
                eq.Print();
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SolveAll()
        {
            Console.WriteLine("The solutions of the equations from the series:\n");
            foreach (Equation eq in equations)
            {
                eq.Solve();
            }
            Console.WriteLine();
        }

        public void Add(Equation eq)
        {
            equations.Add(eq);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Series)))
            {
                Series s = (Series)obj;
                if (Size == s.Size)
                {
                    for (int i = 0; i < Size; ++i)
                    {
                        if (!equations[i].Equals(s.equations[i]))
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Series s1, Series s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Series s1, Series s2)
        {
            return !s1.Equals(s2);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            foreach (Equation eq in equations)
            {
                hash = (hash * 7) + eq.GetHashCode();
            }
            return hash;
        }

        public Series DeepCopy()
        {
            Series copy = new Series();
            foreach (Equation eq in equations)
            {
                copy.Add(eq.DeepCopy());
            }
            return copy;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Equation eq in equations)
            {
                s += eq.ToString();
                s += '\n';
            }
            return s;
        }

        public static void Test()
        {
            Series s1 = new Series();
            s1.Add(new LinearEquation(1, 2));
            s1.Add(new SquareEquation(6.43, 41.3, 9));
            s1.Add(new LinearEquation(4.3, 9));

            Series s2 = s1.DeepCopy();

            Series s3 = new Series();
            s3.Add(new SquareEquation(5, 4, -9.5));
            s3.Add(new SquareEquation(6, 34.5, 0.32));
            s3.Add(new LinearEquation(-53, -7.6));

            Console.WriteLine("Your set of series:\n"
                + "\n" + s1.ToString()
                + "\n" + s2.ToString()
                + "\n" + s3.ToString());

            Console.WriteLine("s1 == s2 : " + (s1 == s2));
            Console.WriteLine("s2 == s3 : " + (s2 == s3));

            Console.WriteLine("s1.Equals(s2) : " + s1.Equals(s2));
            Console.WriteLine("s2.Equals(s3) : " + s2.Equals(s3));

            Console.WriteLine("s1.GetHashCode() : " + s1.GetHashCode());
            Console.WriteLine("s2.GetHashCode() : " + s2.GetHashCode());
            Console.WriteLine("s3.GetHashCode() : " + s3.GetHashCode());

            Console.WriteLine("Let's solve all the equations we have!");
            s1.SolveAll();
            s2.SolveAll();
            s3.SolveAll();
        }
    }
}
