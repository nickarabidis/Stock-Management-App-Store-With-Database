using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private void Products_Load(object sender, EventArgs e)
        {
            this.ActiveControl = productEditDateTimePicker;
            this.productCodeTextBox.Enabled = false;
            this.productSalesFrequencyTextBox.Enabled = false;
            this.productCodeTextBox.MaxLength = 3;
            this.productNameTextBox.MaxLength = 50;
            this.productCategoryTextBox.MaxLength = 50;
            this.productQuantityTextBox.MaxLength = 3;
            this.productQuantityMinTextBox.MaxLength = 3;
            this.productReleaseDateTextBox.MaxLength = 4;
            this.productPriceTextBox.MaxLength = 4;
            this.productRealPriceTextBox.MaxLength = 4;

            LoadData();
            Search();
        }

        private void productNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgview.Rows.Count > 0)
                {
                    productCodeTextBox.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    productNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    productCategoryTextBox.Text = dgview.SelectedRows[0].Cells[2].Value.ToString();
                    this.dgview.Visible = false;
                    productCategoryTextBox.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                    productCategoryTextBox.Focus();
                }
            }
        }

        private void productCategoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productCategoryTextBox.Text.Length > 0)
                {
                    productQuantityTextBox.Focus();
                }
                else
                {
                    productCategoryTextBox.Focus();
                }
            }
        }

        private void productQuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productQuantityTextBox.Text.Length > 0)
                {
                    productQuantityMinTextBox.Focus();
                }
                else
                {
                    productQuantityTextBox.Focus();
                }
            }
        }
        private void productQuantityMinTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productQuantityMinTextBox.Text.Length > 0)
                {
                    productReleaseDateTextBox.Focus();
                }
                else
                {
                    productQuantityMinTextBox.Focus();
                }
            }
        }
        private void productReleaseDateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productReleaseDateTextBox.Text.Length > 0)
                {
                    productPriceTextBox.Focus();
                }
                else
                {
                    productReleaseDateTextBox.Focus();
                }
            }
        }

        private void productPriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productPriceTextBox.Text.Length > 0)
                {
                    productRealPriceTextBox.Focus();
                }
                else
                {
                    productPriceTextBox.Focus();
                }
            }
        }

        private void productRealPriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productRealPriceTextBox.Text.Length > 0)
                {
                    productEditDateTimePicker.Focus();
                }
                else
                {
                    productRealPriceTextBox.Focus();
                }
            }
        }

        private void productEditDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productEditDateTimePicker.Text.Length > 0)
                {
                    addButton.Focus();
                }
                else
                {
                    productEditDateTimePicker.Focus();
                }
            }
        }


        private void productCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void productQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back )
            {
                e.Handled = true;
            }
        }

        private void productQuantityMinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back )
            {
                e.Handled = true;
            }
        }

        private void productPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & e.KeyChar != '€' & e.KeyChar != '$')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                productPriceTextBox.MaxLength = productPriceTextBox.Text.Length + 3;
            }
            else if((Keys)e.KeyChar == Keys.Back)
            {
                productPriceTextBox.MaxLength = 4;
            }
        }

        private void productRealPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & e.KeyChar != '€' & e.KeyChar != '$')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                productRealPriceTextBox.MaxLength = productRealPriceTextBox.Text.Length + 3;
            }
            else if ((Keys)e.KeyChar == Keys.Back)
            {
                productRealPriceTextBox.MaxLength = 4;
            }
        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(productNameTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productNameTextBox, "Product Name Required");
            }
            else if (string.IsNullOrEmpty(productCategoryTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productCategoryTextBox, "Product Category Required");
            }
            else if (string.IsNullOrEmpty(productQuantityTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productQuantityTextBox, "Product Quantity Required");
            }
            else if (string.IsNullOrEmpty(productQuantityMinTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productQuantityMinTextBox, "Product Quantity Min Required");
            }
            else if (string.IsNullOrEmpty(productReleaseDateTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productReleaseDateTextBox, "Product Release Date Required");
            }
            else if (string.IsNullOrEmpty(productPriceTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productPriceTextBox, "Product Price Required");
            }
            else if (string.IsNullOrEmpty(productRealPriceTextBox.Text))
            {
                productErrorProvider.Clear();
                productErrorProvider.SetError(productRealPriceTextBox, "Product Price Required");
            }
            else
            {
                productErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifProductExists(SQLiteConnection con, string productCode)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Products] WHERE [ProductCode] = '" + productCode + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SQLiteConnection con = Database.GetConnection();
                // Insert Logic
                

                var sqlQuery = "";
                if (ifProductExists(con, productCodeTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + productNameTextBox.Text + "', [Category] = '" + productCategoryTextBox.Text + "', [Quantity] = '" + productQuantityTextBox.Text + "', [QuantityMin] = '" + productQuantityMinTextBox.Text + "', [ReleaseDate] = '" + productReleaseDateTextBox.Text + "', [Price] = '" + productPriceTextBox.Text + "', [RealPrice] = '" + productRealPriceTextBox.Text + "', [EditDate] = '" + productEditDateTimePicker.Value.ToString("MM/dd/yyyy") + "', [CreationDate] = '" + productCreationDateTimePicker.Value.ToString("MM/dd/yyyy") + "', [SalesFrequency] = '" + productSalesFrequencyTextBox.Text + "' WHERE [ProductCode] = '" + productCodeTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Products] ([ProductName],[Category],[Quantity],[QuantityMin],[ReleaseDate],[Price],[RealPrice],[EditDate],[CreationDate],[SalesFrequency]) VALUES 
                            ('" + productNameTextBox.Text + "','" + productCategoryTextBox.Text + "','" + productQuantityTextBox.Text + "','" + productQuantityMinTextBox.Text + "','" + productReleaseDateTextBox.Text + "','" + productPriceTextBox.Text + "','" + productRealPriceTextBox.Text + "','" + productEditDateTimePicker.Value.ToString("MM/dd/yyyy") + "','" + productCreationDateTimePicker.Value.ToString("MM/dd/yyyy") + "','" + productSalesFrequencyTextBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                

                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ClearRecords();
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifProductExists(con, productCodeTextBox.Text))
                    {
                        
                        sqlQuery = @"DELETE FROM [Products] WHERE [ProductCode] = '" + productCodeTextBox.Text + "'";
                        SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Record Deleted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record Doesn't Exist!");
                    }
                    LoadData();
                    ClearRecords();
                }
            }
        }

        private void ClearRecords()
        {
            productCodeTextBox.Clear();
            productNameTextBox.Clear();
            productCategoryTextBox.Clear();
            productQuantityTextBox.Clear();
            productQuantityMinTextBox.Clear();
            productReleaseDateTextBox.Clear();
            productPriceTextBox.Clear();
            productRealPriceTextBox.Clear();
            productEditDateTimePicker.Value = DateTime.Now;
            productCreationDateTimePicker.Value = DateTime.Now;
            productSalesFrequencyTextBox.Clear();
            addButton.Text = "Add";
            productNameTextBox.Focus();
            productCreationDateTimePicker.Enabled = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            productDataGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = productDataGridView.Rows.Add();
                productDataGridView.Rows[n].Cells["dgSno"].Value = n + 1;
                productDataGridView.Rows[n].Cells["dgProCode"].Value = row["ProductCode"].ToString();
                productDataGridView.Rows[n].Cells["dgProName"].Value = row["ProductName"].ToString();
                productDataGridView.Rows[n].Cells["dgProCategory"].Value = row["Category"].ToString();
                productDataGridView.Rows[n].Cells["dgProQuantity"].Value = float.Parse(row["Quantity"].ToString());
                productDataGridView.Rows[n].Cells["dgProQuantityMin"].Value = float.Parse(row["QuantityMin"].ToString());
                productDataGridView.Rows[n].Cells["dgProReleaseDate"].Value = row["ReleaseDate"].ToString();
                productDataGridView.Rows[n].Cells["dgProPrice"].Value = float.Parse(row["Price"].ToString());
                productDataGridView.Rows[n].Cells["dgProRealPrice"].Value = float.Parse(row["RealPrice"].ToString());
                productDataGridView.Rows[n].Cells["dgProEditDate"].Value = DateTime.Parse(row["EditDate"].ToString()).ToString("MM/dd/yyyy");
                productDataGridView.Rows[n].Cells["dgProCreationDate"].Value = DateTime.Parse(row["CreationDate"].ToString()).ToString("MM/dd/yyyy");
                productDataGridView.Rows[n].Cells["dgProSalesFrequency"].Value = float.Parse(row["SalesFrequency"].ToString());
            }

            if (productDataGridView.Rows.Count > 0)
            {
                totalProductsValueLabel.Text = productDataGridView.Rows.Count.ToString();
                float totQty = 0;

                for (int i = 0; i < productDataGridView.Rows.Count; i++)
                {
                    totQty += float.Parse(productDataGridView.Rows[i].Cells["dgProQuantity"].Value.ToString());
                    totalQuantityValueLabel.Text = totQty.ToString();
                }
            }
            else
            {
                totalProductsValueLabel.Text = "0";
                totalQuantityValueLabel.Text = "0";
            }
        }

        private void productDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addButton.Text = "Update";
            productCreationDateTimePicker.Enabled = false;
            productCodeTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            productNameTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProName"].Value.ToString();
            productCategoryTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProCategory"].Value.ToString();
            productQuantityTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProQuantity"].Value.ToString();
            productQuantityMinTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProQuantityMin"].Value.ToString();
            productReleaseDateTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProReleaseDate"].Value.ToString();
            productPriceTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProPrice"].Value.ToString();
            productRealPriceTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProRealPrice"].Value.ToString();
            productEditDateTimePicker.Text = DateTime.Parse(productDataGridView.SelectedRows[0].Cells["dgProEditDate"].Value.ToString()).ToString("MM/dd/yyyy");
            productCreationDateTimePicker.Text = DateTime.Parse(productDataGridView.SelectedRows[0].Cells["dgProCreationDate"].Value.ToString()).ToString("MM/dd/yyyy");
            productSalesFrequencyTextBox.Text = productDataGridView.SelectedRows[0].Cells["dgProSalesFrequency"].Value.ToString();

        }

        //private void productCodeTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (productCodeTextBox.Text.Length > 0)
        //    {
        //        if (true)
        //        {
        //            this.dgview.Visible = true;
        //            dgview.BringToFront();
        //            Search(37, 122, 264, 170, "Prod Code,Prod Name", "100,0");
        //            this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);
        //            SqlConnection con = Connection.GetConnection();
        //            SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) ProductCode,ProductName From [Products] WHERE [ProductCode] Like '" + productCodeTextBox.Text + "%'", con);
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);
        //            dgview.Rows.Clear();
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                int n = dgview.Rows.Add();
        //                dgview.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
        //                dgview.Rows[n].Cells[1].Value = row["ProductName"].ToString();
        //            } 
        //        }
        //    }
        //    else
        //    {
        //        dgview.Visible = false;
        //    }
        //}

        private void productNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (productNameTextBox.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(37, 113, 363, 87, "Prod Code,Prod Name,Prod Cat", "116,125,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);
                SQLiteConnection con = Database.GetConnection();
                SQLiteDataAdapter sda = new SQLiteDataAdapter("Select ProductCode,ProductName,Category From [Products] WHERE [ProductName] Like '" + productNameTextBox.Text + "%' LIMIT 10", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["ProductName"].ToString();
                    dgview.Rows[n].Cells[2].Value = row["Category"].ToString();

                }
            }
            else
            {
                dgview.Visible = false;
            }
        }


        private void productCategoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (productCategoryTextBox.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(37, 113, 363, 87, "Prod Code,Prod Name,Prod Cat", "116,125,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);
                SQLiteConnection con = Database.GetConnection();
                SQLiteDataAdapter sda = new SQLiteDataAdapter("Select ProductCode,ProductName,Category From [Products] WHERE [Category] Like '" + productCategoryTextBox.Text + "%' LIMIT 10", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["ProductName"].ToString();
                    dgview.Rows[n].Cells[2].Value = row["Category"].ToString();

                }
            }
            else
            {
                dgview.Visible = false;
            }
        }


        //bool change = true;
        //private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (change)
        //    {
        //        change = false;
        //        productCodeTextBox.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
        //        productNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
        //        productCategoryTextBox.Text = dgview.SelectedRows[0].Cells[2].Value.ToString();
        //        this.dgview.Visible = false;
        //        productQuantityTextBox.Focus();
        //        change = true;
        //    }
        //}

        private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SQLiteConnection con = Database.GetConnection();
            // Insert Logic
            

            try
            {
                productNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM [Products] WHERE (ProductName = '" + productNameTextBox.Text + "')", con);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    productCodeTextBox.Text = reader.GetValue(0).ToString();
                    productNameTextBox.Text = reader.GetValue(1).ToString();
                    productCategoryTextBox.Text = reader.GetValue(2).ToString();
                    productQuantityTextBox.Text = reader.GetValue(3).ToString();
                    productQuantityMinTextBox.Text = reader.GetValue(4).ToString();
                    productReleaseDateTextBox.Text = reader.GetValue(5).ToString();
                    productPriceTextBox.Text = reader.GetValue(6).ToString();
                    productRealPriceTextBox.Text = reader.GetValue(7).ToString();
                    productCreationDateTimePicker.Text = reader.GetValue(9).ToString();
                    productSalesFrequencyTextBox.Text = reader.GetValue(10).ToString();
                    addButton.Text = "Update";
                    this.dgview.Visible = false;
                    productCreationDateTimePicker.Enabled = false;
                    addButton.Focus();
                }
            }
            catch(Exception ex){
                MessageBox.Show("Error in searching" + ex);
            }
        }


        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;
        private DataGridViewTextBoxColumn dgviewcol3;

        void Search()
        {
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            dgviewcol3 = new DataGridViewTextBoxColumn();
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2, this.dgviewcol3 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
            this.dgviewcol3.Visible = false;
            this.dgview.AllowUserToAddRows = false;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dgview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgview_KeyDown);

            this.Controls.Add(dgview);
            this.dgview.ReadOnly = true;
            dgview.BringToFront();
        }

        //Two Column
        void Search(int LX, int LY, int DW, int DH, string ColName, String ColSize)
        {
            this.dgview.Location = new System.Drawing.Point(LX, LY);
            this.dgview.Size = new System.Drawing.Size(DW, DH);

            string[] ClSize = ColSize.Split(',');
            //Size
            for (int i = 0; i < ClSize.Length; i++)
            {
                if (int.Parse(ClSize[i]) != 0)
                {
                    dgview.Columns[i].Width = int.Parse(ClSize[i]);
                }
                else
                {
                    dgview.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            //Name 
            string[] ClName = ColName.Split(',');

            for (int i = 0; i < ClName.Length; i++)
            {
                this.dgview.Columns[i].HeaderText = ClName[i];
                this.dgview.Columns[i].Visible = true;
            }
        }

        private void bestSellersButton_Click(object sender, EventArgs e)
        {
            BestSeller bestSellers = new BestSeller();
            bestSellers.Show();
        }

        private void productDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in productDataGridView.Rows)
            {
                int quantity = Convert.ToInt32(row.Cells["dgProQuantity"].Value);
                int quantityMin = Convert.ToInt32(row.Cells["dgProQuantityMin"].Value);

                if (quantity < quantityMin)
                {
                    row.Cells["dgProQuantity"].Style.ForeColor = Color.Red;
                    row.Cells["dgProQuantityMin"].Style.ForeColor = Color.Red;
                }
                else if (quantity == quantityMin)
                {
                    row.Cells["dgProQuantity"].Style.ForeColor = Color.DarkOrange;
                    row.Cells["dgProQuantityMin"].Style.ForeColor = Color.DarkOrange;
                }
            }
        }


    }
}
