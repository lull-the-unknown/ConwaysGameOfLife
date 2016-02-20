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
        private const int BaseSpeed = 500;

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
            trkZoom_Scroll(null, null);
            trkSpeed_Scroll(null, null);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == "Play")
            {
                btnPlay.Text = "Pause";
                btnStop.Enabled = true;
                grpGameUnit.Enabled = false;
                grpGameBoard.Enabled = false;

                State = GameState.Playing;

                if (game == null)
                {
                    game = new GameUnit(int.Parse(txtWidth_GameUnit.Text), int.Parse(txtHeight_GameUnit.Text));
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.Bottom);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.BottomLeft);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.BottomRight);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.Left);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.Right);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.Top);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.TopLeft);
                    game.RegisterNeighbor(game, ConwaysGameOfLife.Location.TopRight);
                    SetImage(game.Draw(Color.DarkBlue, Color.MintCream, trkZoom.Value));
                }

                timerGameTick.Enabled = true;
            }
            else
            {
                timerGameTick.Enabled = false;
                btnPlay.Text = "Play";
                btnStop.Enabled = true;
                grpGameUnit.Enabled = false;
                grpGameBoard.Enabled = false;

                State = GameState.Paused;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerGameTick.Enabled = false;
            btnPlay.Text = "Play";
            btnStop.Enabled = false;
            btnPlay.Focus();
            grpGameUnit.Enabled = true;
            grpGameBoard.Enabled = true;

            game = null;
            SetImage(null);
            State = GameState.Stopped;
        }

        private void trkZoom_Scroll(object sender, EventArgs e)
        {
            lblZoom.Text = string.Format("x{0}", trkZoom.Value);
        }

        private void trkSpeed_Scroll(object sender, EventArgs e)
        {
            int val = trkSpeed.Value;
            if (val > 10)
            {
                switch (val)
                {
                    case 11:
                        val = 15; //+5
                        break;
                    case 12:
                        val = 20; //+5
                        break;
                    case 13:
                        val = 30; //+10
                        break;
                    case 14:
                        val = 40; //+10
                        break;
                    default:
                        break;
                }
            }
            lblSpeed.Text = string.Format("x{0}", val);
            if (val > 0)
                timerGameTick.Interval = BaseSpeed / val;
            else
                timerGameTick.Interval = int.MaxValue;
        }

        private void timerGameTick_Tick(object sender, EventArgs e)
        {
            if (game == null)
                return;
            //DateTime start = DateTime.Now;
            game.CalculateNextTurn();
            game.CommitTurn();
            SetImage(game.Draw(Color.DarkBlue, Color.MintCream, trkZoom.Value));

            //int elapsed = (DateTime.Now - start).Milliseconds;
            //Console.CursorLeft = Math.Min(elapsed, 15);
            //Console.WriteLine(elapsed);
        }
        private void SetImage(Image img)
        {
            if (picOut.Image != null)
                picOut.Image.Dispose();
            picOut.Image = img;
        }
    }
}
