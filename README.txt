This solution takes an input of one tictactoe grid and will tell you:
1. If anybody has won
2. If there are any moves left
3. If any moves are left, can anybody still win the game

To run the program, edit the files as described below, and then simply run the exe in the bin folder.

There are two files this program reads from, both located in the bin folder with the exe.
board_data.txt provides the TicTacToe grid, and cell_config.json stores the config info for the cells.

in board_data:
you can enter any size grid, but the dimensions of the array must be square. so only 4x4, 8x8, no 8x6 5x9 etc.
the format for the data is that 0 is for an empty square, and any positive integer is representative of that 
player occupying that cell. the max number of players you enter must line up with the max number of players
entered in the cell_config.

I have added a bunch of sample boards in their own folder in bin. Simply copy the one you want into board_data to see it.

in cell_config:
you can specify what the cell info looks like. both the number of players and what letters are associated with
their index is configurable.