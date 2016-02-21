using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    interface IGameBoard
    {
        void TakeTurn();
        Image Draw(Color foreground, Color background);
    }

    public class GameBoardDesc
    {
        public int Width;
        public int Height;
        public GameUnitDesc UnitDescriptor;
    }
}
