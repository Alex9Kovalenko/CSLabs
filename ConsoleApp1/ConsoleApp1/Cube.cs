namespace ConsoleApp1
{
    public class Cube
    {
        private readonly char[] letters;

        public Cube(string str)
        {
            letters = new char[6];
            for (int i = 0; i < 6; ++i)
            {
                letters[i] = str[i];
            }
        }

        public bool Contains(char c)
        {
            foreach (char letter in letters)
            {
                if (letter == c) return true;
            }
            return false;
        }

        public char[] Letters => letters;
    }
}
