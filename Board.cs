namespace A1_CS251
{
    public class Board
    {
        protected char[,] board;
        int length, width;
        public Board(int n , int m){
            this.length = n;
            this.width = m;
            this.board = new char [n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    board[i, j] = '.';
                }
            }
        }
        public void displayBoard(){
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(board[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }    
        }
    }
}