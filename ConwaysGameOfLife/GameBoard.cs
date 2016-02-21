using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class GameBoard : IGameBoard
    {
        private IGameUnit<bool>[,] units;
        private int Width;
        private int Height;
        private int UnitWidth;
        private int UnitHeight;

        public GameBoard(GameBoardDesc desc)
        {
            Width = desc.Width;
            Height = desc.Height;
            UnitWidth = desc.UnitDescriptor.Width;
            UnitHeight = desc.UnitDescriptor.Height;

            units = new IGameUnit<bool>[Width, Height];
            Random rand = new Random();
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    units[x, y] = new GameUnit_Bool(desc.UnitDescriptor, rand);


            int max_x = Width + 1;
            int max_y = Height + 1;
            int iTop = Height - 1;
            int iRight = Width - 1;

            int[] xIndicies = new int[Width + 2];
            for (int x = 1; x < max_x; x++)
                xIndicies[x] = x - 1;
            xIndicies[0] = iRight;
            xIndicies[max_x] = 0;

            int[] yIndicies = new int[Height + 2];
            for (int y = 1; y < max_y; y++)
                yIndicies[y] = y - 1;
            yIndicies[0] = iTop;
            yIndicies[max_y] = 0;

            int xLeft, xCenter, xRight;
            int yTop, yLevel, yBottom;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    xLeft = xIndicies[x];
                    xCenter = xIndicies[x + 1];
                    xRight = xIndicies[x + 2];
                    yTop = yIndicies[y];
                    yLevel = yIndicies[y + 1];
                    yBottom = yIndicies[y + 2];

                    units[x, y].RegisterNeighbor(units[xLeft, yTop], Location.TopLeft);
                    units[x, y].RegisterNeighbor(units[xLeft, yLevel], Location.Left);
                    units[x, y].RegisterNeighbor(units[xLeft, yBottom], Location.BottomLeft);
                    units[x, y].RegisterNeighbor(units[xCenter, yTop], Location.Top);
                    units[x, y].RegisterNeighbor(units[xCenter, yBottom], Location.Bottom);
                    units[x, y].RegisterNeighbor(units[xRight, yTop], Location.TopRight);
                    units[x, y].RegisterNeighbor(units[xRight, yLevel], Location.Right);
                    units[x, y].RegisterNeighbor(units[xRight, yBottom], Location.BottomRight);
                }
                //units[x, 0].RegisterNeighbor(units[x - 1, iTop], Location.TopLeft);
                //units[x, 0].RegisterNeighbor(units[x - 1, 0], Location.Left);
                //units[x, 0].RegisterNeighbor(units[x - 1, 1], Location.BottomLeft);
                //units[x, 0].RegisterNeighbor(units[x, iTop], Location.Top);
                //units[x, 0].RegisterNeighbor(units[x, 1], Location.Bottom);
                //units[x, 0].RegisterNeighbor(units[x + 1, iTop], Location.TopRight);
                //units[x, 0].RegisterNeighbor(units[x + 1, 0], Location.Right);
                //units[x, 0].RegisterNeighbor(units[x + 1, 1], Location.BottomRight);

                //units[x, iTop].RegisterNeighbor(units[x - 1, iTop - 1], Location.TopLeft);
                //units[x, iTop].RegisterNeighbor(units[x - 1, iTop], Location.Left);
                //units[x, iTop].RegisterNeighbor(units[x - 1, 0], Location.BottomLeft);
                //units[x, iTop].RegisterNeighbor(units[x, iTop - 1], Location.Top);
                //units[x, iTop].RegisterNeighbor(units[x, 0], Location.Bottom);
                //units[x, iTop].RegisterNeighbor(units[x + 1, iTop - 1], Location.TopRight);
                //units[x, iTop].RegisterNeighbor(units[x + 1, iTop], Location.Right);
                //units[x, iTop].RegisterNeighbor(units[x + 1, 0], Location.BottomRight);
            }
            //for (int y = 1; y < maxy; y++)
            //{
            //    units[0, y].RegisterNeighbor(units[iRight, y - 1], Location.TopLeft);
            //    units[0, y].RegisterNeighbor(units[iRight, y], Location.Left);
            //    units[0, y].RegisterNeighbor(units[iRight, y + 1], Location.BottomLeft);
            //    units[0, y].RegisterNeighbor(units[0, y - 1], Location.Top);
            //    units[0, y].RegisterNeighbor(units[0, y + 1], Location.Bottom);
            //    units[0, y].RegisterNeighbor(units[1, y - 1], Location.TopRight);
            //    units[0, y].RegisterNeighbor(units[1, y], Location.Right);
            //    units[0, y].RegisterNeighbor(units[1, y + 1], Location.BottomRight);

            //    units[iRight, y].RegisterNeighbor(units[iRight - 1, y - 1], Location.TopLeft);
            //    units[iRight, y].RegisterNeighbor(units[iRight - 1, y], Location.Left);
            //    units[iRight, y].RegisterNeighbor(units[iRight - 1, y + 1], Location.BottomLeft);
            //    units[iRight, y].RegisterNeighbor(units[iRight, y - 1], Location.Top);
            //    units[iRight, y].RegisterNeighbor(units[iRight, y + 1], Location.Bottom);
            //    units[iRight, y].RegisterNeighbor(units[0, y - 1], Location.TopRight);
            //    units[iRight, y].RegisterNeighbor(units[0, y], Location.Right);
            //    units[iRight, y].RegisterNeighbor(units[0, y + 1], Location.BottomRight);
            //}
            //units[0, 0].RegisterNeighbor(units[iRight, iTop], Location.TopLeft);
            //units[0, 0].RegisterNeighbor(units[iRight, 0], Location.Left);
            //units[0, 0].RegisterNeighbor(units[iRight, 1], Location.BottomLeft);
            //units[0, 0].RegisterNeighbor(units[0, iTop], Location.Top);
            //units[0, 0].RegisterNeighbor(units[0, 1], Location.Bottom);
            //units[0, 0].RegisterNeighbor(units[0 + 1, iTop], Location.TopRight);
            //units[0, 0].RegisterNeighbor(units[0 + 1, 0], Location.Right);
            //units[0, 0].RegisterNeighbor(units[0 + 1, 1], Location.BottomRight);


            //units[0, iTop].RegisterNeighbor(units[iRight, y - 1], Location.TopLeft);
            //units[0, iTop].RegisterNeighbor(units[iRight, y], Location.Left);
            //units[0, iTop].RegisterNeighbor(units[iRight, y + 1], Location.BottomLeft);
            //units[0, iTop].RegisterNeighbor(units[x, y - 1], Location.Top);
            //units[0, iTop].RegisterNeighbor(units[x, y + 1], Location.Bottom);
            //units[0, iTop].RegisterNeighbor(units[x + 1, y - 1], Location.TopRight);
            //units[0, iTop].RegisterNeighbor(units[x + 1, y], Location.Right);
            //units[0, iTop].RegisterNeighbor(units[x + 1, y + 1], Location.BottomRight);

            //units[iRight, 0].RegisterNeighbor(units[iRight - 1, iTop], Location.TopLeft);
            //units[iRight, 0].RegisterNeighbor(units[iRight - 1, 0], Location.Left);
            //units[iRight, 0].RegisterNeighbor(units[iRight - 1, 1], Location.BottomLeft);
            //units[iRight, 0].RegisterNeighbor(units[iRight, iTop], Location.Top);
            //units[iRight, 0].RegisterNeighbor(units[iRight, 1], Location.Bottom);
            //units[iRight, 0].RegisterNeighbor(units[0, iTop], Location.TopRight);
            //units[iRight, 0].RegisterNeighbor(units[0, 0], Location.Right);
            //units[iRight, 0].RegisterNeighbor(units[0, 1], Location.BottomRight);

            //units[iRight, iTop].RegisterNeighbor(units[iRight - 1, y - 1], Location.TopLeft);
            //units[iRight, iTop].RegisterNeighbor(units[iRight - 1, y], Location.Left);
            //units[iRight, iTop].RegisterNeighbor(units[iRight - 1, y + 1], Location.BottomLeft);
            //units[iRight, iTop].RegisterNeighbor(units[iRight, y - 1], Location.Top);
            //units[iRight, iTop].RegisterNeighbor(units[iRight, y + 1], Location.Bottom);
            //units[iRight, iTop].RegisterNeighbor(units[0, y - 1], Location.TopRight);
            //units[iRight, iTop].RegisterNeighbor(units[0, y], Location.Right);
            //units[iRight, iTop].RegisterNeighbor(units[0, y + 1], Location.BottomRight);
        }

        public void TakeTurn()
        {
            //DateTime start = DateTime.Now;
            TakeTurn_Sync();
            //int elapsed = (DateTime.Now - start).Milliseconds;
            //Console.CursorLeft = Math.Min(elapsed / 10, 50);
            //Console.WriteLine(elapsed);
        }

        public void TakeTurn_Sync()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    units[x, y].CalculateNextTurn();
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    units[x, y].CommitTurn();
        }

        public Image Draw(Color foreground, Color background)
        {
            Bitmap result = new Bitmap(Width * UnitWidth, Height * UnitHeight);
            Graphics g = Graphics.FromImage(result);
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    g.DrawImageUnscaled(units[x, y].Draw(foreground, background), x * UnitWidth, y * UnitHeight);
            return result;
        }
    }
}
