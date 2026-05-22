namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            btnOpenExcelFile = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            SuspendLayout();
            // 
            // btnOpenExcelFile
            // 
            btnOpenExcelFile.Location = new System.Drawing.Point(288, 12);
            btnOpenExcelFile.Name = "btnOpenExcelFile";
            btnOpenExcelFile.Size = new System.Drawing.Size(180, 29);
            btnOpenExcelFile.TabIndex = 0;
            btnOpenExcelFile.Text = "选择Excel文件(*.xlsx/*.xls)";
            btnOpenExcelFile.UseVisualStyleBackColor = true;
            btnOpenExcelFile.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new System.Drawing.Point(12, 12);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new System.Drawing.Size(270, 418);
            checkedListBox1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(checkedListBox1);
            Controls.Add(btnOpenExcelFile);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnOpenExcelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

