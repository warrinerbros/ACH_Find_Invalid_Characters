using System;
using System.Text;

namespace ACH_Invalid_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for correct amount of command line arguments
            if (args.Length != 1)
            {
                Console.WriteLine("Error: Expected one argument (the path of the file to check)");
                return;
            }

            // Get file contents organized by line
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            // String of all whitelisted characters
            string alphameric = 
            "abcdefghijklmnopqrstuvwxyz" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "0123456789" +
            "_-:.@$=/ ";

            // Loop for each line in the file
            for (int i = 0; i < lines.Length; i++)
            {
                //Loop for each character in this line
                for (int j = 0; j < lines[i].Length; j++)
                {
                    // Alert the user if this is an illegal character
                    if (!alphameric.Contains(lines[i][j]))
                    {
                        Console.WriteLine("Invalid character at line " + (i+1) + " position " + (j+1));
                        Console.WriteLine(lines[i]);
                        string indicator_str = new string(' ', lines[i].Length);
                        StringBuilder indicator_sb = new StringBuilder(indicator_str);
                        indicator_sb.Insert(j, '^');
                        Console.WriteLine(indicator_sb);
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
