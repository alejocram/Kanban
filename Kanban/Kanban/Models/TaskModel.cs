using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Models
{
    class TaskModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int Status { get; set; }
    }
}
