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
