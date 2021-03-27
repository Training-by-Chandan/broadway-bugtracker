using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.BugTracker.ViewModel
{
    public class WorkItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AssigneeName { get; set; }
        public string ReporterName { get; set; }
    }
}
