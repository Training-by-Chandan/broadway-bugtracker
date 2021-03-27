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
            dataGridView1.DataSource = workItemService.GetAll();
            dataGridView1.Refresh();
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
    }
}
