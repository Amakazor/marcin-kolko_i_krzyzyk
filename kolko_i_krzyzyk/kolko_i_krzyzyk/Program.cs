using System;

namespace kolko_i_krzyzyk
{
    class Program
    {
        static void Render(char[,] fields_array)
        {
            Console.Write(" #");
            for(int col = 0; col < 3; col++)
            {
                Console.Write(col+1 + "#");
            }
            Console.Write("\n");

            for(int row = 0; row < 3; row++)
            {
                Console.Write("##");
                for(int col = 0; col < 3; col++)
                {
                    Console.Write("##");
                }
                Console.Write("\n");

                Console.Write(row+1 + "#");
                for(int col = 0; col < 3; col++)
                {
                    Console.Write(fields_array[row, col] + "#");
                }
                Console.Write("\n");
            }

            Console.Write("##");
            for (int col = 0; col < 3; col++)
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
                    if(input_parsed <= max && input_parsed >= min)
                    {
                        bad_input = false;
                    }
                    else bad_input = true;
                }
                else bad_input = true;

            } while (bad_input);

            return input_parsed;
        }

        static bool CheckIfWon(char[,] fields_array, char symbol)
        {
            //poziomo
            for (int row = 0; row < 3; row++)
            {
                int consecutive = 0;

                for (int col = 0; col < 3; col++)
                {
                    if (fields_array[row, col] == symbol)
                    {
                        consecutive++;
                        if (consecutive == 3) return true;
                    }
                    else consecutive = 0;
                }
            }

            //pionowo
            for(int col = 0; col < 3; col++)
            {
                int consecutive = 0;

                for(int row = 0; row < 3; row++)
                {
                    if (fields_array[row, col] == symbol)
                    {
                        consecutive++;
                        if (consecutive == 3) return true;
                    }
                    else consecutive = 0;
                }
            }

            //ukośnie \
            if (fields_array[0, 0] == symbol && fields_array[1, 1] == symbol && fields_array[2, 2] == symbol) return true;

            //ukośnie /
            if (fields_array[0, 2] == symbol && fields_array[1, 1] == symbol && fields_array[2, 0] == symbol) return true;

            return false;
        }

        static bool CheckIfFull(char[,] fields_array, char symbol)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (fields_array[row, col] == symbol) return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            char player_one_symbol  = 'O';
            char player_two_symbol  = 'X';
            char empty_symbol       = ' ';

            char[,] fields          = new char[3, 3];

            int current_player = 1;

            
        }
    }
}