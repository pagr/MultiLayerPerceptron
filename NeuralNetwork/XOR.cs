using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;



namespace Compression
{
    public partial class XOR : Form
    {
        public XOR()
        {
            InitializeComponent();
        }

        int nondupe = 0;
        private void runButton_Click(object sender, EventArgs e)
        {
            var cycles = (int)cyclesNumeric.Value;
            var modString = " Alpha=" + alphaNumeric.Value + " Eta=" + etaNumeric.Value + " Hidden=" + hiddenNumeric.Value+" "+nondupe++;

            chart2.Series.Add("Error"+modString);
            chart1.Series.Insert(0, new System.Windows.Forms.DataVisualization.Charting.Series("11" + modString));
            chart1.Series.Insert(0, new System.Windows.Forms.DataVisualization.Charting.Series("10" + modString));
            chart1.Series.Insert(0, new System.Windows.Forms.DataVisualization.Charting.Series("01" + modString));
            chart1.Series.Insert(0, new System.Windows.Forms.DataVisualization.Charting.Series("00" + modString));
            chart2.Series.Last().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart2.Series.Last().BorderWidth = 3;
            for (int j = 0; j < 4; j++)
            {
                chart1.Series[j].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart1.Series[j].BorderWidth = 4 - (j / 2) * 2;
            }

            var patterns = DenseMatrix.OfArray(new double[,] {{0,0},{0,1},{1,0},{1,1}, { 1, 0 }, { 1, 1 } }).Transpose();
            var targets = DenseMatrix.OfArray(new double[,] {{0,1,1,0,1,0}});
            //var patterns = DenseMatrix.Build.DenseIdentity(8);
            //var targets = patterns;



            var nn = new MPL.MPL(patterns, targets, (int)hiddenNumeric.Value, (double)alphaNumeric.Value, (double)etaNumeric.Value);
            for (int i = 0; i < cycles; i++)
            {
                var error = nn.train();
                var result = nn.evaluate(patterns);
                for (int j = 0; j < 4; j++)
                    chart1.Series[j].Points.AddY(result[0, j]);
                chart2.Series.Last().Points.AddY(error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            nondupe = 0;
        }
    }

    
}
