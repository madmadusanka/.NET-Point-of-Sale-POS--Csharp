

using IMS.Framework;
using System;
using System.Windows.Forms;

namespace FinalPoject.UserInterface.Orders
{
    public partial class QuantityForm : Form
    {
        public QuantityForm()
        {
            InitializeComponent();
        }
        public decimal Quantiy { get; private set; } = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quantiy = 0;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Submit();

        }

        private void Submit()
        {
            try
            {
                Quantiy = decimal.Parse(this.quantity.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show("Invalid Input");

            }
        }
        private void QuantityForm_Load(object sender, EventArgs e)
        {
           
        }

        private void quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Submit();

            }
        }
    }
}
