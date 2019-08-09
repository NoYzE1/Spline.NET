using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IxMilia.Dxf;
using IxMilia.Dxf.Entities;
using MathNet.Numerics.Interpolation;
using MathNet.Spatial.Euclidean;

namespace Spline.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DxfFile dxfFile = DxfFile.Load(@"D:\Test\Spline.dxf");
            IList<DxfEntity> dxfEntities = dxfFile.Entities;
            foreach (var entity in dxfEntities)
            {
                if (entity is DxfSpline)
                {
                    DxfSpline dxfSpline = entity as DxfSpline;
                    Point2D[] p = new Point2D[dxfSpline.ControlPoints.Count];
                    double[] t = new double[dxfSpline.KnotValues.Count];
                    for (int i = 0; i < p.Length; i++)
                    {
                        p[i] = new Point2D(dxfSpline.ControlPoints[i].X, dxfSpline.ControlPoints[i].Y);
                    }
                    for (int i = 0; i < t.Length; i++)
                    {
                        t[i] = dxfSpline.KnotValues[i];
                    }
                    Point2D test = new Point2D(dxfSpline.ControlPoints[0].X, dxfSpline.ControlPoints[0].Y);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.1);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.2);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.3);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.4);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.5);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.6);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.7);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.8);
                    test = NET.Spline.EvaluateSpline(p, t, dxfSpline.DegreeOfCurve, 0.9);
                    test = new Point2D(dxfSpline.ControlPoints[dxfSpline.ControlPoints.Count - 1].X, dxfSpline.ControlPoints[dxfSpline.ControlPoints.Count - 1].Y);
                }
            }
        }
    }
}
