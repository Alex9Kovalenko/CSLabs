using System;

namespace ConsoleApp2
{
    public class MyException : Exception
    {
        public MyException() : base() { }
        public MyException(string e) : base(e) { }
    }
}
