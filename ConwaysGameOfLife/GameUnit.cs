using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class GameUnit : IGameUnit<bool>
    {
        private int Width;
        private int Height;
        private bool[,] prevboard;
        private bool[,] nextboard;

        private delegate bool[] NeighborsEdge();
        private delegate bool NeighborsCorner();
        private NeighborsEdge Neighbor_Left;
        private NeighborsEdge Neighbor_Top;
        private NeighborsEdge Neighbor_Right;
        private NeighborsEdge Neighbor_Bottom;
        private NeighborsCorner Neighbor_TopLeft;
        private NeighborsCorner Neighbor_TopRight;
        private NeighborsCorner Neighbor_BottomLeft;
        private NeighborsCorner Neighbor_BottomRight;
        private bool[] NoNeighborsEdgeLR() { return new bool[Height]; }
        private bool[] NoNeighborsEdgeTB() { return new bool[Width]; }
        private bool NoNeighborsCorner() { return false; }

        public GameUnit(int width, int height)
        {
            Width = width;
            Height = height;
            prevboard = new bool[width, height];
            nextboard = new bool[width, height];

            Random rand = new Random();
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    prevboard[x, y] = (x % 2) == (y % 2);
            //prevboard[x, y] = (rand.Next(10) < 3); // 30% chance cell starts alive

            Neighbor_Left = NoNeighborsEdgeLR;
            Neighbor_Top = NoNeighborsEdgeTB;
            Neighbor_Right = NoNeighborsEdgeLR;
            Neighbor_Bottom = NoNeighborsEdgeTB;
            Neighbor_TopLeft = NoNeighborsCorner;
            Neighbor_TopRight = NoNeighborsCorner;
            Neighbor_BottomLeft = NoNeighborsCorner;
            Neighbor_BottomRight = NoNeighborsCorner;
        }

        public Image Draw(Color foreground, Color background, int zoomFactor)
        {
            Bitmap result = new Bitmap(Width * zoomFactor, Height * zoomFactor, PixelFormat.Format32bppArgb);

            // for using bitmapdata to write pixels efficiently:
            //    https://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx
            //BitmapData data = result.LockBits( new Rectangle(0, 0, result.Width, result.Height), 
            //                                   ImageLockMode.WriteOnly, 
            //                                   result.PixelFormat);

            Color selected;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    selected = prevboard[x, y] ? foreground : background;
                    for (int px = 0, pixelx = x * zoomFactor; px < zoomFactor; px++, pixelx++)
                        for (int py = 0, pixely = y * zoomFactor; py < zoomFactor; py++, pixely++)
                            result.SetPixel(pixelx, pixely, selected);
                }
            }

            //result.UnlockBits(data);
            return result;
        }

        public void RegisterNeighbor(Location edge, IGameUnit<bool> neighbor)
        {
            switch (edge)
            {
                case Location.Left:
                    Neighbor_Left = neighbor.GetEdge_Right;
                    break;
                case Location.Top:
                    Neighbor_Top = neighbor.GetEdge_Bottom;
                    break;
                case Location.Right:
                    Neighbor_Right = neighbor.GetEdge_Left;
                    break;
                case Location.Bottom:
                    Neighbor_Bottom = neighbor.GetEdge_Top;
                    break;
                case Location.TopLeft:
                    Neighbor_TopLeft = neighbor.GetCorner_BottomRight;
                    break;
                case Location.TopRight:
                    Neighbor_TopRight = neighbor.GetCorner_BottomLeft;
                    break;
                case Location.BottomRight:
                    Neighbor_BottomRight = neighbor.GetCorner_TopLeft;
                    break;
                case Location.BottomLeft:
                    Neighbor_BottomLeft = neighbor.GetCorner_TopRight;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool[] GetEdge_Left()
        {
            bool[] result = new bool[Height];
            for (int y = 0; y < Height; y++)
                result[y] = prevboard[1, y];
            return result;
        }

        public bool[] GetEdge_Top()
        {
            bool[] result = new bool[Width];
            for (int x = 0; x < Width; x++)
                result[x] = prevboard[x, 1];
            return result;
        }

        public bool[] GetEdge_Right()
        {
            bool[] result = new bool[Height];
            for (int y = 0; y < Height; y++)
                result[y] = prevboard[Width, y];
            return result;
        }

        public bool[] GetEdge_Bottom()
        {
            bool[] result = new bool[Width];
            for (int x = 0; x < Width; x++)
                result[x] = prevboard[x, Height];
            return result;
        }

        public bool GetCorner_TopLeft()
        {
            return prevboard[1, 1];
        }

        public bool GetCorner_TopRight()
        {
            return prevboard[Width, 1];
        }

        public bool GetCorner_BottomLeft()
        {
            return prevboard[1, Height];
        }

        public bool GetCorner_BottomRight()
        {
            return prevboard[Width, Height];
        }

        public void CalculateNextTurn()
        {
            byte[,] neighbors = new byte[Width + 2, Height + 2];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (prevboard[x, y] == false)
                        continue;
                    for (int nx = 0; nx < 3; nx++)
                        for (int ny = 0; ny < 3; ny++)
                            neighbors[x + nx, y + ny]++; //Note: x in prevboard is == to (x-1) in neighbors because neighbors has extra row and column at the beginning
                }
            }
            bool[] neighborEdge = Neighbor_Top();
            for (int x = 0; x < Width; x++)
            {
                if (neighborEdge[x] == false)
                    continue;
                for (int nx = 0; nx < 3; nx++)
                    neighbors[x + nx, 1]++;
            }
            neighborEdge = Neighbor_Bottom();
            for (int x = 0; x < Width; x++)
            {
                if (neighborEdge[x] == false)
                    continue;
                for (int nx = 0; nx < 3; nx++)
                    neighbors[x + nx, Height + 1]++;
            }
            neighborEdge = Neighbor_Left();
            for (int y = 0; y < Height; y++)
            {
                if (neighborEdge[y] == false)
                    continue;
                for (int ny = 0; ny < 3; ny++)
                    neighbors[1, y + ny]++;
            }
            neighborEdge = Neighbor_Right();
            for (int y = 0; y < Height; y++)
            {
                if (neighborEdge[y] == false)
                    continue;
                for (int ny = 0; ny < 3; ny++)
                    neighbors[Width + 1, y + ny]++;
            }
            if (Neighbor_TopLeft())
                neighbors[1, 1]++;
            if (Neighbor_TopRight())
                neighbors[Width + 1, 1]++;
            if (Neighbor_BottomLeft())
                neighbors[1, Height + 1]++;
            if (Neighbor_BottomRight())
                neighbors[Width + 1, Height + 1]++;

            byte neighborCount;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    neighborCount = neighbors[x + 1, y + 1];
                    if (neighborCount == 3)
                        nextboard[x, y] = true;
                    else if ( (neighborCount == 4) && prevboard[x,y])
                        nextboard[x, y] = true;
                    else
                        nextboard[x, y] = false;
                }
            }
        }

        public void CommitTurn()
        {
            Array.Copy(nextboard, prevboard, Width * Height);
        }
    }
}
