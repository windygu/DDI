namespace DDIV2.UI
{
    partial class AuthorizeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizeEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOrgCode = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.btnSearch = new ORG.UILib.Controls.ButtonEx(this.components);
            this.dgvlist = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.btnAuthorize = new ORG.UILib.Controls.ButtonEx(this.components);
            this.btnForbidden = new ORG.UILib.Controls.ButtonEx(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnForbidden);
            this.groupBox1.Controls.Add(this.btnAuthorize);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.labelEx1);
            this.groupBox1.Controls.Add(this.txtOrgCode);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.Location = new System.Drawing.Point(100, 24);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.OtherText = null;
            this.txtOrgCode.Size = new System.Drawing.Size(152, 21);
            this.txtOrgCode.TabIndex = 0;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(31, 27);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(63, 14);
            this.labelEx1.TabIndex = 1;
            this.labelEx1.Text = "机构编码";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(291, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvlist
            // 
            this.dgvlist.AllowUserToAddRows = false;
            this.dgvlist.ColumnDisplayIndexSave = false;
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlist.ColumnVisibleEnableSave = true;
            this.dgvlist.ColumnWidthSave = true;
            this.dgvlist.Location = new System.Drawing.Point(5, 69);
            this.dgvlist.MyForm = this;
            this.dgvlist.Name = "dgvlist";
            this.dgvlist.RowTemplate.Height = 23;
            this.dgvlist.ShowdgvTotalRow = false;
            this.dgvlist.ShowTotal = 0;
            this.dgvlist.Size = new System.Drawing.Size(799, 321);
            this.dgvlist.SumColumnList = new string[] {
        ""};
            this.dgvlist.SumField = "";
            this.dgvlist.TabIndex = 1;
            this.dgvlist.UserName = "SystemUserName";
            this.dgvlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlist_CellContentClick);
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(372, 23);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 5;
            this.btnAuthorize.Text = "启用序列";
            this.btnAuthorize.UseVisualStyleBackColor = false;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // btnForbidden
            // 
            this.btnForbidden.Location = new System.Drawing.Point(453, 23);
            this.btnForbidden.Name = "btnForbidden";
            this.btnForbidden.Size = new System.Drawing.Size(75, 23);
            this.btnForbidden.TabIndex = 6;
            this.btnForbidden.Text = "禁用序列";
            this.btnForbidden.UseVisualStyleBackColor = false;
            this.btnForbidden.Click += new System.EventHandler(this.btnForbidden_Click);
            // 
            // AuthorizeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(809, 390);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorizeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户序列授权";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ORG.UILib.Controls.TextBoxEx txtOrgCode;
        private ORG.UILib.Controls.ButtonEx btnSearch;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.ButtonEx btnAuthorize;
        private ORG.UILib.Controls.DataGridViewEx dgvlist;
        private ORG.UILib.Controls.ButtonEx btnForbidden;
    }
}