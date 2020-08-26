using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.HtmlConverter;
using Spire.Presentation;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Spire.Doc;
using FileFormat = Spire.Xls.FileFormat;

namespace TestJobForCITApp
{
    class FileHelper
    {
        public void ConvertToPDF(string sourcePath, string contentType, string fileName, string targetLocation)
        {
            if (!string.IsNullOrEmpty(sourcePath))
            {
                switch (contentType.ToLower())
                {
                    case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                    case "application/vnd.ms-powerpoint":
                    case "application/vnd.ms-powerpoint.presentation.macroEnabled.12":
                    case "application/pptx":
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");

                            Presentation presentation = new Presentation();
                            presentation.LoadFromFile(sourcePath, Spire.Presentation.FileFormat.PPT);
                            presentation.SaveToFile(file, Spire.Presentation.FileFormat.PDF);
                        }
                        break;
                    case "image/gif":
                    case "image/jpg":
                    case "image/png":
                    case "image/jpeg":
                    case "application/BMP":
                    case "image/bmp":
                    case "image/tiff":
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");

                            PdfDocument doc = new PdfDocument();
                            PdfSection section = doc.Sections.Add();
                            PdfPageBase page = doc.Pages.Add();
                            PdfImage image = PdfImage.FromFile(sourcePath);
                            float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
                            float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
                            float fitRate = Math.Max(widthFitRate, heightFitRate);
                            float fitWidth = image.PhysicalDimension.Width / fitRate;
                            float fitHeight = image.PhysicalDimension.Height / fitRate;
                            page.Canvas.DrawImage(image, 30, 30, fitWidth, fitHeight);
                            doc.SaveToFile(file);
                            doc.Close();
                        }

                        break;
                    case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    case "application/vnd.ms-excel":
                    case "application/xlsx":
                    case "application/xls":
                    case "application/vnd.ms-excel.sheet.macroEnabled.12":
                    case "application/XLSM":
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");

                            Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                            workbook.LoadFromFile(sourcePath, true);
                            workbook.SaveToFile(file, Spire.Xls.FileFormat.PDF);
                        }

                        break;
                    case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    case "application/msword":
                    case "application/docx":
                    case "application/doc":
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");

                            Document document = new Spire.Doc.Document();
                            document.LoadFromFile(sourcePath, Spire.Doc.FileFormat.Auto);
                            document.SaveToFile(file, Spire.Doc.FileFormat.PDF);
                        }
                        break;
                    case "application/xml":
                    {
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");
                            Document mydoc = new Document();
                            mydoc.LoadFromFile(sourcePath, Spire.Doc.FileFormat.Xml);
                            mydoc.SaveToFile(file, Spire.Doc.FileFormat.PDF);
                        }
                    }
                        break;
                    case "application/txt":
                    case "text/plain":
                        {
                            if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                            {
                                string file = Path.Combine(targetLocation, fileName + ".pdf");
                                string text = File.ReadAllText(sourcePath);
                                PdfDocument doc = new PdfDocument();
                                PdfSection section = doc.Sections.Add();
                                PdfPageBase page = section.Pages.Add();
                                //PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 11);
                                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Helvetica", 11f), true);

                                PdfStringFormat format = new PdfStringFormat();
                                format.LineSpacing = 20f;
                                PdfBrush brush = PdfBrushes.Black;
                                PdfTextWidget textWidget = new PdfTextWidget(text, font, brush);
                                float y = 0;
                                PdfTextLayout textLayout = new PdfTextLayout();
                                textLayout.Break = PdfLayoutBreakType.FitPage;
                                textLayout.Layout = PdfLayoutType.Paginate;
                                RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
                                textWidget.StringFormat = format;
                                textWidget.Draw(page, bounds, textLayout);
                                doc.SaveToFile(file, Spire.Pdf.FileFormat.PDF);
                            }
                        }
                        break;
                    case "application/html":
                    case "application/htm":
                    case "text/html":
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");

                            PdfDocument pdf = new PdfDocument();
                            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat
                            {
                                Layout = PdfLayoutType.Paginate,
                                FitToPage = Clip.Width,
                                LoadHtmlTimeout = 60 * 1000
                            };
                            htmlLayoutFormat.IsWaiting = true;
                            PdfPageSettings setting = new PdfPageSettings();
                            setting.Size = PdfPageSize.A4;
                            Thread thread = new Thread(() => { pdf.LoadFromHTML(sourcePath, true, true, true); });
                            thread.SetApartmentState(ApartmentState.STA);
                            thread.Start();
                            thread.Join();
                            pdf.SaveToFile(file, Spire.Pdf.FileFormat.PDF);
                        }
                        break;
                    case "application/pdf":
                    {
                        if (!string.IsNullOrEmpty(targetLocation) && !string.IsNullOrEmpty(fileName))
                        {
                            string file = Path.Combine(targetLocation, fileName + ".pdf");
                            File.Copy(sourcePath, file);
                        }
                    }
                        break;
                    case "application/msg":
                    case "application/octet-stream":
                    case "multipart/related":
                    case "application/ZIP":
                    case "application/VCF":
                    default:
                        break;
                }

            }
        }
    }
}
