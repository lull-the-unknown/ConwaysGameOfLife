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
        GameUnitDesc GameDesc = new GameUnitDesc();
        private IGameUnit game = null;
        private double sum_calc = 0L;
        private double sum_draw = 0L;
        private long frameCount = 0L;

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

                if (game == null)
                    StartNewGame();

                timerGameTick.Enabled = true;
                State = GameState.Playing;
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
            hScrollBar1.Enabled = false;
            vScrollBar1.Enabled = false;

            game = null;
            ClearImage();
            State = GameState.Stopped;

            Console.WriteLine("\n\n\n---Stopped---\n");
        }

        private void StartNewGame()
        {
            sum_calc = 0d;
            sum_draw = 0d;
            frameCount = 0L;

            GameDesc = new GameUnitDesc();
            Regex reg = new Regex("\\D+");
            GameDesc.Width = int.Parse(reg.Replace(txtWidth.Text, string.Empty));
            GameDesc.Height = int.Parse(reg.Replace(txtHeight.Text, string.Empty));
            Console.WriteLine("Starting new game: width={0}, height={0}", GameDesc.Width, GameDesc.Height);
            game = new GameUnit_Bool(GameDesc, Color.DarkBlue, Color.MintCream);

            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;
            hScrollBar1.Enabled = true;
            vScrollBar1.Enabled = true;
            UpdateScrollBars();

            UpdateImage();
        }

        private void CheckTextBoxes(object sender, EventArgs e)
        {
            TextBox txtSender = sender as TextBox;
            string text = txtSender.Text;
            if (text.IndexOf('.') >= 0)
                text = text.Substring(0, text.IndexOf('.'));
            text = (new Regex("\\D+")).Replace(text, string.Empty);
            if (text.Length < 2)
                text = "10";
            int val = int.Parse(text) + 5;
            val -= val % 10;
            text = val.ToString();
            for (int x = text.Length - 3; x > 0; x -= 3)
            {
                text = string.Format("{0},{1}", text.Substring(0, x), text.Substring(x));
            }
            txtSender.Text = text;
        }

        private void trkZoom_Scroll(object sender, EventArgs e)
        {
            lblZoom.Text = string.Format("x{0}", trkZoom.Value);
            UpdateScrollBars();
            if (game != null)
                UpdateImage();
        }

        private void UpdateScrollBars()
        {
            int zoom = trkZoom.Value;
            int overWidth = GameDesc.Width - picOut.Width / zoom;
            int largeChange = Math.Max(10, overWidth / 10 / zoom);
            hScrollBar1.Maximum = Math.Max(0, overWidth + largeChange + 10);
            hScrollBar1.LargeChange = largeChange;

            int overHeight = GameDesc.Height - picOut.Height / zoom;
            largeChange = Math.Max(10, overHeight / 10 / zoom);
            vScrollBar1.Maximum = Math.Max(0, overHeight + largeChange + 10);
            vScrollBar1.LargeChange = largeChange;
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
            //Console.WriteLine("Timer tick, stopping timer");
            //timerGameTick.Enabled = false;
            if (game == null)
                return;
            DateTime start = DateTime.Now;
            game.Play();
            double elapsed_calc = (DateTime.Now - start).TotalMilliseconds;

            start = DateTime.Now;
            UpdateImage();
            double elapsed_draw = (DateTime.Now - start).TotalMilliseconds;

            frameCount++;
            sum_calc += elapsed_calc;
            double avg_calc = sum_calc / frameCount;
            Console.WriteLine("Calc:{0,8:N4}ms ({1,8:N4}ms)", elapsed_calc, avg_calc);
            sum_draw += elapsed_draw;
            double avg_Draw = sum_draw / frameCount;
            Console.WriteLine("Draw:{0,8:N4}ms ({1,8:N4}ms)", elapsed_draw, avg_Draw);
            double totalTime = avg_calc + avg_Draw;
            Console.WriteLine("Avg ms/turn={0:N4}m, FPS cap={1}fps", totalTime, (int)(1000 / totalTime));
            Console.CursorTop -= 3;
        }

        private void ClearImage()
        {
            if (picOut.Image != null)
                picOut.Image.Dispose();
            picOut.Image = null;
        }

        private void UpdateImage()
        {
            int zoom = trkZoom.Value;
            Image img = game.Draw(hScrollBar1.Value, vScrollBar1.Value, picOut.Width / zoom, picOut.Height / zoom);

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
                bool widthChanged = picOut.Image.Width != img.Width;
                bool heightChanged = picOut.Image.Height != img.Height;
                if (widthChanged || heightChanged)
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
            //picOut.Width = Math.Max(0, this.ClientSize.Width - 11 - picOut.Left);
            //picOut.Height = Math.Max(0, this.ClientSize.Height - 15 - picOut.Top);
        }

        private void picOut_MouseMove(object sender, MouseEventArgs e)
        {
            int new_x = picOut.Left + e.X + 20;
            int max_x = this.ClientSize.Width - lblCellInfo.Width;
            if (new_x > max_x)
                new_x -= lblCellInfo.Width + 40;
            lblCellInfo.Left = new_x;

            int new_y = picOut.Top + e.Y + 20;
            int max_y = this.ClientSize.Height - lblCellInfo.Height;
            if (new_y > max_y)
                new_y -= lblCellInfo.Height + 40;
            lblCellInfo.Top = new_y;

            lblCellInfo.Text = string.Format("Cell Info:\nx={0}\ny={1}\nt={2}", e.X / trkZoom.Value + hScrollBar1.Value, e.Y / trkZoom.Value + vScrollBar1.Value, frameCount);
        }

        private void picOut_MouseEnter(object sender, EventArgs e)
        {
            lblCellInfo.Visible = true;
        }

        private void picOut_MouseLeave(object sender, EventArgs e)
        {
            lblCellInfo.Visible = false;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            toolTip1.SetToolTip(vScrollBar1, string.Format("top={0}", vScrollBar1.Value));
            UpdateImage();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            toolTip1.SetToolTip(hScrollBar1, string.Format("left={0}", hScrollBar1.Value));
            UpdateImage();
        }
    }
}
