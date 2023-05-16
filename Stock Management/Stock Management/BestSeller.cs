using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management
{
    public partial class BestSeller : Form
    {
        public BestSeller()
        {
            InitializeComponent();
        }
        private void BestSeller_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Products] ORDER BY [SalesFrequency] LIMIT 10", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bestSellerProductsDataGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = bestSellerProductsDataGridView.Rows.Add();
                bestSellerProductsDataGridView.Rows[n].Cells["dgSno"].Value = n + 1;
                bestSellerProductsDataGridView.Rows[n].Cells["dgProCode"].Value = row["ProductCode"].ToString();
                bestSellerProductsDataGridView.Rows[n].Cells["dgProName"].Value = row["ProductName"].ToString();
                bestSellerProductsDataGridView.Rows[n].Cells["dgProCategory"].Value = row["Category"].ToString();
                bestSellerProductsDataGridView.Rows[n].Cells["dgProQuantity"].Value = float.Parse(row["Quantity"].ToString());
                bestSellerProductsDataGridView.Rows[n].Cells["dgProQuantityMin"].Value = float.Parse(row["QuantityMin"].ToString());
                bestSellerProductsDataGridView.Rows[n].Cells["dgProReleaseDate"].Value = row["ReleaseDate"].ToString();
                bestSellerProductsDataGridView.Rows[n].Cells["dgProPrice"].Value = float.Parse(row["Price"].ToString());
                bestSellerProductsDataGridView.Rows[n].Cells["dgProRealPrice"].Value = float.Parse(row["RealPrice"].ToString());
                bestSellerProductsDataGridView.Rows[n].Cells["dgProEditDate"].Value = DateTime.Parse(row["EditDate"].ToString()).ToString("MM/dd/yyyy");
                bestSellerProductsDataGridView.Rows[n].Cells["dgProCreationDate"].Value = DateTime.Parse(row["CreationDate"].ToString()).ToString("MM/dd/yyyy");
                bestSellerProductsDataGridView.Rows[n].Cells["dgProSalesFrequency"].Value = float.Parse(row["SalesFrequency"].ToString());
            }
        }

    }
}
