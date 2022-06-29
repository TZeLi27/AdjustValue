namespace AdjustValue
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void btnFourPara_Click(object sender, EventArgs e)
        {
            FourParaForm fourPara= new FourParaForm();
            fourPara.Show();
        }

        private void btnAdjustValue_Click(object sender, EventArgs e)
        {
            AdjustValueForm adjustValue= new AdjustValueForm();
            adjustValue.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}