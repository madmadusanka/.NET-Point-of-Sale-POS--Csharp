using IMS.DataAccess;
using IMS.Entity.InventoryProducts;
using IMS.Entity.InventoryProducts.Customers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Repository.InventoryProducts.Customers
{
    public class CustomersRepo
    {
        private InventoryDBDataAccess iDB { get; set; }

        public CustomersRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }
        public Customer GetCustomerByPhone(string phone)
        {
            Customer customer = null;

            string sql;
            try
            {
                sql = @"select top(1) * from customers where CustomerPhone like '%"+ phone.Trim()+"%'";
                var dt = this.iDB.ExecuteQueryTable(sql);
                
                customer = ConvertToEntity(dt.Rows[0]);


            }
            catch (Exception e)
            {
                return null;
                throw;
            }
            return customer;
        }
        public bool Save(Customer customer)
        {
            try
            {
                var sql = string.Format("INSERT INTO Customers (CustomerFullName, CustomerPhone, CustomerEmail, CustomerAddress) " +
                                 "VALUES ('{0}', '{1}', '{2}', '{3}')",customer.CustomerFullName,customer.CustomerPhone,customer.CustomerEmail,customer.CustomerAddress);

                var rowCount = this.iDB.ExecuteDMLQuery(sql);

                if (rowCount == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

        private Customer ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var customer = new Customer();
            customer.CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
            customer.CustomerEmail = row["CustomerEmail"].ToString();
            customer.CustomerPhone = row["CustomerPhone"].ToString();
            customer.CustomerFullName = row["CustomerFullName"].ToString();
            customer.CustomerAddress = row["CustomerAddress"].ToString();
           
            return customer;
        }
    }
}
