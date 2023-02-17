namespace A1_CS251 {
    class Player {
        char order;
        protected string? name;
        protected char symbol;
        public Player(char order, char symbol) {
            Console.Write("Please Enter your name: ");
            name = Console.ReadLine();
            this.order = order;
            this.symbol = symbol;

        }
        public string GetName() {
            if (name == "" || name == null)
                return "Player " + order;
            return name;
            
        }
        public char GetSymbol() {
            return symbol;
        }
        public void GetMove(ref int x, ref int y) {
            Console.Write("Enter X position: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Y Position: ");
            y = Convert.ToInt32(Console.ReadLine());
        }
    }
}