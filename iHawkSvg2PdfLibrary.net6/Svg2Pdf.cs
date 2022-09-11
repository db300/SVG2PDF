using System;
using System.Collections.Generic;
using iHawkSvg2PdfLibrary.Helpers;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Svg;

namespace iHawkSvg2PdfLibrary
{
    public static class Svg2Pdf
    {
        public static void Convert(string svgFileName, string pdfFileName)
        {
            var pdfDoc = new PdfDocument();
            AddSvg(svgFileName, pdfDoc);
            pdfDoc.Save(pdfFileName);
            pdfDoc.Close();
        }

        public static void Convert(List<string> svgFileNames, string pdfFileName)
        {
            var pdfDoc = new PdfDocument();
            foreach (var svgFileName in svgFileNames) AddSvg(svgFileName, pdfDoc);
            pdfDoc.Save(pdfFileName);
            pdfDoc.Close();
        }

        private static void AddSvg(string svgFileName, PdfDocument pdfDoc)
        {
            var svgDoc = SvgDocument.Open(svgFileName);
            var pdfPage = pdfDoc.AddPage();
            pdfPage.Size = PageSize.A4;
            pdfPage.Orientation = PageOrientation.Portrait;
            using (var graphics = XGraphics.FromPdfPage(pdfPage))
            {
                graphics.SmoothingMode = XSmoothingMode.HighQuality;
                foreach (var child in svgDoc.Children)
                {
                    switch (child)
                    {
                        case SvgGroup svgGroup:
                            DrawHelper.SvgGroup2Pdf(svgGroup, graphics);
                            break;
                        case SvgText svgText:
                            DrawHelper.SvgText2Pdf(svgText, graphics);
                            break;
                        case SvgPath svgPath:
                            DrawHelper.SvgPath2Pdf(svgPath, graphics);
                            break;
                        case SvgRectangle svgRectangle:
                            DrawHelper.SvgRectangle2Pdf(svgRectangle, graphics);
                            break;
                        case SvgLine svgLine:
                            DrawHelper.SvgLine2Pdf(svgLine, graphics);
                            break;
                        default:
                            Console.WriteLine(child);
                            break;
                    }
                }
            }

            pdfPage.Close();
        }
    }
}
