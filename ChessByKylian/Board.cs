using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ChessByKylian
{
    public static class Board
    {
        private const int width = 8;
        private const int height = 8;
        private static int[,] board = new int[height, width];
        private static List<IPiece> pieces = new List<IPiece>();

        /// <summary>
        /// Method to render and display the board
        /// </summary>
        public static void RenderBoard()
        {
            for (var row = 0; row < width; row++)
            {
                for (var col = 0; col < height; col++)
                {
                    var piece = GetPieceObjectAt(col, row);
                    PrintBoard(piece, col, row);
                    
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Prints the rows & columns and handles the colors for the players
        /// </summary>
        private static void PrintBoard(IPiece piece, int col, int row)
        {
            if (piece != null)
            {
                if (piece.Player1)
                {
                    Console.Write(board[row, col] + " ", Console.ForegroundColor = ConsoleColor.Green);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(board[row, col] + " ", Console.ForegroundColor = ConsoleColor.Red);
                }
            }
            else
            {
                Console.Write(board[row, col] + " ", Console.ForegroundColor = ConsoleColor.DarkGray);
            }
        }
        /// <summary>
        /// Retrieves the piece by the x & y-axis from the chess board
        /// </summary>
        /// <returns>Whatever piece is on that location</returns>
        public static IPiece GetPieceObjectAt(int x, int y)
        {
            foreach (var piece in pieces)
            {
                if (piece.posX == x && piece.posY == y)
                {
                    return piece;
                }
            }
            return null;
        }
        /// <summary>
        /// Method to add a piece to a specific position on the board
        /// </summary>
        public static void AddPiece(IPiece piece)
        {
            pieces.Add(piece);
            board[piece.posY, piece.posX] = piece.PieceValue;
        }
        /// <summary>
        /// Move the piece on the chess board after it's checked if it's valid on the :IPiece class.
        /// </summary>
        public static void MovePiece(IPiece piece, int newX, int newY, int oldPosX, int oldPosY)
        {
            board[oldPosY, oldPosX] = 0; 
            board[newY, newX] = piece.PieceValue;
        }
    }
}