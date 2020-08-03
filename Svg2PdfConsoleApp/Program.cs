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
            //args = new[] {@"C:\GitHub\SVG2PDF\Images\tiger.svg"};
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
                var svg = @"C:\Users\db300\source\repos\Svg2PdfConsoleApp\Svg2PdfConsoleApp\bin\Debug\000.svg";
                var pdf = @"C:\Users\db300\source\repos\Svg2PdfConsoleApp\Svg2PdfConsoleApp\bin\Debug\000.pdf";
                iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svg, pdf);
                */

                /*
                var svg = @"C:\Users\db300\Documents\WeChat Files\HawkLeng\FileStorage\File\2020-07\000.svg";
                var pdf = @"C:\Users\db300\Documents\WeChat Files\HawkLeng\FileStorage\File\2020-07\000.pdf";
                iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svg, pdf);
                */

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
                    @"C:\Users\db300\Documents\WeChat Files\HawkLeng\FileStorage\File\2020-07\000(1).svg",
                    @"C:\Users\db300\Documents\WeChat Files\HawkLeng\FileStorage\File\2020-07\001.svg"
                };
                var pdf = @"C:\Users\db300\Documents\WeChat Files\HawkLeng\FileStorage\File\2020-07\000.pdf";
                iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svgs, pdf);
            }

            Console.ReadLine();
        }
    }
}
