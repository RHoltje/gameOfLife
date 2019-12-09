using System;
using System.Threading;

namespace gameOfLife
{
    class MainClass
    {      

        public static void Main(string[] args)
        {
            int height = 50;
            int width = 50;
            int generation = 1;

            bool[,] currentGrid = new bool[width, height];
            bool[,] nextGrid = new bool[width, height];

            bool keepLooping = true;

            Plot plot = new Plot();
            plot.grid = currentGrid;           

            Aliens aliens = new Aliens();
            aliens.grid = currentGrid;
            aliens.plot.grid = currentGrid;

            Neighbors neighbors = new Neighbors();
            neighbors.grid = currentGrid;
            neighbors.width = width;
            neighbors.height = height;
            bool keepAsking = true;

            while (keepAsking)
            {
                Console.WriteLine("Add an Alien?");
                Console.WriteLine("A: Blinker\nB: Beacon\nC: Glider\nD: PentaDecathlon\nE: Middleweight Spaceship\nF: Glider Gun\nG: R-Pentomino\nR: Run");
                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        aliens.Blinker();
                        break;
                    case "B":
                        aliens.Beacon();
                        break;
                    case "C":
                        aliens.Glider();
                        break;
                    case "D":
                        aliens.Penta();                        
                        break;
                    case "E":
                        aliens.Middleweight();
                        break;
                    case "F":
                        aliens.Gun();
                        break;
                    case "G":
                        aliens.RPentomino();
                        break;
                    case "R":
                        keepAsking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please select the letter next to your selection");
                        break;
                }
            }            

           while(keepLooping)
            {
                //this forloop draws currentGrid
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
                    {
                        if (currentGrid[column, row] == true)
                        {
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write(". ");
                        }
                    }
                    Console.WriteLine();
                }

                //this for loop creates nextGrid
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
                    {
                        int count = neighbors.numberOfNeighbors(column, row);
                        if (currentGrid[column, row] == true)
                        {
                            if (count < 2 || count > 3)
                            {
                                nextGrid[column, row] = false;
                            }
                            else
                            {
                                nextGrid[column, row] = true;
                            }
                        }
                        else
                        {
                            if (count == 3)
                            {
                                nextGrid[column, row] = true;
                            }
                            else
                            {
                                nextGrid[column, row] = false;
                            }
                        }
                    }
                }

                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
                    {
                        currentGrid[column, row] = nextGrid[column, row];
                    }
                }

                generation++;
                Console.WriteLine("Generation " + generation);
                //Console.ReadLine();
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }

    /*
 *                          1.	If statements applying each rule
                                    a.	If square = live
                                        i.	if < 2 neighbors OR > 3 neighbors, it dies
                                        ii.	if 2 OR 3 neighbors, it lives
                                    b.	If square = dead
                                        i.	If has 3 neighbors, it lives
                                        ii.	If has < 3 OR > 3 neightbors, it dies
                                        ii.	Plug results into nextGrid
 */

    class Plot
    {
        public bool[,] grid;

        public void PlotRow(string input, int column, int row)
        {

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    grid[i + column, row] = false;
                }
                else
                {
                    grid[i + column, row] = true;
                }
            }
        }
    }

    class Aliens
    {
        public bool[,] grid;

        public Plot plot = new Plot();

        public void RPentomino()
        {
            plot.PlotRow(".##", 25, 25);
            plot.PlotRow("##.", 25, 26);
            plot.PlotRow(".#.", 25, 27);
        }

        public void Gun()
        {
            plot.PlotRow("......................................", 0, 10);
            plot.PlotRow(".........................#............", 0, 11);
            plot.PlotRow(".......................#.#............", 0, 12);
            plot.PlotRow(".............##......##............##.", 0, 13);
            plot.PlotRow("............#...#....##............##.", 0, 14);
            plot.PlotRow(".##........#.....#...##...............", 0, 15);
            plot.PlotRow(".##........#...#.##....#.#............", 0, 16);
            plot.PlotRow("...........#.....#.......#............", 0, 17);
            plot.PlotRow("............#...#.....................", 0, 18);
            plot.PlotRow(".............##.......................", 0, 19);
            plot.PlotRow("......................................", 0, 20);

        }

        public void Blinker()
        {
            grid[12, 12] = true;
            grid[13, 12] = true;
            grid[14, 12] = true;
        }

        public void Beacon()
        {
            grid[7, 7] = true;
            grid[8, 7] = true;
            grid[7, 8] = true;
            grid[8, 8] = true;
            grid[9, 9] = true;
            grid[9, 10] = true;
            grid[10, 9] = true;
            grid[10, 10] = true;
        }

        public void Glider()
        {
            grid[2, 3] = true;
            grid[3, 4] = true;
            grid[4, 4] = true;
            grid[4, 3] = true;
            grid[4, 2] = true;
        }

        public void Penta()
        {
            grid[6, 5] = true;
            grid[6, 6] = true;
            grid[6, 7] = true;
            grid[5, 7] = true;
            grid[7, 7] = true;
            grid[6, 10] = true;
            grid[5, 10] = true;
            grid[7, 10] = true;
            grid[6, 11] = true;
            grid[6, 12] = true;
            grid[6, 13] = true;
            grid[6, 14] = true;
            grid[6, 15] = true;
            grid[5, 15] = true;
            grid[7, 15] = true;
            grid[5, 18] = true;
            grid[6, 18] = true;
            grid[7, 18] = true;
            grid[6, 19] = true;
            grid[6, 20] = true;
        }

        public void Middleweight()
        {
            grid[0, 15] = true;
            grid[0, 16] = true;
            grid[1, 15] = true;
            grid[1, 16] = true;
            grid[1, 17] = true;
            grid[2, 15] = true;
            grid[2, 16] = true;
            grid[2, 17] = true;
            grid[3, 14] = true;
            grid[3, 16] = true;
            grid[3, 17] = true;
            grid[4, 14] = true;
            grid[4, 15] = true;
            grid[4, 16] = true;
            grid[5, 15] = true;
        }
    }

    //this class checks the boxes around the current position
    class Neighbors
    {
        public bool[,] grid;

        public int width;
        public int height;

        public int numberOfNeighbors(int column, int row)
        {
            int count = 0;

            if(upperLeft(column, row))
            {
                count++;
            }
            if (upper(column, row))
            {
                count++;
            }
            if (upperRight(column, row))
            {
                count++;
            }
            if (left(column, row))
            {
                count++;
            }
            if (right(column, row))
            {
                count++;
            }
            if (lowerLeft(column, row))
            {
                count++;
            }
            if (lower(column, row))
            {
                count++;
            }
            if (lowerRight(column, row))
            {
                count++;
            }

            return count;

        }

        public bool upperLeft(int column, int row)
        {
            if((column - 1 < 0) || (row - 1) < 0)
            {
                return false;
            }
            return grid[column - 1, row - 1];
        }

        public bool upper(int column, int row)
        {
            if ((row - 1) < 0)
            {
                return false;
            }
            return grid[column, row - 1];
        }

        public bool upperRight(int column, int row)
        {
            if ((column + 1) > (width - 1) || (row - 1) < 0)
            {
                return false;
            }
            return grid[column + 1, row - 1];
        }

        public bool left(int column, int row)
        {

            if ((column - 1) < 0)
            {
                return false;
            }
            return grid[column -1 , row];
        }

        public bool right(int column, int row)
        {
            if ((column + 1) > (width - 1))
            {
                return false;
            }
            return grid[column + 1, row];
        }

        public bool lowerLeft(int column, int row)
        {
            if ((column - 1) < 0 || (row + 1) > (height -1))
            {
                return false;
            }
            return grid[column - 1, row + 1];
        }

        public bool lower(int column, int row)
        {
            if ((row + 1) > (height - 1))
            {
                return false;
            }
            return grid[column, row + 1];
        }

        public bool lowerRight(int column, int row)
        {
            if ((column + 1) > (width - 1) || (row + 1) > (height -1))
            {
                return false;
            }
            return grid[column + 1, row + 1];
        }

    }
}
