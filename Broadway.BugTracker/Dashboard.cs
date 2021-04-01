using Broadway.BugTracker.Model;
using Broadway.BugTracker.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.BugTracker
{
    public partial class Dashboard : Form
    {
        private WorkItemService workItemService = new WorkItemService();
        private LoginService loginService = new LoginService();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            RefreshWorkITems();
        }

        void PopulateComboBox()
        {
            
        }

        void RefreshWorkITems()
        {
            //dataGridView1.DataSource = workItemService.GetAll();
            //dataGridView1.Refresh();

            //clearing items in the list 
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            //fetching all work items
            var data = workItemService.GetAll();
            
            //separating items
            var todoitem = data.Where(p => p.Status == WorkItemStatus.ToDo).ToArray();
            var inProgressItem = data.Where(p => p.Status == WorkItemStatus.InProgress).ToArray();
            var doneItem = data.Where(p => p.Status == WorkItemStatus.Done).ToArray();

            //filling up items in respective list
            listBox1.Items.AddRange(todoitem);
            listBox2.Items.AddRange(inProgressItem);
            listBox3.Items.AddRange(doneItem);

            //refreshing the list
            listBox1.Refresh();
            listBox2.Refresh();
            listBox3.Refresh();

        }

        void ResetForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var item = new WorkItems() {
                Title = textBox1.Text,
                Description=textBox2.Text,
                
            };

            var result = workItemService.CreateWorkItem(item);

            if (result.Item1)
            {
                //success message
                RefreshWorkITems();
                ResetForm();
                //comboBox1.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(result.Item2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item!=null)
            {

                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                workItemService.ChangeStateofWorkItem(id, WorkItemStatus.InProgress);
                RefreshWorkITems();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var item = listBox2.SelectedItem;
            if (item != null)
            {

                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                workItemService.ChangeStateofWorkItem(id, WorkItemStatus.ToDo);
                RefreshWorkITems();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var item = listBox2.SelectedItem;
            if (item != null)
            {

                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                workItemService.ChangeStateofWorkItem(id, WorkItemStatus.Done);
                RefreshWorkITems();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var item = listBox3.SelectedItem;
            if (item != null)
            {

                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                workItemService.ChangeStateofWorkItem(id, WorkItemStatus.InProgress);
                RefreshWorkITems();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                var workItem = workItemService.GetbyId(id);
                textBox1.Text = workItem.Title;
                textBox2.Text = workItem.Description;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox2.SelectedItem;
            if (item != null)
            {
                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                var workItem = workItemService.GetbyId(id);
                textBox1.Text = workItem.Title;
                textBox2.Text = workItem.Description;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox3.SelectedItem;
            if (item != null)
            {
                var itemArray = item.ToString().Split(':');
                var id = Convert.ToInt32(itemArray[0]);
                var workItem = workItemService.GetbyId(id);
                textBox1.Text = workItem.Title;
                textBox2.Text = workItem.Description;
            }
        }
    }
}
