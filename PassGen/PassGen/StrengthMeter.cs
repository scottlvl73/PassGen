using System.Drawing;
using System.Windows.Forms;

namespace PassGen
{
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