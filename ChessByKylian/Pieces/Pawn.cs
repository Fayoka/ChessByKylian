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
            // normal move
            if (posX == x && posY == y + 1 || posY == y - 1)
            {
                return true;
            }
            // first move (can take 2 steps)
            if (Player1 && posX == 6 && posY == y + 1 || posY == y + 2)
            {
                return true;
            }
            // first move (can take 2 steps)
            if (!Player1 && posX == 1 && posY == y - 1 || posY == y - 2)
            {
                return true;
            }
            // TO-DO implement logic to take other pieces sideways (not even a clue how to do this)
            return false;
        }
    }
}