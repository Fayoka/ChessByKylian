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
            var p1 = Board.GetPieceObjectAt(1, 6);
            var p2 = Board.GetPieceObjectAt(2, 1);
            p1.Move(1,4);
            p2.Move(2,3);
            p2.Move(1,4);
            Console.WriteLine(p2.posY + p2.posX + p2.Player1.ToString());
            
            Board.RenderBoard();

        }
    }
}