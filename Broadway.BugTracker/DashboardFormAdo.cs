using Broadway.BugTracker.Model;
using Broadway.BugTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.BugTracker
{
    public partial class DashboardFormAdo : Form
    {
        public DashboardFormAdo()
        {
            InitializeComponent();
        }

        private void DashboardFormAdo_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from workitems", conn);

            conn.Open();
            var reader = cmd.ExecuteReader();

            List<WorkItemViewModel> lists = new List<WorkItemViewModel>();
            while (reader.Read())
            {
                var item = new WorkItemViewModel();
                item.Id = reader.GetFieldValue<int>(0);
                item.Title = reader.GetFieldValue<string>(1);
                item.Status = reader.GetFieldValue<WorkItemStatus>(5);
                lists.Add(item);
            }

            dataGridView1.DataSource = lists;
            dataGridView1.Refresh();

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"insert into WorkItems (Title, Description, Status) values ('{textBox1.Text}','',0)", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();

            RefreshGrid();
        }
    }
}
