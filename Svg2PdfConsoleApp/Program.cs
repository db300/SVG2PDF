﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svg2PdfConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var svg = @"C:\Users\db300\source\repos\Svg2PdfConsoleApp\Svg2PdfConsoleApp\bin\Debug\000.svg";
            var pdf = @"C:\Users\db300\source\repos\Svg2PdfConsoleApp\Svg2PdfConsoleApp\bin\Debug\000.pdf";
            iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svg, pdf);

            /*
            var svgs = new List<string>
            {
                @"C:\Users\db300\Desktop\Release\tmp\000.svg",
                @"C:\Users\db300\Desktop\Release\tmp\001.svg",
                @"C:\Users\db300\Desktop\Release\tmp\002.svg",
                @"C:\Users\db300\Desktop\Release\tmp\003.svg"
            };
            pdf = @"C:\Users\db300\Desktop\Release\tmp\000.pdf";
            iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svgs, pdf);
            */

            Console.ReadLine();
        }
    }
}