namespace A1_CS251 {
    public class GameManager {
        Player[] player = new Player[2];
        Board gameBoard = new Board(0, 0);
        IGameLogic? gameLogic;
        public void Run() {
            gameLogic = new XO_GameLogic(ref gameBoard);  
            player[0] = new Player('1', 'o', gameLogic);
            player[1] = new Player('2','x', gameLogic);
            gameLogic.DisplayBoard(gameBoard);
            while(true) {
                foreach (Player P in player){
                    P.GetMove();
                    while(!gameLogic.IsValidMove(ref gameBoard, P.GetSymbol())){
                        P.GetMove();
                    }
                    gameLogic.DisplayBoard(gameBoard);
                    if (gameLogic.IsWinner(gameBoard , P.GetSymbol())){
                        Console.WriteLine(P.GetName() + " Wins!!"); 
                        return;
                    }
                    else if (gameLogic.IsDraw(gameBoard)){
                        Console.WriteLine( " Draw!!"); 
                        return;
                    }
                }
            }
        }
    }
}