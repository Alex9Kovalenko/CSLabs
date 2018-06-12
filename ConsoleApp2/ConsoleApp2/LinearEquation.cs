using System;

namespace ConsoleApp2
{
    public class LinearEquation : Equation
    {
        private readonly double A, B;

        public LinearEquation(double A, double B)
        {
            this.A = A;
            this.B = B;
        }

        public override void Solve()
        {
            Console.Write("The equation ");
            Print();
            if (A == 0)
            {
                Console.WriteLine(B == 0
                    ? " has an infinite number of roots"
                    : " has no real roots");
            }
            else
            {
                Console.WriteLine(" has the single root: " + -B / A);
            }
            
        }

        public override void Print()    // B = 0, A = 1
        {
            Console.Write(ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(LinearEquation)))
            {
                LinearEquation leq = (LinearEquation)obj;
                return A == leq.A && B == leq.B;
            }
            else return false;
        }

        public static bool operator ==(LinearEquation leq1, LinearEquation leq2)
        {
            return leq1.Equals(leq2);
        }

        public static bool operator !=(LinearEquation leq1, LinearEquation leq2)
        {
            return !leq1.Equals(leq2);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + A.GetHashCode();
            hash = (hash * 7) + B.GetHashCode();
            return hash;
        }

        public override Equation DeepCopy()
        {
            return new LinearEquation(A, B);
        }

        public override string ToString()
        {
            return $"{A}*x " + (B < 0 ? "" : "+ ") + $"{B} = 0";
        }
    }
}
