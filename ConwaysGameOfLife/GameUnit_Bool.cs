using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GameUnit_Bool : IGameUnit<bool>
    {
        private int Width;
        private int Height;
        private bool[,] currentBoard;
        private bool[,] nextBoard;
        private int[] xIndicies;
        private int[] yIndicies;

        private double sum1 = 0d;
        private double sum2 = 0d;
        private int count = 0;

        public GameUnit_Bool(GameUnitDesc desc)
        {
            Width = desc.Width;
            Height = desc.Height;
            currentBoard = new bool[Width, Height];
            nextBoard = new bool[Width, Height];

            xIndicies = new int[Width + 2];
            xIndicies[0] = Width - 1;
            for (int x = 0; x < Width; x++)
                xIndicies[x + 1] = x;
            xIndicies[Width + 1] = 0;

            yIndicies = new int[Height + 2];
            yIndicies[0] = Height - 1;
            for (int y = 0; y < Height; y++)
                yIndicies[y + 1] = y;
            yIndicies[Height + 1] = 0;

            Random rand = new Random();
            //for (int x = 0; x < Width; x++)
            //{
            //    for (int y = 0; y < Height; y++)
            //    {
            //        //prevboard[x, y] = (x % 2) == (y % 2);
            //        prevboard[x, y] = (rand.Next(10) < 3); // 30% chance cell starts alive
            //    }
            //}
            //int numGliders = Math.Max(1, Math.Min(Width, Height) / 10) + 1;
            int numGliders = Math.Max(1, Width * Height / 100) + 1;
            numGliders = rand.Next(1, numGliders);
            for (int x = 0; x < numGliders; x++)
                DrawGlider(rand.Next(0, Width - 2), rand.Next(0, Height - 2), rand.Next(0, 4));
            //DrawGlider(0, 0, 0);
        }

        private void DrawGlider(int x, int y, int orientation)
        {
            switch (orientation)
            {
                case 0:
                    currentBoard[x, y + 1] = true;
                    currentBoard[x + 1, y + 2] = true;
                    currentBoard[x + 2, y] = true;
                    currentBoard[x + 2, y + 1] = true;
                    currentBoard[x + 2, y + 2] = true;
                    break;
                case 1:
                    currentBoard[x, y + 1] = true;
                    currentBoard[x, y + 2] = true;
                    currentBoard[x + 1, y] = true;
                    currentBoard[x + 1, y + 2] = true;
                    currentBoard[x + 2, y + 2] = true;
                    break;
                case 2:
                    currentBoard[x, y] = true;
                    currentBoard[x, y + 1] = true;
                    currentBoard[x, y + 2] = true;
                    currentBoard[x + 1, y] = true;
                    currentBoard[x + 2, y + 1] = true;
                    break;
                default:
                    currentBoard[x, y] = true;
                    currentBoard[x + 1, y] = true;
                    currentBoard[x + 1, y + 2] = true;
                    currentBoard[x + 2, y] = true;
                    currentBoard[x + 2, y + 1] = true;
                    break;
            }
        }

        public Image Draw(Color foreground, Color background)
        {
            Bitmap result = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            // for using bitmapdata to write pixels efficiently:
            //    https://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx
            //BitmapData data = result.LockBits( new Rectangle(0, 0, result.Width, result.Height), 
            //                                   ImageLockMode.WriteOnly, 
            //                                   result.PixelFormat);

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    result.SetPixel(x, y, currentBoard[x, y] ? foreground : background);

            //result.UnlockBits(data);
            return result;
        }

        public void Play()
        {
            //DateTime start;
            //double diff1;
            //double diff2;
            //count++;

            if (Width < 500 && Height < 500)
            {
                //start = DateTime.Now;
                CalculateNextTurn_Whole();
                //diff1 = (DateTime.Now - start).TotalMilliseconds;
                //sum1 += diff1;
                //start = DateTime.Now;
                //CalculateNextTurn_Sub(0, 0, Width, Height);
                //diff2 = (DateTime.Now - start).TotalMilliseconds;
                //sum2 += diff2;

                //Console.WriteLine("Synchronous 1:{0,8:N4}ms ({1,8:N4}ms)", diff1, sum1 / count);
                //Console.WriteLine("Synchronous 2:{0,8:N4}ms ({1,8:N4}ms)", diff2, sum2 / count);
                //Console.WriteLine();
            }
            else
            {
                //start = DateTime.Now;
                CalculateNextTurn_Async();
                //diff1 = (DateTime.Now - start).TotalMilliseconds;
                //sum1 += diff1;
                //start = DateTime.Now;
                ////CalculateNextTurn_Async2();
                //diff2 = (DateTime.Now - start).TotalMilliseconds;
                //sum2 += diff2;

                //Console.WriteLine("Async 1:{0,8:N4}ms ({1,8:N4}ms)", diff1, sum1 / count);
                //Console.WriteLine("Async 2:{0,8:N4}ms ({1,8:N4}ms)", diff2, sum2 / count);
                //Console.WriteLine();
            }
            CommitTurn();
        }
        public void CalculateNextTurn_Async()
        {
            int count = 10;
            int sizeX = Width / count;
            int sizeY = Height / count;

            Parallel.For(0, count, delegate (int x)
            {
                Parallel.For(0, count, delegate (int y)
                {
                    CalculateNextTurn_Sub(x * sizeX, y * sizeY, sizeX, sizeY);
                });
            });
            CommitTurn();
        }
        public void CalculateNextTurn_Sub(int left, int top, int width, int height)
        {
            int xBoard;
            int xTemp;
            int yBoard;
            int y0;
            int y1;
            int y2;
            byte neighborCount;
            for (int x = 0; x < width; x++)
            {
                xBoard = left + x;
                for (int y = 0; y < height; y++)
                {
                    yBoard = top + y;
                    y0 = yIndicies[yBoard];
                    y1 = yIndicies[yBoard + 1];
                    y2 = yIndicies[yBoard + 2];
                    neighborCount = 0;

                    xTemp = xIndicies[xBoard];
                    if (currentBoard[xTemp, y0])
                        neighborCount++;
                    if (currentBoard[xTemp, y1])
                        neighborCount++;
                    if (currentBoard[xTemp, y2])
                        neighborCount++;
                    xTemp = xIndicies[xBoard + 1];
                    if (currentBoard[xTemp, y0])
                        neighborCount++;
                    //[xBoard, y1] == self
                    if (currentBoard[xTemp, y2])
                        neighborCount++;
                    xTemp = xIndicies[xBoard + 2];
                    if (currentBoard[xTemp, y0])
                        neighborCount++;
                    if (currentBoard[xTemp, y1])
                        neighborCount++;
                    if (currentBoard[xTemp, y2])
                        neighborCount++;

                    if (neighborCount == 3)
                        nextBoard[xBoard, yBoard] = true;
                    else if (neighborCount == 2 && currentBoard[xBoard, yBoard])
                        nextBoard[xBoard, yBoard] = true;
                    else
                        nextBoard[xBoard, yBoard] = false;
                }
            }
        }
        
        public void CalculateNextTurn_Whole()
        {
            int xBoard;
            int y0;
            int y1;
            int y2;
            byte neighborCount;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    neighborCount = 0;
                    y0 = yIndicies[y];
                    y1 = yIndicies[y + 1];
                    y2 = yIndicies[y + 2];
                    xBoard = xIndicies[x];
                    if (currentBoard[xBoard, y0])
                        neighborCount++;
                    if (currentBoard[xBoard, y1])
                        neighborCount++;
                    if (currentBoard[xBoard, y2])
                        neighborCount++;
                    xBoard = xIndicies[x + 1];
                    if (currentBoard[xBoard, y0])
                        neighborCount++;
                    //[xBoard, y1] == self
                    if (currentBoard[xBoard, y2])
                        neighborCount++;
                    xBoard = xIndicies[x + 2];
                    if (currentBoard[xBoard, y0])
                        neighborCount++;
                    if (currentBoard[xBoard, y1])
                        neighborCount++;
                    if (currentBoard[xBoard, y2])
                        neighborCount++;

                    if (neighborCount == 3)
                        nextBoard[x, y] = true;
                    else if (neighborCount == 2 && currentBoard[x, y])
                        nextBoard[x, y] = true;
                    else
                        nextBoard[x, y] = false;
                }
            }
        }

        public void CommitTurn()
        {
            Array.Copy(nextBoard, currentBoard, Width * Height);
        }
    }
}
