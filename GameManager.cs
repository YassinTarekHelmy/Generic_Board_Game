namespace A1_CS251 {
    public class GameManager {
        // static int x, y;
         bool gameIsRunning = true;
        Player[] player = new Player[2];
        Board gameBoard = new Board(0, 0);
        IGameLogic? gameLogic;
        public void Run() {
            gameLogic = new XO_GameLogic(ref gameBoard);  
            player[0] = new Player('1', 'o', gameLogic);
            player[1] = new Player('2','x', gameLogic);
            Console.WriteLine(player[1].GetName());
            // gameBoard = new Board(3, 3);
            while(gameIsRunning) {
                gameLogic.DisplayBoard(gameBoard);
                foreach (Player P in player){
                    P.GetMove();
                    if (gameLogic.IsWinner(gameBoard , P.GetSymbol())){
                        Console.WriteLine(P.GetName() + " is Winner!!"); 
                        gameLogic.DisplayBoard(gameBoard);  //board is displayed for the last time.
                        gameIsRunning = false;
                        break;
                    }
                }
            }
        }
    }
}