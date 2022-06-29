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

    public partial class FourParaForm : Form
    {

        public FourParaForm()
        {
            InitializeComponent();
        }

        private void FourPara_Load(object sender, EventArgs e)
        {

        }


        private void TlsInputData_Click(object sender, EventArgs e)
        {
            ParamFour.InputAdjustData(DGVcoord);
            TlsCalPara.Enabled = true;
        }

        private void TlsCalPara_Click(object sender, EventArgs e)
        {
            double rota = 0.0, scale = 0.0, dx = 0.0, dy = 0.0;
            ParamFour.calPara(DGVcoord,  ref rota, ref scale, ref dx, ref dy);
            RTxtOutpara.Text = "dx=" + dx.ToString() + " ";
            RTxtOutpara.Text += "dy=" + dy.ToString() + " ";
            RTxtOutpara.Text += "rota=" + rota.ToString() + " ";
            RTxtOutpara.Text += "sacle=" + scale.ToString() + " ";
            TlsOutPara.Enabled = true;
        }

        private void TlsOutPara_Click(object sender, EventArgs e)
        {
            SaveFileDialog fs = new SaveFileDialog();
            fs.Filter = "文本文件(*.txt)|*.txt";
            fs.FileName = "文件名.txt";
            if (fs.ShowDialog() == DialogResult.OK)
            {
                RTxtOutpara.SaveFile(fs.FileName, RichTextBoxStreamType.PlainText);
            }
            MessageBox.Show("保存文件成功！");
        }

        private void TlsOutCoor_Click(object sender, EventArgs e)
        {
            ParamFour.OutPara(DGVcoord);
        }

        private void TlsClearData_Click(object sender, EventArgs e)
        {

            DGVcoord.Columns.Clear();

            RTxtOutpara.Clear();
            TlsOutPara.Enabled = false;
            TlsCalPara.Enabled = false;
        }
    }
}


