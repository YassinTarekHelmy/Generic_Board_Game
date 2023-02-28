//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: This is a generic Board Class that you can use to generate any type of board games with two players.
//---------------------------------------------------------------------------------------------------------------------------

using System;

namespace A1_CS251 {
    public class MainClass {
        
        public static void Main(string[] args) {
            GameManager game = new GameManager();
            game.Run();
        }
    }
}