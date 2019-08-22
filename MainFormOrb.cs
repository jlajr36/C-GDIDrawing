using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace OrbitingCircle
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		Thread th;
		Graphics g;
		Graphics fG;
		Bitmap bit;
		
		bool drawing = true;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			bit = new Bitmap(600, 600);
			g = Graphics.FromImage(bit);
			fG = CreateGraphics();
			fG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			th = new Thread(Draw);
			th.IsBackground = true;
			th.Start();
		}
		
		public void Draw() {
			float angle = 0.0f;
			Point org = new Point(250, 250);
			float rad = 250;
			Pen pen = new Pen(Brushes.Azure, 3.0f);
			RectangleF area = new RectangleF(30, 30, 500, 500);
			RectangleF circle = new RectangleF(0, 0, 50, 50);
			
			PointF loc = PointF.Empty;
			PointF img = new PointF(20, 20);
			
			fG.Clear(Color.Black);
			
			while (drawing) {
				g.Clear(Color.Black);
				
				g.DrawEllipse(pen, area);
				loc = CirclePoint(rad, angle, org);
				
				circle.X = loc.X - (circle.Width / 2) + area.X;
				circle.Y = loc.Y - (circle.Height / 2) + area.Y;
				
				g.DrawEllipse(pen, circle);
				
				fG.DrawImage(bit, img);
				
				if(angle < 360) {
					angle += 0.5f;
				} else {
					angle = 0;
				}
			}
		}
		
		public PointF CirclePoint(float radius, float angleInDegrees, PointF orgin) {
			float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180f)) + orgin.X;
			float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180f)) + orgin.Y;
			return new PointF(x, y);
		}
	}
}
