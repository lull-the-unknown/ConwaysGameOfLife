using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        public enum GameState { Playing, Paused, Stopped }
        private const int BaseSpeed = 1000;

        public GameState State = GameState.Stopped;
        private IGameUnit<bool> game = null;
        private long ticks = 0L;
        private long sum1 = 0L;
        private long sum2 = 0L;
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
                btnEditBoard.Enabled = false;

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
                btnEditBoard.Enabled = false;

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
            btnEditBoard.Enabled = false;

            game = null;
            UpdateImage(null);
            State = GameState.Stopped;
        }

        private void StartNewGame()
        {
            ticks = 0L;
            sum1 = 0L;
            sum2 = 0L;
            count = 0L;
            Console.Clear();

            GameUnitDesc unitDesc = new GameUnitDesc();
            Regex reg = new Regex("\\D+");
            unitDesc.Width = int.Parse(reg.Replace(txtWidth.Text, string.Empty)) + 5;
            unitDesc.Width -= unitDesc.Width % 10;
            unitDesc.Height = int.Parse(reg.Replace(txtHeight.Text, string.Empty)) + 5;
            unitDesc.Height -= unitDesc.Height % 10;
            Console.WriteLine("Starting new game: width={0}, height={0}", unitDesc.Width, unitDesc.Height);
            game = new GameUnit_Bool(unitDesc);
            
            //UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));
        }

        private void CheckTextBoxes( object sender, EventArgs e )
        {
            TextBox txtSender = sender as TextBox;
            string text = txtSender.Text;
            if (text.IndexOf('.') >= 0)
                text = text.Substring(0, text.IndexOf('.'));
            text = (new Regex("\\D+")).Replace(text, string.Empty);
            if (text.Length < 1)
                text = "0";
            int result = int.Parse(text);
            for (int x = text.Length - 3; x > 0; x -= 3)
            {
                text = string.Format("{0},{1}", text.Substring(0, x), text.Substring(x));
            }
            txtSender.Text = text;
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
            //Console.WriteLine( "Timer tick, stopping timer" );
            //timerGameTick.Enabled = false;
            if (game == null)
                return;
            //DateTime start = DateTime.Now;
            game.Play();
            //int elapsed1 = (int)(DateTime.Now - start).TotalMilliseconds;
            //start = DateTime.Now;
        
        /**///UpdateImage(game.Draw(Color.DarkBlue, Color.MintCream));
            
            //int elapsed2 = (int)(DateTime.Now - start).TotalMilliseconds;
            //Console.WriteLine("{0}:", ticks++);
            //Console.WriteLine(elapsed1);
            //Console.Write(elapsed2);
            //Console.CursorTop -= 1;
            //Console.CursorLeft = 5;

            //sum1 += elapsed1;
            //sum2 += elapsed2;
            //count++;
            //long avg = sum1 / count;
            //Console.WriteLine("({0})", avg);
            //Console.CursorLeft = 5;
            //avg = sum2 / count;
            //Console.WriteLine("({0})", avg);
        }
        private void UpdateImage(Image img)
        {
            if (img == null)
            {
                if (picOut.Image != null)
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
