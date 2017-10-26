namespace TeamManager.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.customPanel1 = new System.Windows.Forms.Custom.CustomPanel();
            this.customTableLayoutPanel1 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.btnPCreate = new System.Windows.Forms.Button();
            this.btnUnsignedPlayers = new System.Windows.Forms.Button();
            this.btnTCreate = new System.Windows.Forms.Button();
            this.lbxPlayers = new System.Windows.Forms.ListBox();
            this.btnShowAllPlayers = new System.Windows.Forms.Button();
            this.lblTeams = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lbxTeams = new System.Windows.Forms.ListBox();
            this.customTableLayoutPanel2 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.btnPDelete = new System.Windows.Forms.Button();
            this.btnPEdit = new System.Windows.Forms.Button();
            this.customTableLayoutPanel3 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.btnTEdit = new System.Windows.Forms.Button();
            this.btnTDelete = new System.Windows.Forms.Button();
            this.customTableLayoutPanel4 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbnTeams = new System.Windows.Forms.RadioButton();
            this.rbnPlayers = new System.Windows.Forms.RadioButton();
            this.tbxSearch = new System.Windows.Forms.Custom.CustomTextBoxSearch();
            this.customControlBox1 = new System.Windows.Forms.Custom.CustomControlBox();
            this.customPanel1.SuspendLayout();
            this.customTableLayoutPanel1.SuspendLayout();
            this.customTableLayoutPanel2.SuspendLayout();
            this.customTableLayoutPanel3.SuspendLayout();
            this.customTableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.Transparent;
            this.customPanel1.Color1 = System.Drawing.Color.Transparent;
            this.customPanel1.Color2 = System.Drawing.Color.Transparent;
            this.customPanel1.Controls.Add(this.customTableLayoutPanel1);
            this.customPanel1.CustomCursor = false;
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel1.DraggableForm = false;
            this.customPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customPanel1.Location = new System.Drawing.Point(8, 50);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(623, 382);
            this.customPanel1.TabIndex = 0;
            // 
            // customTableLayoutPanel1
            // 
            this.customTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color2 = System.Drawing.Color.Black;
            this.customTableLayoutPanel1.ColumnCount = 7;
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.customTableLayoutPanel1.Controls.Add(this.btnPCreate, 5, 3);
            this.customTableLayoutPanel1.Controls.Add(this.btnUnsignedPlayers, 3, 2);
            this.customTableLayoutPanel1.Controls.Add(this.btnTCreate, 1, 3);
            this.customTableLayoutPanel1.Controls.Add(this.lbxPlayers, 5, 1);
            this.customTableLayoutPanel1.Controls.Add(this.btnShowAllPlayers, 3, 3);
            this.customTableLayoutPanel1.Controls.Add(this.lblTeams, 1, 0);
            this.customTableLayoutPanel1.Controls.Add(this.lblPlayers, 5, 0);
            this.customTableLayoutPanel1.Controls.Add(this.lbxTeams, 1, 1);
            this.customTableLayoutPanel1.Controls.Add(this.customTableLayoutPanel2, 5, 2);
            this.customTableLayoutPanel1.Controls.Add(this.customTableLayoutPanel3, 1, 2);
            this.customTableLayoutPanel1.Controls.Add(this.customTableLayoutPanel4, 3, 1);
            this.customTableLayoutPanel1.CustomCursor = false;
            this.customTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel1.DraggableForm = false;
            this.customTableLayoutPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.customTableLayoutPanel1.Name = "customTableLayoutPanel1";
            this.customTableLayoutPanel1.RowCount = 5;
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customTableLayoutPanel1.Size = new System.Drawing.Size(623, 382);
            this.customTableLayoutPanel1.TabIndex = 0;
            // 
            // btnPCreate
            // 
            this.btnPCreate.BackColor = System.Drawing.Color.Lavender;
            this.btnPCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPCreate.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPCreate.ForeColor = System.Drawing.Color.Black;
            this.btnPCreate.Location = new System.Drawing.Point(466, 312);
            this.btnPCreate.Margin = new System.Windows.Forms.Padding(50, 0, 50, 12);
            this.btnPCreate.Name = "btnPCreate";
            this.btnPCreate.Size = new System.Drawing.Size(64, 28);
            this.btnPCreate.TabIndex = 5;
            this.btnPCreate.Text = "Create";
            this.btnPCreate.UseVisualStyleBackColor = false;
            this.btnPCreate.Click += new System.EventHandler(this.btnPCreate_Click);
            // 
            // btnUnsignedPlayers
            // 
            this.btnUnsignedPlayers.BackColor = System.Drawing.Color.Lavender;
            this.btnUnsignedPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnsignedPlayers.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUnsignedPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnsignedPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnsignedPlayers.ForeColor = System.Drawing.Color.Black;
            this.btnUnsignedPlayers.Location = new System.Drawing.Point(248, 278);
            this.btnUnsignedPlayers.Margin = new System.Windows.Forms.Padding(25, 6, 25, 6);
            this.btnUnsignedPlayers.Name = "btnUnsignedPlayers";
            this.btnUnsignedPlayers.Size = new System.Drawing.Size(113, 28);
            this.btnUnsignedPlayers.TabIndex = 7;
            this.btnUnsignedPlayers.Text = "Unsigned Players";
            this.btnUnsignedPlayers.UseVisualStyleBackColor = false;
            this.btnUnsignedPlayers.Click += new System.EventHandler(this.btnUnsignedPlayers_Click);
            // 
            // btnTCreate
            // 
            this.btnTCreate.BackColor = System.Drawing.Color.Lavender;
            this.btnTCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTCreate.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCreate.ForeColor = System.Drawing.Color.Black;
            this.btnTCreate.Location = new System.Drawing.Point(80, 312);
            this.btnTCreate.Margin = new System.Windows.Forms.Padding(50, 0, 50, 12);
            this.btnTCreate.Name = "btnTCreate";
            this.btnTCreate.Size = new System.Drawing.Size(63, 28);
            this.btnTCreate.TabIndex = 2;
            this.btnTCreate.Text = "Create";
            this.btnTCreate.UseVisualStyleBackColor = false;
            this.btnTCreate.Click += new System.EventHandler(this.btnTCreate_Click);
            // 
            // lbxPlayers
            // 
            this.lbxPlayers.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lbxPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxPlayers.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbxPlayers.FormattingEnabled = true;
            this.lbxPlayers.ItemHeight = 19;
            this.lbxPlayers.Items.AddRange(new object[] {
            "Bob Donaldson",
            "Fred Erentz",
            "Joe Cassidy",
            "James McNaught",
            "Dick Smith",
            "Walter Cartwright",
            "Harry Stafford"});
            this.lbxPlayers.Location = new System.Drawing.Point(419, 33);
            this.lbxPlayers.Name = "lbxPlayers";
            this.lbxPlayers.Size = new System.Drawing.Size(158, 236);
            this.lbxPlayers.TabIndex = 3;
            // 
            // btnShowAllPlayers
            // 
            this.btnShowAllPlayers.BackColor = System.Drawing.Color.Lavender;
            this.btnShowAllPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowAllPlayers.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnShowAllPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllPlayers.ForeColor = System.Drawing.Color.Black;
            this.btnShowAllPlayers.Location = new System.Drawing.Point(248, 312);
            this.btnShowAllPlayers.Margin = new System.Windows.Forms.Padding(25, 0, 25, 12);
            this.btnShowAllPlayers.Name = "btnShowAllPlayers";
            this.btnShowAllPlayers.Size = new System.Drawing.Size(113, 28);
            this.btnShowAllPlayers.TabIndex = 8;
            this.btnShowAllPlayers.Text = "Show All Players";
            this.btnShowAllPlayers.UseVisualStyleBackColor = false;
            this.btnShowAllPlayers.Click += new System.EventHandler(this.btnShowAllPlayers_Click);
            // 
            // lblTeams
            // 
            this.lblTeams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTeams.AutoSize = true;
            this.lblTeams.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeams.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblTeams.Location = new System.Drawing.Point(75, 2);
            this.lblTeams.Name = "lblTeams";
            this.lblTeams.Size = new System.Drawing.Size(72, 25);
            this.lblTeams.TabIndex = 1;
            this.lblTeams.Text = "Teams";
            // 
            // lblPlayers
            // 
            this.lblPlayers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayers.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblPlayers.Location = new System.Drawing.Point(459, 2);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(77, 25);
            this.lblPlayers.TabIndex = 0;
            this.lblPlayers.Text = "Players";
            // 
            // lbxTeams
            // 
            this.lbxTeams.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lbxTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxTeams.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxTeams.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbxTeams.FormattingEnabled = true;
            this.lbxTeams.ItemHeight = 19;
            this.lbxTeams.Items.AddRange(new object[] {
            "England",
            "Arsenal",
            "Chelsea",
            "Manchester United",
            "Scotland",
            "Wales"});
            this.lbxTeams.Location = new System.Drawing.Point(33, 33);
            this.lbxTeams.Name = "lbxTeams";
            this.lbxTeams.Size = new System.Drawing.Size(157, 236);
            this.lbxTeams.TabIndex = 0;
            this.lbxTeams.SelectedIndexChanged += new System.EventHandler(this.lbxTeams_SelectedIndexChanged);
            // 
            // customTableLayoutPanel2
            // 
            this.customTableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.Color2 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.ColumnCount = 2;
            this.customTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel2.Controls.Add(this.btnPDelete, 0, 0);
            this.customTableLayoutPanel2.Controls.Add(this.btnPEdit, 1, 0);
            this.customTableLayoutPanel2.CustomCursor = false;
            this.customTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel2.DraggableForm = false;
            this.customTableLayoutPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel2.Location = new System.Drawing.Point(419, 275);
            this.customTableLayoutPanel2.Name = "customTableLayoutPanel2";
            this.customTableLayoutPanel2.RowCount = 1;
            this.customTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel2.Size = new System.Drawing.Size(158, 34);
            this.customTableLayoutPanel2.TabIndex = 4;
            // 
            // btnPDelete
            // 
            this.btnPDelete.BackColor = System.Drawing.Color.Lavender;
            this.btnPDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnPDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDelete.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDelete.ForeColor = System.Drawing.Color.Black;
            this.btnPDelete.Location = new System.Drawing.Point(3, 3);
            this.btnPDelete.Name = "btnPDelete";
            this.btnPDelete.Size = new System.Drawing.Size(73, 28);
            this.btnPDelete.TabIndex = 0;
            this.btnPDelete.Text = "Delete";
            this.btnPDelete.UseVisualStyleBackColor = false;
            this.btnPDelete.Click += new System.EventHandler(this.btnPDelete_Click);
            // 
            // btnPEdit
            // 
            this.btnPEdit.BackColor = System.Drawing.Color.Lavender;
            this.btnPEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPEdit.ForeColor = System.Drawing.Color.Black;
            this.btnPEdit.Location = new System.Drawing.Point(82, 3);
            this.btnPEdit.Name = "btnPEdit";
            this.btnPEdit.Size = new System.Drawing.Size(73, 28);
            this.btnPEdit.TabIndex = 1;
            this.btnPEdit.Text = "Edit";
            this.btnPEdit.UseVisualStyleBackColor = false;
            this.btnPEdit.Click += new System.EventHandler(this.btnPEdit_Click);
            // 
            // customTableLayoutPanel3
            // 
            this.customTableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel3.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel3.Color2 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel3.ColumnCount = 2;
            this.customTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel3.Controls.Add(this.btnTEdit, 1, 0);
            this.customTableLayoutPanel3.Controls.Add(this.btnTDelete, 0, 0);
            this.customTableLayoutPanel3.CustomCursor = false;
            this.customTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel3.DraggableForm = false;
            this.customTableLayoutPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel3.Location = new System.Drawing.Point(33, 275);
            this.customTableLayoutPanel3.Name = "customTableLayoutPanel3";
            this.customTableLayoutPanel3.RowCount = 1;
            this.customTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel3.Size = new System.Drawing.Size(157, 34);
            this.customTableLayoutPanel3.TabIndex = 1;
            // 
            // btnTEdit
            // 
            this.btnTEdit.BackColor = System.Drawing.Color.Lavender;
            this.btnTEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTEdit.ForeColor = System.Drawing.Color.Black;
            this.btnTEdit.Location = new System.Drawing.Point(81, 3);
            this.btnTEdit.Name = "btnTEdit";
            this.btnTEdit.Size = new System.Drawing.Size(73, 28);
            this.btnTEdit.TabIndex = 1;
            this.btnTEdit.Text = "Edit";
            this.btnTEdit.UseVisualStyleBackColor = false;
            this.btnTEdit.Click += new System.EventHandler(this.btnTEdit_Click);
            // 
            // btnTDelete
            // 
            this.btnTDelete.BackColor = System.Drawing.Color.Lavender;
            this.btnTDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnTDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTDelete.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTDelete.ForeColor = System.Drawing.Color.Black;
            this.btnTDelete.Location = new System.Drawing.Point(3, 3);
            this.btnTDelete.Name = "btnTDelete";
            this.btnTDelete.Size = new System.Drawing.Size(72, 28);
            this.btnTDelete.TabIndex = 0;
            this.btnTDelete.Text = "Delete";
            this.btnTDelete.UseVisualStyleBackColor = false;
            this.btnTDelete.Click += new System.EventHandler(this.btnTDelete_Click);
            // 
            // customTableLayoutPanel4
            // 
            this.customTableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel4.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel4.Color2 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel4.ColumnCount = 1;
            this.customTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel4.Controls.Add(this.btnSearch, 0, 3);
            this.customTableLayoutPanel4.Controls.Add(this.rbnTeams, 0, 2);
            this.customTableLayoutPanel4.Controls.Add(this.rbnPlayers, 0, 1);
            this.customTableLayoutPanel4.Controls.Add(this.tbxSearch, 0, 0);
            this.customTableLayoutPanel4.CustomCursor = false;
            this.customTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel4.DraggableForm = false;
            this.customTableLayoutPanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel4.Location = new System.Drawing.Point(226, 33);
            this.customTableLayoutPanel4.Name = "customTableLayoutPanel4";
            this.customTableLayoutPanel4.RowCount = 4;
            this.customTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.customTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.customTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel4.Size = new System.Drawing.Size(157, 236);
            this.customTableLayoutPanel4.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.BackColor = System.Drawing.Color.Lavender;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(50, 148);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbnTeams
            // 
            this.rbnTeams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbnTeams.AutoSize = true;
            this.rbnTeams.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnTeams.ForeColor = System.Drawing.Color.GhostWhite;
            this.rbnTeams.Location = new System.Drawing.Point(46, 121);
            this.rbnTeams.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.rbnTeams.Name = "rbnTeams";
            this.rbnTeams.Size = new System.Drawing.Size(65, 20);
            this.rbnTeams.TabIndex = 2;
            this.rbnTeams.TabStop = true;
            this.rbnTeams.Text = "Teams  ";
            this.rbnTeams.UseVisualStyleBackColor = true;
            // 
            // rbnPlayers
            // 
            this.rbnPlayers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbnPlayers.AutoSize = true;
            this.rbnPlayers.Checked = true;
            this.rbnPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnPlayers.ForeColor = System.Drawing.Color.GhostWhite;
            this.rbnPlayers.Location = new System.Drawing.Point(47, 94);
            this.rbnPlayers.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.rbnPlayers.Name = "rbnPlayers";
            this.rbnPlayers.Size = new System.Drawing.Size(63, 20);
            this.rbnPlayers.TabIndex = 1;
            this.rbnPlayers.TabStop = true;
            this.rbnPlayers.Text = "Players";
            this.rbnPlayers.UseVisualStyleBackColor = true;
            // 
            // tbxSearch
            // 
            this.tbxSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbxSearch.Animated = true;
            this.tbxSearch.AnimateLength = 50;
            this.tbxSearch.AnimTimeInterval = 0;
            this.tbxSearch.BackgroundColor = System.Drawing.Color.White;
            this.tbxSearch.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.tbxSearch.ForeColor = System.Drawing.Color.DimGray;
            this.tbxSearch.Location = new System.Drawing.Point(35, 58);
            this.tbxSearch.MinimumSize = new System.Drawing.Size(83, 27);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(87, 30);
            this.tbxSearch.TabIndex = 0;
            this.tbxSearch.TabStop = false;
            this.tbxSearch.TextS = "🔍 search";
            this.tbxSearch.TextSearch = "🔍 search";
            // 
            // customControlBox1
            // 
            this.customControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.customControlBox1.BackColorBtns = System.Drawing.Color.Transparent;
            this.customControlBox1.ColorMouseDownExit = System.Drawing.Color.Empty;
            this.customControlBox1.ColorMouseDownMaximize = System.Drawing.Color.Empty;
            this.customControlBox1.ColorMouseDownMinimize = System.Drawing.Color.Empty;
            this.customControlBox1.ColorMouseHoverExit = System.Drawing.Color.Red;
            this.customControlBox1.ColorMouseHoverMaximize = System.Drawing.Color.DimGray;
            this.customControlBox1.ColorMouseHoverMinimize = System.Drawing.Color.DimGray;
            this.customControlBox1.ForeColorBtns = System.Drawing.Color.FloralWhite;
            this.customControlBox1.Location = new System.Drawing.Point(545, 8);
            this.customControlBox1.Margin = new System.Windows.Forms.Padding(0);
            this.customControlBox1.MinimumSize = new System.Drawing.Size(60, 25);
            this.customControlBox1.Name = "customControlBox1";
            this.customControlBox1.Size = new System.Drawing.Size(86, 25);
            this.customControlBox1.TabIndex = 0;
            this.customControlBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AppTitle.Icon = ((System.Drawing.Icon)(resources.GetObject("resource.Icon")));
            this.AppTitle.IconLocation = new System.Drawing.Point(10, 10);
            this.AppTitle.IconSize = new System.Drawing.Size(32, 32);
            this.AppTitle.ShowIcon = true;
            this.AppTitle.ShowTextTitle = true;
            this.AppTitle.TextColor = System.Drawing.Color.GhostWhite;
            this.AppTitle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitle.TextLocation = new System.Drawing.Point(50, 15);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(640, 440);
            this.Controls.Add(this.customControlBox1);
            this.Controls.Add(this.customPanel1);
            this.CustomCursor = true;
            this.FormBackColor.GradientColor1 = System.Drawing.Color.Black;
            this.FormBackColor.GradientColor2 = System.Drawing.Color.Red;
            this.FormBackColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.FormBorders.Color = System.Drawing.Color.Maroon;
            this.FormBorders.DrawBorders = true;
            this.FormBorders.Width = 8;
            this.MinimumSize = new System.Drawing.Size(640, 440);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8, 50, 9, 8);
            this.ResizeGripColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Manager";
            this.customPanel1.ResumeLayout(false);
            this.customTableLayoutPanel1.ResumeLayout(false);
            this.customTableLayoutPanel1.PerformLayout();
            this.customTableLayoutPanel2.ResumeLayout(false);
            this.customTableLayoutPanel3.ResumeLayout(false);
            this.customTableLayoutPanel4.ResumeLayout(false);
            this.customTableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Custom.CustomControlBox customControlBox1;
        private System.Windows.Forms.Custom.CustomPanel customPanel1;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel1;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel2;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel3;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel4;
        private System.Windows.Forms.Custom.CustomTextBoxSearch tbxSearch;
        private System.Windows.Forms.RadioButton rbnPlayers;
        private System.Windows.Forms.RadioButton rbnTeams;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblTeams;
        private System.Windows.Forms.ListBox lbxPlayers;
        private System.Windows.Forms.ListBox lbxTeams;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnTCreate;
        private System.Windows.Forms.Button btnTEdit;
        private System.Windows.Forms.Button btnTDelete;
        private System.Windows.Forms.Button btnPCreate;
        private System.Windows.Forms.Button btnPEdit;
        private System.Windows.Forms.Button btnPDelete;
        private System.Windows.Forms.Button btnShowAllPlayers;
        private System.Windows.Forms.Button btnUnsignedPlayers;
    }
}

