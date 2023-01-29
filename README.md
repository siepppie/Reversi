# Reversi
Reversi is a two-player strategy game played on a board with 8 rows and 8 columns. The objective of the game is to have the majority of your colored tiles on the board at the end of the game.

This project is a C# implementation of the game Reversi, with a GUI built using the System.Windows.Forms library. The board is a 6x6 grid and the game starts with four tiles placed in the center of the board with alternating colors. The players take turns placing tiles on the board with their color, and any tiles of the opponent's color that are enclosed by the newly placed tile and a row of the player's own colored tiles are flipped to the player's color.

The game is won when one of the players has more tiles on the board than the other player or when the board is full.

## Getting Started
The game can be run by opening the Reversi_final.sln file in Visual Studio and running the project. The game board will appear and the players can take turns placing tiles by clicking on the board.

## Built With
* C#
* System.Windows.Forms
* System.Drawing
