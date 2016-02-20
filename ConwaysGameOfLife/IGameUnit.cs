using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public enum Location { Left, TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft }

    interface IGameUnit<T>
    {
        Image Draw( Color foreground, Color background );
        void CalculateNextTurn();
        void CommitTurn();
        T[] GetEdge_Left();
        T[] GetEdge_Top();
        T[] GetEdge_Right();
        T[] GetEdge_Bottom();
        T GetCorner_TopLeft();
        T GetCorner_TopRight();
        T GetCorner_BottomLeft();
        T GetCorner_BottomRight();
        void RegisterNeighbor(IGameUnit<T> neighbor, Location location);
    }
}
