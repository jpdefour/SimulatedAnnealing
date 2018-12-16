using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealingHomework
{
    class SimulatedAnnealingProgram
    {
        static double AnnealingFunction(int[] x) =>
            Math.Pow(x[0], 6) + Math.Pow(x[1], 2)*Math.Pow(x[2], 3)*Math.Pow(x[0], 4) + Math.Pow(x[1], 3)*Math.Pow(x[2], 5) - 8571609;

        static void Main(string[] args)
        {
            var optimalValues = SimulatedAnnealing.DoSimulatedAnnealing(AnnealingFunction);
            int counter = 0;
            foreach (int optimalValue in optimalValues)
            {
                counter++;
                Console.WriteLine("Using Simulated Annealing, the optimal values for variable x" + counter +  " is " + optimalValue);
            }

            Console.ReadLine();
        }
    }
}
