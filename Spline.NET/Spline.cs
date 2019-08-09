using System;
using MathNet.Spatial.Euclidean;

namespace Spline.NET
{
    public static class Spline
    {
        /// <summary>
        /// De Boor Recursion Algorithm
        /// </summary>
        /// <param name="i">index</param>
        /// <param name="p">degree</param>
        /// <param name="t">knot vector</param>
        /// <param name="x">variable</param>
        /// <returns>Result</returns>
        public static double B(int i, int p, double[] t, double x)
        {
            if (p == 0)
            {
                if (t[i] <= x && x < t[i + 1])
                {
                    return 1.0;
                }
                else
                {
                    return 0.0;
                }
            }
            else
            {
                double t1;
                double t2;
                if (t[i + p] - t[i] == 0)
                {
                    t1 = 0;
                }
                else
                {
                    t1 = (x - t[i]) / (t[i + p] - t[i]);
                }
                if (t[i + p + 1] - t[i + 1] == 0)
                {
                    t2 = 0;
                }
                else
                {
                    t2 = (t[i + p + 1] - x) / (t[i + p + 1] - t[i + 1]);
                }
                return t1 * B(i, p - 1, t, x) + t2 * B(i + 1, p - 1, t, x);
            }
        }

        /// <summary>
        /// Evaluate Spline at x
        /// </summary>
        /// <param name="P">Control Points</param>
        /// <param name="t">Knot Values</param>
        /// <param name="p">Degree of Spline</param>
        /// <param name="x">Evaluated at this parameter</param>
        /// <returns>Evaluated Point</returns>
        public static Point2D EvaluateSpline(Point2D[] P, double[] t, int p, double x)
        {
            double n = t.Length;
            double[] cx = new double[P.Length];
            double[] cy = new double[P.Length];
            double xt = 0.0;
            double yt = 0.0;
            for (int i = 0; i < P.Length; i++)
            {
                cx[i] = P[i].X;
                cy[i] = P[i].Y;
            }
            for (int i = 0; i <= n - p - 2; i++)
            {
                xt += cx[i] * B(i, p, t, x);
                yt += cy[i] * B(i, p, t, x);
            }
            return new Point2D(xt, yt);
        }
    }
}
