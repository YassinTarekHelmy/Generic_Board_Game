namespace A1_CS251 {
    public class Connect4_GameLogic : IGameLogic {
        int column;
        const int LENGTH = 7, WIDTH = 6;
        public Connect4_GameLogic(ref Board board) {
            board = new Board(WIDTH, LENGTH);
        }
        public void ComputerMove(Board board, char symbol) {
            throw new NotImplementedException();
        }

        public void DisplayBoard(Board board) {
            for (int i = 0; i < LENGTH; i++) {
                Console.Write("| {0} |", i + 1);
            }
            Console.WriteLine();
            for (int i = 0; i < WIDTH; i++) {
                for (int j = 0; j < LENGTH; j++) {
                    Console.Write("| {0} |", board.GetPosition(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public void GetMove() {
            Console.Write("Enter a col:");
            column = Convert.ToInt32(Console.ReadLine());
        }

        public bool IsDraw(Board board) {
            int count = 0;
            for (int i = 0; i < LENGTH; i++) {
                if (board.GetPosition(0, i) != '.') count++;
            }
            if (count == 7) return true;
            else return false;
        }

        public bool IsValidMove(ref Board board, char symbol) {
            if (column < 1 || column > 7) return false;
            column--;
            for (int i = WIDTH - 1; i >= 0; i--) {
                if (board.GetPosition(i, column) == '.') {
                    board.UpdateBoard(i, column, symbol);
                    return true;
                }
            }
            return false;
        }

        public bool IsWinner(Board board) {
            // Horizontal Check
            for (int row = 0; row < WIDTH; row++) {
                for (int col = 0; col < LENGTH - 3; col++) {
                    if (board.GetPosition(row, col + 1) == board.GetPosition(row, col) &&
                        board.GetPosition(row, col + 2) == board.GetPosition(row, col) &&
                        board.GetPosition(row, col + 3) == board.GetPosition(row, col) && board.GetPosition(row, col) != '.')

                        return true;
                }
            }

            // Vertical Check
            for (int col = 0; col < LENGTH; col++) {
                for (int row = 0; row < WIDTH - 3; row++) {
                    if (board.GetPosition(row + 1, col) == board.GetPosition(row, col) &&
                        board.GetPosition(row + 2, col) == board.GetPosition(row, col) &&
                        board.GetPosition(row + 3, col) == board.GetPosition(row, col) && board.GetPosition(row, col) != '.')

                        return true;
                }
            }

            // Positive Diagonal check
            for (int row = 0; row < WIDTH - 3; row++) {
                for (int col = 0; col < WIDTH - 3; col++) {
                    if (board.GetPosition(row + 1, col + 2) == board.GetPosition(row, col) &&
                        board.GetPosition(row + 2, col + 2) == board.GetPosition(row, col) &&
                        board.GetPosition(row + 3, col + 3) == board.GetPosition(row, col) && board.GetPosition(row, col) != '.')

                        return true;
                }
            }

            // Negative Diagonal check
            for (int col = 0; col < LENGTH - 3; col++) {
                for (int row = 3; row < WIDTH; row++) {
                    if (board.GetPosition(row - 1, col + 1) == board.GetPosition(row, col) &&
                        board.GetPosition(row - 2, col + 2) == board.GetPosition(row, col) &&
                        board.GetPosition(row - 3, col + 3) == board.GetPosition(row, col) && board.GetPosition(row, col) != '.')

                        return true;
                }
            }

            return false;
        }
    }
}