namespace AdjustValue
{
    public partial class MainForm : Form
    {
        // 本文件定义了主界面的控件响应事件
        public MainForm()
        {
            InitializeComponent();
        }

        // 打开四参数转换界面
        private void btnFourPara_Click(object sender, EventArgs e)
        {
            FourParaForm fourPara= new FourParaForm();
            fourPara.Show();
        }
        // 打开水准网平差界面
        private void btnAdjustValue_Click(object sender, EventArgs e)
        {
            AdjustValueForm adjustValue= new AdjustValueForm();
            adjustValue.Show();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}