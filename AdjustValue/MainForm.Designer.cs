namespace AdjustValue
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFourPara = new System.Windows.Forms.Button();
            this.btnAdjustValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFourPara
            // 
            this.btnFourPara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFourPara.Location = new System.Drawing.Point(27, 64);
            this.btnFourPara.Name = "btnFourPara";
            this.btnFourPara.Size = new System.Drawing.Size(94, 53);
            this.btnFourPara.TabIndex = 0;
            this.btnFourPara.Text = "四参数转换";
            this.btnFourPara.UseVisualStyleBackColor = true;
            this.btnFourPara.Click += new System.EventHandler(this.btnFourPara_Click);
            // 
            // btnAdjustValue
            // 
            this.btnAdjustValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjustValue.Location = new System.Drawing.Point(193, 64);
            this.btnAdjustValue.Name = "btnAdjustValue";
            this.btnAdjustValue.Size = new System.Drawing.Size(94, 53);
            this.btnAdjustValue.TabIndex = 1;
            this.btnAdjustValue.Text = "水准网平差";
            this.btnAdjustValue.UseVisualStyleBackColor = true;
            this.btnAdjustValue.Click += new System.EventHandler(this.btnAdjustValue_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "19306052李泽腾";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 166);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdjustValue);
            this.Controls.Add(this.btnFourPara);
            this.Name = "MainForm";
            this.Text = "实用数据测量";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnFourPara;
        private Button btnAdjustValue;
        private Label label1;
    }
}