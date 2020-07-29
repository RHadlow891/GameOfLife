using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    class Grid
    {
        private Ladybird m_currentInsect = new Ladybird(); //Instantiate ladybird current insect
        bool exit;
        Actions m = new Actions();

        public Insect getInsect() //Get the current insect
        {
            return m_currentInsect;
        }

        private string[,] buildGrid; //String array to build the grid
        public const int DIMENSION = 20; //Dimension to specify the size of grid

        
        private Actions move; //Creating the move function


        public Grid() //Grid constructor
        {
            move = new Actions();
            buildGrid = new string[DIMENSION, DIMENSION];
            GridHorizontal = "+---";
            GridVertical = "| ";
        }

        public string GridHorizontal { get; set; } //Get and set the y axis of the grid
        public string GridVertical { get; set; } //Get and set the x axis of the grid

        public void displayGrid() //Function to display grid
        {
            m_currentInsect.initGrid(); //Initialise grid with current insects
            while (!exit)
            {
                Console.Clear(); //Refresh grid each time
                Console.WriteLine(" " +
                    "||----------------   WELCOME TO THE GAME OF LIFE   ----------------||\n ");
                Console.WriteLine("Double press enter to "); //Instructions
                Console.WriteLine("Press X and the press enter twice to exit!"); //Instructions
                Console.WriteLine("   0   1   2   3   4   5   6   7   8   9  10   2   3   4   5   6   7   8   9   1   2"); //Top line of x axis

                for (int row = 0; row < DIMENSION; row++) //Loop through the rows of the grid
                {
                    Console.Write("  ");
                    for (int col = 0; col < DIMENSION; col++) //Within each row it will loop through the columns
                    {
                        Console.Write(GridHorizontal);
                    }

                    Console.Write("+\n");

                    for (int col = 0; col < DIMENSION; col++)
                    {

                        if (col == 0)
                        {
                            if (row < 10)
                                Console.Write("0");
                            Console.Write(row + " ");
                        }


                        Console.Write(GridVertical + Insect.insects[row, col] + " "); //Adds the insects to that specific cell in the grid
                    }
                    Console.Write("|\n");
                }

                Console.Write("  ");
                for (int col = 0; col < DIMENSION; col++) //Loops through the y axis
                {
                    Console.Write(GridHorizontal); //Prints the grid horizontal properties
                }

                Console.Write("+\n\n");
                Console.WriteLine("Ladybirds : " + m_currentInsect.getLBList().Count()); //Displays the Ladybird counter, showing how many are currently in the system
                Console.WriteLine("Greenfly : " + m_currentInsect.getGFList().Count()); //Displays the greenfly counter, showing how many are currently in the system
                string r = Console.ReadLine();
                if(r.ToLower() == "x") //Press x to exit the program
                {
                    exit = true;
                }
                Console.ReadKey();
                m.moveIns(); //Perform the move function
            }
            if(exit)
            {
                Console.Clear();
                Console.WriteLine("Program Terminated! Press enter to close this window!"); //Displays this message when the program is exited
                Console.ReadKey();
            }
        }

    }
}
