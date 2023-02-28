//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: The Class responsible for the board of the game.
//---------------------------------------------------------------------------------------------------------------------------
namespace A1_CS251 {
    public class Board {
        char[,] board;
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
        
        public char GetPosition(int x, int y){
            return board[x, y];
        }

        public void UpdateBoard(int x, int y, char symbol) {
            board[x, y] = symbol;
        }

        public int GetWidth(){
            return width;
        }

        public int GetLength() {
            return length;
        }
    
        public char[,] CopyBoard(){
            char[,] copy = new char[width, length];
            Array.Copy(board, 0, copy, 0, board.Length);
            return copy;
        }

        public void SetBoard(char[,] array) {
            this.board = array;
        }

    }
}