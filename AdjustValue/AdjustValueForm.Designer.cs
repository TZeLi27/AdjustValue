namespace AdjustValue
{
    partial class AdjustValueForm
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
            this.TlsInputdata = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsCalAdjust = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsOutData = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsClearData = new System.Windows.Forms.ToolStripMenuItem();
            this.DGVAdjust = new System.Windows.Forms.DataGridView();
            this.RTxtKnow = new System.Windows.Forms.RichTextBox();
            this.RTxtModel = new System.Windows.Forms.RichTextBox();
            this.RTxtOut = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAdjust)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlsInputdata,
            this.TlsCalAdjust,
            this.TlsOutData,
            this.TlsClearData});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1196, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TlsInputdata
            // 
            this.TlsInputdata.Name = "TlsInputdata";
            this.TlsInputdata.Size = new System.Drawing.Size(83, 24);
            this.TlsInputdata.Text = "导入数据";
            this.TlsInputdata.Click += new System.EventHandler(this.TlsInputdata_Click);
            // 
            // TlsCalAdjust
            // 
            this.TlsCalAdjust.Enabled = false;
            this.TlsCalAdjust.Name = "TlsCalAdjust";
            this.TlsCalAdjust.Size = new System.Drawing.Size(83, 24);
            this.TlsCalAdjust.Text = "平差计算";
            this.TlsCalAdjust.Click += new System.EventHandler(this.TlsCalAdjust_Click);
            // 
            // TlsOutData
            // 
            this.TlsOutData.Enabled = false;
            this.TlsOutData.Name = "TlsOutData";
            this.TlsOutData.Size = new System.Drawing.Size(83, 24);
            this.TlsOutData.Text = "导出结果";
            this.TlsOutData.Click += new System.EventHandler(this.TlsOutData_Click);
            // 
            // TlsClearData
            // 
            this.TlsClearData.Name = "TlsClearData";
            this.TlsClearData.Size = new System.Drawing.Size(83, 24);
            this.TlsClearData.Text = "清除数据";
            this.TlsClearData.Click += new System.EventHandler(this.TlsClearData_Click);
            // 
            // DGVAdjust
            // 
            this.DGVAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGVAdjust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAdjust.Location = new System.Drawing.Point(0, 31);
            this.DGVAdjust.Name = "DGVAdjust";
            this.DGVAdjust.RowHeadersWidth = 51;
            this.DGVAdjust.RowTemplate.Height = 29;
            this.DGVAdjust.Size = new System.Drawing.Size(768, 619);
            this.DGVAdjust.TabIndex = 1;
            // 
            // RTxtKnow
            // 
            this.RTxtKnow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RTxtKnow.Location = new System.Drawing.Point(784, 69);
            this.RTxtKnow.Name = "RTxtKnow";
            this.RTxtKnow.Size = new System.Drawing.Size(400, 170);
            this.RTxtKnow.TabIndex = 2;
            this.RTxtKnow.Text = "";
            // 
            // RTxtModel
            // 
            this.RTxtModel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RTxtModel.Location = new System.Drawing.Point(784, 275);
            this.RTxtModel.Name = "RTxtModel";
            this.RTxtModel.Size = new System.Drawing.Size(400, 170);
            this.RTxtModel.TabIndex = 3;
            this.RTxtModel.Text = "";
            // 
            // RTxtOut
            // 
            this.RTxtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RTxtOut.Location = new System.Drawing.Point(783, 480);
            this.RTxtOut.Name = "RTxtOut";
            this.RTxtOut.Size = new System.Drawing.Size(400, 170);
            this.RTxtOut.TabIndex = 4;
            this.RTxtOut.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(784, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "已知信息：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(783, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "模型构建：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(784, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "结果输出：";
            // 
            // AdjustValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1196, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RTxtOut);
            this.Controls.Add(this.RTxtModel);
            this.Controls.Add(this.RTxtKnow);
            this.Controls.Add(this.DGVAdjust);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdjustValueForm";
            this.Text = "水准网间接平差";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAdjust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem TlsInputdata;
        private ToolStripMenuItem TlsCalAdjust;
        private ToolStripMenuItem TlsOutData;
        private DataGridView DGVAdjust;
        private RichTextBox RTxtKnow;
        private RichTextBox RTxtModel;
        private RichTextBox RTxtOut;
        private Label label1;
        private Label label2;
        private Label label3;
        private ToolStripMenuItem TlsClearData;
    }
}