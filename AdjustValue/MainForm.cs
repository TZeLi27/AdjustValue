namespace AdjustValue
{
    public partial class MainForm : Form
    {
        // ���ļ�������������Ŀؼ���Ӧ�¼�
        public MainForm()
        {
            InitializeComponent();
        }

        // ���Ĳ���ת������
        private void btnFourPara_Click(object sender, EventArgs e)
        {
            FourParaForm fourPara= new FourParaForm();
            fourPara.Show();
        }
        // ��ˮ׼��ƽ�����
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