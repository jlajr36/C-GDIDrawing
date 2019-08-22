using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace theCircle
{
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		void DrawCutCircle(Graphics g, Point centerPos, int radius, int cutOutLen) {
        	RectangleF rectangle = new RectangleF(
                        centerPos.X - radius,
                        centerPos.Y - radius,
                        radius * 2,
                        radius * 2);

        	// calculate the start angle
        	float startAngle = (float)(Math.Asin(
            	1f * (radius - cutOutLen) / radius) / Math.PI * 180);

        	using (GraphicsPath path = new GraphicsPath())
        	{
            	path.AddArc(rectangle, 180 - startAngle, 180 + 2 * startAngle);
            	path.CloseFigure();

            	g.FillPath(Brushes.Yellow, path);
            	using (Pen p = new Pen(Brushes.Yellow))
            	{
                	g.DrawPath(new Pen(Brushes.Blue, 3), path);
            	}
        	}
    	}
		
		protected override void OnPaint(PaintEventArgs e) {
        	base.OnPaint(e);
        	e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        	DrawCutCircle(e.Graphics, new Point(210, 210), 200, 80);
    	}
	}
}
