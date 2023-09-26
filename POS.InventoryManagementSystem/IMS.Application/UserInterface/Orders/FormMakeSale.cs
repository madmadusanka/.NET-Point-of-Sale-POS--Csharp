using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using FinalPoject.UserInterface.Orders;
using IMS.Entity.InventoryProducts;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormMakeSale : Form
    {
        private MasterCategoriesRepo masterCategoriesRepo{ get; set; }
        private ThirdCategoriesRepo  thirdCategoriesRepo { get; set; }
        private SecondCategoriesReop secondCateReop      { get; set; }
        private VendorsRepo          vendorsRepo         { get; set; }
        private BrandsRepo           brandRepo           { get; set; }
        private UsersRepo            usersRepo           { get; set; }
        private DataTable OrderDetailDataTable;
        private OrdersRepo makeSalesRepo{get; set;}

        public FormMakeSale()
        {
            InitializeComponent();
            //
            this.makeSalesRepo = new OrdersRepo();
            this.secondCateReop = new SecondCategoriesReop();
            this.thirdCategoriesRepo = new ThirdCategoriesRepo();
            this.vendorsRepo = new VendorsRepo();
            this.brandRepo = new BrandsRepo();
            this.usersRepo = new UsersRepo();
            //
            InitiateDgvcart();
            //
            this.SecondCategoryIdToName();
            this.ThirdCategoryIdToName();
            this.BrandIdToName();
            this.VendorIdToName();
            this.UsersIdToName();
        }

        //
        private void PopulateGridView(string searchKey = null)
        {
            this.dgvSearchProduct.AutoGenerateColumns = false;
            this.dgvSearchProduct.DataSource = this.makeSalesRepo.GetAll(searchKey);
            this.dgvSearchProduct.ClearSelection();
            this.Refresh();
            this.RefreshContent();
            this.lblTotalItemResult.Text = this.dgvSearchProduct.RowCount.ToString();
        }

        private void FormMakeSale_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }


        //LoadCombo
        private void SecondCategoryIdToName()
        {
            this.cmbSecond.Items.Clear();
            this.cmbSecond.Items.Add("--Not Selected--");
            this.cmbSecond.SelectedIndex = cmbSecond.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.secondCateReop.LoadComboMainCategoryName().Rows)
            {
                this.cmbSecond.Items.Add(row["SecondCategoryName"].ToString());
            }
        }
        private void ThirdCategoryIdToName()
        {
            this.cmbThird.Items.Clear();
            this.cmbThird.Items.Add("--Not Selected--");
            this.cmbThird.SelectedIndex = cmbThird.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.thirdCategoriesRepo.LoadComboThirdCategoryName().Rows)
            {
                this.cmbThird.Items.Add(row["ThirdCategoryName"].ToString());
            }
        }
        private void BrandIdToName()
        {
            this.cmbBrand.Items.Clear();
            this.cmbBrand.Items.Add("--Not Selected--");
            this.cmbBrand.SelectedIndex = cmbBrand.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.brandRepo.LoadComboBrandName().Rows)
            {
                this.cmbBrand.Items.Add(row["BrandName"].ToString());
            }
        }
        private void VendorIdToName()
        {
            this.cmbVendor.Items.Clear();
            this.cmbVendor.Items.Add("--Not Selected--");
            this.cmbVendor.SelectedIndex = cmbVendor.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.vendorsRepo.LoadComboVendorName().Rows)
            {
                this.cmbVendor.Items.Add(row["VendorName"].ToString());
            }
        }
        private void UsersIdToName()
        {
            this.cmbPayByUser.Items.Clear();
            this.cmbPayByUser.Items.Add("--Not Selected--");
            this.cmbPayByUser.SelectedIndex = cmbPayByUser.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.usersRepo.LoadComboUsersName().Rows)
            {
                this.cmbPayByUser.Items.Add(row["FirstName"].ToString() + " " + row["LastName"].ToString() + " - " + row["Role"].ToString());
            }
        }

        //Filter by ComboBox
        private void cmbSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecond.SelectedIndex == 0)
            {
                PopulateGridView(null);
            }
            else
            {
                int count = dgvSearchProduct.Rows.Count;

                while (count != 0)
                {
                    --count;
                    if (dgvSearchProduct.Rows[count].Cells[11].Value.ToString() != cmbSecond.Text)
                    {
                        dgvSearchProduct.Rows.RemoveAt(dgvSearchProduct.Rows[count].Index);
                    }
                }
            }
        }
        private void cmbThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThird.SelectedIndex == 0)
            {
                PopulateGridView(null);
            }
            else
            {
                int count = dgvSearchProduct.Rows.Count;

                while (count != 0)
                {
                    --count;
                    if (dgvSearchProduct.Rows[count].Cells[10].Value.ToString() != cmbThird.Text)
                    {
                        //MessageBox.Show(dgvSearchProduct.Rows[count].Cells[10].Value.ToString() + " is not " + comboBox1.Text + " Removing" + dgvSearchProduct.Rows[count].Index);
                        dgvSearchProduct.Rows.RemoveAt(dgvSearchProduct.Rows[count].Index);
                    }
                    //else
                    //{
                    //   // MessageBox.Show(dgvSearchProduct.Rows[count].Cells[10].Value.ToString() + " is " + comboBox1.Text + " Not Removing" + dgvSearchProduct.Rows[count].Index);
                    //}
                }
            }
        }
        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendor.SelectedIndex == 0)
            {
                PopulateGridView(null);
            }
            else
            {
                int count = dgvSearchProduct.Rows.Count;

                while (count != 0)
                {
                    --count;
                    if (dgvSearchProduct.Rows[count].Cells[9].Value.ToString() != cmbVendor.Text)
                    {
                        dgvSearchProduct.Rows.RemoveAt(dgvSearchProduct.Rows[count].Index);
                    }
                }
            }
        }
        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex == 0)
            {
                PopulateGridView(null);
            }
            else
            {
                int count = dgvSearchProduct.Rows.Count;

                while (count != 0)
                {
                    --count;
                    if (dgvSearchProduct.Rows[count].Cells[3].Value.ToString() != cmbBrand.Text)
                    {
                        dgvSearchProduct.Rows.RemoveAt(dgvSearchProduct.Rows[count].Index);
                    }
                }
            }
        }

        //Search - Product
        private void txtSearchForSell_TextChanged_1(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchForSell.Text);
        }

        //Cancel Search
        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            this.txtSearchForSell.Clear();
            this.PopulateGridView();
        }

        //Refresh
        private void RefreshContent()
        {
            this.txtProductName.Clear();
            this.txtProductId.Clear();
            this.txtProducTag.Clear();
            this.txtProductQuant.Clear();
            this.txtProductPerUnitPrice.Clear();
            this.txtDiscount.Clear();
            this.txtProductMSRP.Clear();
            this.txtBrand.Clear();
            this.txtPorductItemLeft.Clear();
            //
            this.txtCoustomerName.Clear();
            this.txtCoustomerEmail.Clear();
            this.txtCustomerPhone.Clear();
            this.txtCustomerAddress.Clear();
            this.dtpPayDate.Text = "";
            this.cmbPayStatus.StartIndex = -1;
            this.cmbPayByUser.StartIndex = -1;
            this.cmbPaymentMethod.StartIndex = -1;
            this.txtTotalAmount.Text = "0";
            this.OrderDetailDataTable.Clear();
        }

        //Refresh Button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
            this.RefreshContent();
            this.txtSearchForSell.Clear();
            //
            this.cmbSecond.StartIndex = 0; 
            this.cmbThird.StartIndex = 0;
            this.cmbVendor.StartIndex = 0;
            this.cmbBrand.StartIndex = 0; 
            this.cmbPayByUser.StartIndex = 0;
        }


        // ------------ Cart Section ------------

        //Products Click on Details
        private void dgvSearchProdcut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtProductName.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            this.txtProductId.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductId"].Value.ToString();
            this.txtProducTag.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductIdTag"].Value.ToString();
            this.txtPorductItemLeft.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductUnitStock"].Value.ToString();
            this.txtProductPerUnitPrice.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductPerUnitPrice"].Value.ToString();
            this.txtDiscount.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductDiscountRate"].Value.ToString();
            this.txtProductMSRP.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductMSRP"].Value.ToString();
            this.txtBrand.Text = this.dgvSearchProduct.CurrentRow.Cells["BrandName"].Value.ToString();
        }

        //LoadCart
        void InitiateDgvcart()
        {
            OrderDetailDataTable = new DataTable();
            OrderDetailDataTable.Clear();
            dgvCart.AutoGenerateColumns = false;

            OrderDetailDataTable.Columns.Add("Quantity");
            OrderDetailDataTable.Columns.Add("Price");
            foreach (DataGridViewTextBoxColumn col in dgvSearchProduct.Columns)
            {
                OrderDetailDataTable.Columns.Add(col.Name);
            }
          
            dgvCart.DataSource = OrderDetailDataTable;
        }

        //Add product - Cart
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void AddItem()
        {

            DataRow row = OrderDetailDataTable.NewRow();
            if (dgvSearchProduct.SelectedRows[0] != null)
            {

                QuantityForm quantityForm = new QuantityForm();
                quantityForm.ShowDialog();
                if (quantityForm.Quantiy != 0)
                {
                    this.txtProductQuant.Text = quantityForm.Quantiy.ToString();

                    row["Quantity"] = this.txtProductQuant.Text;


                    row["ProductId"] = dgvSearchProduct.SelectedRows[0].Cells[0].Value.ToString();
                    row["ProductName"] = dgvSearchProduct.SelectedRows[0].Cells[2].Value.ToString();

                    row["Price"] = (Convert.ToDouble(dgvSearchProduct.SelectedRows[0].Cells[6].Value) * Convert.ToDouble(this.txtProductQuant.Text)).ToString();

                    row["ProductIdTag"] = dgvSearchProduct.SelectedRows[0].Cells[1].Value.ToString();
                    row["BrandName"] = dgvSearchProduct.SelectedRows[0].Cells[3].Value.ToString();
                    row["ProductUnitStock"] = dgvSearchProduct.SelectedRows[0].Cells[5].Value.ToString();
                    row["ProductMSRP"] = dgvSearchProduct.SelectedRows[0].Cells[6].Value.ToString();
                    row["ProductPerUnitPrice"] = dgvSearchProduct.SelectedRows[0].Cells[7].Value.ToString();
                    row["ProductDiscountRate"] = dgvSearchProduct.SelectedRows[0].Cells[8].Value.ToString();

                    OrderDetailDataTable.Rows.Add(row);

                    UpdatePrice();
                    this.txtProductQuant.Text = String.Empty;
                }




            }
        }

        //Remove Product - Cart
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                this.dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
            }
            else
            {
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("No Item to remove ");
                }
                else
                {
                    MessageBox.Show("Select a Item to remove");
                }
            }
        }

        //FillEntity
        private Order FillEntity()
        {

            var orders = new Order();
            
            orders.Id = usersRepo.GetUsersdId(this.cmbPayByUser.Text);
            orders.CustomerFullName = this.txtCoustomerName.Text;
            orders.CustomerAddress = this.txtCustomerAddress.Text;
            orders.CustomerPhone = this.txtCustomerPhone.Text;
            orders.CustomerEmail = this.txtCoustomerEmail.Text;
            //orders.OrderQuantity = Convert.ToInt32(this.txtProductQuant.Text);
            orders.Date = Convert.ToDateTime(Convert.ToDateTime(dtpPayDate.Value).ToString("yyyy-MM-dd"));
            orders.TotalAmount = Convert.ToDouble(this.txtTotalAmount.Text);
            orders.OrderStatus = this.cmbPayStatus.Text;
            orders.PaymentMethod = this.cmbPaymentMethod.Text;
            if (!String.IsNullOrEmpty(this.txtBarcode.Text)) {
                orders.BarCodeId = Convert.ToInt32(this.txtBarcode.Text);
            }
            


            return orders;
        }

        private OrdersProductsMap FillOrderProductEntity(DataRow row, Order order)
        {

            var ordersProductsMap = new OrdersProductsMap();

            ordersProductsMap.OrderId = order.OrderId;
            ordersProductsMap.Price = double.Parse(row["Price"].ToString());
            ordersProductsMap.Quantity = decimal.Parse(row["Quantity"].ToString());
            ordersProductsMap.ProductMSRP = decimal.Parse(row["ProductMSRP"].ToString());
            ordersProductsMap.ProductId = int.Parse(row["ProductId"].ToString());

            return ordersProductsMap;
        }

        //Load from Cart to Save
        public List<OrdersProductsMap> GetAllForOrders(Order order )
        {
            List<OrdersProductsMap> orderList = new List<OrdersProductsMap>();

            foreach (DataRow row in OrderDetailDataTable.Rows)
            {
                OrdersProductsMap orders = this.FillOrderProductEntity(row, order);
                orderList.Add(orders);
            }
            return orderList;
        }




        //Save - Place Order
        private void btnPlaceOrderToSave_Click(object sender, EventArgs e)
        {
            try
            {
                Order orObj = this.FillEntity();
                if (orObj == null)
                {
                    orObj = new Order();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    if (this.makeSalesRepo.SaveOrder(ref orObj))
                    {
                        if (this.makeSalesRepo.SaveOrders(GetAllForOrders(orObj)))
                        {

                            MessageBox.Show("Save Successfully");

                            foreach (DataGridViewRow row in dgvCart.Rows)
                            {
                                dgvCart.Rows.RemoveAt(row.Index);
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
               
                Refresh();
                this.PopulateGridView();
            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data" + exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Vat
        void UpdatePrice()
        {
            double price = 0.0;
            foreach (DataRow row in OrderDetailDataTable.Rows)
            {
                price += double.Parse(row["Price"].ToString());
            }

            txtTotalAmount.Text = price.ToString();

            txtNewVatAmount.Text = price.ToString();
        }

        // ------------ Cart Section ------------


        //Close Button

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductQuant_TextChanged(object sender, EventArgs e)
        {
            decimal quantity;
            if (decimal.TryParse(txtProductQuant.Text, out quantity))
            {

                int quantityLeft = 0;
                if (Int32.TryParse(txtPorductItemLeft.Text, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out quantityLeft))
                {


                    if (txtProductQuant.Text != "")
                    {
                        decimal itemsLeft = quantityLeft - quantity;

                        if (itemsLeft < 0)
                        {
                            txtProductQuant.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            txtProductQuant.ForeColor = Color.Black;
                        }
                        txtPorductItemLeft.Text = itemsLeft.ToString();
                    }
                    else
                    {
                        txtProductQuant.ForeColor = Color.Black;
                        txtPorductItemLeft.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductUnitStock"].Value.ToString();
                    }
                }
            }

        }


        private void dgvSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AddItem();

            }
        }
        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel18_Paint(object sender, PaintEventArgs e)
        {
                    }
    }
}
