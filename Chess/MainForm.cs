namespace Chess
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void DrawBoard()
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(Color.White);

            Brush saddleBrownBrush = new SolidBrush(Color.SaddleBrown);
            Brush sandyBrownBrush = new SolidBrush(Color.SandyBrown);

            float rectHeight = (float)ClientRectangle.Height / 8.0f;
            float rectWidth = (float)ClientRectangle.Width / 8.0f;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        graphics.FillRectangle(sandyBrownBrush, j * rectWidth, i * rectHeight, rectWidth, rectHeight);
                    else
                        graphics.FillRectangle(saddleBrownBrush, j * rectWidth, i * rectHeight, rectWidth, rectHeight);
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard();
        }
    }
}
