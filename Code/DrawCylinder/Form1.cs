namespace DrawCylinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawCylinder(Graphics g, Pen pen, Brush brush, float x, float y, float width, float height,bool blnVertical=true)
        {
            float radius = (blnVertical == true)?(width / 2): (height / 2);//計算圓半徑
            float diameter = radius * 2;//計算圓直徑
            float TopPoint = (blnVertical == true) ? (y + (height - diameter) / 2): (x + (width - diameter) / 2);

            if(blnVertical)
            {
                //實體
                // Draw top ellipse
                g.FillEllipse(brush, x, TopPoint, width, diameter);

                // Draw bottom ellipse
                g.FillEllipse(brush, x, TopPoint + height - diameter, width, diameter);

                // Draw connecting rectangle
                g.FillRectangle(brush, x, TopPoint + radius, width, height - diameter);

                //邊框
                // Draw top ellipse outline
                g.DrawEllipse(pen, x, TopPoint, width, diameter);

                // Draw bottom ellipse outline
                g.DrawEllipse(pen, x, TopPoint + height - diameter, width, diameter);

                // Draw connecting rectangle outline
                g.DrawRectangle(pen, x, TopPoint + radius, width, height - diameter);
            }
            else
            {
                //實體
                // Draw top ellipse
                g.FillEllipse(brush, TopPoint, y, height, diameter);

                // Draw bottom ellipse
                g.FillEllipse(brush, TopPoint + width - diameter, y, height, diameter);

                // Draw connecting rectangle
                g.FillRectangle(brush, TopPoint + radius, y, width - diameter, height);

                //邊框
                // Draw top ellipse outline
                g.DrawEllipse(pen, TopPoint, y, height, diameter);

                // Draw bottom ellipse outline
                g.DrawEllipse(pen, TopPoint + width - diameter, y, height, diameter);

                // Draw connecting rectangle outline
                g.DrawRectangle(pen, TopPoint + radius, y, width - diameter, height);
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Blue);

            DrawCylinder(g, pen, brush, 50, 50, 100, 500);
            DrawCylinder(g, pen, brush, 50, 50, 500, 100,false);
        }
    }
}