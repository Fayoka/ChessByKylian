namespace ChessByKylian
{
    public interface IPiece
    {
        int posX { get; set; }
        int posY { get; set; }
        int PieceValue {get; }
        bool Player1 { get; set; }
        void Move(int x, int y);
    }
}