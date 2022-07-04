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
            this.数据示例 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFourPara
            // 
            this.btnFourPara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFourPara.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnFourPara.Location = new System.Drawing.Point(255, 45);
            this.btnFourPara.Name = "btnFourPara";
            this.btnFourPara.Size = new System.Drawing.Size(151, 68);
            this.btnFourPara.TabIndex = 0;
            this.btnFourPara.Text = "四参数转换";
            this.btnFourPara.UseVisualStyleBackColor = false;
            this.btnFourPara.Click += new System.EventHandler(this.btnFourPara_Click);
            // 
            // btnAdjustValue
            // 
            this.btnAdjustValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjustValue.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAdjustValue.Location = new System.Drawing.Point(12, 45);
            this.btnAdjustValue.Name = "btnAdjustValue";
            this.btnAdjustValue.Size = new System.Drawing.Size(151, 68);
            this.btnAdjustValue.TabIndex = 1;
            this.btnAdjustValue.Text = "水准网平差";
            this.btnAdjustValue.UseVisualStyleBackColor = false;
            this.btnAdjustValue.Click += new System.EventHandler(this.btnAdjustValue_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "19306052李泽腾";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // 数据示例
            // 
            this.数据示例.AutoSize = true;
            this.数据示例.BackColor = System.Drawing.SystemColors.Info;
            this.数据示例.Location = new System.Drawing.Point(12, 137);
            this.数据示例.Name = "数据示例";
            this.数据示例.Size = new System.Drawing.Size(394, 200);
            this.数据示例.TabIndex = 3;
            this.数据示例.Text = "四参数转换数据示例：\r\n编号,X0,Y0,X1,Y1\r\n1,1,1,3,9\r\n……\r\n水准网平差数据示例：\r\n路线号 起点 终点 观测高差(m) 路线长度(km)" +
    " 已知高程(m)\r\n1 A C +1.359 1.1 A=5.016\r\n2 A D +2.009 1.7 B=6.016\r\n3 B C +0.363 2.3\r\n" +
    "……";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(425, 358);
            this.Controls.Add(this.数据示例);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdjustValue);
            this.Controls.Add(this.btnFourPara);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "实用数据测量";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnFourPara;
        private Button btnAdjustValue;
        private Label label1;
        private Label 数据示例;
    }
}