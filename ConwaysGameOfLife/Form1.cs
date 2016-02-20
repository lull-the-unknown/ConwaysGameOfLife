using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        public enum GameState { Playing, Paused, Stopped }
        public GameState State = GameState.Stopped;
        private GameUnit game = null;

        //public int ZoomLevel
        //{
        //    get
        //    {
        //        return trkZoom.Value * 100;
        //    }
        //}

        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //if (btnPlay.Text == "Play")
            //{
                //btnPlay.Text = "Pause";
            btnStop.Enabled = true;
            grpGameUnit.Enabled = false;
            grpGameBoard.Enabled = false;

            State = GameState.Playing;



            if (game == null)
                game = new GameUnit(int.Parse(txtWidth_GameUnit.Text), int.Parse(txtHeight_GameUnit.Text));
            else
            {
                game.CalculateNextTurn();
                game.CommitTurn();
            }
            picOut.Image = game.Draw(Color.DarkBlue, Color.MintCream, trkZoom.Value);
            //}
            //else
            //{
            //    btnPlay.Text = "Play";
            //    btnStop.Enabled = true;
            //    grpGameUnit.Enabled = false;
            //    grpGameBoard.Enabled = false;

            //    State = GameState.Paused;
            //}
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnPlay.Text = "Play";
            btnStop.Enabled = false;
            btnPlay.Focus();
            grpGameUnit.Enabled = true;
            grpGameBoard.Enabled = true;

            game = null;
            picOut.Image = null;
            State = GameState.Stopped;
        }

        private void trkZoom_Scroll(object sender, EventArgs e)
        {
            lblZoom.Text = string.Format("x{0}", trkZoom.Value);
        }
    }
}
