using System;
using System.Collections.Generic;
using System.Linq;

namespace CSDlab2
{
    // Zacharias Sundlöf. Lab 2. 12.02.2021
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 2)
                {
                    throw new IndexOutOfRangeException();
                }
                CoordinateSystem coordinateSystem = new CoordinateSystem();
                if (args[1].Contains(';'))      // Checks which in which order the arguments are entered.
                {
                    int[] xy = coordinateSystem.HandleXYInput(args[0]);
                    string[] shapes = args[1].Split(';');
                    Console.WriteLine(coordinateSystem.FixOrderAndCalculate(shapes, xy[0], xy[1]));
                }
                else if (args[1].Length < 4)     // Or if the args length is less than four, meaning it should be the coordinates. Perhaps an ugly solution.
                {
                    int[] xy = coordinateSystem.HandleXYInput(args[1]);
                    string[] shapes = args[0].Split(';');
                    Console.WriteLine(coordinateSystem.FixOrderAndCalculate(shapes, xy[0], xy[1]));
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + " Not correct amount of arguments entered.");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + " Please check your arguments.");
            }
            catch (Exception e)             // Very general solution..
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
