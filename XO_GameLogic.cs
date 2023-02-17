namespace A1_CS251 {
    public class XO_GameLogic : IGameLogic {
        int x, y;
        const int WIDTH = 3, LENGTH = 3;
        public XO_GameLogic(ref Board board) {
            board = new Board(WIDTH, LENGTH);
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
            for (int i = 0; i < WIDTH; i++) {
                for (int j = 0; j < LENGTH; j++) {
                    Console.Write($"({i}, {j}) ");
                    Console.Write(board.GetPosition(i, j));
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
        }

        public bool IsWinner(Board board, char symbol) {
            for (int i = 0; i < LENGTH; i++) {
                if (board.GetPosition(i, 0) == symbol && board.GetPosition(i, 1) == symbol && board.GetPosition(i, 2) == symbol) {
                    return true;
                }
                if (board.GetPosition(0, i) == symbol && board.GetPosition(1, i) == symbol && board.GetPosition(2, i) == symbol) {
                    return true;
                }

            }
            if (board.GetPosition(0, 0) == symbol && board.GetPosition(1, 1) == symbol && board.GetPosition(2, 2) == symbol) {
                return true;
            }
            if (board.GetPosition(2, 0) == symbol && board.GetPosition(1, 1) == symbol && board.GetPosition(0, 2) == symbol) {
                return true;
            }

            return false;
        }

        public bool IsDraw(Board board) {
            int count = 0;
            for (int i = 0; i < board.GetLength(); i++) {
                for (int j = 0; j < board.GetWidth(); j++) {
                    if (board.GetPosition(i, j) != '.') count++;
                }
            }

            if (count == 9) return true;

            return false;
        }

        int minimax(bool isMax, Board board){
            return 1;
        }

        public void ComputerMove(Board board, char symbol) {
            int bestScore = -1000;
            for (int i = 0; i < WIDTH; i++) {
                for (int j = 0; j < LENGTH; j++) {
                    if(board.GetPosition(i,j) == '.') {
                        board.UpdateBoard(i, j, symbol);

                        int value = minimax(false, board);

                        board.UpdateBoard(i, j, '.');

                        if (value >= bestScore) {
                            x = i;
                            y = j;
                            bestScore = value;
                        }
                    }
                }
            }
        }
    }

}