using System;

namespace ChessByKylian
{
    public static class Game
    {
        public static void GameStart()
        {
            Console.WriteLine("\nWelcome to ChessByKylian");
            Board.FillStartingBoard();
            Board.RenderBoard();
            
            while (true)
            {
                
                Console.WriteLine("Insert the piece you want to move: ");
                var chosenPiece = Console.ReadLine();
                var str = chosenPiece[0].ToString();
                int result = int.TryParse(chosenPiece[1].ToString(), out result) ? result : 100;
                var notation = Board.ChessNotationToIndex(str, result);
                var piece = Board.GetPieceObjectAt(notation[1], notation[0]);
                
                
                Console.WriteLine("Where do you want to move?");
                var chosenPosition = Console.ReadLine();
                var strPosition = chosenPosition[0].ToString();
                int resultPosition = int.Parse(chosenPosition[1].ToString());
                var notationPosition = Board.ChessNotationToIndex(strPosition, resultPosition);
                piece.Move(notationPosition[0], notationPosition[1]);
                Board.RenderBoard();
                break;
            }
        }
       
    }
}