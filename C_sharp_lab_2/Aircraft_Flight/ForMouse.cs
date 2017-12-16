using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aircraft_Flight
{
    public partial class ForMouse : Form
    {
        Graphics grfx = null;
        const int iMaxPoints = 10000;
        int iNumPoints = 0;
        Point[] apoint = new Point[iMaxPoints];
        Font TimesNewRoman10 = null;
        public ForMouse()
        {
            InitializeComponent();
            this.Location = new Point(1025, 1);
            this.FormBorderStyle = FormBorderStyle.None;

            //TimesNewRoman10 = new Font();

        }

        private void ForMouse_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ForMouse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (iNumPoints < iMaxPoints)               
                    apoint[iNumPoints++] = new Point(e.X, e.Y);
                grfx = CreateGraphics();
                grfx.DrawLine(new Pen(ForeColor), e.X, e.Y, e.X + 1, e.Y + 1);
                grfx.Dispose();
            }
        }

        private void ForMouse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //iNumPoints = 0;
            }
        }

        private void ForMouse_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Invalidate();
            }
        }

        private void ForMouse_Paint(object sender, PaintEventArgs e)
        {
            grfx = e.Graphics;
            Pen pen = new Pen(ForeColor, 1 / 10);
            Pen pen2 = new Pen(Color.Aqua, 1 / 10);
            for (int i = 1; i < iNumPoints - 1; i++)
            {
                grfx.DrawLine(pen, apoint[i - 1], apoint[i]);
                for (int j = i + 10; j < iNumPoints; j++)
                {
                   // grfx.DrawLine(pen2, apoint[j - 10], apoint[j]);
                }
            }
        }

        public int get_number_of_points()
        {
            return iNumPoints;
        }
        public Point[] get_traektory()
        {
            return apoint;
        }
    }
}
