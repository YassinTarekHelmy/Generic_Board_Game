namespace A1_CS251 {
    public class GameManager {
        Player[] player = new Player[2];
        Board gameBoard = new Board(0, 0);
        IGameLogic? gameLogic;
        public void Run() {
            gameLogic = new Connect4_GameLogic(ref gameBoard);
            player[0] = new Player('1', 'O', gameLogic);
            player[1] = new Player('2','X', gameLogic);
            gameLogic.DisplayBoard(gameBoard);
            while (true) {
                foreach (Player P in player) {
                    P.GetMove(gameBoard);
                    while (!gameLogic.IsValidMove(ref gameBoard, P.GetSymbol())) {
                        Console.WriteLine("Invalid Input. Please try again!!");
                        P.GetMove(gameBoard);
                    }
                    gameLogic.DisplayBoard(gameBoard);
                    if (gameLogic.IsWinner(gameBoard)) {
                        Console.WriteLine(P.GetName() + " Wins!!");
                        return;
                    } 
                    if (gameLogic.IsDraw(gameBoard)) {
                        Console.WriteLine(" Draw!!");
                        return;
                    }
                }
            }
        }
    }
}