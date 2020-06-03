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
        int pictureCounter = 1;
        PictureBox pic = null;

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
                labelName = "pictureBox" + i;
                Grid.Controls[labelName].Tag = string.Empty;
                Grid.Controls[labelName].BackColor = Color.Transparent;
            }
            turnCount = 0;
        }

        private void Player_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            //pictureBox1.Tag = "X";

            if (player1 == true)
            {
                if (picture.Tag == string.Empty)
                {
                    pic = picture;
                    pic.Tag = "X";
                    timer1.Start();
                }
            }
            if (player1 == false)
            {
                if (picture.Tag == string.Empty)
                {
                    pic = picture;
                    pic.Tag = "O";
                    timer1.Start();
                }
            }
            turnCount++;
            PlaySound("click_sound");
            CheckForWin();
            CheckForDraw();
            player1 = !player1;

        }

        private void CheckForWin()
        {
            if ((pictureBox1.Tag == pictureBox2.Tag && pictureBox2.Tag == pictureBox3.Tag && pictureBox1.Tag != string.Empty) ||
                (pictureBox4.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox6.Tag && pictureBox4.Tag != string.Empty) ||
                (pictureBox7.Tag == pictureBox8.Tag && pictureBox8.Tag == pictureBox9.Tag && pictureBox7.Tag != string.Empty) ||
                (pictureBox1.Tag == pictureBox4.Tag && pictureBox4.Tag == pictureBox7.Tag && pictureBox1.Tag != string.Empty) ||
                (pictureBox2.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox8.Tag && pictureBox2.Tag != string.Empty) ||
                (pictureBox3.Tag == pictureBox6.Tag && pictureBox6.Tag == pictureBox9.Tag && pictureBox3.Tag != string.Empty) ||
                (pictureBox3.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox7.Tag && pictureBox3.Tag != string.Empty) ||
                (pictureBox1.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox9.Tag && pictureBox1.Tag != string.Empty))
            {
                GameOver();
            }
        }

        private void WinnerCellsChangeColor()
        {
            if (pictureBox1.Tag == pictureBox2.Tag && pictureBox1.Tag == pictureBox3.Tag && pictureBox1.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox1, pictureBox2, pictureBox3, Color.Lime);
            }
            else if (pictureBox4.Tag == pictureBox5.Tag && pictureBox4.Tag == pictureBox6.Tag && pictureBox4.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox4, pictureBox5, pictureBox6, Color.Lime);
            }
            else if (pictureBox7.Tag == pictureBox8.Tag && pictureBox7.Tag == pictureBox9.Tag && pictureBox7.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox7, pictureBox8, pictureBox9, Color.Lime);
            }
            else if (pictureBox1.Tag == pictureBox4.Tag && pictureBox1.Tag == pictureBox7.Tag && pictureBox1.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox1, pictureBox4, pictureBox7, Color.Lime);
            }
            else if (pictureBox2.Tag == pictureBox5.Tag && pictureBox2.Tag == pictureBox8.Tag && pictureBox2.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox2, pictureBox5, pictureBox8, Color.Lime);
            }
            else if (pictureBox3.Tag == pictureBox6.Tag && pictureBox3.Tag == pictureBox9.Tag && pictureBox3.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox3, pictureBox6, pictureBox9, Color.Lime);
            }
            else if (pictureBox1.Tag == pictureBox5.Tag && pictureBox1.Tag == pictureBox9.Tag && pictureBox1.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox1, pictureBox5, pictureBox9, Color.Lime);
            }
            else if (pictureBox3.Tag == pictureBox5.Tag && pictureBox3.Tag == pictureBox7.Tag && pictureBox3.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox3, pictureBox5, pictureBox7, Color.Lime);
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

        private void ChangeCellColors(PictureBox labelFirst, PictureBox labelSecond, PictureBox labelThird, Color color)
        {
            labelFirst.BackColor = color;
            labelSecond.BackColor = color;
            labelThird.BackColor = color;
        }

        private void Animation()
        {
            string turn;
            string pictureName;

            turn = pic.Tag.ToString();
            turn = turn.ToLower();

            pictureName = turn + "_frame_0" + pictureCounter.ToString("00");
            pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(pictureName);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureCounter++;
            if(pictureCounter > 20)
            {
                pictureCounter = 1;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Animation();
        }
    }
}
