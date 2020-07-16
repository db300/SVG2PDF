# SVG2PDF

基于 [Svg](https://github.com/vvvv/SVG "Svg") 和 [PDFsharp](http://www.pdfsharp.net/ "PDFsharp") 实现的将SVG文件转换成PDF文件的类库。

### Demo:

1. 单一SVG文件转换为单一PDF文件
	
    	var svg = <source svg file>;
    	var pdf = <destination pdf file>;
    	iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svg, pdf);
    
2. 多个SVG文件合并成一个PDF文件

		var svgs = new List<string>
		{
			<source svg file 1>,
			<source svg file 2>,
		};
		var pdf = <destination pdf file>;
		iHawkSvg2PdfLibrary.Svg2Pdf.Convert(svgs, pdf);

### 说明：

目前支持SvgGroup、SvgText、SvgPath、SvgRectangle、SvgLine、SvgCircle等元素的转换，主要是从本职工作需要入手的，后续会不断优化和完善。
