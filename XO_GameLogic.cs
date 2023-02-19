namespace A1_CS251 {
    public class XO_GameLogic : IGameLogic {
        int x, y;
        const int WIDTH = 3, LENGTH = 3;
        public XO_GameLogic(ref Board board) {
            board = new Board(WIDTH, LENGTH);
        }

        public bool IsValidMove(ref Board board, char symbol) {
            if (x < 0 || y < 0 || x > 2 || y > 2) return false;

            if (board.GetPosition(x, y) == '.') {
                board.UpdateBoard(x, y, symbol);
                return true;
            }
            return false;
        }

        public void CorrectInputs() {
            Console.WriteLine("Both X and Y should take values from 0 to 2");
        }
        
        public void GetMove() {
            Console.Write("Please input X and Y positions separated by space: ");

            string? multiInput;
            multiInput = Console.ReadLine();

            if (multiInput != null) {
                List<string> inputs = multiInput.Split(' ').ToList();

                if (inputs.Count != 2 || !int.TryParse(inputs[0], out x) || !int.TryParse(inputs[1], out y)) {
                    Console.WriteLine("Please input two numbers only!");
                    GetMove();
                }
            }
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
            Console.WriteLine("----------------------------\n");
        }

        public bool IsWinner(Board board) {
            for (int i = 0; i < LENGTH; i++) {
                if (board.GetPosition(i, 0) == board.GetPosition(i, 1) &&
                    board.GetPosition(i, 2) == board.GetPosition(i, 0) && board.GetPosition(i, 0) != '.') {
                    return true;
                }
                if (board.GetPosition(0, i) == board.GetPosition(1, i) &&
                    board.GetPosition(2, i) == board.GetPosition(0, i) && board.GetPosition(0, i) != '.') {
                    return true;
                }

            }
            if (board.GetPosition(0, 0) == board.GetPosition(1, 1) &&
                board.GetPosition(2, 2) == board.GetPosition(0, 0) && board.GetPosition(0, 0) != '.') {
                return true;
            }
            if (board.GetPosition(2, 0) == board.GetPosition(1, 1) &&
                board.GetPosition(0, 2) == board.GetPosition(2, 0) && board.GetPosition(2, 0) != '.') {
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

        int GetCount(Board board) {
            int count = 1;
            for (int i = 0; i < board.GetLength(); i++) {
                for (int j = 0; j < board.GetWidth(); j++) {
                    if (board.GetPosition(i, j) == '.') count++;
                }
            }

            return count;
        }

        int minimax(bool isMax, Board board, char symbol, char opponent) {
            if (IsWinner(board) && !isMax) return 2 * GetCount(board);
            else if (IsWinner(board) && isMax) return -1 * GetCount(board);
            if (IsDraw(board)) return 1 * GetCount(board);

            int best = isMax ? -1000 : 1000;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    // if Empty position.
                    if (board.GetPosition(i, j) == '.') {
                        // if it's AI's turn, put AI symbol, else put opponent symbol
                        board.UpdateBoard(i, j, isMax ? symbol : opponent);
                        // recursion to find all possibilities 
                        // and return the resulting value of each move
                        int val = minimax(!isMax, board, symbol, opponent);
                        if (isMax) {
                            // for maximizing AI
                            // replace best with val if val > best
                            if (val > best) best = val;
                        } else {
                            // for minimizing player
                            // replace best with val if val < best
                            if (val < best) best = val;
                        }
                        // change move to original form
                        board.UpdateBoard(i, j, '.');
                    }
                }
            }
            // return best choice for either AI or player
            return best;
        }

        public void ComputerMove(Board board, char symbol) {
            char opponent = symbol == 'X' ? 'O' : 'X';
            var moves = new List<Tuple<Position, int>>();

            // int bestScore = -1000;
            for (int i = 0; i < WIDTH; i++) {
                for (int j = 0; j < LENGTH; j++) {
                    if (board.GetPosition(i, j) == '.') {
                        board.UpdateBoard(i, j, symbol);

                        moves.Add(Tuple.Create(new Position(i, j), minimax(false, board, symbol, opponent)));

                        board.UpdateBoard(i, j, '.');

                        // if (value >= bestScore) {
                        //     x = i;
                        //     y = j;
                        //     bestScore = value;
                        // }
                    }
                }
            }

            var random = new Random();
            int maxMoveScore = moves.Max(t => t.Item2);
            var bestMoves = moves.Where(t => t.Item2 == maxMoveScore).ToList();
            Position position = bestMoves[random.Next(0, bestMoves.Count)].Item1;
            x = position.x;
            y = position.y;
        }
    }

    class Position {
        public int x, y;
        public Position(int i, int j) {
            x = i; y = j;
        }
    }

}