namespace DDIV2.UI
{
    partial class Heavy
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
            this.dgvcc = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btncc = new ORG.UILib.Controls.ButtonEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtczdate = new ORG.UILib.Controls.DateTimePickerEx(this.components);
            this.txtywdate = new ORG.UILib.Controls.DateTimePickerEx(this.components);
            this.lblId = new System.Windows.Forms.Label();
            this.txtNewname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSerch = new ORG.UILib.Controls.ButtonEx(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcc)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvcc
            // 
            this.dgvcc.AllowUserToAddRows = false;
            this.dgvcc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvcc.ColumnDisplayIndexSave = false;
            this.dgvcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcc.ColumnVisibleEnableSave = true;
            this.dgvcc.ColumnWidthSave = true;
            this.dgvcc.Location = new System.Drawing.Point(6, 58);
            this.dgvcc.MyForm = this;
            this.dgvcc.Name = "dgvcc";
            this.dgvcc.ShowdgvTotalRow = false;
            this.dgvcc.ShowTotal = 0;
            this.dgvcc.Size = new System.Drawing.Size(868, 317);
            this.dgvcc.SumColumnList = new string[] {
        ""};
            this.dgvcc.SumField = "";
            this.dgvcc.TabIndex = 7;
            this.dgvcc.UserName = "SystemUserName";
            this.dgvcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcc_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Wheat;
            this.groupBox2.Controls.Add(this.btncc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtczdate);
            this.groupBox2.Controls.Add(this.txtywdate);
            this.groupBox2.Controls.Add(this.lblId);
            this.groupBox2.Controls.Add(this.txtNewname);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.groupBox2.Location = new System.Drawing.Point(4, 377);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(870, 91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btncc
            // 
            this.btncc.Location = new System.Drawing.Point(771, 46);
            this.btncc.Name = "btncc";
            this.btncc.Size = new System.Drawing.Size(75, 23);
            this.btncc.TabIndex = 24;
            this.btncc.Text = "重 采";
            this.btncc.UseVisualStyleBackColor = false;
            this.btncc.Click += new System.EventHandler(this.btncc_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "编号：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "业务名称：";
            // 
            // txtczdate
            // 
            this.txtczdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtczdate.CustomFormat = "yyyy-MM-dd";
            this.txtczdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtczdate.Location = new System.Drawing.Point(374, 43);
            this.txtczdate.Margin = new System.Windows.Forms.Padding(2);
            this.txtczdate.Name = "txtczdate";
            this.txtczdate.OtherText = null;
            this.txtczdate.Size = new System.Drawing.Size(149, 21);
            this.txtczdate.TabIndex = 21;
            // 
            // txtywdate
            // 
            this.txtywdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtywdate.CustomFormat = "yyyy-MM-dd";
            this.txtywdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtywdate.Location = new System.Drawing.Point(106, 43);
            this.txtywdate.Margin = new System.Windows.Forms.Padding(2);
            this.txtywdate.Name = "txtywdate";
            this.txtywdate.OtherText = null;
            this.txtywdate.Size = new System.Drawing.Size(166, 21);
            this.txtywdate.TabIndex = 20;
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(67, 20);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 12);
            this.lblId.TabIndex = 19;
            // 
            // txtNewname
            // 
            this.txtNewname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewname.Location = new System.Drawing.Point(276, 17);
            this.txtNewname.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewname.Name = "txtNewname";
            this.txtNewname.Size = new System.Drawing.Size(247, 21);
            this.txtNewname.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "重采操作时间：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "重采业务时间：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Wheat;
            this.groupBox1.Controls.Add(this.btnSerch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(870, 47);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnSerch
            // 
            this.btnSerch.Location = new System.Drawing.Point(766, 16);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(75, 23);
            this.btnSerch.TabIndex = 3;
            this.btnSerch.Text = "查 询";
            this.btnSerch.UseVisualStyleBackColor = false;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(117, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(541, 21);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "业务名称：";
            // 
            // Heavy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(877, 473);
            this.Controls.Add(this.dgvcc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Heavy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重采";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcc)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ORG.UILib.Controls.DataGridViewEx dgvcc;
        private System.Windows.Forms.GroupBox groupBox2;
        private ORG.UILib.Controls.ButtonEx btncc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ORG.UILib.Controls.DateTimePickerEx txtczdate;
        private ORG.UILib.Controls.DateTimePickerEx txtywdate;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtNewname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ORG.UILib.Controls.ButtonEx btnSerch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}