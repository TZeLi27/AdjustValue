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
    public partial class AdjustValueForm : Form
    {
        public AdjustValueForm()
        {
            InitializeComponent();
        }

        private void TlsInputdata_Click(object sender, EventArgs e)
        {
            ParamFour.InputAdjustData(DGVAdjust);
            TlsCalAdjust.Enabled = true;
        }

        private void TlsCalAdjust_Click(object sender, EventArgs e)
        {
            AdjustValue.CalAdjustValue(DGVAdjust,RTxtKnow,RTxtModel,RTxtOut);
            TlsOutData.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TlsOutData_Click(object sender, EventArgs e)
        {
            string sr ="\n已知信息\n"+ RTxtKnow.Text+"\n自动构建模型\n"+RTxtModel.Text+"\n计算结果\n"+RTxtOut.Text;
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
            if (outFilePath == "")
            {
                MessageBox.Show("导出路径不存在！");
                return;
            }

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

        private void TlsClearData_Click(object sender, EventArgs e)
        {
            DGVAdjust.Columns.Clear();
            RTxtKnow.Text = "";
            RTxtModel.Text = "";
            RTxtOut.Text = "";
        }
    }
}
