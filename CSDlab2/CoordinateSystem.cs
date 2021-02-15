using System;
using System.Collections.Generic;
using System.Text;

namespace CSDlab2
{
    class CoordinateSystem  // i.e. the paper
    {
        /// <summary>
        /// Returns a list of shapes where all the shapes are inside the specified point (x,y)
        /// </summary>
        private List<Shape> Hit(List<Shape> shapes, int x, int y)
        {
            List<Shape> hitList = new List<Shape>();
            foreach (Shape shape in shapes)
            {
                if (shape.IsInside(x, y))
                {
                    hitList.Add(shape);
                }
            }
            return hitList;
        }

        /// <summary>
        /// Returns a list of shapes where all the shapes are outside the specified point (x,y)
        /// </summary>
        private List<Shape> Miss(List<Shape> shapes, int x, int y)
        {
            List<Shape> missList = new List<Shape>();
            foreach (Shape shape in shapes)
            {
                if (!shape.IsInside(x, y))
                {
                    missList.Add(shape);
                }
            }
            return missList;
        }

        /// <summary>
        /// Calculates the point-score for given shapes, with regards to the coordinates x & y
        /// </summary>
        private double CalculatePointScore(List<Shape> shapes, int x, int y)
        {
            double ShapeScoreHit = 0;
            double ShapeScoreMiss = 0;
            foreach (Shape shape in Hit(shapes, x, y))
            {
                ShapeScoreHit += shape.ShapeScore;
            }
            foreach (Shape shape in Miss(shapes, x, y))
            {
                ShapeScoreMiss += shape.ShapeScore;
            }
            return Math.Round(ShapeScoreHit - 0.25 * ShapeScoreMiss);
        }

        /// <summary>
        /// Takes a string (which should contain the coordinates x,y) as an argument and returns a int array with two numbers (x,y).
        /// </summary>
        public int[] HandleXYInput(string args)
        {
            int[] xy1 = new int[2];
            try
            {
                string[] xy = args.Split(',');

                if (xy.Length > 2)          // redundant because of the if else statement in program.cs?
                {
                    throw new IndexOutOfRangeException();
                }

                int x = int.Parse(xy[0]);
                int y = int.Parse(xy[1]);
                xy1[0] = x;
                xy1[1] = y;
                return xy1;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + " Please enter only the x and y coordinates.");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + " The x,y input was not correct.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Exception for the coordinates.");
            }
            throw new OperationCanceledException();         // This is here instead of returning xy1, as if xy1 would be returned here 
                                                            // it would be returned even when an exception have been thrown.
                                                            // There exists a better way to do this, but alas, I have not found it.
        }

        /// <summary>
        /// Checks in which order the columns were entered and based on that calculates the pointScore with regards to the coordinates x & y
        /// </summary>
        public string FixOrderAndCalculate(string[] shapes, int x, int y)
        {
            int shapePos, Xpos, Ypos, LENGTHpos, POINTSpos;
            shapePos = Xpos = Ypos = LENGTHpos = POINTSpos = 0;
            string[] columns = shapes[0].Split(',');
            List<Shape> calcValues = new List<Shape>();

            try
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    switch (columns[i].ToUpper().Trim())
                    {
                        case "SHAPE":
                            shapePos = i;
                            break;
                        case "X":
                            Xpos = i;
                            break;
                        case "Y":
                            Ypos = i;
                            break;
                        case "LENGTH":
                            LENGTHpos = i;
                            break;
                        case "POINTS":
                            POINTSpos = i;
                            break;
                        default:
                            throw new ArgumentException(columns[i] + " is not a valid argument for the shapes entry.");
                    }
                }

                // Goes through all input except shapes[0] and adds it to a list of shapes (calcValues). The input gets added to to the list depending on if the input is circle or square.
                // It then does a Console.Writeline for the CalculateShapeScore with calcValues and x,y entered.
                for (int j = 1; j < shapes.Length; j++)     // Starts at 1 because shapes[0] contains the columns and not the values
                {
                    string[] splitted = shapes[j].Split(',');
                    if (splitted[shapePos].ToUpper().Trim() == "CIRCLE")
                    {
                        calcValues.Add(new Circle(int.Parse(splitted[Xpos]), int.Parse(splitted[Ypos]), int.Parse(splitted[LENGTHpos]), double.Parse(splitted[POINTSpos])));
                    }
                    else if (splitted[shapePos].ToUpper().Trim() == "SQUARE")
                    {
                        calcValues.Add(new Square(int.Parse(splitted[Xpos]), int.Parse(splitted[Ypos]), int.Parse(splitted[LENGTHpos]), double.Parse(splitted[POINTSpos])));
                    }
                    else
                    {
                        throw new ArgumentException(splitted[shapePos] + " is not a valid shape. Please enter either 'Square' or 'Circle'.");
                    }
                }
                return "Pointscore: " + CalculatePointScore(calcValues, x, y).ToString();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + " The input for the shapes did not contain the right amount of arguments. Please check.");
            }
            return null;            // to make sure all code paths return a value (more specifically, returns null when an exception has been raised)
        }
    }
}
