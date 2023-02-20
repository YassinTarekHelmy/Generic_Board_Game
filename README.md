<h2> A1_CS251 - Cairo University: Faculty of Computers And Artificial Intelligence<br/>
Generic Board Game<br/>
Authors:<br/>
* Yassin Tarek Helmy<br/>
* Nour El-Deen Ahmed<br/>
* Mahoud Adel Ahmed </h2>

Currently the project Contains Tic-Tac-Toe and Connect4 Games.
Each game can be played Either Player vs Player, Player vs Computer with changing order, or Computer vs Computer (Looks fun so I kept it).

Computer is made using minimax with randomization of similar value outcomes.
Which means the Computer will prioritize winning moves. and randomize its move if there are multiple that returns the same value.

When you choose a game an instance of its logic is created that will control how the moves should be made and win conditions and such.
After that The player is asked to enter their name, if no name is entered the program creates the name "Player" + the order of that player (ex: Player 1).
Then the game starts where each player selects his move till someone wins or a draw happens!

The main point of this code is to make an interface of GameLogic.
This means that any class that defines a new game logic will Inherit from this interface 
and apply the same methods with different Implementations.

This makes it easier to implement other board games in the future!
