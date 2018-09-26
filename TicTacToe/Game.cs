using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game 
    {
        public Boolean?[,] Gameboard;
        public Boolean turn;
        public Boolean over=false;
        public Boolean? winner;
        public Game()
        {
            Gameboard = new Boolean?[3,3];
            Random t = new Random();
            turn = t.Next(2) == 0;
        }
        public void print()
        {
            if(turn){
                Console.Write("X turn");
            }
            else
            {
                Console.Write("O turn");
            }
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (Gameboard[k, i] == null)
                    {
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        if (Gameboard[k, i] == true)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write("O");
                        }
                    }

                }
            }
        }
        public Boolean MakeMove(int x, int y, Boolean Color)
        {
            if (Color == turn && Gameboard[x, y]==null && !over)
            {
                Gameboard[x, y] = Color;
                turn = !turn;
                checkIfOver();

                return true;
            }
            else
            {
                Console.WriteLine("unallowed move stopped");
                checkIfOver();
                return false;

                
            }
        }
        public Game copy()
        {
            Game nGame = new Game();
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    nGame.Gameboard[i,k] = Gameboard[i,k];
                }
            }
            
            nGame.turn = turn;
            nGame.over = over;
            nGame.winner = winner;

            return nGame;
        }
        private void checkIfOver()
        {
            for (int i = 0; i < 3; i++)
            {
                if(null != Gameboard[i, 0] && Gameboard[i, 0] == Gameboard[i, 1] && Gameboard[i, 1] == Gameboard[i, 2])
                {
                    over = true;
                    winner = Gameboard[i, 0];
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (null != Gameboard[0, i] && Gameboard[0, i]  == Gameboard[1, i] && Gameboard[1, i] == Gameboard[2, i])
                {
                    over = true;
                    winner = Gameboard[0, i];
                    return;
                }
            }
            if(null != Gameboard[0, 0] && Gameboard[0, 0] == Gameboard[1, 1] && Gameboard[0, 0] == Gameboard[2, 2])
            {
                over = true;
                winner = Gameboard[0, 0];
                return;
            }
            if (null != Gameboard[0, 2] && Gameboard[0, 2] == Gameboard[1, 1] && Gameboard[0, 2] == Gameboard[2, 0])
            {
                over = true;
                winner = Gameboard[0, 2];
                return;
            }
            
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (Gameboard[i, k] == null)
                    {
                        over = false;
                        return;
                    }
                }
            }
            over = true;




        }

        
    }
}
