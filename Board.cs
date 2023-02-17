namespace A1_CS251 {
    public class Board {
        protected char[,] board;
        int width, length;
        public Board(int n, int m) {
            this.width = n;
            this.length = m;
            this.board = new char[n, m];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    board[i, j] = '.';
                }
            }
        }
        
        public void DisplayBoard() {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < length; j++) {
                    Console.Write($"({i}, {j}) ");
                    Console.Write(board[i, j]);
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
        }

        public void UpdateBoard(int x, int y, char symbol) {
            board[x, y] = symbol;
        }
    }
}