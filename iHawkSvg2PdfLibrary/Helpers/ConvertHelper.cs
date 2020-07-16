using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using Svg;

namespace iHawkSvg2PdfLibrary.Helpers
{
    internal static class ConvertHelper
    {
        internal static XPoint Point2XPoint(System.Drawing.PointF point)
        {
            return new XPoint(point.X, point.Y);
        }

        internal static XPoint Point2XPoint(SvgUnit x, SvgUnit y)
        {
            return new XPoint(x, y);
        }

        internal static XSize Size2XSize(System.Drawing.SizeF size)
        {
            return new XSize(size.Width, size.Height);
        }

        internal static XRect Rectangle2XRect(System.Drawing.RectangleF rectangle)
        {
            return new XRect(Point2XPoint(rectangle.Location), Size2XSize(rectangle.Size));
        }

        internal static XRect Circle2XRect(SvgUnit centerX, SvgUnit centerY, SvgUnit radius)
        {
            return new XRect(centerX.Value - radius.Value, centerY.Value - radius.Value, 2 * radius.Value, 2 * radius.Value);
        }

        internal static XPen Stroke2XPen(SvgPaintServer stroke, SvgUnit strokeWidth)
        {
            var pen = stroke is SvgColourServer stroke1 ? new XPen(Color2XColor(stroke1), strokeWidth.Value) : new XPen(XColors.Black, strokeWidth.Value);
            return pen;
        }

        internal static XPen Stroke2XPen(SvgPaintServer stroke, SvgUnit strokeWidth, SvgStrokeLineCap strokeLineCap, SvgStrokeLineJoin strokeLineJoin)
        {
            var pen = stroke is SvgColourServer stroke1 ? new XPen(Color2XColor(stroke1), strokeWidth.Value) : new XPen(XColors.Black, strokeWidth.Value);
            switch (strokeLineCap)
            {
                case SvgStrokeLineCap.Inherit:
                    pen.LineCap = XLineCap.Flat;
                    break;
                case SvgStrokeLineCap.Butt:
                    break;
                case SvgStrokeLineCap.Round:
                    pen.LineCap = XLineCap.Round;
                    break;
                case SvgStrokeLineCap.Square:
                    pen.LineCap = XLineCap.Square;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (strokeLineJoin)
            {
                case SvgStrokeLineJoin.Inherit:
                    break;
                case SvgStrokeLineJoin.Miter:
                    pen.LineJoin = XLineJoin.Miter;
                    break;
                case SvgStrokeLineJoin.Round:
                    pen.LineJoin = XLineJoin.Round;
                    break;
                case SvgStrokeLineJoin.Bevel:
                    pen.LineJoin = XLineJoin.Bevel;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(strokeLineJoin), strokeLineJoin, null);
            }

            return pen;
        }

        internal static XBrush Fill2XBrush(SvgPaintServer fill)
        {
            return fill is SvgColourServer fill1 ? new XSolidBrush(Color2XColor(fill1)) : XBrushes.Black;
        }

        internal static XColor Color2XColor(SvgColourServer color)
        {
            return color != null ? XColor.FromArgb(color.Colour.ToArgb()) : XColors.Black;
        }
    }
}
