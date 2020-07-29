using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    public abstract class Insect //Parent class
    {
        protected Random m_rnd = new Random(); //Random variable initialised
        protected string m_insectType; //Type of insect
        public char insect_symbol; //Insect symbol
        public const char SPACE = '\0'; //Empty space
        public static char[,] insects; //Array of insects
        public int x, y; //X and Y directions
        private int moveCount; //Counter for moving
        private int breedCount; //Counter for breeding
        static List<Ladybird> ladybirds = new List<Ladybird>(); //List of ladybirds created
        static List<Greenfly> greenfly = new List<Greenfly>(); //List of greenfly created

        public void initGrid() //Initialises grid
        {
            insects = new char[Grid.DIMENSION, Grid.DIMENSION]; //Creates a grid by a certain dimension
            initializeLB(); //Initialises ladybirds on that grid
            initializeGF(); //Initialises greenfly on that grid
        }

        public int getM() //Gets move counter
        {
            return moveCount;
        }

        public int setM(int moveC) //Sets move counter
        {
            moveCount = moveC;
            return moveCount;
        }

        public int getB() //Gets breed counter
        {
            return breedCount;
        }

        public int setB(int moveB) //Sets breed counter
        {
            breedCount = moveB;
            return breedCount;
        }

        public List<Ladybird> getLBList() //Gets list of ladybirds
        {
            return ladybirds;
        }

        public List<Greenfly> getGFList() //Gets list of greenfly
        {
            return greenfly;
        }

        public List<Ladybird> remove(Ladybird l) //Removes ladybirds from list
        {
            ladybirds.Remove(l);
            return ladybirds;
        }

        public List<Greenfly> removeG(Greenfly g) //Removes greenfly from list
        {
            greenfly.Remove(g);
            return greenfly;
        }
        public char getInsectType() //Gets insect type
        {
            return insect_symbol;
        }
        
        private void initializeLB() //Initialise ladybird function
        {

            Random rnd = new Random(); //Creates a random variable
            int i = 0;

            do
            {
                Ladybird insec = new Ladybird(); //Creates ladybird instance
                int row = rnd.Next(0, 20);
                int col = rnd.Next(0, 20);
                //Rows and columns of grid with random number between 0 and 20
                if (insects[row, col] == SPACE) //Looks for unoccupied space
                {
                    insects[row, col] = 'X';
                    insec.x = row;
                    insec.y = col;
                    ladybirds.Add(insec); //Adds ladybird to list
                    i++;
                }

            } while (i < 5); //Creates 5 ladybirds
        }

        private void initializeGF() //Initialise greenfly function
        {

            Random rnd = new Random();
            int i = 0;

            do
            {
                Greenfly insec = new Greenfly(); //Creates greenfly instance
                int row = rnd.Next(0, 20);
                int col = rnd.Next(0, 20);
                //Rows and columns of grid with random number between 0 and 20
                if (insects[row, col] == SPACE)
                {
                    insects[row, col] = 'O';
                    insec.x = row;
                    insec.y = col;
                    greenfly.Add(insec); //Adds greenfly to list
                    i++;
                }

            } while (i < 100); //Creates 100 greenfly
        }

    }

    public class Greenfly : Insect //Child greenfly class
    {

        public Greenfly() //Constructor
        {
            m_insectType = "Greenfly";
        }
    }

    public class Ladybird : Insect //Child ladybird class
    {
        public Ladybird() //Constructor
        {

            m_insectType = "Ladybird";
        }
    }
}
