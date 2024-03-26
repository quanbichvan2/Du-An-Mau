namespace PS28709_QuanBichVan.View.UI.ThongKe
{
    partial class Statistical
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNhapKho = new System.Windows.Forms.TabPage();
            this.dataNhapKho = new System.Windows.Forms.DataGridView();
            this.tabTonKho = new System.Windows.Forms.TabPage();
            this.dataTonKho = new System.Windows.Forms.DataGridView();
            this.NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabNhapKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhapKho)).BeginInit();
            this.tabTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhapKho);
            this.tabControl1.Controls.Add(this.tabTonKho);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 279);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabNhapKho
            // 
            this.tabNhapKho.Controls.Add(this.dataNhapKho);
            this.tabNhapKho.Location = new System.Drawing.Point(4, 25);
            this.tabNhapKho.Name = "tabNhapKho";
            this.tabNhapKho.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhapKho.Size = new System.Drawing.Size(788, 250);
            this.tabNhapKho.TabIndex = 0;
            this.tabNhapKho.Text = "Nhập Kho";
            this.tabNhapKho.UseVisualStyleBackColor = true;
            // 
            // dataNhapKho
            // 
            this.dataNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNhapKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NhanVien});
            this.dataNhapKho.Location = new System.Drawing.Point(7, 29);
            this.dataNhapKho.Name = "dataNhapKho";
            this.dataNhapKho.RowHeadersWidth = 51;
            this.dataNhapKho.RowTemplate.Height = 24;
            this.dataNhapKho.Size = new System.Drawing.Size(778, 215);
            this.dataNhapKho.TabIndex = 0;
            // 
            // tabTonKho
            // 
            this.tabTonKho.Controls.Add(this.dataTonKho);
            this.tabTonKho.Location = new System.Drawing.Point(4, 25);
            this.tabTonKho.Name = "tabTonKho";
            this.tabTonKho.Padding = new System.Windows.Forms.Padding(3);
            this.tabTonKho.Size = new System.Drawing.Size(788, 250);
            this.tabTonKho.TabIndex = 1;
            this.tabTonKho.Text = "Tồn Kho";
            this.tabTonKho.UseVisualStyleBackColor = true;
            // 
            // dataTonKho
            // 
            this.dataTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTonKho.Location = new System.Drawing.Point(7, 30);
            this.dataTonKho.Name = "dataTonKho";
            this.dataTonKho.RowHeadersWidth = 51;
            this.dataTonKho.RowTemplate.Height = 24;
            this.dataTonKho.Size = new System.Drawing.Size(778, 214);
            this.dataTonKho.TabIndex = 0;
            // 
            // NhanVien
            // 
            this.NhanVien.HeaderText = "TenNhanVien";
            this.NhanVien.MinimumWidth = 6;
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.ReadOnly = true;
            this.NhanVien.Visible = false;
            this.NhanVien.Width = 125;
            // 
            // Statistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 287);
            this.Controls.Add(this.tabControl1);
            this.Name = "Statistical";
            this.Text = "Statistical";
            this.tabControl1.ResumeLayout(false);
            this.tabNhapKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataNhapKho)).EndInit();
            this.tabTonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTonKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNhapKho;
        private System.Windows.Forms.TabPage tabTonKho;
        private System.Windows.Forms.DataGridView dataTonKho;
        private System.Windows.Forms.DataGridView dataNhapKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVien;
    }
}