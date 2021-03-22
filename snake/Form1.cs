using SnakeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        Snake Snake;
        ViewController View;

        System.Windows.Forms.Timer t1;

        public void setUpTimer()
        {
            t1 = new System.Windows.Forms.Timer();
            t1.Interval = 500;
            t1.Tick += (sender, args) =>
            {
                if (Snake.Move() == false)
                {
                    label2.Text = "Game over!";
                    t1.Dispose();
                }
                else
                {
                    label3.Text = Snake.Length.ToString();
                };

                pictureBox1.Image = View.PrepareScene(Snake.Body, Snake.EatCoords);
            };
            

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            NewGame();



        }

   
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (((keyData == Keys.Up) || (keyData == Keys.Down) || (keyData == Keys.Right) || (keyData == Keys.Left))&&(Snake!=null))
            {
                //MessageBox.Show("You pressed the key");

                switch (keyData)
                {

                    case Keys.Up:
                     
                        Snake.setCurrentDirection(0, -1);
                        break;
                    case Keys.Down:
          
                        Snake.setCurrentDirection(0, 1);
                        break;
                    case Keys.Right:
               
                        Snake.setCurrentDirection(1, 0);
                        break;
                    case Keys.Left:
                     
                        Snake.setCurrentDirection(-1, 0);
                        break;

                }

                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void NewGame()
        {
            Snake = new Snake(8, 8);

            View = new ViewController(8, 8);

            pictureBox1.Image = View.PrepareScene(Snake.Body, Snake.EatCoords);
            setUpTimer();

            t1.Start();
            label2.Text = "";
        }




    }
}
