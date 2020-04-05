# SVG2PDF

基于 [Svg](https://github.com/vvvv/SVG "Svg") 和 [PDFsharp](http://www.pdfsharp.net/ "PDFsharp") 实现的将SVG文件转换成PDF文件的类库。

### Demo:

1. 单一SVG文件
	
    	var svg = <source svg file>;
    	var pdf = <destination pdf file>;
    	iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svg, pdf);
    
2. 多个SVG文件

		var svgs = new List<string>
		{
			<source svg file 1>,
			<source svg file 2>,
		};
		var pdf = <destination pdf file>;
		iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svgs, pdf);