using System;
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
            if (args.Length > 0)
            {
                Console.Out.WriteLine(args[0]);
                var svg = args[0];
                var pdf = $"{args[0]}.pdf";
                iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svg, pdf);
                Console.Out.WriteLine(pdf);
            }
            else
            {
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

                var svgs = new List<string>
                {
                    @"C:\GitHub\FontStudioV1\FontStudio\bin\Debug\tmp\000.svg"
                    //@"C:\GitHub\SVG2PDF\Svg2PdfConsoleApp\bin\Debug\000.svg"
                };
                var pdf = "000.pdf";
                iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svgs, pdf);
            }
            Console.ReadLine();
        }
    }
}
