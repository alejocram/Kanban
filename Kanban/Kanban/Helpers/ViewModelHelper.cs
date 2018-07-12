using System;
using System.Collections.Generic;
using System.Text;
using Kanban.Enumerations;
using Kanban.Models;
using Kanban.ViewModels.Domain;

namespace Kanban.Helpers
{
    class ViewModelHelper
    {
        internal static TaskItemViewModel Get(TaskModel item)
        {
            return new TaskItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Date = item.DateTime.Date,
                Time = item.DateTime.TimeOfDay,
                Status = (Statuses)item.Status
            };
        }

        internal static TaskModel Get(TaskItemViewModel item)
        {
            return new TaskModel()
            {
                Id = item.Id,
                DateTime = item.Date.Date.Add(item.Time),
                Name = item.Name,
                Status = (int)item.Status
            };
        }
    }
}
