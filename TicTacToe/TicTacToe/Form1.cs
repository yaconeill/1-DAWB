using System;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        int pturn;
        int current_started;
        public int[,] gridvalues = new int[3, 3];
        private void Form1_Load(object sender, EventArgs e)
        {
            current_started = 1;
            pturn = 1;
        }

        private void start_new_game()
        {
            b11.Enabled = true; b11.Text = "";
            b12.Enabled = true; b12.Text = "";
            b13.Enabled = true; b13.Text = "";
            b21.Enabled = true; b21.Text = "";
            b22.Enabled = true; b22.Text = "";
            b23.Enabled = true; b23.Text = "";
            b31.Enabled = true; b31.Text = "";
            b32.Enabled = true; b32.Text = "";
            b33.Enabled = true; b33.Text = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridvalues[i, j] = 0;
                }
            }

            if (current_started == 1)
            {
                current_started = 2;
                pturn = 2;
            }
            else              
                if(current_started == 2)
            {
                current_started = 1;
                pturn = 1; 
            }
        }

        private void check_all_diagonals()
        {
            int countforP1 = 0;
            int countforP2 = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j && gridvalues[j, i] == 1)
                    {
                        countforP1++;
                    }
                    if (i == j && gridvalues[j, i] == 2)
                    {
                        countforP2++;
                    }

                    if ((i + j) == 4 && gridvalues[j, i] == 1)
                    {
                        countforP1++;
                    }
                    if ((i + j) == 4 && gridvalues[j, i] == 2)
                    {
                        countforP2++;
                    }

                    if (countforP1 == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        p1score.Text = Convert.ToString(Convert.ToUInt16(p1score.Text) + 1);
                        start_new_game();
                        break;
                    }
                    if (countforP2 == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        p2score.Text = Convert.ToString(Convert.ToUInt16(p2score.Text) + 1);
                        start_new_game();
                        break;
                    }
                }
            }
        }

        private void check_all_rows()
        {
            int countforP1 = 0;
            int countforP2 = 0;

            for (int i = 0; i < 3; i++)
            {
                countforP1 = 0;
                countforP2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (gridvalues[i, j] == 1)
                    {
                        countforP1++;
                    }
                    if (gridvalues[i, j] == 2)
                    {
                        countforP2++;
                    }

                    if (countforP1 == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        p1score.Text = Convert.ToString(Convert.ToUInt16(p1score.Text)+1);
                        start_new_game();
                        break;
                    }
                    if (countforP2 == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        p2score.Text = Convert.ToString(Convert.ToUInt16(p2score.Text) + 1);
                        start_new_game();
                        break;
                    }
                }
            }
        }
        


        private void check_all_columns()
        {
            int countforP1 = 0;
            int countforP2 = 0;

            for (int i = 0; i < 3; i++)
            {
                countforP1 = 0;
                countforP2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (gridvalues[j, i] == 1)
                    {
                        countforP1++;
                    }
                    if (gridvalues[j, i] == 2)
                    {
                        countforP2++;
                    }

                    if (countforP1 == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        p1score.Text = Convert.ToString(Convert.ToUInt16(p1score.Text) + 1);
                        start_new_game();
                        break;
                    }
                    if (countforP2 == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        p2score.Text = Convert.ToString(Convert.ToUInt16(p2score.Text) + 1);
                        start_new_game();
                        break;
                    }
                }
            }
        }

        private void b11_Click(object sender, EventArgs e)
        {
            b11.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[0, 0] = 1;
                b11.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[0, 0] = 2;
                b11.Text = "O";
                pturn = 1;
            }

            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b12_Click(object sender, EventArgs e)
        {
            b12.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[0, 1] = 1;
                b12.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[0, 1] = 2;
                b12.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b13_Click(object sender, EventArgs e)
        {
            b13.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[0, 2] = 1;
                b13.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[0, 2] = 2;
                b13.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b21_Click(object sender, EventArgs e)
        {
            b21.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[1, 0] = 1;
                b21.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[1, 0] = 2;
                b21.Text = "O";
                pturn = 1;
            }

            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b22_Click(object sender, EventArgs e)
        {
            b22.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[1, 1] = 1;
                b22.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[1, 1] = 2;
                b22.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b23_Click(object sender, EventArgs e)
        {
            b23.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[1, 2] = 1;
                b23.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[1, 2] = 2;
                b23.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b31_Click(object sender, EventArgs e)
        {
            b31.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[2, 0] = 1;
                b31.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[2, 0] = 2;
                b31.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b32_Click(object sender, EventArgs e)
        {
            b32.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[2, 1] = 1;
                b32.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[2, 1] = 2;
                b32.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void b33_Click(object sender, EventArgs e)
        {
            b33.Enabled = false;
            if (pturn == 1)
            {
                gridvalues[2, 2] = 1;
                b33.Text = "X";
                pturn = 2;
            }
            else
            {
                gridvalues[2, 2] = 2;
                b33.Text = "O";
                pturn = 1;
            }
            check_all_rows(); check_all_columns(); check_all_diagonals();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            p1score.Text = "0";
            p2score.Text = "0";
        }

        private void bnewgame_Click(object sender, EventArgs e)
        {
            start_new_game();
        }

        private void bexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Please Visit http://www.Code-Kings.blogspot.com//" ,"Have a Nice Day");

        }

        
    }
}