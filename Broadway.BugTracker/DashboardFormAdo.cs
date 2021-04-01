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
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from workitems", conn);

            conn.Open();
            var reader=cmd.ExecuteReader();

            List<WorkItemViewModel> lists = new List<WorkItemViewModel>();
            while(reader.Read())
            {
                var item = new WorkItemViewModel();
                item.Id = reader.GetFieldValue<int>(0);
                item.Title = reader.GetFieldValue<string>(1);
                lists.Add(item);
            }

            conn.Close();
        }
    }
}
