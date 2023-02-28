//This is a Program made by:
//Student Names: Yassin Tarek Helmy ---- Nour Eldeen Ahmed ---- Mahmoud Adel Ahmed.
//Student IDs respectively : 20210450 ---- 20210431 ---- 20210563.
//Date: 28/2/2023.
//Class: CS251.
//Objective: an interface made to inherit from that will implement the complete logic of any game you like.
//---------------------------------------------------------------------------------------------------------------------------
namespace A1_CS251 {
    public interface IGameLogic {
        public void CorrectInputs();
        public void DisplayBoard(Board board);
        public bool IsValidMove(ref Board board, char symbol);
        public bool IsWinner(Board board);
        public bool IsDraw(Board board);
        public void GetMove();
        public void ComputerMove(Board board, char symbol);
    }
}