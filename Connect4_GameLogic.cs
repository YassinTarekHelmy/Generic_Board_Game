namespace A1_CS251 {
    public class Connect4_GameLogic : IGameLogic {
        int colomn;
        public void ComputerMove(Board board, char symbol)
        {
            throw new NotImplementedException();
        }

         public void DisplayBoard(Board board) {
            for (int i = 0; i < board.GetLength(); i++){
                System.Console.Write("| {0} |", i);
            }
            System.Console.WriteLine();
            for (int i = 0; i < board.GetWidth(); i++){
                for (int j = 0; j < board.GetLength(); j++){
                    Console.Write("| {0} |", board.GetPosition(i,j));
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("----------------------");
        }

        public void GetMove() {
            Console.Write("Enter X position: ");
            colomn = Convert.ToInt32(Console.ReadLine());
        }

        public bool IsDraw(Board board) {
            throw new NotImplementedException();
        }

        public bool IsValidMove(ref Board board, char symbol) {
            for (int i = board.GetWidth()-1; i >= 0; i--)
            {
                if (board.GetPosition(colomn , i) == '.')
                {
                    board.UpdateBoard(colomn, i, symbol);
                    return true;
                }
            }
            return false;
        }

        public bool IsWinner(Board board) {
            throw new NotImplementedException();
        }
    }
}