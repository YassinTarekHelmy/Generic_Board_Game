//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: The main Logic for the connect4 Game and it contains a human and a computer.
//---------------------------------------------------------------------------------------------------------------------------

using System;

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

        public void CorrectInputs() {
            Console.WriteLine("Please Input a value from 1 to 7");
        }
        
        public void GetMove() {
            Console.Write("Enter a column: ");
            if(!int.TryParse(Console.ReadLine(), out column)) {
                Console.WriteLine("Please input numbers only!");
                GetMove();
            }
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
                for (int col = 0; col < LENGTH - 3; col++) {
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

        int minimax(bool isMax, ref Board board, char symbol, char opponent, int alpha, int beta, int depth) {
            if (depth == 0) return 0;
            
            if (IsWinner(board) && !isMax) return depth;
            else if (IsWinner(board) && isMax) return -depth;
            if (IsDraw(board)) return 0;
            

            int best = isMax ? -1000 : 1000;
            Board temp = new Board(WIDTH, LENGTH);
            temp.SetBoard(board.CopyBoard());

            for (int col = 1; col <= LENGTH; col++) { 
                if(IsValidMove(board, isMax ? symbol : opponent, col)) {
                    int val = minimax(!isMax, ref board, symbol, opponent, alpha, beta, depth - 1);
                    
                    board.SetBoard(temp.CopyBoard());
                    if (isMax) {
                        // for maximizing AI
                        // replace best with val if val > best
                        if (val > best) best = val;
                        if(best > alpha) alpha = best;
                    } else {
                        // for minimizing player
                        // replace best with val if val < best
                        if (val < best) best = val;
                        if(best < beta) beta = best;
                    }
                    if (beta <= alpha) break;
                }
                if (beta <= alpha) break;
            }
            return best;
        }

        public void ComputerMove(Board board, char symbol) {
            char opponent = symbol == 'X' ? 'O' : 'X';
            var moves = new List<Tuple<int, int>>();

            Board tempBoard = new Board(WIDTH, LENGTH);
            tempBoard.SetBoard(board.CopyBoard());

            for (int col = 1; col <= LENGTH; col++) {
                if (IsValidMove(board, symbol, col)) {
                    moves.Add(Tuple.Create(col, minimax(false, ref board, symbol, opponent, -1000, 100, 6)));
                    board.SetBoard(tempBoard.CopyBoard());
                }
            }
            
            var random = new Random();
            int maxMoveScore = moves.Max(t => t.Item2);
            var bestMoves = moves.Where(t => t.Item2 == maxMoveScore).ToList();
            column = bestMoves[random.Next(0, bestMoves.Count)].Item1;
        }
    }
}