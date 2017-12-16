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

namespace C_sharp_lab_2
{
    //синглтон
    //1) закрыть конструктор, нельзя создать объект
    //2) внутри класса создается статический объект
    //3) функция доступа
    //sealed - от класса нельзя ничего пронаследовать, нельзя использовать protected

    public sealed partial class Form_aircraft : Form
    {
        TreeNode root;
        string text = "";
        TreeNode object_in_node = new TreeNode();   //Объект дерева для хранения объекта метода
        static Form_aircraft formAicraft = new Form_aircraft();
        public static Form_aircraft Instance_form_aircraft
        {
            get { return formAicraft; }
        }
      
        private Form_aircraft()
        {
           
            InitializeComponent();
            this.Location = new Point(0,0);
            this.FormBorderStyle = FormBorderStyle.None;
         /* treeView1.Nodes.Add("Solution");
            treeView1.Nodes[0].Nodes.Add("Система координат");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("pitch");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("roll");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("yaw");
            treeView1.Nodes[0].Nodes.Add("Атрибуты");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Высота");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Длительность полета");*/

            //или через root
            
            root = this.treeView1.Nodes.Add("Solution");
            root.Nodes.Add("Система координат");
            root.Nodes[0].Nodes.Add("Угол тангажа");
            root.Nodes[0].Nodes.Add("Угол крена");
            root.Nodes[0].Nodes.Add("Угол рысканья");
            root.Nodes.Add("Атрибуты");
            root.Nodes[1].Nodes.Add("Высота");
            root.Nodes[1].Nodes.Add("Длительность полета");
            root.Nodes.Add("Метод");


            ListViewItem item_runge = new ListViewItem();    //объект в списке, метод Рунге-Кутта
            item_runge.Text = "Объект Рунге";
            //Tag Получает или задает объект, содержащий данные, сопоставленные данному элементу, т.е. объекту рунге
            item_runge.Tag = new Method_RungeKutta();                         
            listView1.Items.Add(item_runge);

            ListViewItem item_euler = new ListViewItem();    //объект в списке, Метод Эйлера
            item_euler.Text = "Объект Эйлер";
            //Tag Получает или задает объект, содержащий данные, сопоставленные данному элементу, т.е. объекту рунге
            item_euler.Tag = new Method_Euler();
            listView1.Items.Add(item_euler);
        }

        
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          //  MessageBox.Show(e.Node.Text);
            if (e.Node.Text == "Угол тангажа")
            {
                System.Diagnostics.Process.Start("C_sharp_lab_1");    //диагностика первой лабы
                new System_koord().ShowDialog();

            }
        }

        string Visit(TreeNodeCollection nodes)
        {
            foreach (TreeNode SubNode in nodes)
            {
                if (SubNode.Text == "Метод Рунге-Кутта")
                {
                    text = SubNode.Text;
                    Method_RungeKutta met = new Method_RungeKutta();
                }
                else if (SubNode.Text == "Метод Эйлера")
                {
                    text = SubNode.Text;
                    Method_Euler eul = new Method_Euler();
                  //  Model_aircraft modelAirCraft = new Model_aircraft(new model_aircraft.Method_Euler());
                  //  new Form1(modelAirCraft).ShowDialog();
                }
                Visit(SubNode.Nodes);
            }
            return text;
        }

        public AbstractMethod get_ob()
        {
            AbstractMethod method_diff = (AbstractMethod)object_in_node.Tag;
            return method_diff;
        }
        public string get_node()
        {
            string text = "";
            text = Visit(treeView1.Nodes);
           // MessageBox.Show("" + text);
            return text;
        }

        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object_in_node.Tag = listView1.SelectedItems[0].Tag;               //объект дерева = объект списка
            object_in_node.Text = listView1.SelectedItems[0].Text;             //переносим название из списка в дерево
            root.Nodes[2].Nodes.Add(object_in_node);                           //добавляем узел
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Nodes.Add(toolStripTextBox1.Text);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

                 //   treeView1.SelectedNode.Nodes.Add(toolStripTextBox1.Text);

    }
}
