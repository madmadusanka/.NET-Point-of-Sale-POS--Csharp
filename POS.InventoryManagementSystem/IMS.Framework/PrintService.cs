using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DevExpress.XtraPrinting;
using IMS.Entity.InventoryProducts;
using System.Collections.Generic;
using ExportOptions = CrystalDecisions.Shared.ExportOptions;

namespace IMS.Framework
{
    public class PrintService
    {
        //public static void printWord()
        //{
        //Application wordApp = new Application();

        //try
        //{
        //    // Disable alerts (e.g., confirmation dialogs)
        //    wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;

        //    // Open the Word document
        //    Document doc = wordApp.Documents.Open(@"C:\Users\Dilan\Desktop\template.doc");

        //    // Print the document
        //    doc.PrintOut();

        //    // Close the document without saving changes
        //    doc.Close(WdSaveOptions.wdDoNotSaveChanges);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Error: " + ex.Message);
        //}
        //finally
        //{
        //    // Quit Word application
        //    wordApp.Quit();
        //}
        //}
        //public static void PrintBill(List<OrdersProductsMap> ordersProductsMaps, Order order)
        //{
        //    Application wordApp = new Application();
        //    Document doc = null;



        //    try
        //    {
        //        string rootFolder = AppDomain.CurrentDomain.BaseDirectory;


        //        // Disable alerts (e.g., confirmation dialogs)
        //        wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;

        //        string destinationFilePath = rootFolder+ order.Id.ToString() + "template.doc";
        //        string sourceFilePath = rootFolder + "template.doc";
        //        Logger.Error(new Exception(destinationFilePath));
        //        Logger.Error(new Exception(sourceFilePath));

        //        File.Copy(sourceFilePath, destinationFilePath, true);

        //        // Open the Word document
        //        doc = wordApp.Documents.Open(destinationFilePath,false);



        //        Dictionary<string, string> replacements = new Dictionary<string, string>();

        //        // Replace product names
        //        StringBuilder productNames = new StringBuilder();
        //        StringBuilder prices = new StringBuilder();
        //        foreach (var item in ordersProductsMaps)
        //        {
        //            if (item.Quantity >= 1)
        //            {
        //                productNames.Append($"{item.Name}  {(item.Quantity)}Kg  - {item.Price.ToString("F2")}^p");

        //            }
        //            else
        //            {
        //                productNames.Append($"{item.Name} {((item.Quantity % 1).ToString("F3").Substring(2))}g - {item.Price.ToString("F2")}^p");
        //            }
        //            productNames.Append(Environment.NewLine);
        //        }
        //        //foreach (var item in ordersProductsMaps)
        //        //{
        //        //    prices.Append($"{item.Price.ToString("F2")}");
        //        //    prices.Append(Environment.NewLine);
        //        //}
        //        replacements.Add("#item", productNames.ToString().Trim());
        //        //replacements.Add("#price", prices.ToString().Trim());
        //        replacements.Add("LKRttlcnst","LKR"+order.TotalAmount.ToString("F2"));
        //        replacements.Add("date",order.Date.ToString("d"));;

        //        // Perform find and replace
        //        foreach (var kvp in replacements)
        //        {
        //            if (kvp.Key == "date")
        //            {

        //            }
        //            else
        //            {
        //                wordApp.Selection.Find.Replacement.Font.Size = 7.5f;
        //            }
        //            wordApp.Selection.Find.Text = kvp.Key;
        //            wordApp.Selection.Find.Replacement.Text = kvp.Value;
        //            wordApp.Selection.Find.Execute(Replace: WdReplace.wdReplaceAll);

        //        }

        //        doc.Save();
        //        doc.PrintOut();


        //        // Print the document


        //        // Close the document without saving changes
        //        doc.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        doc.Close();
        //        Logger.Error(ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        // Quit Word application

        //        wordApp.Quit();
        //    }
        //}

        //    public static void PrintBill(string test)
        //    {
        //        try
        //        {
        //            List<OrdersProductsMap> ordersProductsMaps;
        //            Order order;

        //            //string reportPath = @"C:\\Users\\Dilan\\Music\\Report1.repx";
        //            string reportPath = @"C:\Users\Dilan\Documents\GitHub\.NET-Point-of-Sale-POS--Csharp\POS.InventoryManagementSystem\IMS.Application\Report2.rdlc";

        //            LocalReport localReport = new LocalReport();
        //            List<ReportParameter> parameters = new List<ReportParameter>();
        //            localReport.ReportPath = reportPath;
        //            parameters.Add(new ReportParameter("date",DateTime.Today.ToString("d")));
        //            parameters.Add(new ReportParameter("CustomerName", DateTime.Today.ToString("d")));
        //            parameters.Add(new ReportParameter("Total", DateTime.Today.ToString("d")));
        //            parameters.Add(new ReportParameter("CustomerPhone", DateTime.Today.ToString("d")));
        //            localReport.SetParameters(parameters);

        //            localReport.Refresh();

        //            localReport.DataSources.Add(new ReportDataSource("Items", new List<InvoiceData> { new InvoiceData{Item ="123s", Price="23432" },
        //                new InvoiceData { Item = "123s", Price = "23432" }
        //             ,new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //               new InvoiceData{Item ="123s", Price="23432" },
        //                new InvoiceData{Item ="123s", Price="23432" },
        //                 new InvoiceData{Item ="123s", Price="23432" }
        //                 , new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //               new InvoiceData{Item ="123s", Price="23432" },
        //                new InvoiceData{Item ="123s", Price="23432" },
        //                 new InvoiceData{Item ="123s", Price="23432" }
        //                 , new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //               new InvoiceData{Item ="123s", Price="23432" },
        //                new InvoiceData{Item ="123s", Price="23432" },
        //                 new InvoiceData{Item ="123s", Price="23432" }
        //                 , new InvoiceData{Item ="123s", Price="23432" }
        //            ,  new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //               new InvoiceData{Item ="123s", Price="23432" },
        //                new InvoiceData{Item ="123s", Price="23432" },
        //                 new InvoiceData{Item ="123s", Price="23432" }
        //                 , new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //               new InvoiceData{Item ="123s", Price="23432" },
        //                new InvoiceData{Item ="123s", Price="23432" },
        //                 new InvoiceData{Item ="123s", Price="23432" }
        //                 , new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="23432" },
        //              new InvoiceData{Item ="123s", Price="44" },
        //               new InvoiceData{Item ="123s", Price="33" },
        //                new InvoiceData{Item ="123s", Price="22" },
        //                 new InvoiceData{Item ="123s", Price="11" }
        //                 , new InvoiceData{Item ="123s", Price="111" }
        //            }
        //            ));;

        //            localReport.Refresh();
        //            string deviceInfo =
        //                "<DeviceInfo>" +
        //                "  <OutputFormat>EMF</OutputFormat>" +
        //                "  <PageWidth>2.283465in</PageWidth>" +
        //                "  <PageHeight>5in</PageHeight>" +
        //                "  <MarginTop>0in</MarginTop>" +
        //                "  <MarginLeft>0in</MarginLeft>" +
        //                "  <MarginRight>0in</MarginRight>" +
        //                "  <MarginBottom>0in</MarginBottom>" +
        //                "</DeviceInfo>";

        //byte[] bytes = localReport.Render("Image", deviceInfo, out string mimeType, out string encoding, out string extension, out string[] streams, out Warning[] warnings);
        //            Bitmap bitmap = null;
        //            using (MemoryStream stream = new MemoryStream(bytes))
        //            {
        //                 bitmap = new Bitmap(stream);
        //                bitmap.Save(@"C:\\Users\\Dilan\\Music\\aa2.png");
        //            }
        //            using (MemoryStream stream = new MemoryStream(bytes))
        //            {
        //                using (Image image = Image.FromStream(stream))
        //                {
        //                    image.Save(@"C:\\Users\\Dilan\\Music\\aa.png", ImageFormat.Png);
        //                }
        //            }

        //            int i = 0;
        //            PrintDocument printDoc = new PrintDocument();


        //            printDoc.PrintPage += (s, e) =>
        //            {
        //                using (MemoryStream stream = new MemoryStream(bytes))
        //                {
        //                    using (Image image = Image.FromStream(stream))
        //                    {

        //                        switch (i)
        //                        {
        //                            case 0:
        //                                e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
        //                                printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
        //                                printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", bitmap.Width, bitmap.Height);

        //                                // code to be executed 
        //                                break;
        //                            //case 1:
        //                            //    e.Graphics.DrawImage(bitmap, 0, 0);
        //                            //    // code to be executed if expression matches value2
        //                            //    break;
        //                            //// Add more cases as needed
        //                            //case 2:
        //                            //    e.Graphics.DrawImageUnscaled(image, 0, 0);
        //                            //    break;
        //                            //case 3:
        //                            //    e.Graphics.DrawImage (image, 0, 0,(int)image.Width, (int)image.Height);
        //                            //    break;
        //                        }
        //                        i++;


        //                    }
        //                }
        //            };
        //            //printDoc.Print();
        //            //printDoc.Print();
        //            //printDoc.Print();
        //            //printDoc.Print();
        //        }
        //        catch (Exception ex) 
        //        {

        //        }
        //    }

        public static void PrintBill(List<OrdersProductsMap> ordersProductsMaps = null, Order order = null)
        {
            ReportDocument report = new ReportDocument();
            report.Load("C:\\Users\\Dilan\\Documents\\GitHub\\.NET-Point-of-Sale-POS--Csharp\\POS.InventoryManagementSystem\\IMS.Application\\CrystalReport1.rpt"); // Replace with the actual path to your report file
                                                                                                                                                                    //report.PrintOptions.PrinterName = "your_printer_name"; // Replace with the name of your printer

            List<InvoiceData> parameters = new List<InvoiceData>();
            if (ordersProductsMaps == null)
            {

                parameters = new List<InvoiceData>
                {
                     new InvoiceData{Item ="123s", Price="23432" } ,new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                     ,new InvoiceData{Item ="123s", Price="23432" }, new InvoiceData{Item ="123s", Price="23432" }
                };
            }
            else
            {
                    foreach (OrdersProductsMap or in ordersProductsMaps)
                {

                    if (or.Quantity >= 1)
                    {
                        parameters.Add(new InvoiceData { Item = $"{or.Name}  {(or.Quantity)}Kg", Price = or.Price.ToString("F2") });


                    }
                    else
                    {
                        parameters.Add(new InvoiceData { Item = $"{or.Name} {((or.Quantity % 1).ToString("F3").Substring(2))}g", Price = or.Price.ToString("F2") });
                    }

                }
            }

            report.SetDataSource(parameters);


//            ExportOptions exportOptions = new ExportOptions();
//            exportOptions.ExportFormatType = ExportFormatType.ExcelWorkbook; // Use PNG or other image formats if needed
//            exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
//            DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
//            diskFileDestinationOptions.DiskFileName = @"C:\\Users\\Dilan\\Music\\aa.xls
//"; // Replace with the desired file path and name
//            exportOptions.DestinationOptions = diskFileDestinationOptions;
//            // Export the report
//            report.Export(exportOptions);

            report.PrintToPrinter(1, false, 0, 0);

        }

    }
}
