namespace Laboratory_Management_System__Capstone_Project_
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnStudentListShortcut = new System.Windows.Forms.Button();
            this.btnInventoryShortcut = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.ShowCountPanel = new System.Windows.Forms.Panel();
            this.returnedApparatusCountLabel = new System.Windows.Forms.Label();
            this.borrowedApparatusCountLabel = new System.Windows.Forms.Label();
            this.studentCountLabel = new System.Windows.Forms.Label();
            this.apparatusCountLabel = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.apparatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addANewApparatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewApparatusListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registeredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStudentsInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penaltyRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lnklblLogOut = new System.Windows.Forms.LinkLabel();
            this.picBoxBC = new System.Windows.Forms.PictureBox();
            this.panelContainer.SuspendLayout();
            this.ShowCountPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBC)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.label2.Location = new System.Drawing.Point(308, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "           INVENTORY SYSTEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.label3.Location = new System.Drawing.Point(215, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "COLLEGE OF ENGINEERING";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(213, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "LABORATORY";
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelContainer.Controls.Add(this.btnStudentListShortcut);
            this.panelContainer.Controls.Add(this.btnInventoryShortcut);
            this.panelContainer.Controls.Add(this.lblShortcut);
            this.panelContainer.Controls.Add(this.ShowCountPanel);
            this.panelContainer.Controls.Add(this.lblIDNumber);
            this.panelContainer.Controls.Add(this.lblFirstName);
            this.panelContainer.Controls.Add(this.lblTitle);
            this.panelContainer.Location = new System.Drawing.Point(173, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1829, 1066);
            this.panelContainer.TabIndex = 4;
            // 
            // btnStudentListShortcut
            // 
            this.btnStudentListShortcut.Location = new System.Drawing.Point(444, 599);
            this.btnStudentListShortcut.Name = "btnStudentListShortcut";
            this.btnStudentListShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnStudentListShortcut.TabIndex = 10;
            this.btnStudentListShortcut.Text = "student lsit";
            this.btnStudentListShortcut.UseVisualStyleBackColor = true;
            // 
            // btnInventoryShortcut
            // 
            this.btnInventoryShortcut.Location = new System.Drawing.Point(345, 599);
            this.btnInventoryShortcut.Name = "btnInventoryShortcut";
            this.btnInventoryShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnInventoryShortcut.TabIndex = 10;
            this.btnInventoryShortcut.Text = "invetory";
            this.btnInventoryShortcut.UseVisualStyleBackColor = true;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Location = new System.Drawing.Point(381, 569);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(93, 13);
            this.lblShortcut.TabIndex = 9;
            this.lblShortcut.Text = "Featured products";
            // 
            // ShowCountPanel
            // 
            this.ShowCountPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ShowCountPanel.Controls.Add(this.returnedApparatusCountLabel);
            this.ShowCountPanel.Controls.Add(this.borrowedApparatusCountLabel);
            this.ShowCountPanel.Controls.Add(this.studentCountLabel);
            this.ShowCountPanel.Controls.Add(this.apparatusCountLabel);
            this.ShowCountPanel.Controls.Add(this.lblOverview);
            this.ShowCountPanel.Location = new System.Drawing.Point(287, 304);
            this.ShowCountPanel.Name = "ShowCountPanel";
            this.ShowCountPanel.Size = new System.Drawing.Size(264, 209);
            this.ShowCountPanel.TabIndex = 8;
            // 
            // returnedApparatusCountLabel
            // 
            this.returnedApparatusCountLabel.AutoSize = true;
            this.returnedApparatusCountLabel.Location = new System.Drawing.Point(55, 174);
            this.returnedApparatusCountLabel.Name = "returnedApparatusCountLabel";
            this.returnedApparatusCountLabel.Size = new System.Drawing.Size(78, 13);
            this.returnedApparatusCountLabel.TabIndex = 0;
            this.returnedApparatusCountLabel.Text = "Return counter";
            // 
            // borrowedApparatusCountLabel
            // 
            this.borrowedApparatusCountLabel.AutoSize = true;
            this.borrowedApparatusCountLabel.Location = new System.Drawing.Point(55, 141);
            this.borrowedApparatusCountLabel.Name = "borrowedApparatusCountLabel";
            this.borrowedApparatusCountLabel.Size = new System.Drawing.Size(83, 13);
            this.borrowedApparatusCountLabel.TabIndex = 0;
            this.borrowedApparatusCountLabel.Text = "Borrow Counter:";
            // 
            // studentCountLabel
            // 
            this.studentCountLabel.AutoSize = true;
            this.studentCountLabel.Location = new System.Drawing.Point(55, 104);
            this.studentCountLabel.Name = "studentCountLabel";
            this.studentCountLabel.Size = new System.Drawing.Size(87, 13);
            this.studentCountLabel.TabIndex = 0;
            this.studentCountLabel.Text = "Student Counter:";
            // 
            // apparatusCountLabel
            // 
            this.apparatusCountLabel.AutoSize = true;
            this.apparatusCountLabel.Location = new System.Drawing.Point(55, 71);
            this.apparatusCountLabel.Name = "apparatusCountLabel";
            this.apparatusCountLabel.Size = new System.Drawing.Size(98, 13);
            this.apparatusCountLabel.TabIndex = 0;
            this.apparatusCountLabel.Text = "Apparatus Counter:";
            // 
            // lblOverview
            // 
            this.lblOverview.AutoSize = true;
            this.lblOverview.Location = new System.Drawing.Point(15, 27);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(55, 13);
            this.lblOverview.TabIndex = 0;
            this.lblOverview.Text = "Overview:";
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.AutoSize = true;
            this.lblIDNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblIDNumber.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold);
            this.lblIDNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.lblIDNumber.Location = new System.Drawing.Point(838, 38);
            this.lblIDNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(185, 24);
            this.lblIDNumber.TabIndex = 7;
            this.lblIDNumber.Text = "ID NUMBER + ROLE";
            this.lblIDNumber.Visible = false;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.lblFirstName.Location = new System.Drawing.Point(926, 62);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(97, 19);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "FIRST NAME";
            this.lblFirstName.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Bahnschrift", 25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 141);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(213, 41);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "DASHBOARD";
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnToggle.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.toggle;
            this.btnToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.ForeColor = System.Drawing.Color.Transparent;
            this.btnToggle.Location = new System.Drawing.Point(22, 38);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(51, 52);
            this.btnToggle.TabIndex = 3;
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.sidebarlast;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.menuStrip3);
            this.panel1.Controls.Add(this.lnklblLogOut);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(-1, 127);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 959);
            this.panel1.TabIndex = 2;
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apparatusToolStripMenuItem,
            this.registeredToolStripMenuItem,
            this.borrowTransactionToolStripMenuItem,
            this.returnRecordsToolStripMenuItem,
            this.updateTransactionsToolStripMenuItem,
            this.comToolStripMenuItem,
            this.penaltyRecordsToolStripMenuItem});
            this.menuStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip3.Location = new System.Drawing.Point(2, 46);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip3.Size = new System.Drawing.Size(320, 684);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // apparatusToolStripMenuItem
            // 
            this.apparatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addANewApparatusToolStripMenuItem,
            this.viewApparatusListToolStripMenuItem});
            this.apparatusToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.apparatusToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.apparatusToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.app_inventory2;
            this.apparatusToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.apparatusToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.apparatusToolStripMenuItem.MergeIndex = 0;
            this.apparatusToolStripMenuItem.Name = "apparatusToolStripMenuItem";
            this.apparatusToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.apparatusToolStripMenuItem.Size = new System.Drawing.Size(319, 100);
            this.apparatusToolStripMenuItem.Text = " Apparatus Inventory";
            this.apparatusToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addANewApparatusToolStripMenuItem
            // 
            this.addANewApparatusToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addANewApparatusToolStripMenuItem.Image")));
            this.addANewApparatusToolStripMenuItem.Name = "addANewApparatusToolStripMenuItem";
            this.addANewApparatusToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.addANewApparatusToolStripMenuItem.Text = "Add a New Apparatus";
            this.addANewApparatusToolStripMenuItem.Click += new System.EventHandler(this.addANewApparatusToolStripMenuItem_Click);
            // 
            // viewApparatusListToolStripMenuItem
            // 
            this.viewApparatusListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewApparatusListToolStripMenuItem.Image")));
            this.viewApparatusListToolStripMenuItem.Name = "viewApparatusListToolStripMenuItem";
            this.viewApparatusListToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.viewApparatusListToolStripMenuItem.Text = "View and Update Inventory List";
            this.viewApparatusListToolStripMenuItem.Click += new System.EventHandler(this.viewApparatusListToolStripMenuItem_Click);
            // 
            // registeredToolStripMenuItem
            // 
            this.registeredToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAStudentToolStripMenuItem,
            this.viewStudentsInformationToolStripMenuItem});
            this.registeredToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.registeredToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.registeredToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.student_icon;
            this.registeredToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registeredToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.registeredToolStripMenuItem.Name = "registeredToolStripMenuItem";
            this.registeredToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.registeredToolStripMenuItem.Size = new System.Drawing.Size(319, 98);
            this.registeredToolStripMenuItem.Text = " Students List";
            this.registeredToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addAStudentToolStripMenuItem
            // 
            this.addAStudentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addAStudentToolStripMenuItem.Image")));
            this.addAStudentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addAStudentToolStripMenuItem.Name = "addAStudentToolStripMenuItem";
            this.addAStudentToolStripMenuItem.Size = new System.Drawing.Size(429, 56);
            this.addAStudentToolStripMenuItem.Text = "Add a Student Registration";
            this.addAStudentToolStripMenuItem.Click += new System.EventHandler(this.addAStudentToolStripMenuItem_Click);
            // 
            // viewStudentsInformationToolStripMenuItem
            // 
            this.viewStudentsInformationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewStudentsInformationToolStripMenuItem.Image")));
            this.viewStudentsInformationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewStudentsInformationToolStripMenuItem.Name = "viewStudentsInformationToolStripMenuItem";
            this.viewStudentsInformationToolStripMenuItem.Size = new System.Drawing.Size(429, 56);
            this.viewStudentsInformationToolStripMenuItem.Text = "View Registered Student\'s Information";
            this.viewStudentsInformationToolStripMenuItem.Click += new System.EventHandler(this.viewStudentsInformationToolStripMenuItem_Click);
            // 
            // borrowTransactionToolStripMenuItem
            // 
            this.borrowTransactionToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.borrowTransactionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.borrowTransactionToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.hand_up3;
            this.borrowTransactionToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.borrowTransactionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.borrowTransactionToolStripMenuItem.Name = "borrowTransactionToolStripMenuItem";
            this.borrowTransactionToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.borrowTransactionToolStripMenuItem.Size = new System.Drawing.Size(319, 98);
            this.borrowTransactionToolStripMenuItem.Text = "Borrow Issuing";
            this.borrowTransactionToolStripMenuItem.Click += new System.EventHandler(this.borrowTransactionToolStripMenuItem_Click);
            // 
            // returnRecordsToolStripMenuItem
            // 
            this.returnRecordsToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.returnRecordsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.returnRecordsToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.hand_down3;
            this.returnRecordsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.returnRecordsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.returnRecordsToolStripMenuItem.Name = "returnRecordsToolStripMenuItem";
            this.returnRecordsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.returnRecordsToolStripMenuItem.Size = new System.Drawing.Size(319, 98);
            this.returnRecordsToolStripMenuItem.Text = "Return Transaction";
            this.returnRecordsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.returnRecordsToolStripMenuItem.Click += new System.EventHandler(this.returnRecordsToolStripMenuItem_Click);
            // 
            // updateTransactionsToolStripMenuItem
            // 
            this.updateTransactionsToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.updateTransactionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.updateTransactionsToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.update2;
            this.updateTransactionsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateTransactionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateTransactionsToolStripMenuItem.Name = "updateTransactionsToolStripMenuItem";
            this.updateTransactionsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.updateTransactionsToolStripMenuItem.Size = new System.Drawing.Size(319, 92);
            this.updateTransactionsToolStripMenuItem.Text = "Update Transactions";
            this.updateTransactionsToolStripMenuItem.Click += new System.EventHandler(this.updateTransactionsToolStripMenuItem_Click);
            // 
            // comToolStripMenuItem
            // 
            this.comToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.comToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.comToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.report1;
            this.comToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.comToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.comToolStripMenuItem.Name = "comToolStripMenuItem";
            this.comToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.comToolStripMenuItem.Size = new System.Drawing.Size(319, 100);
            this.comToolStripMenuItem.Text = " Report Details";
            this.comToolStripMenuItem.Click += new System.EventHandler(this.comToolStripMenuItem_Click);
            // 
            // penaltyRecordsToolStripMenuItem
            // 
            this.penaltyRecordsToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.penaltyRecordsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.penaltyRecordsToolStripMenuItem.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.warning1;
            this.penaltyRecordsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.penaltyRecordsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.penaltyRecordsToolStripMenuItem.Name = "penaltyRecordsToolStripMenuItem";
            this.penaltyRecordsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(25, 25, 0, 25);
            this.penaltyRecordsToolStripMenuItem.Size = new System.Drawing.Size(319, 96);
            this.penaltyRecordsToolStripMenuItem.Text = " Penalties and Violations";
            this.penaltyRecordsToolStripMenuItem.Click += new System.EventHandler(this.penaltyRecordsToolStripMenuItem_Click);
            // 
            // lnklblLogOut
            // 
            this.lnklblLogOut.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.lnklblLogOut.AutoSize = true;
            this.lnklblLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lnklblLogOut.DisabledLinkColor = System.Drawing.Color.Transparent;
            this.lnklblLogOut.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.lnklblLogOut.ForeColor = System.Drawing.Color.White;
            this.lnklblLogOut.Image = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.logout3;
            this.lnklblLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnklblLogOut.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnklblLogOut.LinkColor = System.Drawing.Color.White;
            this.lnklblLogOut.Location = new System.Drawing.Point(94, 880);
            this.lnklblLogOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblLogOut.Name = "lnklblLogOut";
            this.lnklblLogOut.Size = new System.Drawing.Size(112, 22);
            this.lnklblLogOut.TabIndex = 0;
            this.lnklblLogOut.TabStop = true;
            this.lnklblLogOut.Text = "       LOGOUT";
            this.lnklblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLogOut_LinkClicked);
            // 
            // picBoxBC
            // 
            this.picBoxBC.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBC.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bcc_logo_name;
            this.picBoxBC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBoxBC.Location = new System.Drawing.Point(97, 21);
            this.picBoxBC.Name = "picBoxBC";
            this.picBoxBC.Size = new System.Drawing.Size(97, 99);
            this.picBoxBC.TabIndex = 4;
            this.picBoxBC.TabStop = false;
            this.picBoxBC.Click += new System.EventHandler(this.picBoxBC_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 1061);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBoxBC);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ShowCountPanel.ResumeLayout(false);
            this.ShowCountPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.LinkLabel lnklblLogOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.PictureBox picBoxBC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem apparatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addANewApparatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewApparatusListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registeredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStudentsInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrowTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penaltyRecordsToolStripMenuItem;
        private System.Windows.Forms.Label lblIDNumber;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnStudentListShortcut;
        private System.Windows.Forms.Button btnInventoryShortcut;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Panel ShowCountPanel;
        private System.Windows.Forms.Label returnedApparatusCountLabel;
        private System.Windows.Forms.Label borrowedApparatusCountLabel;
        private System.Windows.Forms.Label studentCountLabel;
        private System.Windows.Forms.Label apparatusCountLabel;
        private System.Windows.Forms.Label lblOverview;
    }
}