using System;

namespace kolko_i_krzyzyk
{
    class Program
    {
        static void Render(char[,] fields_array)
        {
            Console.Write(" #");
            for (int col = 0; col < fields_array.GetLength(1); col++)
            {
                Console.Write(col + "#");
            }
            Console.Write("\n");

            for (int row = 0; row < fields_array.GetLength(0); row++)
            {
                Console.Write("##");
                for (int col = 0; col < fields_array.GetLength(1); col++)
                {
                    Console.Write("##");
                }
                Console.Write("\n");

                Console.Write(row + "#");
                for (int col = 0; col < fields_array.GetLength(1); col++)
                {
                    Console.Write(fields_array[row, col] + "#");
                }
                Console.Write("\n");
            }

            Console.Write("##");
            for (int col = 0; col < fields_array.GetLength(1); col++)
            {
                Console.Write("##");
            }
            Console.Write("\n");
        }

        static int GetInputIntBeetween(int min, int max, string message)
        {
            bool bad_input      = false;
            bool parsed         = false;
            string input        = "";
            int input_parsed    = 0;

            do
            {
                if(bad_input) Console.WriteLine("Bad input!");
                Console.WriteLine(message);

                input = Console.ReadLine();
                parsed = int.TryParse(input, out input_parsed);
                
                if(parsed)
                {
                    if (input_parsed <= max && input_parsed >= min)
                    {
                        bad_input = false;
                    }
                    else bad_input = true;
                }
                else bad_input = true;

            } while (bad_input);

            return input_parsed;
        }

        static void Main(string[] args)
        {
            char player_one_symbol  = 'O';
            char player_two_symbol  = 'X';
            char empty_symbol       = ' ';

            int  size               = 3;

            char[,] fields          = new char[size, size];
        }
    }
}
