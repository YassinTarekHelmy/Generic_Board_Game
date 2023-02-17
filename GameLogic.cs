namespace A1_CS251 {
    public interface IGameLogic {
        public bool IsValidMove(Board board, int x, int y);
        public bool IsWinner();
    }
}