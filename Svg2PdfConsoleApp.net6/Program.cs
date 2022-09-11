namespace Svg2PdfConsoleApp.net6
{
    internal class Program
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
                var svgs = new List<string>
                {
                    @"C:\GitHub\FontStudioV1\FontStudio\bin\Debug\tmp\000.svg"
                };
                var pdf = "000.pdf";
                iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svgs, pdf);
            }
            Console.ReadLine();
        }
    }
}