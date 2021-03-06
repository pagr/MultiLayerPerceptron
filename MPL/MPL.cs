﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MLP
{
    public class MLP
    {
        Matrix<Double> w1;
        Matrix<Double> w2;

        Matrix<Double> dw1;
        Matrix<Double> dw2;

        double alpha = 0.9;
        double eta = 0.5;

        Matrix<Double> patterns;
        Matrix<Double> targets;

        public MLP(Matrix<Double> patterns, Matrix<Double> targets, int hidden, double alpha, double eta)
            : this(patterns, targets, hidden)
        {
            this.alpha = alpha;
            this.eta = eta;
        }
        public MLP(Matrix<Double> patterns, Matrix<Double> targets, int hidden)
        {
            //w1 = Matrix<Double>.Build.Random(hidden, patterns.RowCount + 1);
            //w2 = Matrix<Double>.Build.Random(targets.RowCount, w1.RowCount + 1);
            w1 = Matrix<Double>.Build.DenseIdentity(hidden, patterns.RowCount + 1);
            w2 = Matrix<Double>.Build.DenseIdentity(targets.RowCount, w1.RowCount + 1);

            w1[0, 0] = 1;
            w1[0, 1] = 1;
            w2[0, 0] = 1;
            w2[0, 1] = 1;
            dw1 = w1 * 0;
            dw2 = w2 * 0;
            this.patterns = patterns;
            this.targets = targets;
        }

        public double train()
        {
            var patternsWithBias = addBias(patterns);
            var hIn = w1 * patternsWithBias;
            var hOut = addBias(phi(hIn));
            var oIn = w2 * hOut;
            var oOut = phi(oIn);

            var deltaO = (oOut - targets).PointwiseMultiply((1 + oOut).PointwiseMultiply(1 - oOut))*0.5 ;
            var deltah = (w2.Transpose() * deltaO).PointwiseMultiply((1 + hOut).PointwiseMultiply(1 - hOut))*0.5;

            deltah = Matrix<double>.Build.DenseOfRows(deltah.ToRowArrays().Reverse().Skip(1).Reverse());//drop last row(bias)

            dw1 = (dw1 * alpha) - (deltah * addBias(patterns).Transpose() * (1 - alpha));
            dw2 = (dw2 * alpha) - (deltaO * hOut.Transpose() * (1 - alpha));

            w1 = w1 + dw1 * eta;
            w2 = w2 + dw2 * eta;

            return (oOut - targets).RowAbsoluteSums().Sum();
        }
        public Matrix<Double> evaluate(Matrix<Double> patterns)
        {
            var patternsWithBias = addBias(patterns);
            var hIn = w1 * patternsWithBias;
            var hOut = addBias(phi(hIn));
            var oIn = w2 * hOut;
            return phi(oIn);
        }


        private Matrix<Double> addBias(Matrix<Double> inMatrix)
        {
            var patternsWithBias = Matrix<double>.Build.Dense(inMatrix.RowCount + 1, inMatrix.ColumnCount);
            for (int r = 0; r < inMatrix.RowCount; r++)
                patternsWithBias.SetRow(r, inMatrix.Row(r));
            //patternsWithBias.Row(patternsWithBias.RowCount - 1).SetValues(Enumerable.Repeat(1.0, patternsWithBias.ColumnCount).ToArray());
            for (int i = 0; i < patternsWithBias.ColumnCount; i++)
                patternsWithBias[patternsWithBias.RowCount - 1, i] = 1.0;
            return patternsWithBias;
        }

        private Matrix<double> phi(Matrix<double> hin)
        {
            var phi = Matrix<double>.Build.Dense(hin.RowCount, hin.ColumnCount);
            for (int r = 0; r < hin.RowCount; r++)
                for (int c = 0; c < hin.ColumnCount; c++)
                {
                    phi[r, c] =  1/(1 + Math.Exp(-hin[r, c])) ;//SpecialFunctions.Logistic(hin[r, c]);
                }
            return phi *2-1;
        }

    }
}
