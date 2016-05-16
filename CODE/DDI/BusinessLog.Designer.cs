namespace DDIV2.UI
{
    partial class BusinessLog
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxEx2 = new ORG.UILib.Controls.GroupBoxEx(this.components);
            this.dtpXQTime = new ORG.UILib.Controls.DateTimePickerEx(this.components);
            this.btnSearchTime = new ORG.UILib.Controls.ButtonEx(this.components);
            this.groupBoxEx1 = new ORG.UILib.Controls.GroupBoxEx(this.components);
            this.txtLog = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.groupBoxEx2.SuspendLayout();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEx2.Controls.Add(this.dtpXQTime);
            this.groupBoxEx2.Controls.Add(this.btnSearchTime);
            this.groupBoxEx2.Location = new System.Drawing.Point(14, 2);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Size = new System.Drawing.Size(720, 75);
            this.groupBoxEx2.TabIndex = 2;
            this.groupBoxEx2.TabStop = false;
            this.groupBoxEx2.Text = "日志信息";
            // 
            // dtpXQTime
            // 
            this.dtpXQTime.CustomFormat = "yyyy-MM-dd";
            this.dtpXQTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpXQTime.Location = new System.Drawing.Point(46, 33);
            this.dtpXQTime.Name = "dtpXQTime";
            this.dtpXQTime.OtherText = null;
            this.dtpXQTime.Size = new System.Drawing.Size(137, 21);
            this.dtpXQTime.TabIndex = 12;
            this.dtpXQTime.Value = new System.DateTime(2015, 12, 17, 0, 0, 0, 0);
            // 
            // btnSearchTime
            // 
            this.btnSearchTime.Location = new System.Drawing.Point(251, 34);
            this.btnSearchTime.Name = "btnSearchTime";
            this.btnSearchTime.Size = new System.Drawing.Size(75, 23);
            this.btnSearchTime.TabIndex = 0;
            this.btnSearchTime.Text = "查 询";
            this.btnSearchTime.UseVisualStyleBackColor = false;
            this.btnSearchTime.Click += new System.EventHandler(this.btnSearchTime_Click);
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEx1.Controls.Add(this.txtLog);
            this.groupBoxEx1.Location = new System.Drawing.Point(14, 83);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(720, 332);
            this.groupBoxEx1.TabIndex = 3;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "日志信息";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(3, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.OtherText = null;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(717, 306);
            this.txtLog.TabIndex = 0;
            // 
            // BusinessLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(737, 418);
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.groupBoxEx2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusinessLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusinessLog";
            this.Load += new System.EventHandler(this.BusinessLog_Load);
            this.groupBoxEx2.ResumeLayout(false);
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ORG.UILib.Controls.GroupBoxEx groupBoxEx2;
        private ORG.UILib.Controls.DateTimePickerEx dtpXQTime;
        private ORG.UILib.Controls.ButtonEx btnSearchTime;
        private ORG.UILib.Controls.GroupBoxEx groupBoxEx1;
        private ORG.UILib.Controls.TextBoxEx txtLog;
    }
}