namespace Stock_Management
{
    partial class Providers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Providers));
            this.providerDataGridView = new System.Windows.Forms.DataGridView();
            this.dgSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProviderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProviderCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProviderEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProviderCellphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProviderWebsite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProviderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerWebsiteTextBox = new System.Windows.Forms.TextBox();
            this.providerWebsiteLabel = new System.Windows.Forms.Label();
            this.providerEmailTextBox = new System.Windows.Forms.TextBox();
            this.providerEmailLabel = new System.Windows.Forms.Label();
            this.providerDateLabel = new System.Windows.Forms.Label();
            this.providerDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.providerCellphoneTextBox = new System.Windows.Forms.TextBox();
            this.providerCellphoneLabel = new System.Windows.Forms.Label();
            this.providerCompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.providerCodeTextBox = new System.Windows.Forms.TextBox();
            this.providerCompanyNameLabel = new System.Windows.Forms.Label();
            this.productCodeLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.providerErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.totalProvidersLabel = new System.Windows.Forms.Label();
            this.totalProvidersValueLabel = new System.Windows.Forms.Label();
            this.productQuantityTextBox = new System.Windows.Forms.TextBox();
            this.productQuantityLabel = new System.Windows.Forms.Label();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.websiteButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.providerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerErrorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // providerDataGridView
            // 
            this.providerDataGridView.AllowUserToAddRows = false;
            this.providerDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(84)))));
            this.providerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.providerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSno,
            this.dgProviderCode,
            this.dgProviderCompanyName,
            this.dgProviderEmail,
            this.dgProviderCellphone,
            this.dgProviderWebsite,
            this.dgProCode,
            this.dgProQuantity,
            this.dgProviderDate});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.providerDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.providerDataGridView.GridColor = System.Drawing.Color.Black;
            this.providerDataGridView.Location = new System.Drawing.Point(35, 212);
            this.providerDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.providerDataGridView.Name = "providerDataGridView";
            this.providerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.providerDataGridView.Size = new System.Drawing.Size(978, 444);
            this.providerDataGridView.TabIndex = 60;
            this.providerDataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.providerDataGridView_MouseDoubleClick);
            // 
            // dgSno
            // 
            this.dgSno.HeaderText = "S.No";
            this.dgSno.Name = "dgSno";
            this.dgSno.Width = 50;
            // 
            // dgProviderCode
            // 
            this.dgProviderCode.HeaderText = "Provider Code";
            this.dgProviderCode.Name = "dgProviderCode";
            // 
            // dgProviderCompanyName
            // 
            this.dgProviderCompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgProviderCompanyName.HeaderText = "Company Name";
            this.dgProviderCompanyName.Name = "dgProviderCompanyName";
            // 
            // dgProviderEmail
            // 
            this.dgProviderEmail.HeaderText = "Email";
            this.dgProviderEmail.Name = "dgProviderEmail";
            // 
            // dgProviderCellphone
            // 
            this.dgProviderCellphone.HeaderText = "Cellphone";
            this.dgProviderCellphone.Name = "dgProviderCellphone";
            // 
            // dgProviderWebsite
            // 
            this.dgProviderWebsite.HeaderText = "Website";
            this.dgProviderWebsite.Name = "dgProviderWebsite";
            // 
            // dgProCode
            // 
            this.dgProCode.HeaderText = "Product Code";
            this.dgProCode.Name = "dgProCode";
            this.dgProCode.Width = 80;
            // 
            // dgProQuantity
            // 
            this.dgProQuantity.HeaderText = "Quantity";
            this.dgProQuantity.Name = "dgProQuantity";
            this.dgProQuantity.Width = 80;
            // 
            // dgProviderDate
            // 
            this.dgProviderDate.HeaderText = "Date";
            this.dgProviderDate.Name = "dgProviderDate";
            this.dgProviderDate.Width = 80;
            // 
            // providerWebsiteTextBox
            // 
            this.providerWebsiteTextBox.Location = new System.Drawing.Point(517, 58);
            this.providerWebsiteTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.providerWebsiteTextBox.Name = "providerWebsiteTextBox";
            this.providerWebsiteTextBox.Size = new System.Drawing.Size(112, 25);
            this.providerWebsiteTextBox.TabIndex = 57;
            this.providerWebsiteTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.providerWebsiteTextBox_KeyDown);
            // 
            // providerWebsiteLabel
            // 
            this.providerWebsiteLabel.AutoSize = true;
            this.providerWebsiteLabel.ForeColor = System.Drawing.Color.White;
            this.providerWebsiteLabel.Location = new System.Drawing.Point(514, 24);
            this.providerWebsiteLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.providerWebsiteLabel.Name = "providerWebsiteLabel";
            this.providerWebsiteLabel.Size = new System.Drawing.Size(54, 17);
            this.providerWebsiteLabel.TabIndex = 56;
            this.providerWebsiteLabel.Text = "Website";
            // 
            // providerEmailTextBox
            // 
            this.providerEmailTextBox.Location = new System.Drawing.Point(277, 58);
            this.providerEmailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.providerEmailTextBox.Name = "providerEmailTextBox";
            this.providerEmailTextBox.Size = new System.Drawing.Size(112, 25);
            this.providerEmailTextBox.TabIndex = 55;
            this.providerEmailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.providerEmailTextBox_KeyDown);
            // 
            // providerEmailLabel
            // 
            this.providerEmailLabel.AutoSize = true;
            this.providerEmailLabel.ForeColor = System.Drawing.Color.White;
            this.providerEmailLabel.Location = new System.Drawing.Point(274, 24);
            this.providerEmailLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.providerEmailLabel.Name = "providerEmailLabel";
            this.providerEmailLabel.Size = new System.Drawing.Size(39, 17);
            this.providerEmailLabel.TabIndex = 54;
            this.providerEmailLabel.Text = "Email";
            // 
            // providerDateLabel
            // 
            this.providerDateLabel.AutoSize = true;
            this.providerDateLabel.ForeColor = System.Drawing.Color.White;
            this.providerDateLabel.Location = new System.Drawing.Point(870, 28);
            this.providerDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.providerDateLabel.Name = "providerDateLabel";
            this.providerDateLabel.Size = new System.Drawing.Size(35, 17);
            this.providerDateLabel.TabIndex = 53;
            this.providerDateLabel.Text = "Date";
            // 
            // providerDateTimePicker
            // 
            this.providerDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.providerDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.providerDateTimePicker.Location = new System.Drawing.Point(873, 58);
            this.providerDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.providerDateTimePicker.Name = "providerDateTimePicker";
            this.providerDateTimePicker.Size = new System.Drawing.Size(103, 25);
            this.providerDateTimePicker.TabIndex = 52;
            this.providerDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.providerDateTimePicker_KeyDown);
            // 
            // providerCellphoneTextBox
            // 
            this.providerCellphoneTextBox.Location = new System.Drawing.Point(397, 58);
            this.providerCellphoneTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.providerCellphoneTextBox.Name = "providerCellphoneTextBox";
            this.providerCellphoneTextBox.Size = new System.Drawing.Size(112, 25);
            this.providerCellphoneTextBox.TabIndex = 51;
            this.providerCellphoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.providerCellphoneTextBox_KeyDown);
            this.providerCellphoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.providerCellphoneTextBox_KeyPress);
            // 
            // providerCellphoneLabel
            // 
            this.providerCellphoneLabel.AutoSize = true;
            this.providerCellphoneLabel.ForeColor = System.Drawing.Color.White;
            this.providerCellphoneLabel.Location = new System.Drawing.Point(394, 24);
            this.providerCellphoneLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.providerCellphoneLabel.Name = "providerCellphoneLabel";
            this.providerCellphoneLabel.Size = new System.Drawing.Size(66, 17);
            this.providerCellphoneLabel.TabIndex = 50;
            this.providerCellphoneLabel.Text = "Cellphone";
            // 
            // providerCompanyNameTextBox
            // 
            this.providerCompanyNameTextBox.Location = new System.Drawing.Point(157, 58);
            this.providerCompanyNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.providerCompanyNameTextBox.Name = "providerCompanyNameTextBox";
            this.providerCompanyNameTextBox.Size = new System.Drawing.Size(112, 25);
            this.providerCompanyNameTextBox.TabIndex = 49;
            this.providerCompanyNameTextBox.TextChanged += new System.EventHandler(this.providerCompanyNameTextBox_TextChanged);
            this.providerCompanyNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.providerCompanyNameTextBox_KeyDown);
            // 
            // providerCodeTextBox
            // 
            this.providerCodeTextBox.Location = new System.Drawing.Point(37, 58);
            this.providerCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.providerCodeTextBox.Name = "providerCodeTextBox";
            this.providerCodeTextBox.Size = new System.Drawing.Size(112, 25);
            this.providerCodeTextBox.TabIndex = 48;
            this.providerCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.providerCodeTextBox_KeyPress);
            // 
            // providerCompanyNameLabel
            // 
            this.providerCompanyNameLabel.AutoSize = true;
            this.providerCompanyNameLabel.ForeColor = System.Drawing.Color.White;
            this.providerCompanyNameLabel.Location = new System.Drawing.Point(153, 24);
            this.providerCompanyNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.providerCompanyNameLabel.Name = "providerCompanyNameLabel";
            this.providerCompanyNameLabel.Size = new System.Drawing.Size(102, 17);
            this.providerCompanyNameLabel.TabIndex = 47;
            this.providerCompanyNameLabel.Text = "Company Name";
            // 
            // productCodeLabel
            // 
            this.productCodeLabel.AutoSize = true;
            this.productCodeLabel.ForeColor = System.Drawing.Color.White;
            this.productCodeLabel.Location = new System.Drawing.Point(34, 24);
            this.productCodeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.productCodeLabel.Name = "productCodeLabel";
            this.productCodeLabel.Size = new System.Drawing.Size(92, 17);
            this.productCodeLabel.TabIndex = 46;
            this.productCodeLabel.Text = "Provider Code";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(606, 109);
            this.clearButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(97, 43);
            this.clearButton.TabIndex = 45;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(323, 109);
            this.addButton.Margin = new System.Windows.Forms.Padding(5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(133, 43);
            this.addButton.TabIndex = 44;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(464, 109);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(133, 43);
            this.deleteButton.TabIndex = 43;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // providerErrorProvider
            // 
            this.providerErrorProvider.ContainerControl = this;
            // 
            // totalProvidersLabel
            // 
            this.totalProvidersLabel.AutoSize = true;
            this.totalProvidersLabel.ForeColor = System.Drawing.Color.White;
            this.totalProvidersLabel.Location = new System.Drawing.Point(47, 669);
            this.totalProvidersLabel.Name = "totalProvidersLabel";
            this.totalProvidersLabel.Size = new System.Drawing.Size(98, 17);
            this.totalProvidersLabel.TabIndex = 61;
            this.totalProvidersLabel.Text = "Total Providers:";
            // 
            // totalProvidersValueLabel
            // 
            this.totalProvidersValueLabel.AutoSize = true;
            this.totalProvidersValueLabel.ForeColor = System.Drawing.Color.White;
            this.totalProvidersValueLabel.Location = new System.Drawing.Point(151, 669);
            this.totalProvidersValueLabel.Name = "totalProvidersValueLabel";
            this.totalProvidersValueLabel.Size = new System.Drawing.Size(0, 17);
            this.totalProvidersValueLabel.TabIndex = 62;
            // 
            // productQuantityTextBox
            // 
            this.productQuantityTextBox.Location = new System.Drawing.Point(754, 58);
            this.productQuantityTextBox.Name = "productQuantityTextBox";
            this.productQuantityTextBox.Size = new System.Drawing.Size(112, 25);
            this.productQuantityTextBox.TabIndex = 71;
            this.productQuantityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productQuantityTextBox_KeyDown);
            this.productQuantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productQuantityTextBox_KeyPress);
            // 
            // productQuantityLabel
            // 
            this.productQuantityLabel.AutoSize = true;
            this.productQuantityLabel.ForeColor = System.Drawing.Color.White;
            this.productQuantityLabel.Location = new System.Drawing.Point(751, 28);
            this.productQuantityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.productQuantityLabel.Name = "productQuantityLabel";
            this.productQuantityLabel.Size = new System.Drawing.Size(56, 17);
            this.productQuantityLabel.TabIndex = 70;
            this.productQuantityLabel.Text = "Quantity";
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Location = new System.Drawing.Point(636, 58);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.Size = new System.Drawing.Size(112, 25);
            this.productCodeTextBox.TabIndex = 69;
            this.productCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productCodeTextBox_KeyDown);
            this.productCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productCodeTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(633, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Product Code";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.printButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.productQuantityTextBox);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.productQuantityLabel);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.productCodeTextBox);
            this.panel1.Controls.Add(this.productCodeLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.providerCompanyNameLabel);
            this.panel1.Controls.Add(this.providerCodeTextBox);
            this.panel1.Controls.Add(this.providerCompanyNameTextBox);
            this.panel1.Controls.Add(this.providerCellphoneLabel);
            this.panel1.Controls.Add(this.providerWebsiteTextBox);
            this.panel1.Controls.Add(this.providerCellphoneTextBox);
            this.panel1.Controls.Add(this.providerWebsiteLabel);
            this.panel1.Controls.Add(this.providerDateTimePicker);
            this.panel1.Controls.Add(this.providerEmailTextBox);
            this.panel1.Controls.Add(this.providerDateLabel);
            this.panel1.Controls.Add(this.providerEmailLabel);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 180);
            this.panel1.TabIndex = 72;
            // 
            // websiteButton
            // 
            this.websiteButton.Location = new System.Drawing.Point(475, 669);
            this.websiteButton.Name = "websiteButton";
            this.websiteButton.Size = new System.Drawing.Size(105, 34);
            this.websiteButton.TabIndex = 73;
            this.websiteButton.Text = "Website";
            this.websiteButton.UseVisualStyleBackColor = true;
            this.websiteButton.Click += new System.EventHandler(this.websiteButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(873, 109);
            this.printButton.Margin = new System.Windows.Forms.Padding(4);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(103, 43);
            this.printButton.TabIndex = 72;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // Providers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1048, 719);
            this.Controls.Add(this.websiteButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.totalProvidersValueLabel);
            this.Controls.Add(this.totalProvidersLabel);
            this.Controls.Add(this.providerDataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Providers";
            this.Text = "Providers";
            this.Load += new System.EventHandler(this.Providers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.providerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerErrorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView providerDataGridView;
        private System.Windows.Forms.TextBox providerWebsiteTextBox;
        private System.Windows.Forms.Label providerWebsiteLabel;
        private System.Windows.Forms.TextBox providerEmailTextBox;
        private System.Windows.Forms.Label providerEmailLabel;
        private System.Windows.Forms.Label providerDateLabel;
        private System.Windows.Forms.DateTimePicker providerDateTimePicker;
        private System.Windows.Forms.TextBox providerCellphoneTextBox;
        private System.Windows.Forms.Label providerCellphoneLabel;
        private System.Windows.Forms.TextBox providerCompanyNameTextBox;
        private System.Windows.Forms.TextBox providerCodeTextBox;
        private System.Windows.Forms.Label providerCompanyNameLabel;
        private System.Windows.Forms.Label productCodeLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ErrorProvider providerErrorProvider;
        private System.Windows.Forms.Label totalProvidersLabel;
        private System.Windows.Forms.Label totalProvidersValueLabel;
        private System.Windows.Forms.TextBox productQuantityTextBox;
        private System.Windows.Forms.Label productQuantityLabel;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProviderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProviderCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProviderEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProviderCellphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProviderWebsite;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProviderDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button websiteButton;
        private System.Windows.Forms.Button printButton;
    }
}