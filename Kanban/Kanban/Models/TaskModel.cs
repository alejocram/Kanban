using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int Status { get; set; }
    }
}
