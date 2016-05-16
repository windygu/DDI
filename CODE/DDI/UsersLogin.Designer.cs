namespace DDIV2.UI
{
    partial class UsersLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersLogin));
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtloginname = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.txtorgname = new System.Windows.Forms.TextBox();
            this.PIC_Close = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlogin
            // 
            this.btnlogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnlogin.BackgroundImage")));
            this.btnlogin.Location = new System.Drawing.Point(433, 211);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(70, 58);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Visible = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtloginname
            // 
            this.txtloginname.BackColor = System.Drawing.Color.White;
            this.txtloginname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtloginname.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtloginname.Location = new System.Drawing.Point(312, 194);
            this.txtloginname.Name = "txtloginname";
            this.txtloginname.Size = new System.Drawing.Size(95, 20);
            this.txtloginname.TabIndex = 1;
            // 
            // txtpwd
            // 
            this.txtpwd.BackColor = System.Drawing.Color.White;
            this.txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpwd.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpwd.Location = new System.Drawing.Point(312, 229);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(95, 20);
            this.txtpwd.TabIndex = 2;
            this.txtpwd.Leave += new System.EventHandler(this.txtpwd_Leave);
            // 
            // txtorgname
            // 
            this.txtorgname.BackColor = System.Drawing.Color.White;
            this.txtorgname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtorgname.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtorgname.Location = new System.Drawing.Point(295, 261);
            this.txtorgname.Name = "txtorgname";
            this.txtorgname.Size = new System.Drawing.Size(113, 20);
            this.txtorgname.TabIndex = 3;
            // 
            // PIC_Close
            // 
            this.PIC_Close.BackColor = System.Drawing.Color.Transparent;
            this.PIC_Close.ErrorImage = null;
            this.PIC_Close.Image = ((System.Drawing.Image)(resources.GetObject("PIC_Close.Image")));
            this.PIC_Close.InitialImage = null;
            this.PIC_Close.Location = new System.Drawing.Point(569, 16);
            this.PIC_Close.Name = "PIC_Close";
            this.PIC_Close.Size = new System.Drawing.Size(45, 18);
            this.PIC_Close.TabIndex = 4;
            this.PIC_Close.TabStop = false;
            this.PIC_Close.Click += new System.EventHandler(this.PIC_Close_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(519, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 18);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "配置";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(559, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "V2.1.1";
            // 
            // UsersLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(638, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.PIC_Close);
            this.Controls.Add(this.txtorgname);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtloginname);
            this.Controls.Add(this.btnlogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "UsersLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsersLogin";
            this.Load += new System.EventHandler(this.UsersLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsersLogin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtloginname;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txtorgname;
        private System.Windows.Forms.PictureBox PIC_Close;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
    }
}