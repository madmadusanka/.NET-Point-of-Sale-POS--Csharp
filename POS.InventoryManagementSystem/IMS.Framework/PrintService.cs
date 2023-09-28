using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace IMS.Framework
{
    public class PrintService
    {
        private Bitmap bitmap; 

        public PrintService(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }
        public void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);
            pd.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Draw the graphics on the page
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        //private void PrintWord()
        //{
        //    Word.Application wordApp = new Word.Application();
        //    Word.Document doc = null;

        //    try
        //    {
        //        // Open the Word document
        //        doc = wordApp.Documents.Open(filePath);

        //        // Print the document
        //        doc.PrintOut();

        //        // Optionally, you can specify print settings like number of copies, range, etc.
        //        // doc.PrintOut(Copies: 2, Pages: "1-3");

        //        // Wait for printing to complete (optional)
        //        while (wordApp.BackgroundPrintingStatus > 0)
        //        {
        //            System.Threading.Thread.Sleep(100);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        // Close the document and Word application
        //        doc?.Close();
        //        Marshal.ReleaseComObject(doc);

        //        wordApp.Quit();
        //        Marshal.ReleaseComObject(wordApp);
        //    }
        //}


    }
}
