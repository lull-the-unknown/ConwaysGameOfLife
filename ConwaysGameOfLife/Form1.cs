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
                    UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));
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
            UpdateImage(null);
            State = GameState.Stopped;
        }

        private void trkZoom_Scroll(object sender, EventArgs e)
        {
            lblZoom.Text = string.Format("x{0}", trkZoom.Value);
            if (game != null)
                UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));
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
                    case 15:
                        val = 99; //+59
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
           // DateTime start = DateTime.Now;
            game.CalculateNextTurn();
            game.CommitTurn();
            UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));

            //int elapsed = (DateTime.Now - start).Milliseconds;
            //Console.CursorLeft = Math.Min(elapsed, 15);
            //Console.WriteLine(elapsed);
        }
        private void UpdateImage(Image img)
        {
            if (img == null)
            {
                picOut.Image.Dispose();
                picOut.Image = null;
                return;
            }

            int zoom = trkZoom.Value;
            if (zoom > 1)
            {
                Image imgOld = img;
                img = new Bitmap(img.Width * zoom, img.Height * zoom);
                Graphics g = Graphics.FromImage(img);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(imgOld, 0, 0, img.Width, img.Height);
                imgOld.Dispose();
            }
            if (picOut.Image == null)
            {
                picOut.Image = img;
            }
            else
            {
                if (picOut.Image.Width != img.Width)
                {
                    picOut.Image.Dispose();
                    picOut.Image = img;
                }
                else
                {
                    Graphics g = picOut.CreateGraphics();
                    g.DrawImageUnscaled(img, 0, 0);
                    img.Dispose();
                }
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            panel1.Width = Math.Max(0, this.ClientSize.Width - 8 - panel1.Left);
            panel1.Height = Math.Max(0, this.ClientSize.Height - 8 - panel1.Top);
        }
    }
}
