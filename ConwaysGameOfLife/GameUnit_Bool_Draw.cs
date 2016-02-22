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
        public Image Draw(int x, int y, int width, int height)
        {
            return Draw_1(x, y, width, height);
        }

        public Image Draw_1(int x, int y, int width, int height)
        {
            if (x < 0)
                x = 0;
            if (x >= this.m_Width)
                x = (this.m_Width - 1);
            int xStop = x + width;
            if (xStop > this.m_Width)
            {
                xStop = this.m_Width;
                width = xStop - x;
            }

            if (y < 0)
                y = 0;
            if (y >= this.m_Height)
                y = (this.m_Height - 1);
            int yStop = y + height;
            if (yStop > this.m_Height)
            {
                yStop = this.m_Height;
                height = yStop - y;
            }

            Bitmap result = new Bitmap(width+2, height+2, PixelFormat.Format24bppRgb);

            // for using bitmapdata to write pixels efficiently:
            //    https://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

            BitmapData bmpData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                   ImageLockMode.WriteOnly,
                                                   result.PixelFormat);
            // Get the address of the first line.
            IntPtr ptrDataStart = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int stride = Math.Abs(bmpData.Stride);
            int dataLength = stride * result.Height;
            byte[] rgbValues = new byte[dataLength];

            // Copy the RGB values into the array. (if there were any)
            //System.Runtime.InteropServices.Marshal.Copy(ptrDataStart, rgbValues, 0, dataLength);

            Parallel.For(y, yStop, delegate (int line)
            {
                Color selectedColor;
                int pixelIndex = (line - y + 1) * stride + 3;
                for (int pixel = x; pixel < xStop; pixel++)
                {
                    selectedColor = currentBoard[pixel, line] ? ForeGround : BackGround;
                    rgbValues[pixelIndex++] = selectedColor.B;
                    rgbValues[pixelIndex++] = selectedColor.G;
                    rgbValues[pixelIndex++] = selectedColor.R;
                }
            });

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptrDataStart, dataLength);
            result.UnlockBits(bmpData);
            return result;
        }
    }
}
