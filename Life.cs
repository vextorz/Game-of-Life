/////////////////////////////////////////////////////////////////////////////////////////
/// Change history
/// Date            Developer           Description
/// 02/22/2024      Duc Vy Dang         Creating first state of the program (constructor, variable,..)
///                                     Making Play method, processing game board method, and initialize game board method
/// 02/27/2024      Duc Vy Dang         Creating applying game rule, countneighbor methods
///                                     Config starting pattern and testing.
///                                     Test 2 method create by ChatGPT and by our own.

using System;
using System.Diagnostics;

namespace GLife
{
    // singletone class that controls and "plays" the game/sim
    internal class Life
    {
        private char DEAD = '-';
        private char LIVE = '@';
        private readonly int MaxRows;
        private readonly int MaxCols;
        private Stopwatch watch;

        // storage for the 2 game boards
        private char[,] displayBoard;
        private char[,] resultBoard;

        // life constructor which set maxrows to rows and maxcols to cols
        // this method also initiate the stopwatch
        public Life(int rows, int cols)
        {
            watch = new Stopwatch();
            MaxRows = rows;
            MaxCols = cols;

            // allocate storage for the 2 game boards
            displayBoard = new char[MaxRows, MaxCols];
            resultBoard = new char[MaxRows, MaxCols];

            InitializeGameBoard(displayBoard);
            InitializeGameBoard(resultBoard);

            // choose a start state for an interesting "game"
            //ConfigureStartingPattern(MaxRows / 4, MaxCols / 3);
            ConfigureStartingPattern(MaxRows / 2, MaxCols / 3);

        }

        // This method start the game by start the stop watch, print the game board,
        // process the game board.
        public void Play (int numGenerations)
        {
            watch.Start();
            for (int i = 1; i < numGenerations; i++)
            {
                // 1 - print the game board (display to the user)
                PrintGameBoard(i);

                // 2 - apply the rules of the game
                // process the game board and store the results in the resultsBoard
                ProcessMainGameBoard();

                // 3 - swap the two boards to prepare to start over for the next generation
                SwapGameBoards();
            }
            watch.Stop();
            Console.WriteLine($"Elapsed time: {watch.Elapsed}");
        }


        // This method using a for loop to apply game rule to
        // each character on the game board
        private void ProcessMainGameBoard()
        {

            for (int r = 0; r < MaxRows; r++)
            {
                for (int c = 0; c < MaxCols; c++)
                {
                    resultBoard[r, c] = ApplyGameRules(r, c);
                }
            }
        }


        // This method using the game rule to process the game
        private char ApplyGameRules(int r, int c)
        {
            // Any live cell with fewer than two live neighbors dies, as if by underpopulation.
            // Any live cell with two or three live neighbors lives on to the next generation.
            // Any live cell with more than three live neighbors dies, as if by overpopulation.
            // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

            // Create a variable base on the CountNeighborCells method to determine
            // if neighborcount = 2 then everything remain the same
            // if neighborcount = 3 then that cell will become live
            // else set the cell to dead
            int neighborCount = CountNeighborCells(r, c);
            if (neighborCount == 2)
            {
                return displayBoard[r, c];
            }
            else if (neighborCount == 3)
            {

                return LIVE;
            }

            // case 0,1 -> 4,5,6,7,8
            return DEAD;
        }
        



        // first take - brute force checking r,c for each exceptiona; condition == 8
        private int CountNeighborCells(int r, int c)
        {
            int neighbors = 0;
            if ( r == 0 && c == 0)
            {
                //if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r, c - 1] == LIVE) neighbors++;
                if (displayBoard[r, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c] == LIVE) neighbors++;
                if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (r == 0 && c == MaxCols - 1)
            {
                //if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (displayBoard[r, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r, c + 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (r == MaxRows - 1 && c == MaxCols - 1)
            {
                if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r - 1, c] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (displayBoard[r, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (r == MaxRows - 1 && c == 0)
            {
                //if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r - 1, c] == LIVE) neighbors++;
                if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r, c - 1] == LIVE) neighbors++;
                if (displayBoard[r, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (r == 0)
            {
                //if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (displayBoard[r, c - 1] == LIVE) neighbors++;
                if (displayBoard[r, c + 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c] == LIVE) neighbors++;
                if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (r == MaxRows - 1)
            {
                if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r - 1, c] == LIVE) neighbors++;
                if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (displayBoard[r, c - 1] == LIVE) neighbors++;
                if (displayBoard[r, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (c == 0)
            {
                //if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r - 1, c] == LIVE) neighbors++;
                if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r, c - 1] == LIVE) neighbors++;
                if (displayBoard[r, c + 1] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c] == LIVE) neighbors++;
                if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else if (c == MaxCols - 1)
            {
                if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r - 1, c] == LIVE) neighbors++;
                //if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (displayBoard[r, c - 1] == LIVE) neighbors++;
                //if (displayBoard[r, c + 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c] == LIVE) neighbors++;
                //if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            else
            {
                if (displayBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (displayBoard[r - 1, c] == LIVE) neighbors++;
                if (displayBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (displayBoard[r, c - 1] == LIVE) neighbors++;
                if (displayBoard[r, c + 1] == LIVE) neighbors++;
                if (displayBoard[r + 1, c - 1] == LIVE) neighbors++; 
                if (displayBoard[r + 1, c] == LIVE) neighbors++;
                if (displayBoard[r + 1, c + 1] == LIVE) neighbors++;
            }
            return neighbors;
        }

        // display the game board to the user with the generation number label
        private void PrintGameBoard(int gen)
        {
            Console.WriteLine($"Generation: #{gen}");
            for (int r = 0; r < MaxRows; r++)
            {
                for (int c = 0; c < MaxCols; c++)
                {
                    // for initial, just set everything to DEAD
                    Console.Write(displayBoard[r, c]);
                }
                Console.WriteLine();
            }
        }

        // swap the 2 game boards to prepare for the next generation
        private void SwapGameBoards()
        {
            char[,] tmp = displayBoard;
            displayBoard = resultBoard;
            resultBoard = tmp;
        }

        // This method restart the game by setting all the cell to dead
        private void InitializeGameBoard(char[,] board)
        {
            for (int r = 0; r < MaxRows; r++)
            {
                for(int c = 0; c < MaxCols; c++)
                {
                    // for initial, just set everything to DEAD
                    board[r, c] = DEAD;
                }
            }
        }

        // This method configure the first state of the board by
        // setting up first generation of cells
        private void ConfigureStartingPattern(int r, int c)
        {
            displayBoard[r, c + 1] = LIVE;
            displayBoard[r, c + 2] = LIVE;
            displayBoard[r, c + 3] = LIVE;
            displayBoard[r, c + 4] = LIVE;
            displayBoard[r, c + 5] = LIVE;
            displayBoard[r, c + 6] = LIVE;
            displayBoard[r, c + 7] = LIVE;
            displayBoard[r, c + 8] = LIVE;
            // DEAD
            displayBoard[r, c + 10] = LIVE;
            displayBoard[r, c + 11] = LIVE;
            displayBoard[r, c + 12] = LIVE;
            displayBoard[r, c + 13] = LIVE;
            displayBoard[r, c + 14] = LIVE;
            // DEAD
            displayBoard[r, c + 18] = LIVE;
            displayBoard[r, c + 19] = LIVE;
            displayBoard[r, c + 20] = LIVE;
            // DEAD
            displayBoard[r, c + 27] = LIVE;
            displayBoard[r, c + 28] = LIVE;
            displayBoard[r, c + 29] = LIVE;
            displayBoard[r, c + 30] = LIVE;
            displayBoard[r, c + 31] = LIVE;
            displayBoard[r, c + 32] = LIVE; 
            displayBoard[r, c + 33] = LIVE;
            // DEAD
            displayBoard[r, c + 35] = LIVE;
            displayBoard[r, c + 36] = LIVE;
            displayBoard[r, c + 37] = LIVE;
            displayBoard[r, c + 38] = LIVE;
            displayBoard[r, c + 39] = LIVE;

        }
    }
}