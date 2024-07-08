There are two files this program reads from.
board_data.txt provides the TicTacToe grid, and cell_config.json stores the config info for the cells.

in board_data:
you can enter any size grid, but the dimensions of the array must be square. so only 5x5, 8x8, no 8x6 5x9 etc.
the format for the data is that 0 is for an empty square, and any positive integer is representative of that 
player occupying that cell. the max number of players you enter must line up with the max number of players
entered in the cell_config.

in cell_config:
you can specify what the cell info looks like. both the number of players and what letters are associated with
their index is configurable.