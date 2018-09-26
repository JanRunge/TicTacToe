using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Game currentagme;
        private Bot GameBot;
        private Boolean playercolor;
        private Button[,] Buttons;
        public Form1()
        {
            InitializeComponent();
            Buttons = new Button[,] { { button7, button4, button1 }, { button8, button5, button2 }, { button9, button6, button3 } };
            startNewGame();
        }
        public void startNewGame()
        {
            currentagme = new Game();
            RedrawBoard();
            playercolor = true;
            //GameBot = new RandBot(currentagme, !playercolor);
            GameBot = new AlgoBot(currentagme, !playercolor);
            if (playercolor != currentagme.turn)
            {
                callAI();
            }
        }
        public void callAI()
        {
            this.GameBot.call();
            RedrawBoard();
            if (currentagme.over)
            {
                gameover();
            }

        }
        public void gameover()
        {
            Console.WriteLine("Game is over!");
            if (currentagme.winner == true)
            {
                Console.WriteLine("X wins");
            }
            else if (currentagme.winner == false)
            {
                Console.WriteLine("O wins");
            }
            else
            {
                Console.WriteLine("Tie");
            }
        }
        public void click(int x, int y)
        {
            Boolean MoveSucceeded = false ;
            if (currentagme != null)
            {
                MoveSucceeded=currentagme.MakeMove(x, y, playercolor);
            }
            if (MoveSucceeded)
            {
                RedrawBoard();
                if (currentagme.over)
                {
                    gameover();
                    
                }
                else
                {
                    callAI();
                }
               
                
            }
            else
            {
                Console.WriteLine("moveunallowed");
            }
            
        }
        public void RedrawBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (currentagme.Gameboard[i, k] == null)
                    {
                        Buttons[i, k].Text = "";
                    }
                    else
                    {
                        if (currentagme.Gameboard[i, k]==true)
                        {
                            Buttons[i, k].Text = "X";
                        }
                        else
                        {
                            Buttons[i, k].Text = "O";
                        }
                    }
                        
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            click(0, 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click(1, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            click(2, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            click(0, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            click(1, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            click(2, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            click(0, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            click(1, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            click(2, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            startNewGame();
        }
    }
}
