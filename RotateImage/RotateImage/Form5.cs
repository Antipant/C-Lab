using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model_aircraft;

namespace RotateImage
{
    public partial class Form5 : Form
    {
        Model_aircraft model_aircraft = new Model_aircraft();
        Image img = global::RotateImage.Properties.Resources._1290073907pq8BxO;
        PictureBox picturebox1 = new PictureBox();

        public Form5(float angle)
        {
            picturebox1.Parent = this;
            InitializeComponent();
            model_aircraft.Pitch = angle;
            picturebox1.Image = img;
            picturebox1.Bounds = new Rectangle(0,0, this.Width, this.Height - 100);
            picturebox1.Paint += myRotate.Rotate.my_pictureBox1_Paint;
            myRotate.Rotate.type = RotateType.OZ;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 4);
            e.Graphics.TranslateTransform(this.Width / 2f, this.Height / 2f);
            e.Graphics.RotateTransform(model_aircraft.Pitch);
            e.Graphics.DrawLine(p,-this.Width,0,this.Width,0);
            e.Graphics.DrawLine(p, 0, -this.Height, 0, this.Height);
            e.Graphics.DrawImage(img, -img.Width / 2f - 48, -img.Height /2f - 48);
            e.Graphics.RotateTransform(-model_aircraft.Pitch);
            e.Graphics.TranslateTransform(-this.Width / 2, -this.Height / 2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                model_aircraft.Pitch += 5;
            }
            if (e.KeyCode == Keys.Left)
            {
                model_aircraft.Pitch -= 5;
            }
            picturebox1.Refresh();
            //picturebox1.Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            myRotate.Rotate.type = RotateType.OX;
            trackBar1_ValueChanged(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            myRotate.Rotate.type = RotateType.OY;
            trackBar1_ValueChanged(sender, e);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            myRotate.Rotate.type = RotateType.OZ;
            trackBar1_ValueChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myRotate.Rotate.Angle += 5;
            picturebox1.Refresh();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           // trackBar1.Value = Convert.ToInt32(model_aircraft.Pitch);
            myRotate.Rotate.Angle = trackBar1.Value;
            picturebox1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
