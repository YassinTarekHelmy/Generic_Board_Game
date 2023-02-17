namespace A1_CS251
{
    class Player
    {
        string name;
        char symbol;
        public Player(string Name , char Symbol){
            this.name = Name;
            this.symbol = Symbol;
        }
        public string getName(){
            return this.name;
        }
        public char getSymbol(){
            return this.symbol;
        }
        public void getMove(ref int x , ref int y){
            System.Console.Write("enter the length: ");
            x=Convert.ToInt32(Console.ReadLine());
            System.Console.Write("enter the width: ");
            y=Convert.ToInt32(Console.ReadLine());
        }
    }
}