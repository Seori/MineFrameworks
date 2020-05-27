namespace MineTestForm
{
    partial class ThreadCheckForm
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
            this.tbThreadInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbThreadInfo
            // 
            this.tbThreadInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbThreadInfo.Location = new System.Drawing.Point(0, 0);
            this.tbThreadInfo.Multiline = true;
            this.tbThreadInfo.Name = "tbThreadInfo";
            this.tbThreadInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbThreadInfo.Size = new System.Drawing.Size(383, 236);
            this.tbThreadInfo.TabIndex = 0;
            // 
            // ThreadCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 236);
            this.Controls.Add(this.tbThreadInfo);
            this.Name = "ThreadCheckForm";
            this.Text = "쓰레드체크 프로그램";
            this.Load += new System.EventHandler(this.ThreadCheckForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbThreadInfo;
    }
}