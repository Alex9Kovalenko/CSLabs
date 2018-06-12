using System;

namespace ConsoleApp2
{
    class SquareEquation : Equation
    {
        private readonly double A, B, C;

        public SquareEquation(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public override void Print()    // C = 0, A = 1, B = 1
        {
            Console.Write(ToString());
        }

        public override void Solve()
        {
            Console.Write("The equation ");
            Print();
            if (A == 0)
            {
                if (B == 0)
                {
                    Console.WriteLine(C == 0
                        ? " has an infinite number of roots"
                        : " has no real roots");
                }
                else
                {
                    Console.WriteLine(" has the single root: " + -C / B);
                }
            }
            else
            {
                double D = B*B - 4*A*C;
                if (D < 0)
                {
                    Console.WriteLine(" has no real roots");
                }
                else if (D == 0)
                {
                    Console.WriteLine(" has the single root: " + -B / (2 * A));
                }
                else
                {
                    double sqrtD = Math.Sqrt(D);
                    Console.WriteLine(" has two real roots: "
                        + (-B + sqrtD) / (2 * A) + " and "
                        + (-B - sqrtD) / (2 * A));
                }
                
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(SquareEquation)))
            {
                SquareEquation seq = (SquareEquation)obj;
                return A == seq.A && B == seq.B && C == seq.C;
            }
            else return false;
        }

        public static bool operator ==(SquareEquation seq1, SquareEquation seq2)
        {
            return seq1.Equals(seq2);
        }

        public static bool operator !=(SquareEquation seq1, SquareEquation seq2)
        {
            return !seq1.Equals(seq2);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = (hash * 3) + A.GetHashCode();
            hash = (hash * 3) + B.GetHashCode();
            hash = (hash * 3) + C.GetHashCode();
            return hash;
        }

        public override Equation DeepCopy()
        {
            return new SquareEquation(A, B, C);
        }

        public override string ToString()
        {
            return $"{A}*x^2 "
                + (B < 0 ? "" : "+ ") + $"{B}*x "
                + (C < 0 ? "" : "+ ") + $"{C} = 0";
        }
    }
}
