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
        public Image Draw(Color foreground, Color background)
        {
            return Draw_1(foreground, background);
            //Bitmap result = new Bitmap(51, 50, PixelFormat.Format24bppRgb);
            //Graphics g = Graphics.FromImage(result);
            //Rectangle rectLeft = new Rectangle(0, 0, 25, 50);
            //Rectangle rectRight = new Rectangle(26, 0, 25, 50);

            //Image subResult;
            //DateTime start;
            //double diff1;
            //double diff2;
            //count++;

            //start = DateTime.Now;
            //subResult = Draw_1(foreground, background);
            //diff1 = (DateTime.Now - start).TotalMilliseconds;
            //sum1 += diff1;
            //g.DrawImage(subResult, rectLeft, rectLeft, GraphicsUnit.Pixel);
            //subResult.Dispose();

            //start = DateTime.Now;
            //subResult = Draw_2(foreground, background);
            //diff2 = (DateTime.Now - start).TotalMilliseconds;
            //sum2 += diff2;
            //g.DrawImage(subResult, rectRight, rectLeft, GraphicsUnit.Pixel);
            //subResult.Dispose();

            //double avg1 = sum1 / count;
            //Console.WriteLine("1:{0,8:N4}ms ({1,8:N4}ms)", diff1, avg1);
            //double avg2 = sum2 / count;
            //Console.Write("2:{0,8:N4}ms ({1,8:N4}ms)", diff2, avg2);
            //Console.WriteLine("  ({0}{1:N4}ms)", avg2 > avg1 ? "+" : "", avg2 - avg1);
            //Console.WriteLine();
            //return result;
        }

        public Image Draw_1(Color foreground, Color background)
        {
            Bitmap result = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

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

            Parallel.For(0, Height, delegate (int line)
            {
                Color selectedColor;
                int pixelIndex = line * stride;
                for (int pixel = 0; pixel < Width; pixel++)
                {
                    selectedColor = currentBoard[pixel, line] ? foreground : background;
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
