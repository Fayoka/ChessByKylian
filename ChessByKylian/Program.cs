using System;

namespace ChessByKylian
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (var i = 0; i < 8; i++)
            {
                var pawn = new Pawn(i, 1, false);
                var pawnP1 = new Pawn(i, 6, true);
                Board.AddPiece(pawn);
                Board.AddPiece(pawnP1);
            }
            Board.RenderBoard();
            Console.WriteLine("Press any key to exit...");
            var tetsin = Board.GetPieceObjectAt(1, 1);
            tetsin.Move(1, 4);
            Board.RenderBoard();

        }
    }
}