using System;

namespace ChessByKylian
{
    public class Rook: IPiece
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int PieceValue => 4;
        public bool Player1 { get; set; }

        public Rook(int posX, int posY, bool player1)
        {
            this.posX = posX;
            this.posY = posY;
            Player1 = player1;
        }

        public void Move(int x, int y)
        {
            if (isValid(x, y))
            {
                throw new NotImplementedException();
            }

        }

        private bool isValid(int x, int y)
        {
            if (posX != x)
            {
                // should be a separate function checking if there is a piece in its path
                for (int i = 0; i < y; i++)
                {
                    var foundPiece = Board.GetPieceObjectAt(x, i);
                    if (foundPiece != null)
                    {
                        return true;
                    }
                    {
                        
                    }
                }
            }
            return false;
        }
    }
}