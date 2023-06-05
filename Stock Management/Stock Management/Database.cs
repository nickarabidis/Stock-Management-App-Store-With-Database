using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Stock_Management
{
    internal class Database
    {
        private static bool check = true;
        private static SQLiteConnection con;
        private static SQLiteCommand sqlite_cmd;

        /*
         we create the connection of the db
        and it returns sqliteconnection we need for the other functions
         
         */


        //____________________________________SETUP____________________________________________
        public static void CreateDb()
        {
            if (check)
            {

                //con = new SQLiteConnection($"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db/database.accdb; Version = 3; New = True; Compress = True; ");
                con = new SQLiteConnection($"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db/database.db; Version = 3; New = True; Compress = True; ");
                con.Open();
                check = false;
            }
        }

        /*
         
            Get database connection
         
         */
        public static SQLiteConnection GetConnection()
        {
            return con;
        }

        /*
         
         We create and set up the db tables 
          the parammeter is to get the connection
         
         */


        public static void CreateTables()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Login(UserName VARCHAR(50) PRIMARY KEY,Password VARCHAR(50) NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
            
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Products(ProductCode INTEGER PRIMARY KEY AUTOINCREMENT,ProductName VARCHAR(150) NULL,Category VARCHAR(150) NULL,Quantity FLOAT NULL,QuantityMin FLOAT NULL,ReleaseDate VARCHAR(150) NULL,Price FLOAT NULL,RealPrice FLOAT NULL,EditDate VARCHAR(150) NULL,CreationDate VARCHAR(150) NULL,SalesFrequency FLOAT NULL)";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Providers(ProviderCode INTEGER PRIMARY KEY AUTOINCREMENT,ProviderName VARCHAR(150) NULL,Email VARCHAR(150) NULL,Cellphone VARCHAR(150) NULL,Website VARCHAR(150) NULL,ProductCode INTEGER NOT NULL,Quantity FLOAT NULL,TransDate VARCHAR(150) NULL)";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Customers(CustomerCode INTEGER PRIMARY KEY AUTOINCREMENT,CustomerName VARCHAR(150) NULL,Email VARCHAR(150) NULL,Cellphone VARCHAR(150) NULL,Address VARCHAR(150) NULL,TaxOffice VARCHAR(150) NULL,VATNumber VARCHAR(150) NULL,ProductCode INTEGER NOT NULL,Quantity FLOAT NULL,TransDate VARCHAR(150) NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertLogin()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = $"INSERT INTO Login(UserName,Password) VALUES('{"admin"}','{"admin123"}')";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = $"INSERT INTO Login(UserName,Password) VALUES('{"employee"}','{"employee123"}')";
            sqlite_cmd.ExecuteNonQuery();
        }

        /* 
         we get 2 parameters , username and password 
         both of them are strings

         it returns an sqlite reader with the role of the user .
        
         */
        //public static SqliteDataReader Login(string UserName, string Password)
        //{
        //    sqlite_cmd = conn.CreateCommand();

        //    string logincomm = $"SELECT * FROM Login WHERE UserName= '{UserName}' AND Password='{Password}'";
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = logincomm;
        //    sqlite_cmd.CommandType = CommandType.Text;
        //    SqliteDataReader myReader = sqlite_cmd.ExecuteReader();


        //    return myReader;
        //}

        //// add Product
        //public void addProduct(string ProductName, string Category, float Quantity, float QuantityMin, string ReleaseDate, float Price, float RealPrice, DateTime EditDate, DateTime CreationDate)
        //{
        //    sqlite_cmd = conn.CreateCommand();
        //    string addProduct = $"INSERT INTO Products(ProductName,Category,Quantity,QuantityMin,ReleaseDate,Price,RealPrice,EditDate,CreationDate) VALUES('{ProductName}','{Category}','{Quantity}',{QuantityMin},{ReleaseDate},{Price},{RealPrice},{EditDate},{CreationDate})";
        //    sqlite_cmd.CommandText = addProduct;
        //    sqlite_cmd.ExecuteNonQuery();

        //}


        ////get name from product
        //public static SqliteDataReader getProductName()
        //{
        //    sqlite_cmd = conn.CreateCommand();
        //    string getamkas = "SELECT ProductName FROM Products";
        //    sqlite_cmd.CommandText = getamkas;
        //    sqlite_cmd.CommandType = CommandType.Text;
        //    SqliteDataReader myReader = sqlite_cmd.ExecuteReader();
        //    return myReader;

        //}

        

        public static SQLiteDataReader getProduct(string ProductCode)
        {
            sqlite_cmd = con.CreateCommand();


            string getCustomers = $"SELECT * FROM Products WHERE ProductCode = {ProductCode}";


            sqlite_cmd.CommandText = getCustomers;
            sqlite_cmd.CommandType = CommandType.Text;
            SQLiteDataReader myReader = sqlite_cmd.ExecuteReader();
            return myReader;
        }

        public static SQLiteDataReader getProvider(string ProviderCode)
        {
            sqlite_cmd = con.CreateCommand();


            string getProviders = $"SELECT * FROM Providers WHERE ProviderCode = {ProviderCode}";


            sqlite_cmd.CommandText = getProviders;
            sqlite_cmd.CommandType = CommandType.Text;
            SQLiteDataReader myReader = sqlite_cmd.ExecuteReader();
            return myReader;
        }

        public static SQLiteDataReader getCustomer(string CustomerCode)
        {
            sqlite_cmd = con.CreateCommand();


            string getCustomers = $"SELECT * FROM Customers WHERE CustomerCode = {CustomerCode}";


            sqlite_cmd.CommandText = getCustomers;
            sqlite_cmd.CommandType = CommandType.Text;
            SQLiteDataReader myReader = sqlite_cmd.ExecuteReader();
            return myReader;
        }
    }
}
