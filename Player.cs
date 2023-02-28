//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: Player Class is responsible for making an instances of a player variable that can be used to input a move and get a symbol.
//---------------------------------------------------------------------------------------------------------------------------

namespace A1_CS251 {
    public class Player {
        char order;
        protected string? name;
        protected char symbol;
        protected IGameLogic? gameLogic;

        public Player(char symbol, IGameLogic gameLogic) {
            this.symbol = symbol;
            this.gameLogic = gameLogic;
        }

        public Player(char order, char symbol, IGameLogic gameLogic) {
            Console.Write($"Player {order} Please Enter your name: ");
            name = Console.ReadLine();
            this.order = order;
            this.symbol = symbol;
            this.gameLogic = gameLogic;
        }

        public string GetName() {
            if (name == "" || name == null)
                return "Player " + order;
            return name;
        }

        public char GetSymbol() {
            return symbol;
        }
        
        public virtual void GetMove(Board board) {
            if(gameLogic != null)
                gameLogic.GetMove();
        }
    }
}