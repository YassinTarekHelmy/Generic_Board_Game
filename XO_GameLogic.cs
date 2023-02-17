namespace A1_CS251 {
    public class XO_GameLogic : IGameLogic {

        public XO_GameLogic(ref Board board) {
            board = new Board(3, 3);
        }

        public bool IsValidMove(Board board, int x, int y) {
            // throw new NotImplementedException();
            return true;
        }

        public bool IsWinner() {
            return true;
            // throw new NotImplementedException();
        }
    }
}