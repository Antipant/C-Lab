using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model_aircraft;
using C_sharp_lab_2;

namespace Aircraft_Flight
{
    public partial class Form1 : Form
    {

        Model_aircraft modelAirCraft = new Model_aircraft();
        Form_aircraft form_mdi;
        ForMouse formouse_mdi;
        Point[] points = new Point[10000];
        int num;
        int j=0;
        public Form1()
        {
            InitializeComponent();

          //  if (radioButton_runge.Checked) { modelAirCraft = new Model_aircraft(new model_aircraft.Method_RungeKutta()); }
            //if (radioButton_runge.Checked) { modelAirCraft = new Model_aircraft(new model_aircraft.Method_Euler()); }

            this.IsMdiContainer = true;
            form_mdi = Form_aircraft.Instance_form_aircraft;
            form_mdi.MdiParent = this;
            form_mdi.Show();

            formouse_mdi = new ForMouse();
            formouse_mdi.MdiParent = this;
            formouse_mdi.Show();

            num = formouse_mdi.get_number_of_points();
            points = formouse_mdi.get_traektory();
        }

        private void trackBar_pitch_Scroll(object sender, EventArgs e)
        {
            modelAirCraft.Pitch = this.trackBar_pitch.Value;
            label_pitch.Text = Convert.ToString(modelAirCraft.Pitch);          
            modelAirCraft.VH = modelAirCraft.Speed_sin();
            modelAirCraft.VL = modelAirCraft.Speed_cos(); 
        }

        private void trackBar_speed_Scroll(object sender, EventArgs e)
        {
            this.modelAirCraft.Speed = this.trackBar_speed.Value;
            label_speed.Text = Convert.ToString(modelAirCraft.Speed);         
            modelAirCraft.VH = modelAirCraft.Speed_sin();
            modelAirCraft.VL = modelAirCraft.Speed_cos(); 
        }

        public void set_speedBar(int value)
        {
            trackBar_speed.Value = value;
        }

        public void refresh_bars()
        {
            trackBar_speed_Scroll(new object(), new EventArgs());
            trackBar_pitch_Scroll(new object(), new EventArgs());
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black,3);
            pen.StartCap = LineCap.ArrowAnchor;
            e.Graphics.DrawLine(pen, new Point(5, 5), new Point(5, 393));
            e.Graphics.DrawLine(pen, new Point(393, 393), new Point(5, 393));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), 10 + (float)modelAirCraft.Lenght, 380 - (float)modelAirCraft.Hight, 10, 10);
           // e.Graphics.FillEllipse(new SolidBrush(Color.Black), 10 + (float)modelAirCraft.Lenght, (float)modelAirCraft.Hight, 10, 10);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.textBox1.Text = modelAirCraft.Hight.ToString("N4");
            this.textBox2.Text = modelAirCraft.Lenght.ToString("N4");
            label_pitch.Text = Convert.ToString(modelAirCraft.Pitch);
            label_speed.Text = Convert.ToString(modelAirCraft.Speed);

            if (modelAirCraft.Hight >= 0 && modelAirCraft.Hight <= 393 && modelAirCraft.Lenght >= 0 && modelAirCraft.Lenght <= 393)
            {
                modelAirCraft.Step(this.timer1.Interval * 0.1);
                Refresh();
            }
            else if (modelAirCraft.Lenght > 393)
            {
                modelAirCraft.Lenght = 5;
                Refresh();
            }

            if (modelAirCraft.Speed != 0)
            {
                toolStripStatusLabel1.Text = "Движется";
            }
            else { toolStripStatusLabel1.Text = "Не движется"; }
             // modelAirCraft.Pitch = Convert.ToSingle(Math.Atan((points[j + 5].Y - points[j].Y) / (points[j + 5].X - points[j].X))*Math.PI/180);
            //    modelAirCraft.Lenght = points[j].X;
              //  modelAirCraft.Hight = points[j].Y;
                //modelAirCraft.Step(this.timer1.Interval * 0.1);

                j++;
            Refresh();
        }


        private void button_start_Click(object sender, EventArgs e)
        {
         /*   string node_text;
            node_text = form_mdi.get_node();
            switch (node_text)
            {
                case "Метод Рунге-Кутта": modelAirCraft = new Model_aircraft(new model_aircraft.Method_RungeKutta());
                    break;
                case "Метод Эйлера": modelAirCraft = new Model_aircraft(new model_aircraft.Method_Euler());
                    break;
            }
            */

            modelAirCraft = new Model_aircraft(form_mdi.get_ob());

            timer1.Start();

            modelAirCraft.Speed = this.trackBar_speed.Value;
            modelAirCraft.Pitch = this.trackBar_pitch.Value;

            modelAirCraft.VH = modelAirCraft.Speed_sin();
            modelAirCraft.VL = modelAirCraft.Speed_cos(); 
        }
        private void button_reset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button_chain_Click(object sender, EventArgs e)
        {
            int[] mission_mass = { 1 };
            modelAirCraft.Pitch = Convert.ToInt32(modelAirCraft.mission(mission_mass));
            trackBar_pitch.Value = Convert.ToInt32(modelAirCraft.Pitch);
            trackBar_pitch_Scroll(new object(), new EventArgs());
            //   mission.Mission(mission_mass);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int num = formouse_mdi.get_number_of_points();
            Point[] points = new Point[10000];
            points = formouse_mdi.get_traektory();
            for (int i = 0; i < num - 1; i++)
            {
                MessageBox.Show("" + points[i]);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Скрыть/показать форму с деревом и списком
            if (treeToolStripMenuItem.Checked == true)
            {
                form_mdi.Visible = false;
                treeToolStripMenuItem.Checked = false;
            }
            else
            {
                form_mdi.Visible = true;
                form_mdi.Location = new Point(0, 0);
                treeToolStripMenuItem.Checked = true;
            }
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Скрыть/показать форму с рисовалкой
            if (drawToolStripMenuItem.Checked == true)
            {
                formouse_mdi.Visible = false;
                drawToolStripMenuItem.Checked = false;
            }
            else
            {
                formouse_mdi.Visible = true;
                formouse_mdi.Location = new Point(1025, 1);
                drawToolStripMenuItem.Checked = true;
            }
        }

        
    }
   

}
