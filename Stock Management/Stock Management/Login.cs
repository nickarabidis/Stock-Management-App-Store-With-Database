using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            usernameTextbox.MaxLength = 50;
            passwordTextbox.MaxLength = 50;
            /*
            if the db doesnt exists it creates the db connection
            and setup the tables

            if it exists it just create the connection
            */

            if (!Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db"))
            {
                Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db");
            }
            if (!(File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db/database.db")))

            {
                Database.CreateDb();
                Database.CreateTables();
                Database.InsertLogin();

            }

            else
            {
                Database.CreateDb();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // .Text = "" and .Clear() do the same
            usernameTextbox.Text = "";
            passwordTextbox.Clear();

            usernameTextbox.Focus();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = Database.GetConnection();
            SQLiteDataAdapter sda = new SQLiteDataAdapter(@"SELECT * FROM Login Where UserName='" + usernameTextbox.Text + "' and Password='" + passwordTextbox.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();

                if (usernameTextbox.Text == "employee")
                {
                    employeeStockMain main2 = new employeeStockMain();
                    main2.Show();
                    this.Hide();

                }
                else if (usernameTextbox.Text == "admin")
                {
                    adminStockMain main = new adminStockMain(); // pass username value to constructor
                    main.Show();
                    this.Hide();
                }
            }

            else
            {
                MessageBox.Show("Invalid Username & Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearButton_Click(sender, e);
            }
        }


        
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
