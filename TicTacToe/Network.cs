using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Network
    {
        public InputNeuron[] InputNeurons;
        private Neuron[][] hiddenNeurons;
        public Neuron[] outputNeurons;
        public string type;
        public Network()
        {

        }
        public void MakeXOR()
        {
            //Create all neurons that are needed, so that the network can learn how XOR works
            /*
             Needs 2 input neurons
                   2 hidden neurons
                   1 output neuron
             */
            int i;
            /*****************************
             InputNeurons
             ****************************/
            InputNeurons = new InputNeuron[] { new InputNeuron(), new InputNeuron() };
            i = 0;
            foreach (InputNeuron curNeur in InputNeurons)
            {
                i++;
                curNeur.name = "inputNeuron " + i;
            }
            /*****************************
            HiddenNeurons
            ****************************/
            hiddenNeurons[0] = new Neuron[] { new Neuron(), new Neuron() };
            i = 0;
            foreach (Neuron curNeur in hiddenNeurons[0])
            {
                i++;
                curNeur.name = "hiddenNeuron " + i;
                curNeur.randomizeWeights();
                curNeur.inputs = new Neuron[] { InputNeurons[0], InputNeurons[1] };
            }

            /*****************************
            OutputNeurons
            ****************************/
            outputNeurons = new Neuron[] { new Neuron() };
            i = 0;
            foreach (Neuron curNeur in outputNeurons)
            {
                i++;
                curNeur.name = "OutputNeuron " + i;
                curNeur.randomizeWeights();
                curNeur.inputs = new Neuron[] { hiddenNeurons[0][0], hiddenNeurons[0][1] };

            }

        }
        public void trainXOR()
        {
            Console.WriteLine("starting training");
            // the input values
            double[,] inputs =
             {
                 { 0, 0},
                 { 0, 1},
                 { 1, 0},
                 { 1, 1}
             };

            // desired results
            double[] results = { 0, 1, 1, 0 };

            int epoch = 0;

            while (epoch < 2000)
            {
                epoch++;
                for (int i = 0; i < 4; i++)  // very important, do NOT train for only one example
                {
                    //set Inputvars
                    InputNeurons[0].input = inputs[i, 0];
                    InputNeurons[1].input = inputs[i, 1];

                    //Console.WriteLine("{0} xor {1} = {2}", inputs[i, 0], inputs[i, 1], outputNeurons[0].output);

                    // 2) back propagation (adjusts weights)

                    // adjusts the weight of the output neuron, based on its error
                    outputNeurons[0].error = Sigmoid.derivative(outputNeurons[0].output) * (results[i] - outputNeurons[0].output);
                    outputNeurons[0].adjustWeights();

                    // then adjusts the hidden neurons' weights, based on their errors
                    hiddenNeurons[0][0].error = Sigmoid.derivative(hiddenNeurons[0][0].output) * outputNeurons[0].error * outputNeurons[0].weights[0];
                    hiddenNeurons[0][1].error = Sigmoid.derivative(hiddenNeurons[0][1].output) * outputNeurons[0].error * outputNeurons[0].weights[1];

                    hiddenNeurons[0][0].adjustWeights();
                    hiddenNeurons[0][1].adjustWeights();


                }
            }
            Console.WriteLine("Training finished");

        }

        public Network(int inputneurons, int[] hiddenlayers, int outputneurons)
        {
            InputNeurons = new InputNeuron[inputneurons];
            for (int i = 0; i < inputneurons; i++)
            {
                InputNeurons[i] = new InputNeuron();
                InputNeurons[i].name = "InputNeuron " + i;
            }
            this.hiddenNeurons = new Neuron[hiddenlayers.Count()][];
            //alle hiddenlayers werden mit den inputneurons und sonst nichts verbunden
            for (int i = 0; i < hiddenlayers.Count(); i++)
            {
                hiddenNeurons[i] = new Neuron[hiddenlayers[i]];
                for (int k = 0; k < hiddenlayers[i]; k++)
                {
                    hiddenNeurons[i][k] = new Neuron();
                    hiddenNeurons[i][k].name = "inputNeuron " + i + "_" + k;
                    hiddenNeurons[i][k].randomizeWeights();
                    hiddenNeurons[i][k].inputs = InputNeurons;
                }
            }
            for (int i = 0; i < outputneurons; i++)
            {
                outputNeurons[i] = new Neuron();
                outputNeurons[i].name = "OutputNeuron " + i;
                outputNeurons[i].randomizeWeights();
                outputNeurons[i].inputs = hiddenNeurons[0];
            }


        }
    }
}
