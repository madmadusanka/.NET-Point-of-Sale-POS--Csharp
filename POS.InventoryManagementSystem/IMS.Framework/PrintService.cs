using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Framework
{
    public class PrintService
    {
        public static void GenerateBill()
        {
            int paperWidth = 300; // Set the width in pixels (adjust as needed)
            int paperHeight = 3000; // Set the height dynamically (adjust as needed)

            Bitmap bitmap = new Bitmap(paperWidth, paperHeight);
            Graphics g = Graphics.FromImage(bitmap);;
            Font font = new Font("Arial", 10);

            // Draw header
            string imagePath = "example.jpg";
            Image image = Image.FromFile(@"C:\Users\Dilan\Downloads\smart kade.jpg");
            Image resizedImage = image.GetThumbnailImage(250, 100, null, IntPtr.Zero);

            // Load the image
            
            g.DrawImageUnscaled(resizedImage, 0,0);
            g.DrawString("Your Company Name", font, Brushes.Black, 50, 50);
            g.DrawString("Address: Your Company Address", font, Brushes.Black, 50, 70);
            g.DrawString("Contact: Your Contact Information", font, Brushes.Black, 50, 90);
            g.DrawString("--------------------------------", font, Brushes.Black, 50, 110);

            // Draw itemized list
            int yPos = 130;
            g.DrawString("Item                 Qty   Price", font, Brushes.Black, 50, yPos);
            yPos += 20;
            g.DrawString("--------------------------------", font, Brushes.Black, 50, yPos);
            yPos += 20;
            g.DrawString("Product 1         2       $10.00", font, Brushes.Black, 50, yPos);
            yPos += 20;
            g.DrawString("Product 2         1       $5.00", font, Brushes.Black, 50, yPos);
            yPos += 20;
            g.DrawString("Product 3         3       $15.00", font, Brushes.Black, 50, yPos);

            // Calculate total
            double total = 2 * 10.00 + 1 * 5.00 + 3 * 15.00;

            // Draw total
            yPos += 60;
            g.DrawString($"Total:                           ${total}", font, Brushes.Black, 50, yPos);

            // Draw footer
            yPos += 30;
            g.DrawString("Thank you for your business!", font, Brushes.Black, 50, yPos);

            bitmap.Save("output.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
