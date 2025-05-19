namespace FinalProject_IS
{
    partial class F_DungMaKhuyenMai
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
            this.btn_SuDung = new System.Windows.Forms.Button();
            this.lbl_ThongBao = new System.Windows.Forms.Label();
            this.txt_SDT = new System.Windows.Forms.RichTextBox();
            this.button25 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(116, 134);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.RowTemplate.Height = 24;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(600, 140);
            this.dgvKhuyenMai.TabIndex = 0;
            // 
            // btn_SuDung
            // 
            this.btn_SuDung.Location = new System.Drawing.Point(283, 312);
            this.btn_SuDung.Name = "btn_SuDung";
            this.btn_SuDung.Size = new System.Drawing.Size(211, 57);
            this.btn_SuDung.TabIndex = 1;
            this.btn_SuDung.Text = "Sử Dụng";
            this.btn_SuDung.UseVisualStyleBackColor = true;
            this.btn_SuDung.Click += new System.EventHandler(this.btn_SuDung_Click);
            // 
            // lbl_ThongBao
            // 
            this.lbl_ThongBao.Location = new System.Drawing.Point(280, 44);
            this.lbl_ThongBao.Name = "lbl_ThongBao";
            this.lbl_ThongBao.Size = new System.Drawing.Size(283, 45);
            this.lbl_ThongBao.TabIndex = 2;
            this.lbl_ThongBao.Text = "Thông Báo";
            this.lbl_ThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ThongBao.Click += new System.EventHandler(this.lbl_ThongBao_Click);
            // 
            // txt_SDT
            // 
            this.txt_SDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.txt_SDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SDT.Location = new System.Drawing.Point(137, 24);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(167, 26);
            this.txt_SDT.TabIndex = 38;
            this.txt_SDT.Text = "";
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(220)))));
            this.button25.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(37, 24);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(105, 26);
            this.button25.TabIndex = 37;
            this.button25.Text = "SĐT";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // F_DungMaKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_SDT);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.lbl_ThongBao);
            this.Controls.Add(this.btn_SuDung);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Name = "F_DungMaKhuyenMai";
            this.Text = "F_DungMaKhuyenMai";
            this.Load += new System.EventHandler(this.F_DungMaKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Button btn_SuDung;
        private System.Windows.Forms.Label lbl_ThongBao;
        internal System.Windows.Forms.RichTextBox txt_SDT;
        private System.Windows.Forms.Button button25;
    }
}