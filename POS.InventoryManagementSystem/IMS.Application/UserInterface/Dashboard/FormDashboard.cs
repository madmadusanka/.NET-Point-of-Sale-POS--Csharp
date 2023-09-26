using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalPoject.UserInterface.Exp;
using IMS.Repository;
using IMS.Repository.InventoryProducts.Expense;

namespace FinalPoject.UserInterface.Dashboard
{
    public partial class FormDashboard : Form
    {
        private ExpenseRepo          expenseRepo           {get; set;}
        private OrdersRepo           ordersRepo            {get; set;}
        private UsersRepo            usersRepo             {get; set;}
        private ProductsRepo         productsRepo          {get; set;}
        private MasterCategoriesRepo msMasterCategoriesRepo{get; set;}
        public FormDashboard()
        {
            InitializeComponent();
            this.expenseRepo = new ExpenseRepo();
            this.ordersRepo = new OrdersRepo();
            this.usersRepo = new UsersRepo();
            this.productsRepo = new ProductsRepo();
            this.msMasterCategoriesRepo = new MasterCategoriesRepo();
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            lblExpLast7Day.Text = expenseRepo.GetLastWeekExpense() + Constants.Currency;
            lblTotalExp.Text = expenseRepo.GetTotalExpense() + Constants.Currency;
            lblExpLast30Day.Text = expenseRepo.GetLastMonth() + Constants.Currency;
            lblExpLastDay.Text = expenseRepo.GetTodayExpense() + Constants.Currency;
            //
            lblLastTotalSell.Text = ordersRepo.GetTotalOrders() + Constants.Currency;
            lblLastDaySell.Text = ordersRepo.GetTodaySell() + Constants.Currency;
            lblLast7DaySell.Text = ordersRepo.GetLastWeekSell() + Constants.Currency;
            lblLast30DaySell.Text = ordersRepo.GetLastMonthSell() + Constants.Currency;
            //
            lblTotalAdmin.Text = usersRepo.GetTotalAdmin();
            lblTotalSalesMan.Text = usersRepo.GetTotalSalesman();
            lblTotalCashier.Text = usersRepo.GetTotalCashier();
            lblTotalUser.Text = usersRepo.GetTotalUser();
            //
            lblTotalStock.Text = productsRepo.GetTotalProducts();
            lblAvailableStock.Text = productsRepo.GetAvailableProducts();
            lblNotAvailableStock.Text = productsRepo.GetNoAvailableProducts();
            //
            lblAdminTotalSal.Text = usersRepo.GetAdminSal() + Constants.Currency;
            lblCashierTotalSal.Text = usersRepo.GetCashierSal() + Constants.Currency;
            lblSalesManTotalSal.Text = usersRepo.GetSalesmanSal() + Constants.Currency;
            lblTotalSal.Text = usersRepo.GetTotalSal() + Constants.Currency;
            //
            lblTotalMC.Text = msMasterCategoriesRepo.GetMainCate();
            lblTotalSC.Text = msMasterCategoriesRepo.GetSecCate();
            lblTotalTH.Text = msMasterCategoriesRepo.GetThCate();
            lblTotalVN.Text = msMasterCategoriesRepo.GetVN();
            lblTotalBR.Text = msMasterCategoriesRepo.GetBR();
        }

        private void btnShowSales_Click(object sender, EventArgs e)
        {
            FormSellsHistory sellsHistory = new FormSellsHistory();
            sellsHistory.ShowDialog();
        }

        private void btnShowStock_Click(object sender, EventArgs e)
        {
            FormMasterCategory productsMaster = new FormMasterCategory();
            productsMaster.ShowDialog();
        }

        private void btnShowUser_Click(object sender, EventArgs e)
        {
            FormUser user = new FormUser();
            user.ShowDialog();
        }

        private void btnShowExpenses_Click(object sender, EventArgs e)
        {
            FormExpense expense = new FormExpense();
            expense.ShowDialog();
        }

        private void btnShowSalary_Click(object sender, EventArgs e)
        {
            FormUser user = new FormUser();
            user.ShowDialog();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            FormMasterCategory masterCategory = new FormMasterCategory();
            masterCategory.ShowDialog();
        }

    }
}
