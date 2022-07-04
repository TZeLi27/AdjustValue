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
    // 本文件定义了四参数转换窗口及控件响应事件
    public partial class FourParaForm : Form
    {

        public FourParaForm()
        {
            InitializeComponent();
        }
        
        // 数据输入按钮事件响应
        private void TlsInputData_Click(object sender, EventArgs e)
        {
            ParamFour.InputAdjustData(DGVcoord); // 调用ParamFour文件中的导入数据函数，数据存放在DGV表格中 
            TlsInputData.Enabled = false;                 // 导入数据后禁止按钮
            TlsCalPara.Enabled = true;                      // 激活计算参数按钮
        }
        
        // 计算参数按钮事件响应
        private void TlsCalPara_Click(object sender, EventArgs e)
        {
            double rota = 0.0, scale = 0.0, dx = 0.0, dy = 0.0,p=0.0;                             // 定义四参数：rote 旋转；scale 缩放；dx,dy 平移量
            ParamFour.calPara(DGVcoord,  ref rota, ref scale, ref dx, ref dy,ref p);        // 调用ParamFour文件中的计算参数函数
            // 结果输出到窗口的文本框中
            RTxtOutpara.Text = "四参数："+"dx=" + dx.ToString() + " ";
            RTxtOutpara.Text += "dy=" + dy.ToString() + " ";
            RTxtOutpara.Text += "rota=" + rota.ToString() + "° ";
            RTxtOutpara.Text += "sacle=" + scale.ToString() + "\n";
            RTxtOutpara.Text += "平面点位中误差(mm)：" + p.ToString() + " ";
            TlsOutPara.Enabled = true;                       // 激活参数导出按钮
        }

        // 参数导出按钮事件响应
        private void TlsOutPara_Click(object sender, EventArgs e)
        {
            // 打开文本文件
            SaveFileDialog fs = new SaveFileDialog();
            fs.Filter = "文本文件(*.txt)|*.txt";
            fs.FileName = "文件名.txt";
            if (fs.ShowDialog() == DialogResult.OK) // 若正常打开文件，则保存文本框中的参数结果
            {   
                RTxtOutpara.SaveFile(fs.FileName, RichTextBoxStreamType.PlainText);
            }
            MessageBox.Show("保存文件成功！");
        }
       
        // 数据导出按钮事件响应
        private void TlsOutCoor_Click(object sender, EventArgs e)
        {
            ParamFour.OutPara(DGVcoord);            // 调用ParamFour文件中的导出文件函数
        }
       
        // 清除数据按钮
        private void TlsClearData_Click(object sender, EventArgs e)
        {
            // 清空DGV表格
            DGVcoord.Columns.Clear();
            // 清空文本框
            RTxtOutpara.Clear();

            TlsOutPara.Enabled = false;
            TlsCalPara.Enabled = false;
            TlsInputData.Enabled = true;            // 清除数据后激活导入数据按钮     
        }


        private void FourPara_Load(object sender, EventArgs e)
        {

        }
    }
}


