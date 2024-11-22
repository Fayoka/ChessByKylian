using System;
using System.Text.RegularExpressions;

namespace ChessByKylian
{
    public static class Game
    {
        public static void StartGame()
        {
            // to-do Bool GameOver
            
            Console.WriteLine("\nWelcome to ChessByKylian");
            Board.FillStartingBoard();
            Board.RenderBoard();
            // ManageGame
            var turnWhite = true;
            while (true)
            {
                Console.WriteLine("\nWhat piece would you like to move?");
                var chosenPiece = Console.ReadLine();
                var canMove = validMove(chosenPiece, turnWhite);
                Console.WriteLine(canMove);
            }
        }

        private static bool validMove(string chosenPiece, bool turnWhite)
        {
            var chosenMoves = new UserMove("null", "null");
            chosenMoves = ParseInput(chosenPiece);
            Console.WriteLine("User Input was: " + chosenPiece);
            Console.WriteLine("\nYou wanna move the position row (" + chosenMoves.Row + ") and column (" + chosenMoves.Column + ").");
            return false;
        }

        private static UserMove ParseInput(string moveChosen)
        {
            if (CheckValidInput(moveChosen))
            {
                var success = int.TryParse(moveChosen[1].ToString(), out var score);
                return success ? new UserMove(moveChosen[1].ToString(), moveChosen[0].ToString()) : new UserMove(moveChosen[0].ToString(), moveChosen[1].ToString());
            }

            return new UserMove("null", "null");
        }

        private static bool CheckValidInput(string moveChosen)
        {
            string pattern = @"^[a-hA-H]\d$|^\d[a-hA-H]$";
            bool isMatch = Regex.IsMatch(moveChosen, pattern);

            if (isMatch)
            {
                return true;
            }

            Console.WriteLine($"The {moveChosen} is not a valid letter-number or number-letter combination.");
            return false;
        }
    }
}