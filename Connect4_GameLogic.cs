namespace A1_CS251 {
    public class Connect4_GameLogic : IGameLogic {
        int col;
        const int LENGTH = 7 ,WIDTH = 6;
        public Connect4_GameLogic(ref Board board){
            board = new Board(WIDTH,LENGTH);
        } 
        public void ComputerMove(Board board, char symbol)
        {
            throw new NotImplementedException();
        }

        public void DisplayBoard(Board board) {
            for (int i = 0; i < board.GetLength(); i++){
                Console.Write("| {0} |", i + 1);
            }
            Console.WriteLine();
            for (int i = 0; i < board.GetWidth(); i++){
                for (int j = 0; j < board.GetLength(); j++){
                    Console.Write("| {0} |", board.GetPosition(i,j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public void GetMove(){
            Console.Write("Enter a col:");
            col = Convert.ToInt32(Console.ReadLine());
        }

        public bool IsDraw(Board board)
        {
            int count = 0;
            for (int i = 0; i < board.GetLength(); i++){
                if (board.GetPosition(0,i) != '.') count++;
            }
            if (count == 7) return true;
            else return false;
        }

        public bool IsValidMove(ref Board board, char symbol) {
            if (col < 1 || col > 7) return false;
            col--;
            for (int i = board.GetWidth() - 1; i >= 0; i--) {
                if (board.GetPosition(i , col) == '.')
                {
                    board.UpdateBoard(i, col, symbol);
                    return true;
                }
            }
            return false;
        }

        public bool IsWinner(Board board){   
            return false;
        }
    }
}