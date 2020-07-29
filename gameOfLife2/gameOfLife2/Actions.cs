using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    public class Actions : Insect //Move subclass
    {
        Ladybird ins = new Ladybird(); //Creates instance of ladybird
        List<Ladybird> ladybirds = new List<Ladybird>(); //Creates a list of ladybirds
        List<Greenfly> greenfly = new List<Greenfly>(); //Creates a list of greenfly

        public void getLists() //Gets ladybird and greenfly list
        {
            ladybirds = ins.getLBList();
            greenfly = ins.getGFList();
        }

        public void moveIns() //Move insects function, handles all insect actions
        {
            getLists(); //Calls get lists
            Greenfly gf = new Greenfly(); //Instance of greenfly
            char up, down, left, right; //Directions

            foreach (Ladybird l in ladybirds.ToList()) //Loops through list of ladybirds
            {
                if (l.getM() == 3) //Gets the move counter
                {
                    Insect.insects[l.x, l.y] = '\0'; //When the move is 3 and the ladybird has not eaten set the position is set to empty space
                                                        //This is determined by the move counter which is only incrimented every time the ladybird cannot eat.
                    ins.remove(l); //Insect is removed from list
                }
                else

                //Set directions to determine movement etc later on, these are stored in a char and depend on the current position of the insect,
                //if the insect is sat at a corner or on the edge it won't be able to move in a direction that would take it off the grid.

                {   //if statements to check movements available when at every possible border
                    if (l.x == 0 && l.y == 0) //Top left
                    {
                        up = Insect.insects[l.x, l.y];
                        down = Insect.insects[l.x + 1, l.y];
                        left = Insect.insects[l.x, l.y];
                        right = Insect.insects[l.x, l.y + 1];
                    }
                    else if (l.x == 19 && l.y == 19) //Top right
                    {
                        up = Insect.insects[l.x - 1, l.y];
                        down = Insect.insects[l.x, l.y];
                        left = Insect.insects[l.x, l.y - 1];
                        right = Insect.insects[l.x, l.y];
                    }
                    else if (l.x == 0)
                    {
                        up = Insect.insects[l.x, l.y];
                        down = Insect.insects[l.x + 1, l.y];
                        left = Insect.insects[l.x, l.y - 1];
                        right = Insect.insects[l.x, l.y + 1];
                    }
                    else if (l.y == 0)
                    {
                        up = Insect.insects[l.x - 1, l.y];
                        down = Insect.insects[l.x + 1, l.y];
                        left = Insect.insects[l.x, l.y];
                        right = Insect.insects[l.x, l.y + 1];
                    }
                    else if (l.x == 19 || l.y == 19) //Bottom right
                    {
                        if(l.x == 19)
                        {
                            up = Insect.insects[l.x - 1, l.y];
                            down = Insect.insects[l.x, l.y];
                            left = Insect.insects[l.x, l.y - 1];
                            right = Insect.insects[l.x, l.y + 1];
                        }
                        else
                        {
                            up = Insect.insects[l.x - 1, l.y];
                            down = Insect.insects[l.x + 1, l.y];
                            left = Insect.insects[l.x, l.y - 1];
                            right = Insect.insects[l.x, l.y];
                        }

                    }
                    else if (l.x == 0 && l.y == 19)
                    {
                        up = Insect.insects[l.x, l.y];
                        down = Insect.insects[l.x + 1, l.y];
                        left = Insect.insects[l.x, l.y - 1];
                        right = Insect.insects[l.x, l.y];
                    }
                    else if (l.y == 0 && l.x == 19)
                    {
                        up = Insect.insects[l.x - 1, l.y];
                        down = Insect.insects[l.x, l.y];
                        left = Insect.insects[l.x, l.y];
                        right = Insect.insects[l.x, l.y + 1];
                    }
                    else
                    {
                        up = Insect.insects[l.x - 1, l.y];
                        down = Insect.insects[l.x + 1, l.y];
                        left = Insect.insects[l.x, l.y - 1];
                        right = Insect.insects[l.x, l.y + 1];
                    }
                    //Checks for greenfly and eats
                    if (up == 'O')
                    {
                        Insect.insects[l.x - 1, l.y] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.x = l.x - 1;
                        //Removes the chosen greenfly from the list, this is done in the insect class by passing the insect through and then using the remove function on the current
                        //insect.
                        gf.x = gf.x - 1;
                        ins.removeG(gf);
                    }
                    else if (down == 'O')
                    {
                        Insect.insects[l.x + 1, l.y] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.x = l.x + 1;
                        gf.x = gf.x + 1;
                        ins.removeG(gf);
                    }
                    else if (left == 'O')
                    {
                        Insect.insects[l.x, l.y - 1] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.y = l.y - 1;
                        gf.y = gf.y - 1;
                        ins.removeG(gf);
                    }
                    else if (right == 'O')
                    {
                        Insect.insects[l.x, l.y + 1] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.y = l.y + 1;
                        gf.y = gf.y + 1;
                        ins.removeG(gf);
                    }
                    else if (up == '\0')
                    {
                        Insect.insects[l.x - 1, l.y] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.x = l.x - 1;
                        l.setM(l.getM() + 1);
                        //Breed if the breed counter is 8, after the insect has moved it will place an X in the grid space it moved from.
                        //then resets the breed counter to 0. This is the same for all below code with the same function in.
                        if (l.getB() == 8)
                        {
                            Insect.insects[l.x, l.y] = 'X';
                            l.setB(0);
                        }
                    }
                    else if (down == '\0')
                    {
                        Insect.insects[l.x + 1, l.y] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.x = l.x + 1;
                        l.setM(l.getM() + 1);
                        if (l.getB() == 8)
                        {
                            Insect.insects[l.x, l.y] = 'X';
                            l.setB(0);
                        }
                    }
                    else if (left == '\0')
                    {
                        Insect.insects[l.x, l.y - 1] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.y = l.y - 1;
                        l.setM(l.getM() + 1);
                        if (l.getB() == 8)
                        {
                            Insect.insects[l.x, l.y] = 'X';
                            l.setB(0);
                        }
                    }
                    else if (right == '\0')
                    {
                        Insect.insects[l.x, l.y + 1] = 'X';
                        Insect.insects[l.x, l.y] = '\0';
                        l.y = l.y + 1;
                        l.setM(l.getM() + 1);
                        if (l.getB() == 8)
                        {
                            Insect.insects[l.x, l.y] = 'X';
                            l.setB(0);
                        }

                    }
                    l.setB(l.getB() + 1); //The breed function
                }
            }


            foreach (Greenfly g in greenfly.ToList()) //Loops through list of greenfly
            {
                g.setM(g.getM() + 1);

                //Set directions to determine movement etc later on, these are stored in a char and depend on the current position of the insect,
                //if the insect is sat at a corner or on the edge it won't be able to move in a direction that would take it off the grid.

                //if statements to check movements available when at every possible border
                if (g.x == 0 && g.y == 0) //Top left corner
                {
                    up = Insect.insects[g.x, g.y];
                    down = Insect.insects[g.x + 1, g.y];
                    left = Insect.insects[g.x, g.y];
                    right = Insect.insects[g.x, g.y + 1];
                }
                else if (g.x == 19 && g.y == 19) //Bottom right
                {
                    up = Insect.insects[g.x - 1, g.y];
                    down = Insect.insects[g.x, g.y];
                    left = Insect.insects[g.x, g.y - 1];
                    right = Insect.insects[g.x, g.y];
                }
                else if (g.x == 0 && g.y == 19) //Bottom left
                {
                    up = Insect.insects[g.x, g.y];
                    down = Insect.insects[g.x + 1, g.y];
                    left = Insect.insects[g.x, g.y - 1];
                    right = Insect.insects[g.x, g.y];
                }
                else if (g.y == 0 && g.x == 19) //Top right
                {
                    up = Insect.insects[g.x - 1, g.y];
                    down = Insect.insects[g.x, g.y];
                    left = Insect.insects[g.x, g.y];
                    right = Insect.insects[g.x, g.y + 1];
                }
                else if (g.x == 0 || g.y == 0) //Top left
                {
                    if(g.x == 0)
                    {
                        up = Insect.insects[g.x, g.y];
                        down = Insect.insects[g.x + 1, g.y];
                        left = Insect.insects[g.x, g.y - 1];
                        right = Insect.insects[g.x, g.y + 1];
                    }
                    else
                    {
                        up = Insect.insects[g.x - 1, g.y];
                        down = Insect.insects[g.x + 1, g.y];
                        left = Insect.insects[g.x, g.y];
                        right = Insect.insects[g.x, g.y + 1];
                    }
                }
                else if (g.x == 19 || g.y == 19)
                {
                    if (g.x == 19)
                    {
                        up = Insect.insects[g.x - 1, g.y];
                        down = Insect.insects[g.x, g.y];
                        left = Insect.insects[g.x, g.y - 1];
                        right = Insect.insects[g.x, g.y + 1];
                    }
                    else
                    {
                        up = Insect.insects[g.x - 1, g.y];
                        down = Insect.insects[g.x + 1, g.y];
                        left = Insect.insects[g.x, g.y - 1];
                        right = Insect.insects[g.x, g.y];
                    }

                }
                else
                {
                    up = Insect.insects[g.x - 1, g.y];
                    down = Insect.insects[g.x + 1, g.y];
                    left = Insect.insects[g.x, g.y - 1];
                    right = Insect.insects[g.x, g.y + 1];
                }
                    if (up == '\0')
                    {
                        Insect.insects[g.x - 1, g.y] = 'O';
                        Insect.insects[g.x, g.y] = '\0';
                        g.x = g.x - 1;
                    //Breed if the breed counter is 3, after the insect has moved it will place an O in the grid space it moved from.
                    //then resets the breed counter to 0. This is the same for all below code with the same function in.
                    if (g.getM() == 3)
                        {
                            Insect.insects[g.x, g.y] = 'O';
                            g.setB(0);
                        }
                    }
                    else if (down == '\0')
                    {
                        Insect.insects[g.x + 1, g.y] = 'O';
                        Insect.insects[g.x, g.y] = '\0';
                        g.x = g.x + 1;
                        if (g.getM() == 3)
                        {
                            Insect.insects[g.x, g.y] = 'O';
                            g.setB(0);
                        }
                    }
                    else if (left == '\0')
                    {
                        Insect.insects[g.x, g.y - 1] = 'O';
                        Insect.insects[g.x, g.y] = '\0';
                        g.y = g.y - 1;
                        if (g.getM() == 3)
                        {
                            Insect.insects[g.x, g.y] = 'O';
                            g.setB(0);
                        }
                    }
                    else if (right == '\0')
                    {
                        Insect.insects[g.x, g.y + 1] = 'O';
                        Insect.insects[g.x, g.y] = '\0';
                        g.y = g.y + 1;
                        if (g.getM() == 3)
                        {
                            Insect.insects[g.x, g.y] = 'O';
                            g.setB(0);
                        }
                    }
            }
        }
    }
}
