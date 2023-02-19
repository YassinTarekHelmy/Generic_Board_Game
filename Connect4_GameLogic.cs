namespace A1_CS251 {
    public class Connect4_GameLogic : IGameLogic {
        int column;
        const int LENGTH = 7, WIDTH = 6;
        public Connect4_GameLogic(ref Board board) {
            board = new Board(WIDTH, LENGTH);
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
            Console.WriteLine("-----------------------------------------");
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

        public bool IsValidMove(Board board, char symbol, int col) {
            if (col < 1 || col > 7) return false;
            col--;
            for (int i = WIDTH - 1; i >= 0; i--) {
                if (board.GetPosition(i, col) == '.') {
                    board.UpdateBoard(i, col, symbol);
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

        int GetCount(ref Board board) {
            int count = 1;
            for (int i = 0; i < WIDTH; i++) {
                for (int j = 0; j < LENGTH; j++) {
                    if (board.GetPosition(i, j) == '.') count++;
                }
            }

            return count;
        }

        int minimax(bool isMax, ref Board board, char symbol, char opponent) {
            if (IsWinner(board) && !isMax) return 2 * GetCount(ref board);
            else if (IsWinner(board) && isMax) return -1 * GetCount(ref board);
            if (IsDraw(board)) return 1 * GetCount(ref board);

            int best = isMax ? -1000 : 1000;
            Board temp = new Board(WIDTH, LENGTH);
            temp.SetBoard(board.CopyBoard());

            for (int col = 1; col <= LENGTH; col++) { 
                if(IsValidMove(board, isMax ? symbol : opponent, col)) {
                    int val = minimax(!isMax, ref board, symbol, opponent);

                    if (isMax) {
                        // for maximizing AI
                        // replace best with val if val > best
                        if (val > best) best = val;
                    } else {
                        // for minimizing player
                        // replace best with val if val < best
                        if (val < best) best = val;
                    }

                    board.SetBoard(temp.CopyBoard());
                }
            }
            return best;
        }

        public void ComputerMove(Board board, char symbol) {
            char opponent = symbol == 'X' ? 'O' : 'X';
            int bestScore = -1000;

            Board tempBoard = new Board(WIDTH, LENGTH);
            tempBoard.SetBoard(board.CopyBoard());

            for (int col = 1; col <= LENGTH; col++) {
                if (IsValidMove(board, symbol, col)) {
                    int value = minimax(false, ref board, symbol, opponent);
                    board.SetBoard(tempBoard.CopyBoard());

                    if (value >= bestScore) {
                        column = col;
                        bestScore = value;
                    }
                }
            }
        }
    }
}