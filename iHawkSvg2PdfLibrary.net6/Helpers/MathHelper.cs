using System;
using System.Drawing;

namespace iHawkSvg2PdfLibrary.Helpers
{
    internal static class MathHelper
    {
        internal static Tuple<PointF, PointF, PointF, PointF> Quadratic2Cubic(PointF start, PointF controlPoint, PointF end)
        {
            var c1X = (start.X + 2 * controlPoint.X) / 3;
            var c1Y = (start.Y + 2 * controlPoint.Y) / 3;
            var c2X = (end.X + 2 * controlPoint.X) / 3;
            var c2Y = (end.Y + 2 * controlPoint.Y) / 3;
            return new Tuple<PointF, PointF, PointF, PointF>(start, new PointF(c1X, c1Y), new PointF(c2X, c2Y), end);
        }
    }
}
