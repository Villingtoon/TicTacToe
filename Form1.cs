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
    public partial class TicTacToe : Form
    {
        bool player1 = true;
        int turnCount = 0;
        public TicTacToe()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
        }

        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightCoral;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void InitializeCells()
        {
            string labelName;
            for (int i = 1; i <= 9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
                Grid.Controls[labelName].BackColor = Color.LightCoral;
            }
            turnCount = 0;
        }

        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            //label1.Text = "X";

            if (player1 == true)
            {
                if (label.Text == string.Empty)
                {
                    label.Text = "X";
                    turnCount += 1;
                }
            }
            if (player1 == false)
            {
                if (label.Text == string.Empty)
                {
                    label.Text = "O";
                    turnCount += 1;
                }
            }
            PlaySound("click_sound");
            CheckForWin();
            CheckForDraw();
            player1 = !player1;

        }

        private void CheckForWin()
        {
            if ((label1.Text == label2.Text && label2.Text == label3.Text && label1.Text != string.Empty) ||
                (label4.Text == label5.Text && label5.Text == label6.Text && label4.Text != string.Empty) ||
                (label7.Text == label8.Text && label8.Text == label9.Text && label7.Text != string.Empty) ||
                (label1.Text == label4.Text && label4.Text == label7.Text && label1.Text != string.Empty) ||
                (label2.Text == label5.Text && label5.Text == label8.Text && label2.Text != string.Empty) ||
                (label3.Text == label6.Text && label6.Text == label9.Text && label3.Text != string.Empty) ||
                (label3.Text == label5.Text && label5.Text == label7.Text && label3.Text != string.Empty) ||
                (label1.Text == label5.Text && label5.Text == label9.Text && label1.Text != string.Empty))
            {
                GameOver();
            }
        }

        private void WinnerCellsChangeColor()
        {
            if (label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label2, label3, Color.Lime);
            }
            else if (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "")
            {
                ChangeCellColors(label4, label5, label6, Color.Lime);
            }
            else if (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "")
            {
                ChangeCellColors(label7, label8, label9, Color.Lime);
            }
            else if (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label4, label7, Color.Lime);
            }
            else if (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "")
            {
                ChangeCellColors(label2, label5, label8, Color.Lime);
            }
            else if (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label6, label9, Color.Lime);
            }
            else if (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label5, label9, Color.Lime);
            }
            else if (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label5, label7, Color.Lime);
            }

        }

        private void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void GameOver()
        {
            string winner = string.Empty;
            if (player1)
            {
                winner = "X";
            }
            if (!player1)
            {
                winner = "O";
            }
            WinnerCellsChangeColor();
            MessageBox.Show(winner + " wins!");
            InitializeCells();
        }
        private void CheckForDraw()
        {
            if(turnCount == 9)
            {
                MessageBox.Show("Draw!");
                InitializeCells();
            }
        }

        private void ChangeCellColors(Label labelFirst, Label labelSecond, Label labelThird, Color color)
        {
            labelFirst.BackColor = color;
            labelSecond.BackColor = color;
            labelThird.BackColor = color;
        }
    }
}
