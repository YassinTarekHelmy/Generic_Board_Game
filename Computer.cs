namespace A1_CS251 {
    public class Computer : Player {
        public Computer(char symbol, IGameLogic gameLogic) : base(symbol, gameLogic) {
            name = "Computer";
        }

        public override void GetMove(Board board) {
            if (gameLogic != null)
                gameLogic.ComputerMove(board, symbol);
        }
    }
}