using Microsoft.VisualBasic.Devices;

namespace DragDrop
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        bool isDragging = false;
        Point clickPosition;


        public Form1()
        {
            InitializeComponent();
            rect = new Rectangle(20, 20, 100, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush myBrush = new SolidBrush(
                Color.FromArgb(Math.Abs(rect.X % 255), Math.Abs(rect.Y % 255), Math.Abs((rect.X * 2 + rect.Y * 2) % 255)));

            e.Graphics.FillEllipse(myBrush, rect);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left 
                && e.X >= rect.X 
                && e.X <= rect.X + rect.Width 
                && e.Y >= rect.Y 
                && e.Y <= rect.Y + rect.Height)
            {
                isDragging = true;
                clickPosition = new Point(e.X - rect.X, e.Y - rect.Y);
                this.Cursor = Cursors.Cross;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(isDragging)
            {
                rect.Location = new Point(e.X - clickPosition.X, e.Y - clickPosition.Y);
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDragging = false;
            this.Cursor = Cursors.Default;
        }
    }
}
