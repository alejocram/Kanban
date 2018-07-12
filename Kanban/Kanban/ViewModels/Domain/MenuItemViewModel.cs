using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels.Domain
{
    public class MenuItemViewModel
    {

        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string ActionKey { get; set; }

        public ICommand ExecuteActionCommand { get; set; }

        public MenuItemViewModel()
        {
            ExecuteActionCommand = new Command(ExecuteAction);
        }

        private void ExecuteAction()
        {
            MessagingCenter.Send<string>(ActionKey, "ExecuteAction");
        }
    }
}
