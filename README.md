**Hunting the Manticore - A C# Game**

Hunting the Manticore is a two player game and challenge progran that was created from scratch following the objectives from the book *C# Player’s Guide*. This program uses the basics of C#. 

The game starts with the Manticore having 10 health points and the city having 15 health points. The game begins at round 1.

The first player chooses the Manticore’s distance from the city (0 to 100). The game then runs in a loop until either the Manticore’s or city’s health reaches 0.

Before the second player’s turn, the round number, the city’s health, and the Manticore’s health are displayed. The damage the cannon will deal this round is computed as follows:

10 points if the round number is a multiple of both 3 and 5
3 points if it is a multiple of 3 or 5 (but not both)
1 point otherwise.
The second player then provides a target range. The game resolves its effect and informs the player if they overshot, fell short, or hit the Manticore. If it was a hit, the Manticore’s health is reduced by the expected amount.

If the Manticore is still alive, the city’s health is reduced by 1. The game then advances to the next round.

When the Manticore or the city’s health reaches 0, the game ends and the outcome is displayed.

Different colors are used for different types of messages to enhance the user experience.
