namespace A1_CS251 {
    public interface IGameLogic {
        public void DisplayBoard(Board board);
        public bool IsValidMove(ref Board board, char symbol);
        public bool IsWinner(Board board, char symbol);
        public bool IsDraw(Board board);
        public void GetMove();
        public void ComputerMove(Board board, char symbol);
    }
}