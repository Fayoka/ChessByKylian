namespace ChessByKylian
{
    public static class TestCases
    {
        public static void TestPawns()
        {
            for (var i = 0; i < 8; i++)
            {
                var pawn = new Pawn(i, 1, false);
                var pawnP1 = new Pawn(i, 6, true);
                Board.AddPiece(pawn);
                Board.AddPiece(pawnP1);
            }

            var p1 = Board.GetPieceObjectAt(1, 6);
            var p2 = Board.GetPieceObjectAt(2, 1);
            p1.Move(1,4);
            p2.Move(2,3);
            p2.Move(1,4);
            
            Board.RenderBoard();
        }

        public static void TestGame()
        {
            Game.GameStart();
        }
    }
}