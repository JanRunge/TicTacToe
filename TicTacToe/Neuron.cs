using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Neuron
    {
        public Neuron[] inputs;
        public double[] weights = new double[2];
        public double error;
        public String name;
        private double biasWeight;
        private Random r = new Random();


        public virtual double output
        {

            get
            {
                double t = 0;
                for (int i = 0; i < weights.Count(); i++)
                {
                    t = t + (weights[i] * inputs[i].output);
                }
                t = t + biasWeight;
                return Sigmoid.output(t);
            }
        }

        public void randomizeWeights()
        {
            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] = r.NextDouble();
            }
            biasWeight = r.NextDouble();
        }

        public void adjustWeights()
        {
            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] += error * inputs[i].output;
            }
            biasWeight += error;
        }
    }
}
