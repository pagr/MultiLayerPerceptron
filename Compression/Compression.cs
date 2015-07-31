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
    public partial class Compression : Form
    {
        public Compression()
        {
            InitializeComponent();
        }

        Matrix<Double> patterns = DenseMatrix.Build.DenseIdentity(8)*2-1;
        Matrix<Double> targets = DenseMatrix.Build.DenseIdentity(8) * 2 - 1;

        int nondupe = 0;
        private void runButton_Click(object sender, EventArgs e)
        {
            int cycles = prepareCharts();

            var nn = new MLP.MLP(patterns, targets, (int)hiddenNumeric.Value, (double)alphaNumeric.Value, (double)etaNumeric.Value);
            for (int i = 0; i < cycles; i++)
                chart2.Series.Last().Points.AddY(nn.train());


            var result = nn.evaluate(patterns);

            setLabelText(result);

        }

        private int prepareCharts()
        {
            var cycles = (int)cyclesNumeric.Value;
            var modString = " Alpha=" + alphaNumeric.Value + " Eta=" + etaNumeric.Value + " Hidden=" + hiddenNumeric.Value + " " + nondupe++;

            chart2.Series.Add("Error Raw" + modString);
            chart2.Series.Add("Error" + modString);

            chart2.Series.Last().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart2.Series.Last().BorderWidth = 3;
            chart2.Series.Reverse().Skip(1).First().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart2.Series.Reverse().Skip(1).First().BorderWidth = 3;
            return cycles;
        }

        private void setLabelText(Matrix<double> result)
        {
            outRawLabel.Text = "";
            outProcessedLabel.Text = "";
            for (var r = 0; r < result.RowCount; r++)
            {
                for (var c = 0; c < result.ColumnCount; c++)
                {
                    outRawLabel.Text += String.Format("{0,-10:F} ", result[r, c]);
                    outProcessedLabel.Text += String.Format("{0,-4:F} ", ((result[r, c] > 0) ? "X" : "O"));
                }
                outRawLabel.Text += "\n";
                outProcessedLabel.Text += "\n";
            }
        }

        private void clear(object sender, EventArgs e)
        {
            outRawLabel.Text = "";
            outProcessedLabel.Text = "";
            chart2.Series.Clear();
            nondupe = 0;
        }

        private void autoOptimize(object sender, EventArgs e)
        {
            var hidden = 3;
            var minError = Double.MaxValue;
            Parallel.ForEach(new double[] { 0.01, 0.05, 0.1, 0.3, 0.5, 0.7, 0.9, 0.95, 0.96, 0.97, 0.98, 0.99, 1 }, alpha =>
            {
                foreach (var eta in new double[] { 0.01, 0.05, 0.1, 0.3, 0.5, 0.7, 0.9, 0.95, 0.96, 0.97, 0.98, 0.99, 1 })
                {
                    for (int j = 0; j < 10; j++)
                    {
                        var nn = new MLP.MLP(patterns, targets, hidden, alpha, eta);
                        var error = 0.0;
                        for (int i = 0; i < 10000; i++)
                            error = nn.train();

                        if (error < minError)
                        {
                            Console.WriteLine("Alpha =" + alpha + " eta=" + eta + " error=" + error);
                            minError = error;
                        }
                    }
                }
            });
            Console.WriteLine("Done");
        }

    }
}
