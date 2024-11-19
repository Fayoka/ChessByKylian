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
        private static List<IPiece> killedPieces = new List<IPiece>();

        /// <summary>
        /// Method to render and display the board
        /// </summary>
        public static void RenderBoard()
        {
            for (var row = 0; row < width; row++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row + 1 + "  ");
                Console.ResetColor();
                for (var col = 0; col < height; col++)
                {
                    var piece = GetPieceObjectAt(col, row);
                    PrintBoard(piece, col, row);
                    
                }
                Console.WriteLine();
            }
            Console.Write("   "); // Indent to align with the board
            for (var col = 0; col < width; col++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                char character = (char)('A' + col); // Convert index to letter
                Console.Write(character + " ");
                Console.ResetColor();
            }
            Console.WriteLine(); // Move to a new line
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
                    Console.ResetColor();
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
            DeletePieceIfOneIsOnLocation(newX, newY, piece);
        }
        /// <summary>
        /// Method that checks if there is a piece at the location a piece is trying to move to, if it's a enemy piece it should be removed.
        /// </summary>
        private static void DeletePieceIfOneIsOnLocation(int newX, int newY, IPiece piece)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                var piece1 = pieces[i];
                if (piece1.posX == newX && piece1.posY == newY && piece.Player1 != piece1.Player1)
                {
                    killedPieces.Add(piece1);
                    pieces.RemoveAt(i);
                    break;
                }
            }
        }

        public static void FillStartingBoard()
        {
            FillPlayer1Board();
        }

        private static void FillPlayer1Board()
        {
            // Pawn
            for (var i = 0; i < 8; i++)
            {
                var pawnP1 = new Pawn(i, 6, true);
                Board.AddPiece(pawnP1);
            }
            
            //Rooks
            Rook LeftRook = new Rook(0, 7, true);
            Board.AddPiece(LeftRook);
            Rook RightRook = new Rook(7, 7, true);
            Board.AddPiece(RightRook);
            
            //Knight
            Knight LeftKnight = new Knight(1, 7, true);
            Knight RightKnight = new Knight(6, 7, true);
            Board.AddPiece(LeftKnight);
            Board.AddPiece(RightKnight);
            
            //Bishop
            Bishop LeftBishop = new Bishop(2, 7, true);
            Bishop RightBishop = new Bishop(5, 7, true);
            Board.AddPiece(LeftBishop);
            Board.AddPiece(RightBishop);
            
            //MasterPieces
            Queen queen = new Queen(3, 7, true);
            King king = new King(4, 7, true);
            Board.AddPiece(queen);
            Board.AddPiece(king);
        }
    }
}