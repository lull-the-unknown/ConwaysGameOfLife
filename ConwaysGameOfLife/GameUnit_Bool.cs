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
            //        currentBoard[x, y] = (x % 2) == (y % 2);
            //        //currentBoard[x, y] = (rand.Next(10) < 3); // 30% chance cell starts alive
            //    }
            //}
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

    }
}
