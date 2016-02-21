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
        private const int BaseSpeed = 1000;

        public GameState State = GameState.Stopped;
        private IGameBoard game = null;
        private IGameUnit<bool> gameUnit = null;
        private long ticks = 0L;
        private long sum = 0L;
        private long suma = 0L;
        private long count = 0L;

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
                    StartNewGame();

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

        private void StartNewGame()
        {
            GameUnitDesc unitDesc = new GameUnitDesc();
            unitDesc.Width = int.Parse(txtWidth_GameUnit.Text);
            unitDesc.Height = int.Parse(txtHeight_GameUnit.Text);
            GameBoardDesc gameDesc = new GameBoardDesc();
            gameDesc.Width = int.Parse(txtWidth_GameBoard.Text);
            gameDesc.Height = int.Parse(txtHeight_GameBoard.Text);
            gameDesc.UnitDescriptor = unitDesc;
            game = new GameBoard(gameDesc);

            unitDesc.Width *= gameDesc.Width;
            unitDesc.Height *= gameDesc.Height;
            gameUnit = new GameUnit_Bool(unitDesc);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.Bottom);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.BottomLeft);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.BottomRight);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.Left);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.Right);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.Top);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.TopLeft);
            gameUnit.RegisterNeighbor(gameUnit, ConwaysGameOfLife.Location.TopRight);
            
            UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));

            ticks = 0L;
            sum = 0L;
            suma = 0L;
            count = 0L;
            Console.Clear();
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
            //DateTime start = DateTime.Now;
            gameUnit.CalculateNextTurn();
            gameUnit.CommitTurn();
            //int elapsed1a = (DateTime.Now - start).Milliseconds;
            UpdateImage(gameUnit.Draw(Color.DarkBlue, Color.MintCream));
            //int elapsed1 = (DateTime.Now - start).Milliseconds;
            ////Console.Write("{0}:", ticks++);
            ////Console.CursorLeft = Math.Min(elapsed / 10, 30);
            //Console.WriteLine(elapsed1a);
            //Console.Write(elapsed1);
            //Console.CursorTop -= 1;
            //Console.CursorLeft = 5;


            //start = DateTime.Now;
            //game.TakeTurn();
            //int elapsed2a = (DateTime.Now - start).Milliseconds;
            //UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));
            //int elapsed2 = (DateTime.Now - start).Milliseconds;
            ////Console.Write("{0}:", ticks++);
            ////Console.CursorLeft = Math.Min(elapsed / 10 + 30, 60);
            //Console.WriteLine(elapsed2a);
            //Console.CursorLeft = 5;
            //Console.Write(elapsed2);
            //Console.CursorTop -= 1;
            //Console.CursorLeft = 10;

            //int diff = elapsed2a - elapsed1a;
            //Console.Write("({0}{1})", diff < 0 ? "" : "+", diff);
            //suma += diff;
            //count++;
            //long avg = suma / count;
            //Console.CursorLeft += 3;
            //Console.WriteLine("({0}{1})", avg < 0 ? "" : "+", avg);
            //Console.CursorLeft = 10;

            //diff = elapsed2 - elapsed1;
            //Console.Write("({0}{1})", diff < 0 ? "" : "+", diff);
            //sum += diff;
            //avg = sum / count;
            //Console.CursorLeft += 3;
            //Console.WriteLine("({0}{1})", avg < 0 ? "" : "+", avg);
            //Console.WriteLine();
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
                GC.Collect();
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
