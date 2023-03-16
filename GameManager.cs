//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: Managerial Class to manage the complete game by using the instances of the classes made.
//---------------------------------------------------------------------------------------------------------------------------

namespace A1_CS251 {
    public class GameManager {
        Player[] player = new Player[2];
        Board gameBoard = new Board(0, 0);
        IGameLogic? gameLogic;

        private bool UserInterface() {
            Console.WriteLine("\nWelcome to Board Games!\n");

            int userInput;
            do {
                Console.WriteLine("1) X-O\n2) Connect 4\n3) Exit");
                Console.Write("Select a game you want to play: ");
                int.TryParse(Console.ReadLine(), out userInput);

                switch (userInput) {
                    case 1:
                        gameLogic = new XO_GameLogic(ref gameBoard);
                        break;
                    case 2:
                        gameLogic = new Connect4_GameLogic(ref gameBoard);
                        break;
                    case 3:
                        Console.WriteLine("Ending game now!\n");
                        return false;
                    default:
                        Console.WriteLine("Please choose a valid number!\n");
                        break;
                }
            } while (!Enumerable.Range(1,3).Contains(userInput));
            
            if(gameLogic != null)
            do {
                Console.WriteLine("\n1) Player vs Player\n2) Player vs Computer \n3) Computer vs Player");
                Console.WriteLine("4) Computer vs Computer\n5) Exit");
                Console.Write("How do you want to play?: ");
                int.TryParse(Console.ReadLine(), out userInput);

                switch (userInput) {
                    case 1:
                        player[0] = new Player('1', 'O', gameLogic);
                        player[1] = new Player('2', 'X', gameLogic);
                        break;
                    case 2:
                        player[0] = new Player('1', 'O', gameLogic);
                        player[1] = new Computer('X', gameLogic);
                        break;
                    case 3:
                        player[0] = new Computer('O', gameLogic);
                        player[1] = new Player('2', 'X', gameLogic);
                        break;
                    case 4:
                        player[0] = new Computer('O', gameLogic);
                        player[1] = new Computer('X', gameLogic);
                        break;
                    case 5:
                        Console.WriteLine("Ending game now!\n");
                        return false;
                    default:
                        Console.WriteLine("Please choose a valid number!\n");
                        break;
                }
            } while (!Enumerable.Range(1, 5).Contains(userInput));

            return true;
        }
        
        public void Run() {
            if(UserInterface())
            if (gameLogic != null) {
                gameLogic.DisplayBoard(gameBoard);
                while (true) {
                    foreach (Player P in player) {
                        P.GetMove(gameBoard);
                        while (!gameLogic.IsValidMove(ref gameBoard, P.GetSymbol())) {
                            gameLogic.CorrectInputs();
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
}