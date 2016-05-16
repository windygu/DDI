namespace DDIV2.UI
{
    partial class Encrypt
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
            this.buttonEx1 = new ORG.UILib.Controls.ButtonEx(this.components);
            this.buttonEx2 = new ORG.UILib.Controls.ButtonEx(this.components);
            this.textBoxEx1 = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.textBoxEx2 = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.buttonEx3 = new ORG.UILib.Controls.ButtonEx(this.components);
            this.buttonEx4 = new ORG.UILib.Controls.ButtonEx(this.components);
            this.SuspendLayout();
            // 
            // buttonEx1
            // 
            this.buttonEx1.Location = new System.Drawing.Point(499, 305);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Size = new System.Drawing.Size(75, 23);
            this.buttonEx1.TabIndex = 0;
            this.buttonEx1.Text = "加 密";
            this.buttonEx1.UseVisualStyleBackColor = false;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.Location = new System.Drawing.Point(601, 305);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Size = new System.Drawing.Size(75, 23);
            this.buttonEx2.TabIndex = 1;
            this.buttonEx2.Text = "解 密";
            this.buttonEx2.UseVisualStyleBackColor = false;
            this.buttonEx2.Click += new System.EventHandler(this.buttonEx2_Click);
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.Location = new System.Drawing.Point(99, 12);
            this.textBoxEx1.Multiline = true;
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.OtherText = null;
            this.textBoxEx1.Size = new System.Drawing.Size(577, 113);
            this.textBoxEx1.TabIndex = 2;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(35, 69);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(49, 14);
            this.labelEx1.TabIndex = 3;
            this.labelEx1.Text = "加密前";
            // 
            // textBoxEx2
            // 
            this.textBoxEx2.Location = new System.Drawing.Point(99, 143);
            this.textBoxEx2.Multiline = true;
            this.textBoxEx2.Name = "textBoxEx2";
            this.textBoxEx2.OtherText = null;
            this.textBoxEx2.Size = new System.Drawing.Size(577, 113);
            this.textBoxEx2.TabIndex = 4;
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(35, 197);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(49, 14);
            this.labelEx2.TabIndex = 5;
            this.labelEx2.Text = "加密后";
            // 
            // buttonEx3
            // 
            this.buttonEx3.Location = new System.Drawing.Point(312, 305);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Size = new System.Drawing.Size(75, 23);
            this.buttonEx3.TabIndex = 6;
            this.buttonEx3.Text = "MD5加 密";
            this.buttonEx3.UseVisualStyleBackColor = false;
            this.buttonEx3.Click += new System.EventHandler(this.buttonEx3_Click);
            // 
            // buttonEx4
            // 
            this.buttonEx4.Location = new System.Drawing.Point(408, 305);
            this.buttonEx4.Name = "buttonEx4";
            this.buttonEx4.Size = new System.Drawing.Size(75, 23);
            this.buttonEx4.TabIndex = 7;
            this.buttonEx4.Text = "MD5解 密";
            this.buttonEx4.UseVisualStyleBackColor = false;
            this.buttonEx4.Click += new System.EventHandler(this.buttonEx4_Click);
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 346);
            this.Controls.Add(this.buttonEx4);
            this.Controls.Add(this.buttonEx3);
            this.Controls.Add(this.labelEx2);
            this.Controls.Add(this.textBoxEx2);
            this.Controls.Add(this.labelEx1);
            this.Controls.Add(this.textBoxEx1);
            this.Controls.Add(this.buttonEx2);
            this.Controls.Add(this.buttonEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Encrypt";
            this.Text = "字符串加密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.ButtonEx buttonEx1;
        private ORG.UILib.Controls.ButtonEx buttonEx2;
        private ORG.UILib.Controls.TextBoxEx textBoxEx1;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.TextBoxEx textBoxEx2;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.ButtonEx buttonEx3;
        private ORG.UILib.Controls.ButtonEx buttonEx4;
    }
}