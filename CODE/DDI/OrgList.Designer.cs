namespace DDIV2.UI
{
    partial class OrgList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgList));
            this.txtusers = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtorgcode = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.btnSave = new ORG.UILib.Controls.ButtonEx(this.components);
            this.SuspendLayout();
            // 
            // txtusers
            // 
            this.txtusers.Enabled = false;
            this.txtusers.Location = new System.Drawing.Point(185, 29);
            this.txtusers.Name = "txtusers";
            this.txtusers.OtherText = null;
            this.txtusers.Size = new System.Drawing.Size(212, 21);
            this.txtusers.TabIndex = 0;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(72, 32);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(91, 14);
            this.labelEx1.TabIndex = 1;
            this.labelEx1.Text = "用户登录名称";
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(72, 76);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(91, 14);
            this.labelEx2.TabIndex = 3;
            this.labelEx2.Text = "关联机构编码";
            // 
            // txtorgcode
            // 
            this.txtorgcode.Location = new System.Drawing.Point(185, 73);
            this.txtorgcode.Name = "txtorgcode";
            this.txtorgcode.OtherText = null;
            this.txtorgcode.Size = new System.Drawing.Size(212, 21);
            this.txtorgcode.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OrgList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 202);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelEx2);
            this.Controls.Add(this.txtorgcode);
            this.Controls.Add(this.labelEx1);
            this.Controls.Add(this.txtusers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrgList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多机构查询关联设置";
            this.Load += new System.EventHandler(this.OrgList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.TextBoxEx txtusers;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.TextBoxEx txtorgcode;
        private ORG.UILib.Controls.ButtonEx btnSave;
    }
}