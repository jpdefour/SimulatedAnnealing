using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealingHomework
{
    public static class SimulatedAnnealing
    {
        static Random Random = new Random();
        const int NumberOfVariables = 3;
        const int NumberOfIterationsAtTemperature = 1000;

        public static int[] DoSimulatedAnnealing(Func<int[],double> annealingFunction)
        {
            var currentNumbers = GenerateRandomValues(NumberOfVariables);
            var newNumbers = GenerateRandomValues(NumberOfVariables);
            int temperature = 100;
            for (int i = 10; i >= 1; i--)
            {
                temperature = i * 10;
                for (int j = 0; j < NumberOfIterationsAtTemperature; j++)
                {
                    var probability = CalculateProbability(currentNumbers, newNumbers, temperature, annealingFunction);

                    if (!CurrentProbabilityIsBetter(probability)) currentNumbers = newNumbers;
                    newNumbers = GenerateRandomValues(NumberOfVariables);
                }
            }
            return currentNumbers;
        }

        public static double CalculateProbability(int[] currentValues, int[] newValues, int temperature, Func<int[], double> annealingFunction)
        {
            var currentEnergy = Math.Abs(annealingFunction(currentValues));
            var newEnergy = Math.Abs(annealingFunction(newValues));
            var exponent = -(currentEnergy - newEnergy) / temperature;
            return Math.Pow(Math.E, exponent);
        }

        public static bool CurrentProbabilityIsBetter(double value) => (value > 1);

        public static int GenerateRandomValue() => Random.Next(0, 11);

        public static int[] GenerateRandomValues(int numberOfVariables)
        {
            int[] values = new int[numberOfVariables];
            for(int i = 0; i < numberOfVariables; i++)
            {
                values[i] = GenerateRandomValue();
            }
            return values;
        }
    }
}
