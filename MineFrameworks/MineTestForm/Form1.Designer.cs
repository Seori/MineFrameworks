namespace MineTestForm
{
    partial class Form1
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
            this.originGrid = new System.Windows.Forms.DataGridView();
            this.targetGrid = new System.Windows.Forms.DataGridView();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.tbVal = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // originGrid
            // 
            this.originGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.originGrid.Location = new System.Drawing.Point(12, 12);
            this.originGrid.Name = "originGrid";
            this.originGrid.RowTemplate.Height = 23;
            this.originGrid.Size = new System.Drawing.Size(736, 70);
            this.originGrid.TabIndex = 0;
            // 
            // targetGrid
            // 
            this.targetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.targetGrid.Location = new System.Drawing.Point(12, 152);
            this.targetGrid.Name = "targetGrid";
            this.targetGrid.RowTemplate.Height = 23;
            this.targetGrid.Size = new System.Drawing.Size(736, 80);
            this.targetGrid.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(673, 88);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 55);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "대상컬럼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "값";
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(69, 95);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(152, 21);
            this.tbTarget.TabIndex = 5;
            // 
            // tbVal
            // 
            this.tbVal.Location = new System.Drawing.Point(69, 122);
            this.tbVal.Name = "tbVal";
            this.tbVal.Size = new System.Drawing.Size(503, 21);
            this.tbVal.TabIndex = 6;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbLog.Location = new System.Drawing.Point(12, 273);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(736, 139);
            this.tbLog.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 424);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.tbVal);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.targetGrid);
            this.Controls.Add(this.originGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView originGrid;
        private System.Windows.Forms.DataGridView targetGrid;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.TextBox tbVal;
        private System.Windows.Forms.TextBox tbLog;
    }
}

