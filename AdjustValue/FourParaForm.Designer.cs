namespace AdjustValue
{
    partial class FourParaForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TlsInputData = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsCalPara = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsOutPara = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsOutCoor = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsClearData = new System.Windows.Forms.ToolStripMenuItem();
            this.RTxtOutpara = new System.Windows.Forms.RichTextBox();
            this.DGVcoord = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVcoord)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlsInputData,
            this.TlsCalPara,
            this.TlsOutPara,
            this.TlsOutCoor,
            this.TlsClearData});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TlsInputData
            // 
            this.TlsInputData.Name = "TlsInputData";
            this.TlsInputData.Size = new System.Drawing.Size(83, 24);
            this.TlsInputData.Text = "导入数据";
            this.TlsInputData.Click += new System.EventHandler(this.TlsInputData_Click);
            // 
            // TlsCalPara
            // 
            this.TlsCalPara.Enabled = false;
            this.TlsCalPara.Name = "TlsCalPara";
            this.TlsCalPara.Size = new System.Drawing.Size(83, 24);
            this.TlsCalPara.Text = "参数计算";
            this.TlsCalPara.Click += new System.EventHandler(this.TlsCalPara_Click);
            // 
            // TlsOutPara
            // 
            this.TlsOutPara.Enabled = false;
            this.TlsOutPara.Name = "TlsOutPara";
            this.TlsOutPara.Size = new System.Drawing.Size(83, 24);
            this.TlsOutPara.Text = "导出参数";
            this.TlsOutPara.Click += new System.EventHandler(this.TlsOutPara_Click);
            // 
            // TlsOutCoor
            // 
            this.TlsOutCoor.Name = "TlsOutCoor";
            this.TlsOutCoor.Size = new System.Drawing.Size(83, 24);
            this.TlsOutCoor.Text = "导出数据";
            this.TlsOutCoor.Click += new System.EventHandler(this.TlsOutCoor_Click);
            // 
            // TlsClearData
            // 
            this.TlsClearData.Name = "TlsClearData";
            this.TlsClearData.Size = new System.Drawing.Size(83, 24);
            this.TlsClearData.Text = "清除数据";
            this.TlsClearData.Click += new System.EventHandler(this.TlsClearData_Click);
            // 
            // RTxtOutpara
            // 
            this.RTxtOutpara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTxtOutpara.Location = new System.Drawing.Point(0, 405);
            this.RTxtOutpara.Name = "RTxtOutpara";
            this.RTxtOutpara.Size = new System.Drawing.Size(762, 61);
            this.RTxtOutpara.TabIndex = 1;
            this.RTxtOutpara.Text = "";
            // 
            // DGVcoord
            // 
            this.DGVcoord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVcoord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVcoord.Location = new System.Drawing.Point(0, 31);
            this.DGVcoord.Name = "DGVcoord";
            this.DGVcoord.RowHeadersWidth = 51;
            this.DGVcoord.RowTemplate.Height = 29;
            this.DGVcoord.Size = new System.Drawing.Size(762, 368);
            this.DGVcoord.TabIndex = 2;
            // 
            // FourParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(762, 468);
            this.Controls.Add(this.DGVcoord);
            this.Controls.Add(this.RTxtOutpara);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FourParaForm";
            this.Text = "四参数转换";
            this.Load += new System.EventHandler(this.FourPara_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVcoord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem TlsInputData;
        private ToolStripMenuItem TlsCalPara;
        private ToolStripMenuItem TlsOutPara;
        private RichTextBox RTxtOutpara;
        private DataGridView DGVcoord;
        private ToolStripMenuItem TlsOutCoor;
        private ToolStripMenuItem TlsClearData;
    }
}