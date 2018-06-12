using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static string name;
        static Cube[] cubes;

        static void Main(string[] args)
        {
            cubes = new Cube[EnterNum()];
            EnterName(out name);
            FillCubes(cubes);

            OutputResults(ComposeName(name, cubes));

            Console.WriteLine("Press [Enter] to continue...");
            Console.ReadLine();
        }

        static int EnterNum()
        {
            Console.Write("Enter the number of cubes: ");
            string input;
            int number;

            while (true)
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input, out number) && number > 0
                    && number < 100)
                {
                    Console.WriteLine();
                    return number;
                }
                else
                {
                    Console.Write("Wrong value for the number of cubes! "
                        + "Try again: ");
                }
            }

        }

        static void EnterName(out string name)
        {
            Console.Write("Great! Now enter the name of Peter's sister: ");
            do
            {
                name = Console.ReadLine();
            } while (name.Length >= 100);
            name = name.ToUpper();
            Console.WriteLine(name + " is co cute name!\n");
        }

        static void FillCubes(Cube[] cubes)
        {
            Console.WriteLine("You're such a nut! Enter 6 letters for each "
                + "cube\n(lines with more than 6 characters will be truncated): ");
            string input;
            for (int i = 0, number = cubes.Length; i < number; ++i)
            {
                do
                {
                    Console.Write(i + ": ");
                    input = Console.ReadLine();
                } while (input.Length < 6);
                cubes[i] = new Cube(input.ToUpper());
            }
            Console.WriteLine();
        }

        static List<int> ComposeName(string name, Cube[] cubes)
        {
            if (name.Length > cubes.Length) return null;

            Stack<int> sequence = new Stack<int>(name.Length);
            bool found = false;
            int firstCubeIndex = 0;

            for (int letterIndex = 0, len = name.Length; letterIndex < len; 
                /*no inc*/)
            {
                found = false;
                for (int cubeIndex = firstCubeIndex, number = cubes.Length;
                    cubeIndex < number; ++cubeIndex)
                {
                    if (cubes[cubeIndex].Contains(name[letterIndex]) 
                        && !sequence.Contains(cubeIndex))
                    {
                        sequence.Push(cubeIndex);
                        found = true;
                        ++letterIndex;
                        firstCubeIndex = 0;
                        break;
                    }
                }
                if (!found)
                {
                    if (sequence.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        firstCubeIndex = sequence.Pop() + 1;
                        --letterIndex;
                    }
                }
            }
            List<int> list = new List<int>(sequence);
            list.Reverse();
            return list;
        }

        static void OutputResults(List<int> sequence)
        {
            if (sequence != null)
            {
                int tmp;
                Console.WriteLine("You can compose the name " + name
                    + " as follows:\n");
                for (int i = 0, len = name.Length; i < len; ++i)
                {
                    Console.WriteLine(i + " (" + name[i] + "): cube #"
                        + (tmp = sequence[i]) + " ("
                        + new string(cubes[tmp].Letters) + ")");
                }
            }
            else
            {
                Console.WriteLine("You cannot compose the name " + name
                    + " with your set of cubes.");
            }
            Console.WriteLine();
        }
    }
}
