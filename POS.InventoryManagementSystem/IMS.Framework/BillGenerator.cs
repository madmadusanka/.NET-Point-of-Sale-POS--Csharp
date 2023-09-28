using IMS.Entity.InventoryProducts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Framework
{
    public class BillGenerator
    {

        public static Bitmap GenerateBill(List<OrdersProductsMap> list,string currency, Order order)
        {
            int paperWidth = 300; // Set the width in pixels (adjust as needed)
            int paperHeight = 150+list.Count()*20+270; // Set the height dynamically (adjust as needed)



            Bitmap bitmap = new Bitmap(paperWidth, paperHeight);
            Graphics g = Graphics.FromImage(bitmap);;
            Font font = new Font("Arial", 10);

            // Draw header
          
            Image image = Image.FromFile(@"C:\Users\Dilan\Downloads\smart kade.jpg");
            Image resizedImage = image.GetThumbnailImage(250, 100, null, IntPtr.Zero);

            // Load the image
            
            g.DrawImageUnscaled(resizedImage, 40,0);



            DrawStringInCenter(ref g, font, paperWidth, 100, "141,High Level Road");
            DrawStringInCenter(ref g, font, paperWidth, 120, "Kendalanda,Homagama.");
            DrawStringInCenter(ref g, font, paperWidth, 140, "WhatsApp - 076 102 7 502");
            //DrawStringInCenter(ref g, font, paperWidth, 160, "WhatsApp - 076 102 7 502");
            DrawStringInCenter(ref g, font, paperWidth, 180, order.Date.ToString());
            DrawStringInCenter(ref g, font, paperWidth, 200, "-----------------------");

            // Draw itemized list
            int yPos = 220;
            g.DrawString("Item", font, Brushes.Black, 50, yPos);
            g.DrawString("Qty", font, Brushes.Black, 200, yPos);
            g.DrawString("Price", font, Brushes.Black, 250, yPos);
            
            foreach (var item in list)
            {
                yPos += 20;
                g.DrawString(item.Name, font, Brushes.Black, 50, yPos);
                g.DrawString(item.Quantity.ToString(), font, Brushes.Black, 200, yPos);
                g.DrawString(item.Price.ToString(), font, Brushes.Black, 250, yPos);
            }

            // Draw total
            yPos += 60;
            g.DrawString($"Total:                           {currency}{order.TotalAmount}", font, Brushes.Black, 50, yPos);

            // Draw footer
            yPos += 30;
            DrawStringInCenter(ref g, font, paperWidth, yPos, "* ව්‍යාපාරයකට වඩා ගුණාත්මක ");
            yPos += 20;
            DrawStringInCenter(ref g, font, paperWidth, yPos, "සේවයකට Smartකඩේ");
            yPos += 20;
            DrawStringInCenter(ref g, font, paperWidth, yPos, "සේවයකට Smartකඩේ");
            yPos += 20;
            DrawStringInCenter(ref g, font, paperWidth, yPos, "නිරෝගිමත් දිවියකට නැව්ම් එළවලු");
            yPos += 20;
            DrawStringInCenter(ref g, font, paperWidth, yPos, "ස්තූතියි!");

            bitmap.Save("output.png", System.Drawing.Imaging.ImageFormat.Png);
            return bitmap;
        }

        public static int CenterTextInImage(string text, int width, Font font )
        {

            //// Get the size of the text
            //SizeF textSize = g.MeasureString(text, font);

            //// Calculate the position to center the text
            //return (width - (int)textSize.Width) / 2;
            return 50;
        }
        public static void DrawStringInCenter(ref Graphics g, Font font, int width,int ypos, string text)
        {
            SizeF textSize = g.MeasureString(text, font);
            g.DrawString(text, font, Brushes.Black, (width - (int)textSize.Width) / 2, ypos);
        }


     


    }
}
