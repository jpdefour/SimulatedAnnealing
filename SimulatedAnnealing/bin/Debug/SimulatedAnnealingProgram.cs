using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealingHomework
{
    //Minimize the function E(x) = x2 – 15x +54 = 0, using simulated annealing method.Take an initial random guess x1 between 0 and 99.  Set the value of Temperature T = 100.Calculate E(x1).  Choose another random guess x2.(again between 0 and 99) Calculate E(x2).  Calculate the probabilityP = exp(-[E(x2)-E(x2)]/T). If p> 1, accept x2, otherwise choose another random guess.Continue 5 iterations.Then reduce the temperature to 90 and repeat the procedure.  Then reduce the temperature to 80, 70, 60, 50, 40, 30, 20, and 10.  Determine the optimum value of x.

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
