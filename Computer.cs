//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: The Computer class is responsible for making a Computer move and is inherited from the main Player Class.
//---------------------------------------------------------------------------------------------------------------------------

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