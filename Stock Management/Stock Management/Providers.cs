using Ofthalmiatrio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management
{
    public partial class Providers : Form
    {
        public Providers()
        {
            InitializeComponent();
            websiteButton.Click += OpenWebsite;
        }
        private void Providers_Load(object sender, EventArgs e)
        {
            this.ActiveControl = providerDateTimePicker;
            providerCodeTextBox.Enabled = false;
            providerCodeTextBox.MaxLength = 3;
            providerCompanyNameTextBox.MaxLength = 50;
            providerEmailTextBox.MaxLength = 50;
            providerWebsiteTextBox.MaxLength = 50;
            providerCellphoneTextBox.MaxLength = 13;
            productCodeTextBox.MaxLength = 3;
            productQuantityTextBox.MaxLength = 3;
            LoadData();
            Search();
        }

        private void providerCompanyNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgview.Rows.Count > 0)
                {
                    providerCodeTextBox.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    providerCompanyNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    this.dgview.Visible = false;
                    providerEmailTextBox.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                    providerEmailTextBox.Focus();
                }
            }
        }


        private void providerEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (providerEmailTextBox.Text.Length > 0)
                {
                    providerCellphoneTextBox.Focus();
                }
                else
                {
                    providerEmailTextBox.Focus();
                }
            }
        }

        private void providerCellphoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (providerCellphoneTextBox.Text.Length > 0)
                {
                    providerWebsiteTextBox.Focus();
                }
                else
                {
                    providerCellphoneTextBox.Focus();
                }
            }
        }

        private void providerWebsiteTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (providerWebsiteTextBox.Text.Length > 0)
                {
                    productCodeTextBox.Focus();
                }
                else
                {
                    providerWebsiteTextBox.Focus();
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
                    providerDateTimePicker.Focus();
                }
                else
                {
                    productQuantityTextBox.Focus();
                }
            }
        }

        private void providerDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (providerDateTimePicker.Text.Length > 0)
                {
                    addButton.Focus();
                }
                else
                {
                    providerDateTimePicker.Focus();
                }
            }
        }

        private void providerCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void providerCellphoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '+')
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
            if (string.IsNullOrEmpty(providerCompanyNameTextBox.Text))
            {
                providerErrorProvider.Clear();
                providerErrorProvider.SetError(providerCompanyNameTextBox, "Company Name Required");
            }
            else if (string.IsNullOrEmpty(providerEmailTextBox.Text))
            {
                providerErrorProvider.Clear();
                providerErrorProvider.SetError(providerEmailTextBox, "Provider Email Required");
            }
            else if (string.IsNullOrEmpty(providerCellphoneTextBox.Text))
            {
                providerErrorProvider.Clear();
                providerErrorProvider.SetError(providerCellphoneTextBox, "Provider Cellphone Required");
            }
            else if (string.IsNullOrEmpty(providerWebsiteTextBox.Text))
            {
                providerErrorProvider.Clear();
                providerErrorProvider.SetError(providerWebsiteTextBox, "Provider Website Required");
            }
            else if (string.IsNullOrEmpty(productCodeTextBox.Text))
            {
                providerErrorProvider.Clear();
                providerErrorProvider.SetError(productCodeTextBox, "Product Code Required");
            }
            else if (string.IsNullOrEmpty(productQuantityTextBox.Text))
            {
                providerErrorProvider.Clear();
                providerErrorProvider.SetError(productQuantityTextBox, "Product Quantity Required");
            }
            else
            {
                providerErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifProviderExists(SQLiteConnection con, string providerCode)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Providers] WHERE [ProviderCode] = '" + providerCode + "' ", con);
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
                if (ifProviderExists(con, providerCodeTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Providers] SET [ProviderName] = '" + providerCompanyNameTextBox.Text + "', [Email] = '" + providerEmailTextBox.Text + "', [Cellphone] = '" + providerCellphoneTextBox.Text + "', [Website] = '" + providerWebsiteTextBox.Text + "' , [ProductCode] = '" + productCodeTextBox.Text + "', [Quantity] = '" + productQuantityTextBox.Text + "', [TransDate] = '" + providerDateTimePicker.Value.ToString("MM/dd/yyyy") + "' WHERE [ProviderCode] = '" + providerCodeTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Providers] ([ProviderName],[Email],[Cellphone],[Website],[ProductCode],[Quantity],[TransDate]) VALUES 
                            ('" + providerCompanyNameTextBox.Text + "','" + providerEmailTextBox.Text + "','" + providerCellphoneTextBox.Text + "','" + providerWebsiteTextBox.Text + "','" + productCodeTextBox.Text + "','" + productQuantityTextBox.Text + "','" + providerDateTimePicker.Value.ToString("MM/dd/yyyy") + "')";
                    sqlQueryUpdateQuantity = @"UPDATE [Products] SET [Quantity] = [Quantity] + '" + productQuantityTextBox.Text + "' WHERE ProductCode = '" + productCodeTextBox.Text + "'"; //AND ProductCode IN (SELECT ProductCode FROM Providers WHERE ProductCode = '" + productCodeTextBox.Text + "')
   
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                SQLiteCommand cmdUpdateQuantity = new SQLiteCommand(sqlQueryUpdateQuantity, con);
                cmd.ExecuteNonQuery();
                cmdUpdateQuantity.ExecuteNonQuery();
                

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
                    if (ifProviderExists(con, providerCodeTextBox.Text))
                    {
                       
                        sqlQuery = @"DELETE FROM [Providers] WHERE [ProviderCode] = '" + providerCodeTextBox.Text + "'";
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
            providerCodeTextBox.Clear();
            providerCompanyNameTextBox.Clear();
            providerEmailTextBox.Clear();
            providerCellphoneTextBox.Clear();
            providerWebsiteTextBox.Clear();
            productCodeTextBox.Clear();
            productQuantityTextBox.Clear();
            providerDateTimePicker.Value = DateTime.Now;
            addButton.Text = "Add";
            providerCompanyNameTextBox.Focus();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Providers]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            providerDataGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = providerDataGridView.Rows.Add();
                providerDataGridView.Rows[n].Cells["dgSno"].Value = n + 1;
                providerDataGridView.Rows[n].Cells["dgProviderCode"].Value = row["ProviderCode"].ToString();
                providerDataGridView.Rows[n].Cells["dgProviderCompanyName"].Value = row["ProviderName"].ToString();
                providerDataGridView.Rows[n].Cells["dgProviderEmail"].Value = row["Email"].ToString();
                providerDataGridView.Rows[n].Cells["dgProviderCellphone"].Value = row["Cellphone"].ToString();
                providerDataGridView.Rows[n].Cells["dgProviderWebsite"].Value = row["Website"].ToString();
                providerDataGridView.Rows[n].Cells["dgProCode"].Value = row["ProductCode"].ToString();
                providerDataGridView.Rows[n].Cells["dgProQuantity"].Value = row["Quantity"].ToString();
                providerDataGridView.Rows[n].Cells["dgProviderDate"].Value = DateTime.Parse(row["TransDate"].ToString()).ToString("MM/dd/yyyy");
            }

            if (providerDataGridView.Rows.Count > 0)
            {
                totalProvidersValueLabel.Text = providerDataGridView.Rows.Count.ToString();
            }
            else
            {
                totalProvidersValueLabel.Text = "0";
            }
        }

        private void providerDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addButton.Text = "Update";

            providerCodeTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProviderCode"].Value.ToString();
            providerCompanyNameTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProviderCompanyName"].Value.ToString();
            providerEmailTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProviderEmail"].Value.ToString();
            providerCellphoneTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProviderCellphone"].Value.ToString();
            providerWebsiteTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProviderWebsite"].Value.ToString();
            productCodeTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            productQuantityTextBox.Text = providerDataGridView.SelectedRows[0].Cells["dgProQuantity"].Value.ToString();
            providerDateTimePicker.Text = DateTime.Parse(providerDataGridView.SelectedRows[0].Cells["dgProviderDate"].Value.ToString()).ToString("MM/dd/yyyy");
        }

        //private void providerCodeTextBox_TextChanged(object sender, EventArgs e)
        //{

        //    if (providerCodeTextBox.Text.Length > 0)
        //    {
        //        this.dgview.Visible = true;
        //        dgview.BringToFront();
        //        Search(50, 116, 308, 164, "Prov Code,Prov Name", "100,0");
        //        this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.providerCode_MouseDoubleClick);
        //        SqlConnection con = Connection.GetConnection();
        //        SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) ProviderCode,ProviderName From [Providers] WHERE [ProviderCode] Like '" + providerCodeTextBox.Text + "%'", con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        dgview.Rows.Clear();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            int n = dgview.Rows.Add();
        //            dgview.Rows[n].Cells[0].Value = row["ProviderCode"].ToString();
        //            dgview.Rows[n].Cells[1].Value = row["ProviderName"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        dgview.Visible = false;
        //    }
        //}

        private void providerCompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (providerCompanyNameTextBox.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(50, 116, 232, 90, "Prov Code,Prov Name", "110,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.providerCode_MouseDoubleClick);
                SQLiteConnection con = Database.GetConnection();
                SQLiteDataAdapter sda = new SQLiteDataAdapter("Select ProviderCode,ProviderName From [Providers] WHERE [ProviderName] Like '" + providerCompanyNameTextBox.Text + "%' LIMIT 10", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["ProviderCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["ProviderName"].ToString();
                }
            }
            else
            {
                dgview.Visible = false;
            }
        }
        //bool change = true;
        //private void providerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (change)
        //    {
        //        change = false;
        //        providerCodeTextBox.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
        //        providerCompanyNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
        //        this.dgview.Visible = false;
        //        providerEmailTextBox.Focus();
        //        change = true;
        //    }
        //}

        private void providerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SQLiteConnection con = Database.GetConnection();
            // Insert Logic

            try
            {
                providerCompanyNameTextBox.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM [Providers] WHERE (ProviderName = '" + providerCompanyNameTextBox.Text + "')", con);
                SQLiteDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    providerCodeTextBox.Text = reader.GetValue(0).ToString();
                    providerCompanyNameTextBox.Text = reader.GetValue(1).ToString();
                    providerEmailTextBox.Text = reader.GetValue(2).ToString();
                    providerCellphoneTextBox.Text = reader.GetValue(3).ToString();
                    providerWebsiteTextBox.Text = reader.GetValue(4).ToString();
                    productCodeTextBox.Text = reader.GetValue(5).ToString();
                    productQuantityTextBox.Text = reader.GetValue(6).ToString();
                    providerDateTimePicker.Text = reader.GetValue(7).ToString();
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

        private void websiteButton_Click(object sender, EventArgs e)
        {
            Process.Start(providerWebsiteTextBox.Text);
        }

        private void OpenWebsite(object sender, EventArgs e)
        {
            string url = providerWebsiteTextBox.Text;

            // Check if the URL is not empty
            if (!string.IsNullOrWhiteSpace(url))
            {
                // Check if the URL doesn't start with "http://" or "https://", and add it if missing
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                try
                {
                    // Open the URL in the default web browser
                    Process.Start(url);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the process
                    MessageBox.Show("not an invalid link " + ex.Message);
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            string path_name;
            var providerCode = Database.getProvider(providerCodeTextBox.Text);
            var productCode = Database.getProduct(productCodeTextBox.Text);

            SaveFileDialog print = new SaveFileDialog();
            print.Filter = "Pdf Files|*.pdf";
            if (print.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path_name = print.FileName;
                try
                {
                    PdfMaker.getProvider(path_name, providerCode, productCode);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }
    }
}
