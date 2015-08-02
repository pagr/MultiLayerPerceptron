using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Compression
{
    public partial class Separation : Form
    {
        public Separation()
        {
            InitializeComponent();
        }

        MLP.MLP nn;
        private void runButton_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            chart2.Series.Add("Error");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            var patternsTmp = redPoints.Select(p => new Double[] { (p.X / (double)pictureBox1.Width) * 2 - 1, (p.Y / (double)pictureBox1.Height) * 2 - 1 }).Concat(bluePoints.Select(p => new Double[] { (p.X / (double)pictureBox1.Width) * 2 - 1, (p.Y / (double)pictureBox1.Height) * 2 - 1 })).ToArray();
            var targetsTmp = redPoints.Select(p => -1.0).Concat(bluePoints.Select(p => 1.0)).ToArray();
            var patterns = new double[2, patternsTmp.Length];
            var targets = new double[1, patternsTmp.Length];
            for (int i = 0; i < patternsTmp.Length; i++)
            {
                patterns[0, i] = patternsTmp[i][0];
                patterns[1, i] = patternsTmp[i][1];
                targets[0, i] = targetsTmp[i];
            }
            var tmp = new { Cool = "", Stuff = "" };
            
            nn = new MLP.MLP(Matrix<Double>.Build.DenseOfArray(patterns), Matrix<Double>.Build.DenseOfArray(targets), (int)hiddenNumeric.Value, (double)alphaNumeric.Value, (double)etaNumeric.Value);

            for (int cycle = 0; cycle < (int)cyclesNumeric.Value; cycle++)
            {
                chart2.Series[0].Points.AddY(nn.train());
                if (cycle % 100 == 0)
                {
                    drawImage(0.1);
                    //pictureBox1.Refresh();
                    Refresh();
                }
            }
            drawImage(1);

        }

        List<Point> redPoints = new List<Point>();
        List<Point> bluePoints = new List<Point>();
        private void addPoint(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
                redPoints.Add(new Point(x, y));
            else
                bluePoints.Add(new Point(x, y));

            drawImage(0.1);
        }

        private void drawImage(double scale = 1)
        {
            var bmp = new Bitmap((int)(pictureBox1.Width * scale), (int)(pictureBox1.Height * scale));
            Rectangle rect = new Rectangle(0, 0, bmp.Width , bmp.Height);

            BitmapData bmpData =
               bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
               bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int counter = 2; counter < rgbValues.Length; counter += 1)
                rgbValues[counter] = 255;
            if (nn != null)
            {
                Parallel.For(0, bmpData.Width, x =>
                 {
                    //for (int x = 0; x < bmpData.Width; x++)
                    for (int y = 0; y < bmpData.Height; y++)
                     {
                         var mat = Matrix.Build.DenseOfArray(new double[,] { { ((x / (double)bmpData.Width) * 2 - 1) }, { ((y / (double)bmpData.Height) * 2 - 1) } });
                         if (nn.evaluate(mat)[0, 0] < 0)
                         {

                             rgbValues[x * 4 + y * bmpData.Stride] = (byte)(-nn.evaluate(mat)[0, 0] * 255);
                             rgbValues[x * 4 + 1 + y * bmpData.Stride] = 0;
                             rgbValues[x * 4 + 2 + y * bmpData.Stride] = 0;
                         }
                         else
                         {
                             rgbValues[x * 4 + y * bmpData.Stride] = 0;
                             rgbValues[x * 4 + 1 + y * bmpData.Stride] = 0;
                             rgbValues[x * 4 + 2 + y * bmpData.Stride] = (byte)(nn.evaluate(mat)[0, 0] * 127);
                         }
                     }
                 });
            }
            foreach (var point in redPoints)
                for (var dx = -5; dx < 5; dx++)
                    for (var dy = -5; dy < 5; dy++)
                    {
                        rgbValues[(((int)((point.X + dx) * scale)) * 4 + ((int)((point.Y + dy) * scale)) * bmpData.Stride)] = 255;
                        rgbValues[(((int)((point.X + dx) * scale)) * 4 + 1 + ((int)((point.Y + dy) * scale)) * bmpData.Stride)] = 127;
                        rgbValues[(((int)((point.X + dx) * scale)) * 4 + 2 + ((int)((point.Y + dy) * scale)) * bmpData.Stride)] = 127;
                    }
            foreach (var point in bluePoints)
                for (var dx = -5; dx < 5; dx++)
                    for (var dy = -5; dy < 5; dy++)
                    {
                        rgbValues[(((int)((point.X + dx) * scale)) * 4 + ((int)((point.Y + dy) * scale)) * bmpData.Stride)] = 127;
                        rgbValues[(((int)((point.X + dx) * scale)) * 4 + 1 + ((int)((point.Y + dy) * scale)) * bmpData.Stride)] = 127;
                        rgbValues[(((int)((point.X + dx) * scale)) * 4 + 2 + ((int)((point.Y + dy) * scale)) * bmpData.Stride)] = 255;
                    }



            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            bmp.UnlockBits(bmpData);

            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //Size newSize = new Size(pictureBox1.Width, pictureBox1.Height);
            //Bitmap newImage = new Bitmap(bmp, newSize);

            pictureBox1.Image = bmp;// newImage;
            pictureBox1.Invalidate();
        }


        private void pictureBox1_SizeChanged(object sender, EventArgs e) => drawImage();

        private void clear(object sender, EventArgs e)
        {
            nn = null;
            redPoints.Clear();
            bluePoints.Clear();
            drawImage();
        }
    }
}
