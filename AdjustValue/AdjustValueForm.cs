using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustValue
{
    // 本文件定义了水准网间接平差窗口及控件响应事件
    public partial class AdjustValueForm : Form
    {
        public AdjustValueForm()
        {
            InitializeComponent();
        }
        // 定义数据输入按钮事件响应
        private void TlsInputdata_Click(object sender, EventArgs e)
        {
            ParamFour.InputAdjustData(DGVAdjust);       // 调用ParamFour文件中的数据输入函数
            if (DGVAdjust.ColumnCount < 6 )                   // 当不符合示例数据格式时，返回警告
            {
                MessageBox.Show("数据格式错误，请检查数据！");
                return;
            }
            TlsCalAdjust.Enabled = true;                            // 激活平差计算按钮
        }
       
        // 定义平差计算按钮事件响应
        private void TlsCalAdjust_Click(object sender, EventArgs e)
        {
            AdjustValue.CalAdjustValue(DGVAdjust,RTxtKnow,RTxtModel,RTxtOut);    // 调用AdjustValue文件中的平差计算函数
            TlsOutData.Enabled = true;                              // 激活结果导出按钮
        }

        // 定义数据输出按钮事件响应
        private void TlsOutData_Click(object sender, EventArgs e)
        {
            // 将三个文本框中的数据输出
            string sr ="\n已知信息\n"+ RTxtKnow.Text+"\n自动构建模型\n"+RTxtModel.Text+"\n计算结果\n"+RTxtOut.Text;
            // 打开文本文件并返回路径
            string outFilePath = "";
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Title = "导出TXT结果";
            SaveFileDialog1.Filter = "导出TXT结果 (*.txt)|*.txt";
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string saveFilename = SaveFileDialog1.FileName;
                if (!string.IsNullOrEmpty(saveFilename))
                {
                    outFilePath = SaveFileDialog1.FileName;
                }
            }
            // 判断是否正常返回文本文件路径
            if (outFilePath == "")
            {
                MessageBox.Show("导出路径不存在！");
                return;
            }

            // 保存结果到打开的文本文件
            FileStream fileStream = new FileStream(outFilePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            try
            {
                streamWriter.WriteLine(sr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                streamWriter.Close();
                fileStream.Close();
            }

        }

        // 定义清除数据按钮事件响应
        private void TlsClearData_Click(object sender, EventArgs e)
        {
            // 清空DGV表格
            DGVAdjust.Columns.Clear();
            // 清空文本框
            RTxtKnow.Text = "";
            RTxtModel.Text = "";
            RTxtOut.Text = "";
        }

        private void AdjustValueForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
