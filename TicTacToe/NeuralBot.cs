using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class NeuralBot : Bot
    {
        Network Brain;
        Dictionary<int, int[]> NeuronToMove = new Dictionary<int, int[]>();
       
        public NeuralBot(Game i_game, Boolean Color)
        {
            myGame = i_game;
            this.Color = Color;
            int[] hiddenlayer= new int[1];
            hiddenlayer[0] = 18;
            Brain = new Network(18, hiddenlayer, 9);

            NeuronToMove.Add(0, new int[] { 0, 0 });
            NeuronToMove.Add(1, new int[] { 0, 1 });
            NeuronToMove.Add(2, new int[] { 0, 1 });
            NeuronToMove.Add(3, new int[] { 1, 0 });
            NeuronToMove.Add(4, new int[] { 1, 1 });
            NeuronToMove.Add(5, new int[] { 1, 2 });
            NeuronToMove.Add(6, new int[] { 2, 0 });
            NeuronToMove.Add(7, new int[] { 2, 1 });
            NeuronToMove.Add(8, new int[] { 2, 2 });
        }
        override public void call()
        {
            Console.WriteLine("NeuralBot Called");
            /*
             Fill inputneurons
             2 neurons for each field on the board
             */
            int f = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (myGame.Gameboard[i, k] == null)
                    {
                        Brain.InputNeurons[f].input = 0;
                        Brain.InputNeurons[f + 1].input = 0;
                    }
                    else
                    {
                        if (myGame.Gameboard[i, k] == true)
                        {
                            Brain.InputNeurons[f].input = 1;
                            Brain.InputNeurons[f+1].input = 0;
                        }
                        else
                        {
                            Brain.InputNeurons[f].input = 0;
                            Brain.InputNeurons[f+1].input = 1;
                        }
                    }
                    f++;
                    f++;
                }
            }
            double lastOutput = -1;
            f = 0;
            int IndexofActiveNeuron = -1;
            //find the move he meant
            foreach (Neuron Neur in Brain.outputNeurons)
            {
                if (Neur.output>lastOutput && myGame.Gameboard[NeuronToMove[f][0], NeuronToMove[f][1]]==null )
                {
                    IndexofActiveNeuron = f;
                }
                f++;
            }

            int[] move = NeuronToMove[IndexofActiveNeuron];
            myGame.MakeMove(move[0], move[1], this.Color);
        }
        public void learnByExample()
        {

        }
    }
}
