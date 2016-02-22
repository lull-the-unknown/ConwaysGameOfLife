using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public interface IGameUnit
    {
        Image Draw( int x, int y, int width, int height );
        void Play();
    }

    public class GameUnitDesc
    {
        public int Width;
        public int Height;
    }
}
