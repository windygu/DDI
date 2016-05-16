namespace DDIV2.UI
{
    partial class RegisterSesting
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
            this.txtCode = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtName = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx3 = new ORG.UILib.Controls.LabelEx(this.components);
            this.textBoxEx3 = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.btnRegister = new ORG.UILib.Controls.ButtonEx(this.components);
            this.txtregister = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx4 = new ORG.UILib.Controls.LabelEx(this.components);
            this.lblSupplierCode = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx5 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx6 = new ORG.UILib.Controls.LabelEx(this.components);
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(130, 27);
            this.txtCode.Name = "txtCode";
            this.txtCode.OtherText = null;
            this.txtCode.Size = new System.Drawing.Size(284, 21);
            this.txtCode.TabIndex = 0;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(65, 30);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(63, 14);
            this.labelEx1.TabIndex = 1;
            this.labelEx1.Text = "机构编码";
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(65, 67);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(63, 14);
            this.labelEx2.TabIndex = 3;
            this.labelEx2.Text = "机构名称";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 64);
            this.txtName.Name = "txtName";
            this.txtName.OtherText = null;
            this.txtName.Size = new System.Drawing.Size(284, 21);
            this.txtName.TabIndex = 2;
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx3.ForeColor = System.Drawing.Color.Black;
            this.labelEx3.Location = new System.Drawing.Point(92, 103);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(35, 14);
            this.labelEx3.TabIndex = 5;
            this.labelEx3.Text = "描述";
            // 
            // textBoxEx3
            // 
            this.textBoxEx3.Location = new System.Drawing.Point(130, 101);
            this.textBoxEx3.Multiline = true;
            this.textBoxEx3.Name = "textBoxEx3";
            this.textBoxEx3.OtherText = null;
            this.textBoxEx3.Size = new System.Drawing.Size(284, 95);
            this.textBoxEx3.TabIndex = 4;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(339, 237);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "注 册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtregister
            // 
            this.txtregister.Location = new System.Drawing.Point(130, 202);
            this.txtregister.Name = "txtregister";
            this.txtregister.OtherText = null;
            this.txtregister.ReadOnly = true;
            this.txtregister.Size = new System.Drawing.Size(284, 21);
            this.txtregister.TabIndex = 7;
            // 
            // labelEx4
            // 
            this.labelEx4.AutoSize = true;
            this.labelEx4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx4.ForeColor = System.Drawing.Color.Black;
            this.labelEx4.Location = new System.Drawing.Point(78, 205);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.Size = new System.Drawing.Size(49, 14);
            this.labelEx4.TabIndex = 8;
            this.labelEx4.Text = "序列号";
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSupplierCode.ForeColor = System.Drawing.Color.Red;
            this.lblSupplierCode.Location = new System.Drawing.Point(420, 30);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(14, 14);
            this.lblSupplierCode.TabIndex = 10;
            this.lblSupplierCode.Text = "*";
            // 
            // labelEx5
            // 
            this.labelEx5.AutoSize = true;
            this.labelEx5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx5.ForeColor = System.Drawing.Color.Red;
            this.labelEx5.Location = new System.Drawing.Point(420, 67);
            this.labelEx5.Name = "labelEx5";
            this.labelEx5.Size = new System.Drawing.Size(14, 14);
            this.labelEx5.TabIndex = 11;
            this.labelEx5.Text = "*";
            // 
            // labelEx6
            // 
            this.labelEx6.AutoSize = true;
            this.labelEx6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx6.ForeColor = System.Drawing.Color.Red;
            this.labelEx6.Location = new System.Drawing.Point(420, 182);
            this.labelEx6.Name = "labelEx6";
            this.labelEx6.Size = new System.Drawing.Size(14, 14);
            this.labelEx6.TabIndex = 12;
            this.labelEx6.Text = "*";
            // 
            // RegisterSesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(496, 287);
            this.Controls.Add(this.labelEx6);
            this.Controls.Add(this.labelEx5);
            this.Controls.Add(this.lblSupplierCode);
            this.Controls.Add(this.labelEx4);
            this.Controls.Add(this.txtregister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.labelEx3);
            this.Controls.Add(this.textBoxEx3);
            this.Controls.Add(this.labelEx2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelEx1);
            this.Controls.Add(this.txtCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterSesting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品注册";
            this.Load += new System.EventHandler(this.RegisterSesting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.TextBoxEx txtCode;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.TextBoxEx txtName;
        private ORG.UILib.Controls.LabelEx labelEx3;
        private ORG.UILib.Controls.TextBoxEx textBoxEx3;
        private ORG.UILib.Controls.ButtonEx btnRegister;
        private ORG.UILib.Controls.TextBoxEx txtregister;
        private ORG.UILib.Controls.LabelEx labelEx4;
        private ORG.UILib.Controls.LabelEx lblSupplierCode;
        private ORG.UILib.Controls.LabelEx labelEx5;
        private ORG.UILib.Controls.LabelEx labelEx6;
    }
}