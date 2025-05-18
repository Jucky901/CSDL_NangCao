namespace FinalProject_IS
{
    partial class F_DungKhuyenMai
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
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.btn_sudung = new System.Windows.Forms.Button();
            this.lbl_ThongBao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(72, 102);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.RowTemplate.Height = 24;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(648, 150);
            this.dgvKhuyenMai.TabIndex = 0;
            // 
            // btn_sudung
            // 
            this.btn_sudung.Location = new System.Drawing.Point(291, 310);
            this.btn_sudung.Name = "btn_sudung";
            this.btn_sudung.Size = new System.Drawing.Size(196, 56);
            this.btn_sudung.TabIndex = 1;
            this.btn_sudung.Text = "Sử dụng";
            this.btn_sudung.UseVisualStyleBackColor = true;
            this.btn_sudung.Click += new System.EventHandler(this.btn_sudung_Click);
            // 
            // lbl_ThongBao
            // 
            this.lbl_ThongBao.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_ThongBao.Location = new System.Drawing.Point(231, 31);
            this.lbl_ThongBao.Name = "lbl_ThongBao";
            this.lbl_ThongBao.Size = new System.Drawing.Size(342, 39);
            this.lbl_ThongBao.TabIndex = 2;
            this.lbl_ThongBao.Text = "ThongBao";
            this.lbl_ThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // F_DungKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_ThongBao);
            this.Controls.Add(this.btn_sudung);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Name = "F_DungKhuyenMai";
            this.Text = "F_DungKhuyenMai";
            this.Load += new System.EventHandler(this.F_DungKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Button btn_sudung;
        private System.Windows.Forms.Label lbl_ThongBao;
    }
}