using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.BugTracker.Model
{
    public class WorkItems
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AsigneeId { get; set; }
        public int? ReporterId { get; set; }

        [ForeignKey("AsigneeId")]
        public virtual User Asignee { get; set; }
        [ForeignKey("ReporterId")]
        public virtual User Reporter { get; set; }
        public WorkItemStatus Status { get; set; }
    }

    public enum WorkItemStatus
    {
        ToDo=0,
        InProgress=1,
        Done=2
    }
}
