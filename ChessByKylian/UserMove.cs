namespace ChessByKylian
{
    public class UserMove
    {
        public string Row { get; set; }
        public string Column { get; set; }

        public UserMove(string row, string column)
        {
            Row = row;
            Column = column;
        }
    }
}