namespace Laboratory_Management_System__Capstone_Project_
{
    partial class InventoryList
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAppaSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvApparatusList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbEditStatus = new System.Windows.Forms.ComboBox();
            this.tbPurchaseDate = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbModelNum = new System.Windows.Forms.TextBox();
            this.tbAppName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApparatusList)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Apparatus Inventory List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(590, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search:";
            // 
            // tbAppaSearch
            // 
            this.tbAppaSearch.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbAppaSearch.Location = new System.Drawing.Point(681, 82);
            this.tbAppaSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbAppaSearch.Name = "tbAppaSearch";
            this.tbAppaSearch.Size = new System.Drawing.Size(223, 27);
            this.tbAppaSearch.TabIndex = 3;
            this.tbAppaSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAppaSearch_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1192, 80);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 32);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvApparatusList
            // 
            this.dgvApparatusList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApparatusList.Location = new System.Drawing.Point(24, 141);
            this.dgvApparatusList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvApparatusList.Name = "dgvApparatusList";
            this.dgvApparatusList.RowHeadersWidth = 51;
            this.dgvApparatusList.RowTemplate.Height = 24;
            this.dgvApparatusList.Size = new System.Drawing.Size(1306, 427);
            this.dgvApparatusList.TabIndex = 5;
            this.dgvApparatusList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApparatusList_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.tbRemarks);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbEditStatus);
            this.panel2.Controls.Add(this.tbPurchaseDate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbQuantity);
            this.panel2.Controls.Add(this.tbBrand);
            this.panel2.Controls.Add(this.tbPrice);
            this.panel2.Controls.Add(this.tbModelNum);
            this.panel2.Controls.Add(this.tbAppName);
            this.panel2.Location = new System.Drawing.Point(11, 458);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1391, 383);
            this.panel2.TabIndex = 6;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(595, 228);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(148, 27);
            this.cbCategory.TabIndex = 29;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(730, 308);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(156, 39);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tbRemarks
            // 
            this.tbRemarks.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbRemarks.Location = new System.Drawing.Point(899, 74);
            this.tbRemarks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(297, 149);
            this.tbRemarks.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(895, 42);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 19);
            this.label11.TabIndex = 26;
            this.label11.Text = "Item Remarks:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(473, 228);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Category:";
            // 
            // cbEditStatus
            // 
            this.cbEditStatus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.cbEditStatus.FormattingEnabled = true;
            this.cbEditStatus.Items.AddRange(new object[] {
            "Ready for Use",
            "Not Ready for Use",
            "Needs Maintenance",
            "Has Missing Parts"});
            this.cbEditStatus.Location = new System.Drawing.Point(595, 146);
            this.cbEditStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cbEditStatus.Name = "cbEditStatus";
            this.cbEditStatus.Size = new System.Drawing.Size(190, 27);
            this.cbEditStatus.TabIndex = 23;
            // 
            // tbPurchaseDate
            // 
            this.tbPurchaseDate.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbPurchaseDate.Location = new System.Drawing.Point(155, 196);
            this.tbPurchaseDate.Margin = new System.Windows.Forms.Padding(2);
            this.tbPurchaseDate.Name = "tbPurchaseDate";
            this.tbPurchaseDate.Size = new System.Drawing.Size(262, 27);
            this.tbPurchaseDate.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(928, 308);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 39);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1156, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 39);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Green;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(1127, 296);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 39);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(440, 189);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "Stock Quantity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(492, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(495, 108);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Brand:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(93, 238);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(32, 196);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Purchase Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Model Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Apparatus Name:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbQuantity.Location = new System.Drawing.Point(595, 189);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(148, 27);
            this.tbQuantity.TabIndex = 12;
            // 
            // tbBrand
            // 
            this.tbBrand.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbBrand.Location = new System.Drawing.Point(595, 108);
            this.tbBrand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(190, 27);
            this.tbBrand.TabIndex = 10;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbPrice.Location = new System.Drawing.Point(155, 236);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(120, 27);
            this.tbPrice.TabIndex = 9;
            this.tbPrice.Enter += new System.EventHandler(this.tbPrice_Enter);
            this.tbPrice.Leave += new System.EventHandler(this.tbPrice_Leave);
            // 
            // tbModelNum
            // 
            this.tbModelNum.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbModelNum.Location = new System.Drawing.Point(158, 154);
            this.tbModelNum.Margin = new System.Windows.Forms.Padding(2);
            this.tbModelNum.Name = "tbModelNum";
            this.tbModelNum.Size = new System.Drawing.Size(262, 27);
            this.tbModelNum.TabIndex = 8;
            // 
            // tbAppName
            // 
            this.tbAppName.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbAppName.Location = new System.Drawing.Point(158, 112);
            this.tbAppName.Margin = new System.Windows.Forms.Padding(2);
            this.tbAppName.Name = "tbAppName";
            this.tbAppName.Size = new System.Drawing.Size(262, 27);
            this.tbAppName.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1249, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Items.AddRange(new object[] {
            "Ready for Use",
            "Not Ready for Use",
            "Needs Maintenance",
            "Has Missing Parts"});
            this.cbStatusFilter.Location = new System.Drawing.Point(1055, 82);
            this.cbStatusFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbStatusFilter.Name = "cbStatusFilter";
            this.cbStatusFilter.Size = new System.Drawing.Size(126, 27);
            this.cbStatusFilter.TabIndex = 9;
            this.cbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cbStatusFilter_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label12.Location = new System.Drawing.Point(923, 82);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 19);
            this.label12.TabIndex = 10;
            this.label12.Text = "Filter by Status";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label13.Location = new System.Drawing.Point(276, 86);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 19);
            this.label13.TabIndex = 12;
            this.label13.Text = "Filter Category";
            // 
            // cbCategoryFilter
            // 
            this.cbCategoryFilter.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.cbCategoryFilter.FormattingEnabled = true;
            this.cbCategoryFilter.Items.AddRange(new object[] {
            "Plasticware",
            "Glassware",
            "Metalware",
            "Heating Equipment",
            "Measuring Instrument",
            "Safety Equipment"});
            this.cbCategoryFilter.Location = new System.Drawing.Point(408, 85);
            this.cbCategoryFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(126, 27);
            this.cbCategoryFilter.TabIndex = 11;
            this.cbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFilter_SelectedIndexChanged);
            // 
            // InventoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1322, 884);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbCategoryFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbStatusFilter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvApparatusList);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbAppaSearch);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apparatus Inventory List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApparatusList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAppaSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvApparatusList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbModelNum;
        private System.Windows.Forms.TextBox tbAppName;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbPurchaseDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbEditStatus;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
    }
}