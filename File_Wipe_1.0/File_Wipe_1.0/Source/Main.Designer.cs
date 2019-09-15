namespace File_Wipe_1._0
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.file_btn = new System.Windows.Forms.Button();
            this.file_tb = new System.Windows.Forms.TextBox();
            this.file_lb = new System.Windows.Forms.Label();
            this.file_lv = new System.Windows.Forms.ListView();
            this.filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logo_lb = new System.Windows.Forms.Label();
            this.wiping_progressbar = new System.Windows.Forms.ProgressBar();
            this.progress_lb = new System.Windows.Forms.Label();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.wipe_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // file_btn
            // 
            this.file_btn.Location = new System.Drawing.Point(398, 28);
            this.file_btn.Name = "file_btn";
            this.file_btn.Size = new System.Drawing.Size(37, 23);
            this.file_btn.TabIndex = 0;
            this.file_btn.Text = "...";
            this.file_btn.UseVisualStyleBackColor = true;
            this.file_btn.Click += new System.EventHandler(this.file_btn_Click);
            // 
            // file_tb
            // 
            this.file_tb.Location = new System.Drawing.Point(129, 28);
            this.file_tb.Name = "file_tb";
            this.file_tb.ReadOnly = true;
            this.file_tb.Size = new System.Drawing.Size(264, 21);
            this.file_tb.TabIndex = 3;
            // 
            // file_lb
            // 
            this.file_lb.AutoSize = true;
            this.file_lb.Location = new System.Drawing.Point(81, 32);
            this.file_lb.Name = "file_lb";
            this.file_lb.Size = new System.Drawing.Size(41, 12);
            this.file_lb.TabIndex = 9;
            this.file_lb.Text = "파일 : ";
            // 
            // file_lv
            // 
            this.file_lv.AllowDrop = true;
            this.file_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filename,
            this.path,
            this.modified,
            this.size});
            this.file_lv.GridLines = true;
            this.file_lv.Location = new System.Drawing.Point(28, 93);
            this.file_lv.Name = "file_lv";
            this.file_lv.Size = new System.Drawing.Size(540, 339);
            this.file_lv.TabIndex = 5;
            this.file_lv.UseCompatibleStateImageBehavior = false;
            this.file_lv.View = System.Windows.Forms.View.Details;
            this.file_lv.DragDrop += new System.Windows.Forms.DragEventHandler(this.file_lv_DragDrop);
            this.file_lv.DragEnter += new System.Windows.Forms.DragEventHandler(this.file_lv_DragEnter);
            // 
            // filename
            // 
            this.filename.Text = "파일명";
            this.filename.Width = 100;
            // 
            // path
            // 
            this.path.Text = "파일경로";
            this.path.Width = 236;
            // 
            // modified
            // 
            this.modified.Text = "최종 수정일시";
            this.modified.Width = 100;
            // 
            // size
            // 
            this.size.Text = "파일크기";
            this.size.Width = 100;
            // 
            // logo_lb
            // 
            this.logo_lb.AutoSize = true;
            this.logo_lb.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.logo_lb.Location = new System.Drawing.Point(440, 449);
            this.logo_lb.Name = "logo_lb";
            this.logo_lb.Size = new System.Drawing.Size(145, 12);
            this.logo_lb.TabIndex = 13;
            this.logo_lb.Text = "대한민국 공군 군수전산소";
            // 
            // wiping_progressbar
            // 
            this.wiping_progressbar.Location = new System.Drawing.Point(129, 57);
            this.wiping_progressbar.Name = "wiping_progressbar";
            this.wiping_progressbar.Size = new System.Drawing.Size(307, 21);
            this.wiping_progressbar.TabIndex = 4;
            // 
            // progress_lb
            // 
            this.progress_lb.AutoSize = true;
            this.progress_lb.Location = new System.Drawing.Point(70, 62);
            this.progress_lb.Name = "progress_lb";
            this.progress_lb.Size = new System.Drawing.Size(53, 12);
            this.progress_lb.TabIndex = 15;
            this.progress_lb.Text = "진행률 : ";
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "모든 파일 (*.*)|*.*";
            // 
            // wipe_btn
            // 
            this.wipe_btn.Location = new System.Drawing.Point(441, 28);
            this.wipe_btn.Name = "wipe_btn";
            this.wipe_btn.Size = new System.Drawing.Size(83, 50);
            this.wipe_btn.TabIndex = 1;
            this.wipe_btn.Text = "완전삭제";
            this.wipe_btn.UseVisualStyleBackColor = true;
            this.wipe_btn.Click += new System.EventHandler(this.wipe_btn_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(591, 469);
            this.Controls.Add(this.wipe_btn);
            this.Controls.Add(this.progress_lb);
            this.Controls.Add(this.wiping_progressbar);
            this.Controls.Add(this.logo_lb);
            this.Controls.Add(this.file_lv);
            this.Controls.Add(this.file_btn);
            this.Controls.Add(this.file_tb);
            this.Controls.Add(this.file_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "파일 완전삭제 프로그램";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button file_btn;
        private System.Windows.Forms.TextBox file_tb;
        private System.Windows.Forms.Label file_lb;
        private System.Windows.Forms.ListView file_lv;
        private System.Windows.Forms.ColumnHeader filename;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader modified;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.Label logo_lb;
        private System.Windows.Forms.ProgressBar wiping_progressbar;
        private System.Windows.Forms.Label progress_lb;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button wipe_btn;
    }
}

