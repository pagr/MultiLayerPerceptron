using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compression
{
    public partial class SimpleTestDemo : Form
    {
        public SimpleTestDemo()
        {
            InitializeComponent();

            var patterns = new double[1, 1];
            var targets = new double[1, 1];

            patterns[0, 0] = 0;
            targets[0, 0] = 0;

            var nn = new MLP.MLP(Matrix<Double>.Build.DenseOfArray(patterns), Matrix<Double>.Build.DenseOfArray(targets), 1, 0, 1.0);
            for (int i = 0; i < 2; i++)
            {
                nn.train();
            }
            Console.Write("");
        }
    }
}
