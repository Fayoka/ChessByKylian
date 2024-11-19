namespace ChessByKylian
{
    public class Knight : IPiece
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int PieceValue => 2;
        public bool Player1 { get; set; }

        public Knight(int posX, int posY, bool player1)
        {
            this.posX = posX;
            this.posY = posY;
            Player1 = player1;
        }

        public void Move(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}