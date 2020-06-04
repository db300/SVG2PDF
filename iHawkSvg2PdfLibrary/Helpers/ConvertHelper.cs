﻿using System;
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

        internal static XPen Stroke2XPen(SvgColourServer stroke, SvgUnit strokeWidth)
        {
            return stroke != null ? new XPen(Color2XColor(stroke), strokeWidth.Value) : XPens.Black;
        }

        internal static XBrush Fill2XBrush(SvgColourServer fill)
        {
            return fill != null ? new XSolidBrush(Color2XColor(fill)) : XBrushes.Black;
        }

        internal static XColor Color2XColor(SvgColourServer color)
        {
            return XColor.FromArgb(color.Colour.ToArgb());
        }
    }
}