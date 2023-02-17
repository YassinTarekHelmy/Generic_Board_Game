namespace A1_CS251 {
    public class XO_GameLogic : IGameLogic {
        int x, y;

        public XO_GameLogic(ref Board board) {
            board = new Board(3, 3);
        }

        public bool IsValidMove(ref Board board, char symbol) {
            if (board.GetPosition(x, y) == '.') {
                board.UpdateBoard(x, y, symbol);
                return true;
            }
            return false;
        }
        
        public void GetMove() {
            Console.Write("Enter X position: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Y Position: ");
            y = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayBoard(Board board) {
            for (int i = 0; i < board.GetWidth(); i++) {
                for (int j = 0; j < board.GetLength(); j++) {
                    Console.Write($"({i}, {j}) ");
                    Console.Write(board.GetPosition(i, j));
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
        }

        public bool IsWinner(Board board) {
            return true;
        }
    }
}