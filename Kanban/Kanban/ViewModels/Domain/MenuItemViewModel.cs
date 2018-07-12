using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.ViewModels.Domain
{
    public class MenuItemViewModel
    {

        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public string ActionKey { get; set; }
    }
}
