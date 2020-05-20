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
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            //label1.Text = "X";

            if (player1 == true)
            {
                label.Text = "X";
                player1 = false;
            }
            else
            {
                label.Text = "O";
                player1 = true;
            }
        }
    }
}
