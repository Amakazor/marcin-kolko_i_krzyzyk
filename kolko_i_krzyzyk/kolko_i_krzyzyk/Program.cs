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

            int state = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    fields[row, col] = empty_symbol;
                }
            }

            while (true)
            {
                int row;
                int column;

                bool wrong_field = false;

                do
                {
                    Console.Clear();
                    Render(fields);

                    if (wrong_field) Console.WriteLine("Field not empty.");
                    Console.WriteLine("Input field data");

                    row = GetInputIntBeetween(1, 3, "Input row number") - 1;
                    column = GetInputIntBeetween(1, 3, "Input column number") - 1;

                    if (fields[row, column] != empty_symbol)
                    {
                        wrong_field = true;
                    }
                    else
                    {
                        wrong_field = false;
                    }

                } while (wrong_field);

                if (current_player == 1)
                {
                    fields[row, column] = player_one_symbol;
                    if (CheckIfWon(fields, player_one_symbol))
                    {
                        state = 1;
                    }
                }
                else 
                {
                    fields[row, column] = player_two_symbol;
                    if (CheckIfWon(fields, player_two_symbol))
                    {
                        state = 2;
                    }
                }

                if (state == 0 && CheckIfFull(fields, empty_symbol))
                {
                    state = 3;
                }

                if (state != 0)
                {
                    break;
                }
                else
                {
                    if (current_player == 1) current_player = 2;
                    else current_player = 1;
                }
            }

            switch (state)
            {
                case 1:
                    Console.WriteLine(player_one_symbol + " won!");
                    break;
                case 2:
                    Console.WriteLine(player_two_symbol + " won!");
                    break;
                case 3:
                    Console.WriteLine("Draw!");
                    break;
            }
        }
    }
}