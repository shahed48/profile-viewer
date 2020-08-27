using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class TaskViewModel
    {
        public long Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string NameOfAssignee { get; set; }
        public DateTime StartingDate { get; set; }
        public int NoOfDays { get; set; }
        public string Status { get; set; }
    }
}
