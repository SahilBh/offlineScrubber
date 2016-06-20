namespace OfflineScrubber
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnChoose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_sheet = new System.Windows.Forms.ComboBox();
            this.loadingBar = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.sheet_and_type = new System.Windows.Forms.Label();
            this.filename_holder = new System.Windows.Forms.Label();
            this.Reload_btn = new System.Windows.Forms.Button();
            this.Refresh_btn = new System.Windows.Forms.Button();
            this.Export_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChoose.Location = new System.Drawing.Point(12, 16);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(76, 23);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "Select";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(824, 324);
            this.dataGridView1.TabIndex = 2;
            // 
            // comboBox_sheet
            // 
            this.comboBox_sheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_sheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sheet.FormattingEnabled = true;
            this.comboBox_sheet.Location = new System.Drawing.Point(544, 16);
            this.comboBox_sheet.Name = "comboBox_sheet";
            this.comboBox_sheet.Size = new System.Drawing.Size(160, 21);
            this.comboBox_sheet.TabIndex = 3;
            // 
            // loadingBar
            // 
            this.loadingBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadingBar.AutoSize = true;
            this.loadingBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadingBar.Location = new System.Drawing.Point(13, 386);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(61, 15);
            this.loadingBar.TabIndex = 4;
            this.loadingBar.Text = "Loading...";
            // 
            // comboBox_type
            // 
            this.comboBox_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "All",
            "Random 500",
            "Random 1000",
            "Remaining True Positives"});
            this.comboBox_type.Location = new System.Drawing.Point(377, 16);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(159, 21);
            this.comboBox_type.TabIndex = 5;
            // 
            // sheet_and_type
            // 
            this.sheet_and_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sheet_and_type.AutoSize = true;
            this.sheet_and_type.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sheet_and_type.Location = new System.Drawing.Point(13, 387);
            this.sheet_and_type.Name = "sheet_and_type";
            this.sheet_and_type.Size = new System.Drawing.Size(316, 13);
            this.sheet_and_type.TabIndex = 6;
            this.sheet_and_type.Text = "Showing: All of Sheet: Sheet1                                                    " +
    "    ";
            // 
            // filename_holder
            // 
            this.filename_holder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.filename_holder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filename_holder.Location = new System.Drawing.Point(390, 387);
            this.filename_holder.Name = "filename_holder";
            this.filename_holder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filename_holder.Size = new System.Drawing.Size(446, 13);
            this.filename_holder.TabIndex = 7;
            this.filename_holder.Text = "File name";
            this.filename_holder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Reload_btn
            // 
            this.Reload_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Reload_btn.Location = new System.Drawing.Point(96, 16);
            this.Reload_btn.Name = "Reload_btn";
            this.Reload_btn.Size = new System.Drawing.Size(75, 23);
            this.Reload_btn.TabIndex = 8;
            this.Reload_btn.Text = "Reload";
            this.Reload_btn.UseVisualStyleBackColor = true;
            this.Reload_btn.Click += new System.EventHandler(this.Reload_btn_Click);
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Refresh_btn.Location = new System.Drawing.Point(710, 14);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(58, 23);
            this.Refresh_btn.TabIndex = 9;
            this.Refresh_btn.Text = "Refresh";
            this.Refresh_btn.UseVisualStyleBackColor = true;
            this.Refresh_btn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Export_btn
            // 
            this.Export_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Export_btn.Location = new System.Drawing.Point(772, 13);
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.Size = new System.Drawing.Size(64, 23);
            this.Export_btn.TabIndex = 10;
            this.Export_btn.Text = "Export";
            this.Export_btn.UseVisualStyleBackColor = true;
            this.Export_btn.Click += new System.EventHandler(this.Export_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(848, 410);
            this.Controls.Add(this.Export_btn);
            this.Controls.Add(this.Refresh_btn);
            this.Controls.Add(this.Reload_btn);
            this.Controls.Add(this.filename_holder);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.loadingBar);
            this.Controls.Add(this.comboBox_sheet);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.sheet_and_type);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Offline Scrubber";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_sheet;
        private System.Windows.Forms.Label loadingBar;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label sheet_and_type;
        private System.Windows.Forms.Label filename_holder;
        private System.Windows.Forms.Button Reload_btn;
        private System.Windows.Forms.Button Refresh_btn;
        private System.Windows.Forms.Button Export_btn;
    }
}

