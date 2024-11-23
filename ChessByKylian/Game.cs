using System;
using System.Text.RegularExpressions;

namespace ChessByKylian
{
    public static class Game
    {
    private static bool GameOver = false;
        public static void StartGame()
        {
            Console.WriteLine("\nWelcome to ChessByKylian");
            Board.FillStartingBoard();
            Board.RenderBoard();
            
            
            // ManageGame
            var turnWhite = true;
            
            while (!GameOver)
            {
                Console.Write("\nWhat piece would you like to move? ");
                var chosenPiece = Console.ReadLine();
                var userInput = ParseInput(chosenPiece);
                var canMove = validMove(userInput, turnWhite);
                Console.WriteLine(canMove);
            }
        }

        /// <summary>
        /// Check if there is a piece and if it can be moved, ex: turn 1 queen can't move because there is a pawn in front of it
        /// </summary>
        /// <param name="userMove"></param>
        /// <param name="turnWhite"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static bool validMove(UserMove userMove, bool turnWhite)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Parse the input string given by the user
        /// </summary>
        /// <param name="moveChosen"></param>
        /// <returns></returns>
        private static UserMove ParseInput(string moveChosen)
        {
            if (!CheckValidInput(moveChosen)) return new UserMove("null", "null");
            var success = int.TryParse(moveChosen[1].ToString(), out var score);
            return success ? new UserMove(moveChosen[1].ToString(), moveChosen[0].ToString()) : new UserMove(moveChosen[0].ToString(), moveChosen[1].ToString());
        }
        /// <summary>
        /// Check if it was given valid input string
        /// </summary>
        /// <param name="moveChosen"></param>
        /// <returns></returns>
        private static bool CheckValidInput(string moveChosen)
        {
            var pattern = @"^[a-hA-H]\d$|^\d[a-hA-H]$";
            var isMatch = Regex.IsMatch(moveChosen, pattern);

            if (isMatch)
            {
                return true;
            }

            Console.WriteLine($"The {moveChosen} is not a valid letter-number or number-letter combination.");
            return false;
        }
    }
}