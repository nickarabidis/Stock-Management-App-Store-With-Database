using Ofthalmiatrio;
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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            this.ActiveControl = customerDateTimePicker;
            customerCodeTextBox.Enabled = false;
            customerCodeTextBox.MaxLength = 3;
            customerCompanyNameTextBox.MaxLength = 50;
            customerEmailTextBox.MaxLength = 50;
            customerAddressTextBox.MaxLength = 50;
            customerTaxOfficeTextBox.MaxLength = 50;
            customerCellphoneTextBox.MaxLength = 13;
            customerVATNumberTextBox.MaxLength = 9;
            productCodeTextBox.MaxLength = 3;
            productQuantityTextBox.MaxLength = 3;
            LoadData();
            Search();
        }

        private void customerCompanyNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgview.Rows.Count > 0)
                {
                    customerCodeTextBox.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    customerCompanyNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    this.dgview.Visible = false;
                    customerEmailTextBox.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                    customerEmailTextBox.Focus();
                }
            }
        }

        private void customerEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (customerEmailTextBox.Text.Length > 0)
                {
                    customerCellphoneTextBox.Focus();
                }
                else
                {
                    customerEmailTextBox.Focus();
                }
            }
        }

        private void customerCellphoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (customerCellphoneTextBox.Text.Length > 0)
                {
                    customerAddressTextBox.Focus();
                }
                else
                {
                    customerCellphoneTextBox.Focus();
                }
            }
        }

        private void customerAddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (customerAddressTextBox.Text.Length > 0)
                {
                    customerTaxOfficeTextBox.Focus();
                }
                else
                {
                    customerAddressTextBox.Focus();
                }
            }
        }

        private void customerTaxOfficeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (customerTaxOfficeTextBox.Text.Length > 0)
                {
                    customerVATNumberTextBox.Focus();
                }
                else
                {
                    customerTaxOfficeTextBox.Focus();
                }
            }
        }

        private void customerVATNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (customerVATNumberTextBox.Text.Length > 0)
                {
                    productCodeTextBox.Focus();
                }
                else
                {
                    customerVATNumberTextBox.Focus();
                }
            }
        }

        private void productCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productCodeTextBox.Text.Length > 0)
                {
                    productQuantityTextBox.Focus();
                }
                else
                {
                    productCodeTextBox.Focus();
                }
            }
        }
        private void productQuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productQuantityTextBox.Text.Length > 0)
                {
                    customerDateTimePicker.Focus();
                }
                else
                {
                    productQuantityTextBox.Focus();
                }
            }
        }

        private void customerDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (customerDateTimePicker.Text.Length > 0)
                {
                    addButton.Focus();
                }
                else
                {
                    customerDateTimePicker.Focus();
                }
            }
        }

        private void customerCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void customerCellphoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void customerVATNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
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
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(customerCompanyNameTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(customerCompanyNameTextBox, "Company Name Required");
            }
            else if (string.IsNullOrEmpty(customerEmailTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(customerEmailTextBox, "Customer Email Required");
            }
            else if (string.IsNullOrEmpty(customerCellphoneTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(customerCellphoneTextBox, "Customer Cellphone Required");
            }
            else if (string.IsNullOrEmpty(customerAddressTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(customerAddressTextBox, "Customer Address Required");
            }
            else if (string.IsNullOrEmpty(customerTaxOfficeTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(customerTaxOfficeTextBox, "Customer Tax Office Required");
            }
            else if (string.IsNullOrEmpty(customerVATNumberTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(customerVATNumberTextBox, "Customer VAT Number Required");
            }
            else if (string.IsNullOrEmpty(productCodeTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(productCodeTextBox, "Product Code Required");
            }
            else if (string.IsNullOrEmpty(productQuantityTextBox.Text))
            {
                customerErrorProvider.Clear();
                customerErrorProvider.SetError(productQuantityTextBox, "Product Quantity Required");
            }
            else
            {
                customerErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifCustomerExists(SQLiteConnection con, string customerCode)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Customers] WHERE [CustomerCode] = '" + customerCode + "' ", con);
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
                var sqlQueryUpdateQuantity = "";
                var sqlQueryUpdateSalesFrequency = "";
                if (ifCustomerExists(con, customerCodeTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Customers] SET [CustomerName] = '" + customerCompanyNameTextBox.Text + "', [Email] = '" + customerEmailTextBox.Text + "', [Cellphone] = '" + customerCellphoneTextBox.Text + "', [Address] = '" + customerAddressTextBox.Text + "' , [TaxOffice] = '" + customerTaxOfficeTextBox.Text + "' , [VATNumber] = '" + customerVATNumberTextBox.Text + "' , [ProductCode] = '" + productCodeTextBox.Text + "', [Quantity] = '" + productQuantityTextBox.Text + "', [TransDate] = '" + customerDateTimePicker.Value.ToString("MM/dd/yyyy") + "' WHERE [CustomerCode] = '" + customerCodeTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Customers] ([CustomerName],[Email],[Cellphone],[Address],[TaxOffice],[VATNumber],[ProductCode],[Quantity],[TransDate]) VALUES 
                            ('" + customerCompanyNameTextBox.Text + "','" + customerEmailTextBox.Text + "','" + customerCellphoneTextBox.Text + "','" + customerAddressTextBox.Text + "','" + customerTaxOfficeTextBox.Text + "','" + customerVATNumberTextBox.Text + "','" + productCodeTextBox.Text + "','" + productQuantityTextBox.Text + "','" + customerDateTimePicker.Value.ToString("MM/dd/yyyy") + "')";
                    sqlQueryUpdateQuantity = @"UPDATE [Products] SET [Quantity] = [Quantity] - '" + productQuantityTextBox.Text + "' WHERE ProductCode = '" + productCodeTextBox.Text + "'";
                    sqlQueryUpdateSalesFrequency = @"UPDATE [Products] SET [SalesFrequency] = [SalesFrequency] + '" + productQuantityTextBox.Text + "' WHERE ProductCode = '" + productCodeTextBox.Text + "'";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                SQLiteCommand cmdUpdateQuantity = new SQLiteCommand(sqlQueryUpdateQuantity, con);
                SQLiteCommand cmdUpdateSalesFrequency = new SQLiteCommand(sqlQueryUpdateSalesFrequency, con);
                cmd.ExecuteNonQuery();
                cmdUpdateQuantity.ExecuteNonQuery();
                cmdUpdateSalesFrequency.ExecuteNonQuery();

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
                    if (ifCustomerExists(con, customerCodeTextBox.Text))
                    {
                        sqlQuery = @"DELETE FROM [Customers] WHERE [CustomerCode] = '" + customerCodeTextBox.Text + "'";
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
            customerCodeTextBox.Clear();
            customerCompanyNameTextBox.Clear();
            customerEmailTextBox.Clear();
            customerCellphoneTextBox.Clear();
            customerAddressTextBox.Clear();
            customerTaxOfficeTextBox.Clear();
            customerVATNumberTextBox.Clear();
            productCodeTextBox.Clear();
            productQuantityTextBox.Clear();
            customerDateTimePicker.Value = DateTime.Now;
            addButton.Text = "Add";
            customerCompanyNameTextBox.Focus();
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }
        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Customers]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            customerDataGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = customerDataGridView.Rows.Add();
                customerDataGridView.Rows[n].Cells["dgSno"].Value = n + 1;
                customerDataGridView.Rows[n].Cells["dgCusCode"].Value = row["CustomerCode"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusCompanyName"].Value = row["CustomerName"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusEmail"].Value = row["Email"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusCellphone"].Value = row["Cellphone"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusAddress"].Value = row["Address"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusTaxOffice"].Value = row["TaxOffice"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusVATNumber"].Value = row["VATNumber"].ToString();
                customerDataGridView.Rows[n].Cells["dgProCode"].Value = row["ProductCode"].ToString();
                customerDataGridView.Rows[n].Cells["dgProQuantity"].Value = row["Quantity"].ToString();
                customerDataGridView.Rows[n].Cells["dgCusDate"].Value = DateTime.Parse(row["TransDate"].ToString()).ToString("MM/dd/yyyy");
            }

            if (customerDataGridView.Rows.Count > 0)
            {
                totalCustomersValueLabel.Text = customerDataGridView.Rows.Count.ToString();
            }
            else
            {
                totalCustomersValueLabel.Text = "0";
            }
        }
        private void customerDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addButton.Text = "Update";

            customerCodeTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusCode"].Value.ToString();
            customerCompanyNameTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusCompanyName"].Value.ToString();
            customerEmailTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusEmail"].Value.ToString();
            customerCellphoneTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusCellphone"].Value.ToString();
            customerAddressTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusAddress"].Value.ToString();
            customerTaxOfficeTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusTaxOffice"].Value.ToString();
            customerVATNumberTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgCusVATNumber"].Value.ToString();
            productCodeTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            productQuantityTextBox.Text = customerDataGridView.SelectedRows[0].Cells["dgProQuantity"].Value.ToString();
            customerDateTimePicker.Text = DateTime.Parse(customerDataGridView.SelectedRows[0].Cells["dgCusDate"].Value.ToString()).ToString("MM/dd/yyyy");
        }

        //private void customerCodeTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (customerCodeTextBox.Text.Length > 0)
        //    {
        //        this.dgview.Visible = true;
        //        dgview.BringToFront();
        //        Search(33, 137, 250, 150, "Cust Code,Cust Name", "100,0");
        //        this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.customerCode_MouseDoubleClick);
        //        SqlConnection con = Connection.GetConnection();
        //        SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) CustomerCode,CustomerName From [Customers] WHERE [CustomerCode] Like '" + customerCodeTextBox.Text + "%'", con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        dgview.Rows.Clear();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            int n = dgview.Rows.Add();
        //            dgview.Rows[n].Cells[0].Value = row["CustomerCode"].ToString();
        //            dgview.Rows[n].Cells[1].Value = row["CustomerName"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        dgview.Visible = false;
        //    }
        //}

        private void customerCompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (customerCompanyNameTextBox.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(34, 111, 240, 81, "Cust Code,Cust Name", "110,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.customerCode_MouseDoubleClick);
                SQLiteConnection con = Database.GetConnection();
                SQLiteDataAdapter sda = new SQLiteDataAdapter("Select CustomerCode,CustomerName From [Customers] WHERE [CustomerName] Like '" + customerCompanyNameTextBox.Text + "%' LIMIT 10", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["CustomerCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["CustomerName"].ToString();
                }
            }
            else
            {
                dgview.Visible = false;
            }
        }

        //bool change = true;
        //private void customerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (change)
        //    {
        //        change = false;
        //        customerCodeTextBox.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
        //        customerCompanyNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
        //        this.dgview.Visible = false;
        //        customerEmailTextBox.Focus();
        //        change = true;
        //    }
        //}
        private void customerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SQLiteConnection con = Database.GetConnection();
            // Insert Logic

            try
            {
                customerCompanyNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM [Customers] WHERE (CustomerName = '" + customerCompanyNameTextBox.Text + "')", con);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    customerCodeTextBox.Text = reader.GetValue(0).ToString();
                    customerCompanyNameTextBox.Text = reader.GetValue(1).ToString();
                    customerEmailTextBox.Text = reader.GetValue(2).ToString();
                    customerCellphoneTextBox.Text = reader.GetValue(3).ToString();
                    customerAddressTextBox.Text = reader.GetValue(4).ToString();
                    customerTaxOfficeTextBox.Text = reader.GetValue(5).ToString();
                    customerVATNumberTextBox.Text = reader.GetValue(6).ToString();
                    productCodeTextBox.Text = reader.GetValue(7).ToString();
                    productQuantityTextBox.Text = reader.GetValue(8).ToString();
                    customerDateTimePicker.Text = reader.GetValue(9).ToString();
                    addButton.Text = "Update";
                    this.dgview.Visible = false;
                    addButton.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in searching" + ex);
            }
        }

        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;

        void Search()
        {
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
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

        private void printButton_Click(object sender, EventArgs e)
        {
            string path_name;
            var customerCode = Database.getCustomer(customerCodeTextBox.Text);
            var productCode = Database.getProduct(productCodeTextBox.Text);

            SaveFileDialog print = new SaveFileDialog();
            print.Filter = "Pdf Files|*.pdf";
            if (print.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path_name = print.FileName;
                try
                {
                    PdfMaker.getCustomer(path_name, customerCode, productCode);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }
    }
}
