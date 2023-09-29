using IMS.Entity.InventoryProducts;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace IMS.Framework
{
    public class PrintService
    {
        public static void printWord()
        {
            Application wordApp = new Application();

            try
            {
                // Disable alerts (e.g., confirmation dialogs)
                wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;

                // Open the Word document
                Document doc = wordApp.Documents.Open(@"C:\Users\Dilan\Desktop\template.doc");

                // Print the document
                doc.PrintOut();

                // Close the document without saving changes
                doc.Close(WdSaveOptions.wdDoNotSaveChanges);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Quit Word application
                wordApp.Quit();
            }
        }
        public static void PrintBill(List<OrdersProductsMap> ordersProductsMaps, Order order)
        {
            Application wordApp = new Application();
            Document doc = null;



            try
            {
                string rootFolder = AppDomain.CurrentDomain.BaseDirectory;


                // Disable alerts (e.g., confirmation dialogs)
                wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;

                string destinationFilePath = rootFolder+ order.Id.ToString() + "template.doc";
                string sourceFilePath = rootFolder + "template.doc";
                File.Copy(sourceFilePath, destinationFilePath, true);

                // Open the Word document
                doc = wordApp.Documents.Open(destinationFilePath,false);



                Dictionary<string, string> replacements = new Dictionary<string, string>();

                // Replace product names
                StringBuilder productNames = new StringBuilder();
                StringBuilder prices = new StringBuilder();
                foreach (var item in ordersProductsMaps)
                {
                    if (item.Quantity > 1)
                    {
                        productNames.Append($"{item.Name}  {(item.Quantity)}Kg");

                    }
                    else
                    {
                        productNames.Append($"{item.Name}  {((item.Quantity % 1).ToString("F3").Substring(2))}g");
                    }
                    productNames.Append(Environment.NewLine);
                }
                foreach (var item in ordersProductsMaps)
                {
                    prices.Append($"{item.Price.ToString("F2")}");
                    prices.Append(Environment.NewLine );
                }
                replacements.Add("#item", productNames.ToString().Trim());
                replacements.Add("#price", prices.ToString().Trim());
                replacements.Add("LKRttlcnst","LKR"+order.TotalAmount.ToString("F2"));
                replacements.Add("date","LKR"+order.Date.ToString("d"));;

                // Perform find and replace
                foreach (var kvp in replacements)
                {
                    if (kvp.Key == "date")
                    {
                        
                    }
                    else
                    {
                        wordApp.Selection.Find.Replacement.Font.Size = 7.5f;
                    }
                    wordApp.Selection.Find.Text = kvp.Key;
                    wordApp.Selection.Find.Replacement.Text = kvp.Value;
                    wordApp.Selection.Find.Execute(Replace: WdReplace.wdReplaceAll);

                }

                doc.Save();
                doc.PrintOut();
                

                // Print the document
               

                // Close the document without saving changes
                doc.Close();
            }
            catch (Exception ex)
            {
                doc.Close();
                Logger.Error(ex);
                throw;
            }
            finally
            {
                // Quit Word application
              
                wordApp.Quit();
            }
        }


    }
}
