namespace A1_CS251 {
    public class Player {
        char order;
        protected string? name;
        protected char symbol;
        protected IGameLogic? gameLogic;

        public Player(char symbol, IGameLogic gameLogic) { }

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