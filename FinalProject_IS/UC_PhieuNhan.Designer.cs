namespace FinalProject_IS
{
    partial class UC_PhieuNhan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ThemPhieu = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtgvPhieuNhan = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.rtxb_SearchBox = new System.Windows.Forms.RichTextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cb_Box_Filter = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_ThemPhieu);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.dtgvPhieuNhan);
            this.panel2.Controls.Add(this.btn_Search);
            this.panel2.Controls.Add(this.rtxb_SearchBox);
            this.panel2.Controls.Add(this.btnFilter);
            this.panel2.Controls.Add(this.cb_Box_Filter);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(16, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1150, 448);
            this.panel2.TabIndex = 49;
            // 
            // btn_ThemPhieu
            // 
            this.btn_ThemPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(161)))), ((int)(((byte)(203)))));
            this.btn_ThemPhieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btn_ThemPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThemPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.btn_ThemPhieu.Location = new System.Drawing.Point(888, 94);
            this.btn_ThemPhieu.Name = "btn_ThemPhieu";
            this.btn_ThemPhieu.Size = new System.Drawing.Size(205, 27);
            this.btn_ThemPhieu.TabIndex = 47;
            this.btn_ThemPhieu.Text = "+Thêm phiếu nhận mới";
            this.btn_ThemPhieu.UseVisualStyleBackColor = false;
            this.btn_ThemPhieu.Click += new System.EventHandler(this.btn_ThemPhieu_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(951, 575);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(114, 28);
            this.numericUpDown1.TabIndex = 45;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(840, 569);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 43);
            this.button3.TabIndex = 43;
            this.button3.Text = "Tiếp theo";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(730, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 43);
            this.button2.TabIndex = 42;
            this.button2.Text = "Lùi lại";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dtgvPhieuNhan
            // 
            this.dtgvPhieuNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPhieuNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPhieuNhan.Location = new System.Drawing.Point(34, 127);
            this.dtgvPhieuNhan.Name = "dtgvPhieuNhan";
            this.dtgvPhieuNhan.RowHeadersWidth = 51;
            this.dtgvPhieuNhan.Size = new System.Drawing.Size(1059, 424);
            this.dtgvPhieuNhan.TabIndex = 41;
            this.dtgvPhieuNhan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhieuNhan_CellContentClick);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(161)))), ((int)(((byte)(203)))));
            this.btn_Search.Location = new System.Drawing.Point(960, 28);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(57, 35);
            this.btn_Search.TabIndex = 40;
            this.btn_Search.Text = "⌕";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // rtxb_SearchBox
            // 
            this.rtxb_SearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.rtxb_SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxb_SearchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.rtxb_SearchBox.Location = new System.Drawing.Point(424, 28);
            this.rtxb_SearchBox.Name = "rtxb_SearchBox";
            this.rtxb_SearchBox.Size = new System.Drawing.Size(530, 35);
            this.rtxb_SearchBox.TabIndex = 39;
            this.rtxb_SearchBox.Text = "Nhập mã phiếu nhận";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(161)))), ((int)(((byte)(203)))));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(212, 28);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(57, 26);
            this.btnFilter.TabIndex = 24;
            this.btnFilter.Text = "↑↓";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cb_Box_Filter
            // 
            this.cb_Box_Filter.AutoCompleteCustomSource.AddRange(new string[] {
            "Lọc theo tên"});
            this.cb_Box_Filter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_Box_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Box_Filter.FormattingEnabled = true;
            this.cb_Box_Filter.Items.AddRange(new object[] {
            "Sắp xếp theo ngày",
            "Sắp xếp theo mã"});
            this.cb_Box_Filter.Location = new System.Drawing.Point(29, 28);
            this.cb_Box_Filter.Name = "cb_Box_Filter";
            this.cb_Box_Filter.Size = new System.Drawing.Size(177, 26);
            this.cb_Box_Filter.TabIndex = 22;
            this.cb_Box_Filter.Text = "Lọc theo tên mã";
            this.cb_Box_Filter.SelectedIndexChanged += new System.EventHandler(this.cb_Box_Filter_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(482, 639);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(245, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "__________________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 31);
            this.label1.TabIndex = 50;
            this.label1.Text = "Phần mềm bán hàng VNBSports";
            // 
            // UC_PhieuNhan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Name = "UC_PhieuNhan";
            this.Size = new System.Drawing.Size(1182, 513);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dtgvPhieuNhan;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.RichTextBox rtxb_SearchBox;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cb_Box_Filter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ThemPhieu;
    }
}
