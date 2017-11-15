namespace TeamManager.Views.Forms.ChildForms
{
    partial class UnsignedPlayersForm
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
            this.btnPCreate = new System.Windows.Forms.Button();
            this.lbxPlayers = new System.Windows.Forms.ListBox();
            this.btnPAddToTeam = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnPDelete = new System.Windows.Forms.Button();
            this.customControlBoxDialog1 = new System.Windows.Forms.Custom.CustomControlBoxDialog();
            this.customTableLayoutPanel1 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.customTableLayoutPanel2 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.customTableLayoutPanel1.SuspendLayout();
            this.customTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPCreate
            // 
            this.btnPCreate.BackColor = System.Drawing.Color.Lavender;
            this.btnPCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPCreate.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnPCreate.ForeColor = System.Drawing.Color.Black;
            this.btnPCreate.Location = new System.Drawing.Point(111, 0);
            this.btnPCreate.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.btnPCreate.Name = "btnPCreate";
            this.btnPCreate.Size = new System.Drawing.Size(107, 34);
            this.btnPCreate.TabIndex = 1;
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
            this.lbxPlayers.ItemHeight = 19;
            this.lbxPlayers.Items.AddRange(new object[] {
            "Neville Southall",
            "James Chester",
            "Gareth Southgate",
            "Clarke Carlisle",
            "Jermaine Darlington",
            "Stuart Ripley",
            "Steve Stone"});
            this.lbxPlayers.Location = new System.Drawing.Point(26, 50);
            this.lbxPlayers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbxPlayers.Name = "lbxPlayers";
            this.lbxPlayers.Size = new System.Drawing.Size(215, 251);
            this.lbxPlayers.TabIndex = 0;
            // 
            // btnPAddToTeam
            // 
            this.btnPAddToTeam.BackColor = System.Drawing.Color.Lavender;
            this.btnPAddToTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPAddToTeam.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPAddToTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPAddToTeam.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnPAddToTeam.ForeColor = System.Drawing.Color.Black;
            this.btnPAddToTeam.Location = new System.Drawing.Point(26, 341);
            this.btnPAddToTeam.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnPAddToTeam.Name = "btnPAddToTeam";
            this.btnPAddToTeam.Size = new System.Drawing.Size(215, 30);
            this.btnPAddToTeam.TabIndex = 2;
            this.btnPAddToTeam.Text = "Add to Team";
            this.btnPAddToTeam.UseVisualStyleBackColor = false;
            this.btnPAddToTeam.Click += new System.EventHandler(this.btnPAddToTeam_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F);
            this.lblHeader.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblHeader.Location = new System.Drawing.Point(25, 23);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(216, 24);
            this.lblHeader.TabIndex = 5;
            this.lblHeader.Text = "Players With No Team";
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
            this.btnPDelete.Location = new System.Drawing.Point(3, 0);
            this.btnPDelete.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.btnPDelete.Name = "btnPDelete";
            this.btnPDelete.Size = new System.Drawing.Size(106, 34);
            this.btnPDelete.TabIndex = 0;
            this.btnPDelete.Text = "Delete";
            this.btnPDelete.UseVisualStyleBackColor = false;
            this.btnPDelete.Click += new System.EventHandler(this.btnPDelete_Click);
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
            this.customControlBoxDialog1.Location = new System.Drawing.Point(215, 8);
            this.customControlBoxDialog1.Margin = new System.Windows.Forms.Padding(0);
            this.customControlBoxDialog1.MinimumSize = new System.Drawing.Size(50, 25);
            this.customControlBoxDialog1.Name = "customControlBoxDialog1";
            this.customControlBoxDialog1.Size = new System.Drawing.Size(60, 29);
            this.customControlBoxDialog1.TabIndex = 1;
            this.customControlBoxDialog1.TabStop = false;
            // 
            // customTableLayoutPanel1
            // 
            this.customTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color2 = System.Drawing.Color.Black;
            this.customTableLayoutPanel1.ColumnCount = 3;
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customTableLayoutPanel1.Controls.Add(this.lbxPlayers, 1, 2);
            this.customTableLayoutPanel1.Controls.Add(this.lblHeader, 1, 1);
            this.customTableLayoutPanel1.Controls.Add(this.customTableLayoutPanel2, 1, 3);
            this.customTableLayoutPanel1.Controls.Add(this.btnPAddToTeam, 1, 4);
            this.customTableLayoutPanel1.CustomCursor = false;
            this.customTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel1.DraggableForm = false;
            this.customTableLayoutPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel1.Location = new System.Drawing.Point(8, 50);
            this.customTableLayoutPanel1.Name = "customTableLayoutPanel1";
            this.customTableLayoutPanel1.RowCount = 6;
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.customTableLayoutPanel1.Size = new System.Drawing.Size(267, 403);
            this.customTableLayoutPanel1.TabIndex = 9;
            // 
            // customTableLayoutPanel2
            // 
            this.customTableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.Color2 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel2.ColumnCount = 2;
            this.customTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel2.Controls.Add(this.btnPCreate, 1, 0);
            this.customTableLayoutPanel2.Controls.Add(this.btnPDelete, 0, 0);
            this.customTableLayoutPanel2.CustomCursor = false;
            this.customTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel2.DraggableForm = false;
            this.customTableLayoutPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel2.Location = new System.Drawing.Point(23, 304);
            this.customTableLayoutPanel2.Name = "customTableLayoutPanel2";
            this.customTableLayoutPanel2.RowCount = 1;
            this.customTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customTableLayoutPanel2.Size = new System.Drawing.Size(221, 34);
            this.customTableLayoutPanel2.TabIndex = 1;
            // 
            // UnsignedPlayersForm
            // 
            this.AppTitle.Icon = null;
            this.AppTitle.IconLocation = new System.Drawing.Point(0, 0);
            this.AppTitle.IconSize = new System.Drawing.Size(0, 0);
            this.AppTitle.ShowIcon = false;
            this.AppTitle.ShowTextTitle = true;
            this.AppTitle.TextColor = System.Drawing.Color.GhostWhite;
            this.AppTitle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitle.TextLocation = new System.Drawing.Point(10, 15);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.customTableLayoutPanel1);
            this.Controls.Add(this.customControlBoxDialog1);
            this.CustomCursor = true;
            this.FormBackColor.GradientColor1 = System.Drawing.Color.Black;
            this.FormBackColor.GradientColor2 = System.Drawing.Color.Blue;
            this.FormBackColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.FormBorders.Color = System.Drawing.Color.MediumSlateBlue;
            this.FormBorders.DrawBorders = true;
            this.FormBorders.Width = 8;
            this.MaximumSize = new System.Drawing.Size(669, 748);
            this.MinimumSize = new System.Drawing.Size(284, 461);
            this.Name = "UnsignedPlayersForm";
            this.Padding = new System.Windows.Forms.Padding(8, 50, 9, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unsigned Players";
            this.customTableLayoutPanel1.ResumeLayout(false);
            this.customTableLayoutPanel1.PerformLayout();
            this.customTableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Custom.CustomControlBoxDialog customControlBoxDialog1;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel1;
        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ListBox lbxPlayers;
        private System.Windows.Forms.Button btnPAddToTeam;
        private System.Windows.Forms.Button btnPCreate;
        private System.Windows.Forms.Button btnPDelete;
    }
}