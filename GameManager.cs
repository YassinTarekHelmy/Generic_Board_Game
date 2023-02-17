namespace A1_CS251 {
    public class GameManager {
        // static int x, y;
        Player[] player = new Player[2];
        Board gameBoard = new Board(0, 0);
        IGameLogic? gameLogic;
        public void Run() {
            gameLogic = new XO_GameLogic(ref gameBoard);
            
            player[0] = new Player('1', 'y', gameLogic);
            player[1] = new Computer('x', gameLogic);
            Console.WriteLine(player[1].GetName());
            // gameBoard = new Board(3, 3);
            while(true) {
                if (gameLogic.IsWinner(gameBoard)){
                    gameLogic.DisplayBoard(gameBoard);
                    break;
                }
            }
        }
    }
}