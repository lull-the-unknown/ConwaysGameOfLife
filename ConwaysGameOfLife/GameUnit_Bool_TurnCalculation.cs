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
    public partial class GameUnit_Bool : IGameUnit
    {
        public void Play()
        {
            //DateTime start;
            //double diff1;
            //double diff2;
            //count++;

            if (m_Width < 500 && m_Height < 500)
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
            int sizeX = m_Width / count;
            int sizeY = m_Height / count;

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
            for (int x = 0; x < m_Width; x++)
            {
                for (int y = 0; y < m_Height; y++)
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
            Array.Copy(nextBoard, currentBoard, m_Width * m_Height);
        }
    }
}
