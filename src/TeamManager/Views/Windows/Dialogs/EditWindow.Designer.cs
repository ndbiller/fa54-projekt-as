namespace TeamManager.Views.Windows.Dialogs
{
    partial class EditWindow
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
            this.cbxTeams = new System.Windows.Forms.ComboBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lbTeam = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.customTableLayoutPanel1 = new System.Windows.Forms.Custom.CustomTableLayoutPanel();
            this.customControlBoxDialog1 = new System.Windows.Forms.Custom.CustomControlBoxDialog();
            this.customTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblName.Location = new System.Drawing.Point(46, 43);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // cbxTeams
            // 
            this.cbxTeams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeams.FormattingEnabled = true;
            this.cbxTeams.Items.AddRange(new object[] {
            "England",
            "Arsenal",
            "Chelsea",
            "Manchester United",
            "Scotland",
            "Wales"});
            this.cbxTeams.Location = new System.Drawing.Point(124, 80);
            this.cbxTeams.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTeams.Name = "cbxTeams";
            this.cbxTeams.Size = new System.Drawing.Size(156, 24);
            this.cbxTeams.TabIndex = 2;
            // 
            // tbxName
            // 
            this.tbxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxName.Location = new System.Drawing.Point(124, 44);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(156, 22);
            this.tbxName.TabIndex = 1;
            // 
            // lbTeam
            // 
            this.lbTeam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTeam.AutoSize = true;
            this.lbTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbTeam.Location = new System.Drawing.Point(47, 80);
            this.lbTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTeam.Name = "lbTeam";
            this.lbTeam.Size = new System.Drawing.Size(69, 25);
            this.lbTeam.TabIndex = 2;
            this.lbTeam.Text = "Team:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lavender;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(285, 41);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Lavender;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(285, 78);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // customTableLayoutPanel1
            // 
            this.customTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color1 = System.Drawing.Color.Transparent;
            this.customTableLayoutPanel1.Color2 = System.Drawing.Color.Black;
            this.customTableLayoutPanel1.ColumnCount = 5;
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.customTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.customTableLayoutPanel1.Controls.Add(this.tbxName, 2, 1);
            this.customTableLayoutPanel1.Controls.Add(this.lblName, 1, 1);
            this.customTableLayoutPanel1.Controls.Add(this.cbxTeams, 2, 2);
            this.customTableLayoutPanel1.Controls.Add(this.lbTeam, 1, 2);
            this.customTableLayoutPanel1.Controls.Add(this.btnSave, 3, 1);
            this.customTableLayoutPanel1.Controls.Add(this.btnCancel, 3, 2);
            this.customTableLayoutPanel1.CustomCursor = false;
            this.customTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTableLayoutPanel1.DraggableForm = false;
            this.customTableLayoutPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.customTableLayoutPanel1.Location = new System.Drawing.Point(11, 62);
            this.customTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.customTableLayoutPanel1.Name = "customTableLayoutPanel1";
            this.customTableLayoutPanel1.RowCount = 4;
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.customTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.customTableLayoutPanel1.Size = new System.Drawing.Size(404, 174);
            this.customTableLayoutPanel1.TabIndex = 5;
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
            this.customControlBoxDialog1.Location = new System.Drawing.Point(349, 10);
            this.customControlBoxDialog1.Margin = new System.Windows.Forms.Padding(0);
            this.customControlBoxDialog1.MinimumSize = new System.Drawing.Size(67, 31);
            this.customControlBoxDialog1.Name = "customControlBoxDialog1";
            this.customControlBoxDialog1.Size = new System.Drawing.Size(67, 36);
            this.customControlBoxDialog1.TabIndex = 5;
            this.customControlBoxDialog1.TabStop = false;
            // 
            // EditWindow
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
            this.ClientSize = new System.Drawing.Size(427, 246);
            this.Controls.Add(this.customControlBoxDialog1);
            this.Controls.Add(this.customTableLayoutPanel1);
            this.CustomCursor = true;
            this.FormBackColor.GradientColor1 = System.Drawing.Color.Black;
            this.FormBackColor.GradientColor2 = System.Drawing.Color.Goldenrod;
            this.FormBackColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.FormBorders.Color = System.Drawing.Color.PeachPuff;
            this.FormBorders.DrawBorders = true;
            this.FormBorders.Width = 8;
            this.Icon = global::TeamManager.Properties.Resources.app;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(667, 246);
            this.MinimumSize = new System.Drawing.Size(427, 246);
            this.Name = "EditWindow";
            this.Padding = new System.Windows.Forms.Padding(11, 62, 12, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit \\ Create";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditWindow_FormClosed);
            this.customTableLayoutPanel1.ResumeLayout(false);
            this.customTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Custom.CustomTableLayoutPanel customTableLayoutPanel1;
        private System.Windows.Forms.Custom.CustomControlBoxDialog customControlBoxDialog1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lbTeam;
        private System.Windows.Forms.ComboBox cbxTeams;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}