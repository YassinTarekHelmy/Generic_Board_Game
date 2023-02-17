using System;


namespace A1_CS251 {
    public class MainClass {
        public static int x1, y1;
        public static void Main(string[] args) {
            Console.WriteLine("Hello, World");
            Player p1 = new Player("Nour elgamed", '$');
            p1.getMove(ref x1,ref y1);
            Board B = new Board(5 , 5);
            B.displayBoard();
        }
    }
}