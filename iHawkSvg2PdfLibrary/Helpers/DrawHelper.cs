﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using Svg;
using Svg.Pathing;

namespace iHawkSvg2PdfLibrary.Helpers
{
    internal static class DrawHelper
    {
        internal static void SvgGroup2Pdf(SvgGroup element, XGraphics graphics)
        {
            if (element.Display == "none") return;
            foreach (var child in element.Children)
            {
                switch (child)
                {
                    case SvgGroup svgGroup:
                        SvgGroup2Pdf(svgGroup, graphics);
                        break;
                    case SvgText svgText:
                        SvgText2Pdf(svgText, graphics);
                        break;
                    case SvgPath svgPath:
                        SvgPath2Pdf(svgPath, graphics);
                        break;
                    case SvgRectangle svgRectangle:
                        SvgRectangle2Pdf(svgRectangle, graphics);
                        break;
                    case SvgLine svgLine:
                        SvgLine2Pdf(svgLine, graphics);
                        break;
                    case SvgCircle svgCircle:
                        SvgCircle2Pdf(svgCircle, graphics);
                        break;
                    default:
                        Console.WriteLine(child);
                        break;
                }
            }
        }

        internal static void SvgText2Pdf(SvgText element, XGraphics graphics)
        {
            if (element.Display == "none") return;
            if (!string.IsNullOrWhiteSpace(element.Content))
                graphics.DrawString(element.Content, new XFont("黑体", element.FontSize), XBrushes.Black, ConvertHelper.Rectangle2XRect(element.Bounds), XStringFormats.TopLeft);
        }

        internal static void SvgPath2Pdf(SvgPath element, XGraphics graphics)
        {
            if (element.Display == "none") return;
            var path = new XGraphicsPath {FillMode = XFillMode.Winding};
            foreach (var segment in element.PathData)
            {
                switch (segment)
                {
                    case SvgMoveToSegment svgMoveToSegment:
                        Console.WriteLine($"{segment.GetType()}, start: {svgMoveToSegment.Start}, end: {svgMoveToSegment.End}");
                        path.StartFigure();
                        break;
                    case SvgCubicCurveSegment svgCubicCurveSegment:
                        Console.WriteLine(
                            $"{segment.GetType()}, start: {svgCubicCurveSegment.Start}, first control: {svgCubicCurveSegment.FirstControlPoint}, second control: {svgCubicCurveSegment.SecondControlPoint}, end: {svgCubicCurveSegment.End}");
                        path.AddBezier(ConvertHelper.Point2XPoint(svgCubicCurveSegment.Start),
                            ConvertHelper.Point2XPoint(svgCubicCurveSegment.FirstControlPoint),
                            ConvertHelper.Point2XPoint(svgCubicCurveSegment.SecondControlPoint),
                            ConvertHelper.Point2XPoint(svgCubicCurveSegment.End));
                        break;
                    case SvgLineSegment svgLineSegment:
                        Console.WriteLine($"{segment.GetType()}, start: {svgLineSegment.Start}, end: {svgLineSegment.End}");
                        path.AddLine(ConvertHelper.Point2XPoint(svgLineSegment.Start), ConvertHelper.Point2XPoint(svgLineSegment.End));
                        break;
                    case SvgClosePathSegment svgClosePathSegment:
                        Console.WriteLine($"{segment.GetType()}, start: {svgClosePathSegment.Start}, end: {svgClosePathSegment.End}");
                        path.CloseFigure();
                        break;
                    default:
                        Console.WriteLine(segment.GetType());
                        break;
                }
            }

            if (element.Fill != SvgPaintServer.None)
            {
                var brush = ConvertHelper.Fill2XBrush(element.Fill);
                graphics.DrawPath(brush, path);
            }

            if (element.Stroke != null)
            {
                var pen = ConvertHelper.Stroke2XPen(element.Stroke, element.StrokeWidth, element.StrokeLineCap, element.StrokeLineJoin);
                graphics.DrawPath(pen, path);
            }
        }

        internal static void SvgRectangle2Pdf(SvgRectangle element, XGraphics graphics)
        {
            if (element.Display == "none") return;
            if (element.Fill == SvgPaintServer.None)
            {
                var pen = ConvertHelper.Stroke2XPen(element.Stroke, element.StrokeWidth);
                graphics.DrawRectangle(pen, ConvertHelper.Rectangle2XRect(element.GetRectangle()));
            }
            else
            {
                var brush = ConvertHelper.Fill2XBrush(element.Fill);
                graphics.DrawRectangle(brush, ConvertHelper.Rectangle2XRect(element.GetRectangle()));
            }

        }

        internal static void SvgLine2Pdf(SvgLine element, XGraphics graphics)
        {
            if (element.Display == "none") return;
            var pen = ConvertHelper.Stroke2XPen(element.Stroke, element.StrokeWidth);
            graphics.DrawLine(pen, ConvertHelper.Point2XPoint(element.StartX, element.StartY), ConvertHelper.Point2XPoint(element.EndX, element.EndY));
        }

        internal static void SvgCircle2Pdf(SvgCircle element, XGraphics graphics)
        {
            if (element.Display == "none") return;
            if (element.Fill == SvgPaintServer.None)
            {
                var pen = ConvertHelper.Stroke2XPen(element.Stroke, element.StrokeWidth);
                graphics.DrawEllipse(pen, ConvertHelper.Circle2XRect(element.CenterX, element.CenterY, element.Radius));
            }
            else
            {
                var brush = ConvertHelper.Fill2XBrush(element.Fill);
                graphics.DrawEllipse(brush, ConvertHelper.Circle2XRect(element.CenterX, element.CenterY, element.Radius));
            }
        }
    }
}
