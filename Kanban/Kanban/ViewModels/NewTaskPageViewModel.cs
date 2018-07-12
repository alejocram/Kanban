using Kanban.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels
{
    class NewTaskPageViewModel: BindableBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public ICommand CreateCommand { get; set; }

        public NewTaskPageViewModel()
        {
            CreateCommand = new Command(Create);
        }

        private void Create()
        {
            
        }
    }
}
