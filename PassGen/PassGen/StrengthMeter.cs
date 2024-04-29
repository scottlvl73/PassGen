using System.Drawing;
using System.Windows.Forms;

namespace PassGen
{
    /// <summary>
    /// The StrengthMeter class uses System.Drawing to redraw a new strength bar everytime a password is generated and determine a color by the "strength" of the password generated.
    /// </summary>
    public class StrengthMeter : Control
    {
        private int _strength;

        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                //Forces a redraw of the bar every time a new password is generated
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            //Creates empty meter before filling
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, 0, 0, Width, Height);
            }

            using (Pen borderPen = new Pen(Color.Black, 1)) // You can adjust the color and thickness of the border
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }

            // Relates color to determined strength
            Color color;
            if (Strength < 33)
                color = Color.Red;
            else if (Strength < 66)
                color = Color.Orange;
            else
                color = Color.Green;

            // Draw strength
            using (SolidBrush brush = new SolidBrush(color))
            {
                //Determines the width of the meter based on a percentage of determined strength
                int width = (int)(Width * (Strength / 100.0)); 
                e.Graphics.FillRectangle(brush, 0, 0, width, Height);
            }
        }
    }
}