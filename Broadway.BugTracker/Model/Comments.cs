using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.BugTracker.Model
{
    public class Comments
    {
        [Key]
        public Guid CommentId { get; set; }
    }
}
