using System;

namespace ConsoleApp2
{
    public abstract class Equation // this name is more preferable than 'Solution'
    {
        public abstract void Solve();
        public abstract void Print();
        public abstract Equation DeepCopy();
    }
}
