namespace FinalProject_IS
{
    partial class F_DangNhap
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
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Location = new System.Drawing.Point(167, 274);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(106, 31);
            this.btn_XacNhan.TabIndex = 1;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Location = new System.Drawing.Point(122, 224);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(247, 22);
            this.txt_MatKhau.TabIndex = 3;
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Location = new System.Drawing.Point(122, 130);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(247, 22);
            this.txt_MaNV.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật Khẩu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FinalProject_IS.Properties.Resources.tải_xuống;
            this.pictureBox1.Location = new System.Drawing.Point(15, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // F_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(443, 371);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MaNV);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.label1);
            this.Name = "F_DangNhap";
            this.Text = "F_DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}