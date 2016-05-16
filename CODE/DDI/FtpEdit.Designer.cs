namespace DDIV2.UI
{
    partial class FtpEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FtpEdit));
            this.txtftpurl = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtfileurl = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx3 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtpwd = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx4 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtusername = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.cbEnabled = new ORG.UILib.Controls.CheckBoxEx(this.components);
            this.lblSupplierCode = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx6 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx7 = new ORG.UILib.Controls.LabelEx(this.components);
            this.btnSave = new ORG.UILib.Controls.ButtonEx(this.components);
            this.btnSearch = new ORG.UILib.Controls.ButtonEx(this.components);
            this.labelEx9 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtbusname = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvleft = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.labelEx8 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx10 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtid = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx11 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx12 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txbusname = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvleft)).BeginInit();
            this.SuspendLayout();
            // 
            // txtftpurl
            // 
            this.txtftpurl.Location = new System.Drawing.Point(580, 112);
            this.txtftpurl.Name = "txtftpurl";
            this.txtftpurl.OtherText = null;
            this.txtftpurl.Size = new System.Drawing.Size(265, 21);
            this.txtftpurl.TabIndex = 0;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(487, 117);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(91, 14);
            this.labelEx1.TabIndex = 1;
            this.labelEx1.Text = "Ftp上传地址:";
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(487, 160);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(91, 14);
            this.labelEx2.TabIndex = 3;
            this.labelEx2.Text = "Ftp目标路径:";
            // 
            // txtfileurl
            // 
            this.txtfileurl.Location = new System.Drawing.Point(580, 157);
            this.txtfileurl.Name = "txtfileurl";
            this.txtfileurl.OtherText = null;
            this.txtfileurl.Size = new System.Drawing.Size(265, 21);
            this.txtfileurl.TabIndex = 2;
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx3.ForeColor = System.Drawing.Color.Black;
            this.labelEx3.Location = new System.Drawing.Point(536, 248);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(42, 14);
            this.labelEx3.TabIndex = 7;
            this.labelEx3.Text = "密码:";
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(580, 245);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.OtherText = null;
            this.txtpwd.Size = new System.Drawing.Size(265, 21);
            this.txtpwd.TabIndex = 6;
            // 
            // labelEx4
            // 
            this.labelEx4.AutoSize = true;
            this.labelEx4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx4.ForeColor = System.Drawing.Color.Black;
            this.labelEx4.Location = new System.Drawing.Point(522, 203);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.Size = new System.Drawing.Size(56, 14);
            this.labelEx4.TabIndex = 5;
            this.labelEx4.Text = "用户名:";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(580, 200);
            this.txtusername.Name = "txtusername";
            this.txtusername.OtherText = null;
            this.txtusername.Size = new System.Drawing.Size(265, 21);
            this.txtusername.TabIndex = 4;
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEnabled.Location = new System.Drawing.Point(580, 287);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(54, 18);
            this.cbEnabled.TabIndex = 8;
            this.cbEnabled.Text = "启用";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSupplierCode.ForeColor = System.Drawing.Color.Red;
            this.lblSupplierCode.Location = new System.Drawing.Point(851, 115);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(14, 14);
            this.lblSupplierCode.TabIndex = 9;
            this.lblSupplierCode.Text = "*";
            // 
            // labelEx6
            // 
            this.labelEx6.AutoSize = true;
            this.labelEx6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx6.ForeColor = System.Drawing.Color.Red;
            this.labelEx6.Location = new System.Drawing.Point(851, 203);
            this.labelEx6.Name = "labelEx6";
            this.labelEx6.Size = new System.Drawing.Size(14, 14);
            this.labelEx6.TabIndex = 11;
            this.labelEx6.Text = "*";
            // 
            // labelEx7
            // 
            this.labelEx7.AutoSize = true;
            this.labelEx7.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx7.ForeColor = System.Drawing.Color.Red;
            this.labelEx7.Location = new System.Drawing.Point(851, 248);
            this.labelEx7.Name = "labelEx7";
            this.labelEx7.Size = new System.Drawing.Size(14, 14);
            this.labelEx7.TabIndex = 12;
            this.labelEx7.Text = "*";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(770, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(364, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelEx9
            // 
            this.labelEx9.AutoSize = true;
            this.labelEx9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx9.ForeColor = System.Drawing.Color.Black;
            this.labelEx9.Location = new System.Drawing.Point(17, 25);
            this.labelEx9.Name = "labelEx9";
            this.labelEx9.Size = new System.Drawing.Size(70, 14);
            this.labelEx9.TabIndex = 11;
            this.labelEx9.Text = "业务名称:";
            // 
            // txtbusname
            // 
            this.txtbusname.Location = new System.Drawing.Point(93, 22);
            this.txtbusname.Name = "txtbusname";
            this.txtbusname.OtherText = null;
            this.txtbusname.Size = new System.Drawing.Size(265, 21);
            this.txtbusname.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvleft);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtbusname);
            this.groupBox1.Controls.Add(this.labelEx9);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 464);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置信息列表";
            // 
            // dgvleft
            // 
            this.dgvleft.AllowUserToAddRows = false;
            this.dgvleft.AllowUserToDeleteRows = false;
            this.dgvleft.AllowUserToOrderColumns = true;
            this.dgvleft.ColumnDisplayIndexSave = true;
            this.dgvleft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvleft.ColumnVisibleEnableSave = true;
            this.dgvleft.ColumnWidthSave = true;
            this.dgvleft.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvleft.Location = new System.Drawing.Point(6, 48);
            this.dgvleft.MyForm = this;
            this.dgvleft.Name = "dgvleft";
            this.dgvleft.RowTemplate.Height = 23;
            this.dgvleft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvleft.ShowdgvTotalRow = false;
            this.dgvleft.ShowTotal = 0;
            this.dgvleft.Size = new System.Drawing.Size(446, 415);
            this.dgvleft.SumColumnList = new string[] {
        ""};
            this.dgvleft.SumField = "";
            this.dgvleft.TabIndex = 15;
            this.dgvleft.TabStop = false;
            this.dgvleft.UserName = "SystemUserName";
            this.dgvleft.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvleft_CellMouseDoubleClick);
            this.dgvleft.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvleft_CellMouseDown);
            // 
            // labelEx8
            // 
            this.labelEx8.AutoSize = true;
            this.labelEx8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx8.ForeColor = System.Drawing.Color.Red;
            this.labelEx8.Location = new System.Drawing.Point(851, 30);
            this.labelEx8.Name = "labelEx8";
            this.labelEx8.Size = new System.Drawing.Size(14, 14);
            this.labelEx8.TabIndex = 19;
            this.labelEx8.Text = "*";
            // 
            // labelEx10
            // 
            this.labelEx10.AutoSize = true;
            this.labelEx10.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx10.ForeColor = System.Drawing.Color.Black;
            this.labelEx10.Location = new System.Drawing.Point(508, 27);
            this.labelEx10.Name = "labelEx10";
            this.labelEx10.Size = new System.Drawing.Size(70, 14);
            this.labelEx10.TabIndex = 18;
            this.labelEx10.Text = "业务编码:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(580, 25);
            this.txtid.Name = "txtid";
            this.txtid.OtherText = null;
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(265, 21);
            this.txtid.TabIndex = 17;
            // 
            // labelEx11
            // 
            this.labelEx11.AutoSize = true;
            this.labelEx11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx11.ForeColor = System.Drawing.Color.Red;
            this.labelEx11.Location = new System.Drawing.Point(851, 73);
            this.labelEx11.Name = "labelEx11";
            this.labelEx11.Size = new System.Drawing.Size(14, 14);
            this.labelEx11.TabIndex = 22;
            this.labelEx11.Text = "*";
            // 
            // labelEx12
            // 
            this.labelEx12.AutoSize = true;
            this.labelEx12.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx12.ForeColor = System.Drawing.Color.Black;
            this.labelEx12.Location = new System.Drawing.Point(507, 71);
            this.labelEx12.Name = "labelEx12";
            this.labelEx12.Size = new System.Drawing.Size(70, 14);
            this.labelEx12.TabIndex = 21;
            this.labelEx12.Text = "业务名称:";
            // 
            // txbusname
            // 
            this.txbusname.Location = new System.Drawing.Point(580, 69);
            this.txbusname.Name = "txbusname";
            this.txbusname.OtherText = null;
            this.txbusname.ReadOnly = true;
            this.txbusname.Size = new System.Drawing.Size(265, 21);
            this.txbusname.TabIndex = 20;
            // 
            // FtpEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(903, 467);
            this.Controls.Add(this.labelEx11);
            this.Controls.Add(this.labelEx12);
            this.Controls.Add(this.txbusname);
            this.Controls.Add(this.labelEx8);
            this.Controls.Add(this.labelEx10);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelEx7);
            this.Controls.Add(this.labelEx6);
            this.Controls.Add(this.lblSupplierCode);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.labelEx3);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.labelEx4);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.labelEx2);
            this.Controls.Add(this.txtfileurl);
            this.Controls.Add(this.labelEx1);
            this.Controls.Add(this.txtftpurl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FtpEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户添加";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvleft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.TextBoxEx txtftpurl;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.TextBoxEx txtfileurl;
        private ORG.UILib.Controls.LabelEx labelEx3;
        private ORG.UILib.Controls.TextBoxEx txtpwd;
        private ORG.UILib.Controls.LabelEx labelEx4;
        private ORG.UILib.Controls.TextBoxEx txtusername;
        private ORG.UILib.Controls.CheckBoxEx cbEnabled;
        private ORG.UILib.Controls.LabelEx lblSupplierCode;
        private ORG.UILib.Controls.LabelEx labelEx6;
        private ORG.UILib.Controls.LabelEx labelEx7;
        private ORG.UILib.Controls.ButtonEx btnSave;
        private ORG.UILib.Controls.ButtonEx btnSearch;
        private ORG.UILib.Controls.LabelEx labelEx9;
        private ORG.UILib.Controls.TextBoxEx txtbusname;
        private ORG.UILib.Controls.LabelEx labelEx11;
        private ORG.UILib.Controls.LabelEx labelEx12;
        private ORG.UILib.Controls.TextBoxEx txbusname;
        private ORG.UILib.Controls.LabelEx labelEx8;
        private ORG.UILib.Controls.LabelEx labelEx10;
        private ORG.UILib.Controls.TextBoxEx txtid;
        private System.Windows.Forms.GroupBox groupBox1;
        private ORG.UILib.Controls.DataGridViewEx dgvleft;
    }
}