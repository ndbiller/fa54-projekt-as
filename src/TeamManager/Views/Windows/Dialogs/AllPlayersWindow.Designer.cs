namespace TeamManager.Views.Windows.Dialogs
{
    partial class AllPlayersWindow
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbxTeam = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lbTeam = new System.Windows.Forms.Label();
            this.btnPCreate = new System.Windows.Forms.Button();
            this.lbxPlayers = new System.Windows.Forms.ListBox();
            this.btnPEdit = new System.Windows.Forms.Button();
            this.lblAllPlayers = new System.Windows.Forms.Label();
            this.btnPDelete = new System.Windows.Forms.Button();
            this.customTableLayoutPanel1 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.customTableLayoutPanel2 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.customTableLayoutPanel3 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.customControlBoxDialog1 = new System.Windows.Forms.Custom.CustomControlBoxDialog();
            this.customTableLayoutPanel1.SuspendLayout();
            this.customTableLayoutPanel2.SuspendLayout();
            this.customTableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblName.Location = new System.Drawing.Point(13, 61);
            this.lblName.Margin = new System.Windows.Forms.Padding(13, 4, 40, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 24);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name:";
            // 
            // tbxTeam
            // 
            this.tbxTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTeam.Enabled = false;
            this.tbxTeam.Location = new System.Drawing.Point(13, 163);
            this.tbxTeam.Margin = new System.Windows.Forms.Padding(13, 4, 29, 4);
            this.tbxTeam.Name = "tbxTeam";
            this.tbxTeam.ReadOnly = true;
            this.tbxTeam.Size = new System.Drawing.Size(140, 22);
            this.tbxTeam.TabIndex = 9;
            this.tbxTeam.TabStop = false;
            // 
            // tbxName
            // 
            this.tbxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(13, 93);
            this.tbxName.Margin = new System.Windows.Forms.Padding(13, 4, 29, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.ReadOnly = true;
            this.tbxName.Size = new System.Drawing.Size(140, 22);
            this.tbxName.TabIndex = 9;
            this.tbxName.TabStop = false;
            // 
            // lbTeam
            // 
            this.lbTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTeam.AutoSize = true;
            this.lbTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbTeam.Location = new System.Drawing.Point(13, 131);
            this.lbTeam.Margin = new System.Windows.Forms.Padding(13, 4, 40, 4);
            this.lbTeam.Name = "lbTeam";
            this.lbTeam.Size = new System.Drawing.Size(64, 24);
            this.lbTeam.TabIndex = 11;
            this.lbTeam.Text = "Team:";
            // 
            // btnPCreate
            // 
            this.btnPCreate.BackColor = System.Drawing.Color.Lavender;
            this.btnPCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPCreate.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnPCreate.ForeColor = System.Drawing.Color.Black;
            this.btnPCreate.Location = new System.Drawing.Point(41, 568);
            this.btnPCreate.Margin = new System.Windows.Forms.Padding(8, 0, 8, 15);
            this.btnPCreate.Name = "btnPCreate";
            this.btnPCreate.Size = new System.Drawing.Size(250, 34);
            this.btnPCreate.TabIndex = 2;
            this.btnPCreate.Text = "Create";
            this.btnPCreate.UseVisualStyleBackColor = false;
            this.btnPCreate.Click += new System.EventHandler(this.btnPCreate_Click);
            // 
            // lbxPlayers
            // 
            this.lbxPlayers.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lbxPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lbxPlayers.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbxPlayers.FormattingEnabled = true;
            this.lbxPlayers.ItemHeight = 23;
            this.lbxPlayers.Items.AddRange(new object[] {
            "Bob Donaldson",
            "Fred Erentz",
            "Joe Cassidy",
            "James McNaught",
            "Dick Smith",
            "Walter Cartwright",
            "Harry Stafford",
            "Neville Southall",
            "James Chester",
            "Gareth Southgate",
            "Clarke Carlisle",
            "Jermaine Darlington",
            "Stuart Ripley",
            "Steve Stone"});
            this.lbxPlayers.Location = new System.Drawing.Point(41, 41);
            this.lbxPlayers.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.lbxPlayers.Name = "lbxPlayers";
            this.lbxPlayers.Size = new System.Drawing.Size(250, 474);
            this.lbxPlayers.TabIndex = 0;
            this.lbxPlayers.SelectedIndexChanged += new System.EventHandler(this.lbxPlayers_SelectedIndexChanged);
            // 
            // btnPEdit
            // 
            this.btnPEdit.BackColor = System.Drawing.Color.Lavender;
            this.btnPEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnPEdit.ForeColor = System.Drawing.Color.Black;
            this.btnPEdit.Location = new System.Drawing.Point(133, 4);
            this.btnPEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnPEdit.Name = "btnPEdit";
            this.btnPEdit.Size = new System.Drawing.Size(121, 33);
            this.btnPEdit.TabIndex = 1;
            this.btnPEdit.Text = "Edit";
            this.btnPEdit.UseVisualStyleBackColor = false;
            this.btnPEdit.Click += new System.EventHandler(this.btnPEdit_Click);
            // 
            // lblAllPlayers
            // 
            this.lblAllPlayers.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblAllPlayers.AutoSize = true;
            this.lblAllPlayers.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F);
            this.lblAllPlayers.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblAllPlayers.Location = new System.Drawing.Point(78, 4);
            this.lblAllPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.lblAllPlayers.Name = "lblAllPlayers";
            this.lblAllPlayers.Size = new System.Drawing.Size(176, 29);
            this.lblAllPlayers.TabIndex = 5;
            this.lblAllPlayers.Text = "All Players List";
            // 
            // btnPDelete
            // 
            this.btnPDelete.BackColor = System.Drawing.Color.Lavender;
            this.btnPDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnPDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDelete.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnPDelete.ForeColor = System.Drawing.Color.Black;
            this.btnPDelete.Location = new System.Drawing.Point(4, 4);
            this.btnPDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnPDelete.Name = "btnPDelete";
            this.btnPDelete.Size = new System.Drawing.Size(121, 33);
            this.btnPDelete.TabIndex = 0;
            this.btnPDelete.Text = "Delete";
            this.btnPDelete.UseVisualStyleBackColor = false;
            this.btnPDelete.Click += new System.EventHandler(this.btnPDelete_Click);
            // 
            // customTableLayoutPanel1
            // 
            this.customTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color2 = System.Drawing.Color.Black;
            this.customTableLayoutPanel1.ColumnCount = 4;
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.customTableLayoutPanel1.Controls.Add(this.lbxPlayers, 1, 1);
            this.customTableLayoutPanel1.Controls.Add(this.btnPCreate, 1, 3);
            this.customTableLayoutPanel1.Controls.Add(this.lblAllPlayers, 1, 0);
            this.customTableLayoutPanel1.Controls.Add(this.customTableLayoutPanel2, 2, 1);
            this.customTableLayoutPanel1.Controls.Add(this.customTableLayoutPanel3, 1, 2);
            this.customTableLayoutPanel1.CustomCursor = false;
            this.customTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel1.DraggableForm = false;
            this.customTableLayoutPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel1.Location = new System.Drawing.Point(11, 62);
            this.customTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.customTableLayoutPanel1.Name = "customTableLayoutPanel1";
            this.customTableLayoutPanel1.RowCount = 5;
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.customTableLayoutPanel1.Size = new System.Drawing.Size(541, 642);
            this.customTableLayoutPanel1.TabIndex = 12;
            // 
            // customTableLayoutPanel2
            // 
            this.customTableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.Color2 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.ColumnCount = 1;
            this.customTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
            this.customTableLayoutPanel2.Controls.Add(this.lbTeam, 0, 2);
            this.customTableLayoutPanel2.Controls.Add(this.tbxTeam, 0, 3);
            this.customTableLayoutPanel2.Controls.Add(this.tbxName, 0, 1);
            this.customTableLayoutPanel2.CustomCursor = false;
            this.customTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel2.DraggableForm = false;
            this.customTableLayoutPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel2.Location = new System.Drawing.Point(303, 41);
            this.customTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.customTableLayoutPanel2.Name = "customTableLayoutPanel2";
            this.customTableLayoutPanel2.RowCount = 4;
            this.customTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.customTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.customTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.customTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.customTableLayoutPanel2.Size = new System.Drawing.Size(182, 474);
            this.customTableLayoutPanel2.TabIndex = 6;
            // 
            // customTableLayoutPanel3
            // 
            this.customTableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel3.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel3.Color2 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel3.ColumnCount = 2;
            this.customTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel3.Controls.Add(this.btnPDelete, 0, 0);
            this.customTableLayoutPanel3.Controls.Add(this.btnPEdit, 1, 0);
            this.customTableLayoutPanel3.CustomCursor = false;
            this.customTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel3.DraggableForm = false;
            this.customTableLayoutPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel3.Location = new System.Drawing.Point(37, 523);
            this.customTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.customTableLayoutPanel3.Name = "customTableLayoutPanel3";
            this.customTableLayoutPanel3.RowCount = 1;
            this.customTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel3.Size = new System.Drawing.Size(258, 41);
            this.customTableLayoutPanel3.TabIndex = 1;
            // 
            // customControlBoxDialog1
            // 
            this.customControlBoxDialog1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customControlBoxDialog1.BackColor = System.Drawing.Color.Transparent;
            this.customControlBoxDialog1.BackColorBtns = System.Drawing.Color.Transparent;
            this.customControlBoxDialog1.ColorMouseDownExit = System.Drawing.Color.Empty;
            this.customControlBoxDialog1.ColorMouseDownMinimize = System.Drawing.Color.Empty;
            this.customControlBoxDialog1.ColorMouseHoverExit = System.Drawing.Color.Red;
            this.customControlBoxDialog1.ColorMouseHoverMinimize = System.Drawing.Color.DimGray;
            this.customControlBoxDialog1.ForeColorBtns = System.Drawing.Color.FloralWhite;
            this.customControlBoxDialog1.Location = new System.Drawing.Point(485, 10);
            this.customControlBoxDialog1.Margin = new System.Windows.Forms.Padding(0);
            this.customControlBoxDialog1.MinimumSize = new System.Drawing.Size(67, 31);
            this.customControlBoxDialog1.Name = "customControlBoxDialog1";
            this.customControlBoxDialog1.Size = new System.Drawing.Size(67, 36);
            this.customControlBoxDialog1.TabIndex = 8;
            this.customControlBoxDialog1.TabStop = false;
            // 
            // AllPlayersWindow
            // 
            this.AppTitle.Icon = null;
            this.AppTitle.IconLocation = new System.Drawing.Point(0, 0);
            this.AppTitle.IconSize = new System.Drawing.Size(0, 0);
            this.AppTitle.ShowIcon = false;
            this.AppTitle.ShowTextTitle = true;
            this.AppTitle.TextColor = System.Drawing.Color.GhostWhite;
            this.AppTitle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitle.TextLocation = new System.Drawing.Point(10, 15);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(564, 714);
            this.Controls.Add(this.customControlBoxDialog1);
            this.Controls.Add(this.customTableLayoutPanel1);
            this.CustomCursor = true;
            this.FormBackColor.GradientColor1 = System.Drawing.Color.Black;
            this.FormBackColor.GradientColor2 = System.Drawing.Color.BlueViolet;
            this.FormBackColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.FormBorders.Color = System.Drawing.Color.MediumPurple;
            this.FormBorders.DrawBorders = true;
            this.FormBorders.Width = 8;
            this.Icon = global::TeamManager.Properties.Resources.app;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1067, 1034);
            this.MinimumSize = new System.Drawing.Size(564, 714);
            this.Name = "AllPlayersWindow";
            this.Padding = new System.Windows.Forms.Padding(11, 62, 12, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Players";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AllPlayersWindow_FormClosed);
            this.customTableLayoutPanel1.ResumeLayout(false);
            this.customTableLayoutPanel1.PerformLayout();
            this.customTableLayoutPanel2.ResumeLayout(false);
            this.customTableLayoutPanel2.PerformLayout();
            this.customTableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel1;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel2;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel3;
        private System.Windows.Forms.Custom.CustomControlBoxDialog customControlBoxDialog1;
        private System.Windows.Forms.Label lblAllPlayers;
        private System.Windows.Forms.Label lbTeam;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListBox lbxPlayers;
        private System.Windows.Forms.TextBox tbxTeam;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnPCreate;
        private System.Windows.Forms.Button btnPEdit;
        private System.Windows.Forms.Button btnPDelete;
    }
}