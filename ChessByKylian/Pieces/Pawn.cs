using System;

namespace ChessByKylian
{
    public class Pawn : IPiece

    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int PieceValue => 1;
        public bool Player1 { get; set; }
        
        public Pawn(int posX, int posY, bool player1)
        {
            this.posX = posX;
            this.posY = posY;
            this.Player1 = player1;
        }
        public void Move(int x, int y)
        {
            if (IsValidMove(x, y))
            {
                Board.MovePiece(this, x, y, posX, posY);
                posX = x;
                posY = y;
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
        }

        private bool IsValidMove(int x, int y)
        {
            // normal move for p1
            if (Player1 && posX == x && posY == y + 1)
            {
                return true;
            }
            // normal move for p2
            if (!Player1 && posY == y - 1 && posX == x)
            {
                return true;
            }
            // first move for p1 (can take 2 steps)
            if (Player1 && posX == 6 && posY == y + 1 || posY == y + 2)
            {
                return true;
            }
            // first move for p2 (can take 2 steps)
            if (!Player1 && posX == 1 && posY == y - 1 || posY == y - 2)
            {
                return true;
            }
            
            var enemyPiece = Board.GetPieceObjectAt(x, y);
            Console.WriteLine(enemyPiece.Player1);
            if (enemyPiece != null && enemyPiece.Player1 != Player1)
            {
                Console.WriteLine("Did you check this ? ");
                if (Player1 && posX == x + 1 || posX == x - 1 && posY == y + 1)
                {
                    return true;
                }

                if (!Player1 && posX == x + 1 || posX == x - 1 && posY == y + - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}