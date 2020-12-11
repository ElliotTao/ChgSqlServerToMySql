namespace ChgSqlServerToMySql
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
            this.SqlTextBox = new System.Windows.Forms.TextBox();
            this.MySqlTextBox = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SqlTextBox
            // 
            this.SqlTextBox.Location = new System.Drawing.Point(28, 12);
            this.SqlTextBox.Multiline = true;
            this.SqlTextBox.Name = "SqlTextBox";
            this.SqlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SqlTextBox.Size = new System.Drawing.Size(740, 150);
            this.SqlTextBox.TabIndex = 0;
            // 
            // MySqlTextBox
            // 
            this.MySqlTextBox.Location = new System.Drawing.Point(28, 251);
            this.MySqlTextBox.Multiline = true;
            this.MySqlTextBox.Name = "MySqlTextBox";
            this.MySqlTextBox.Size = new System.Drawing.Size(740, 150);
            this.MySqlTextBox.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(218, 182);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(106, 50);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "转换";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(452, 182);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(123, 50);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "复制MySQL脚本";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.MySqlTextBox);
            this.Controls.Add(this.SqlTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SqlTextBox;
        private System.Windows.Forms.TextBox MySqlTextBox;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCopy;
    }
}

