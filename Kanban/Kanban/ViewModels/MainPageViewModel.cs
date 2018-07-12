using Kanban.Base;
using Kanban.Helpers;
using Kanban.Models;
using Kanban.Services;
using Kanban.ViewModels.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly NavigationService navigationService;
        private readonly ApiService apiService;

        public ObservableCollection<TaskItemViewModel> ToDo { get; set; }
        public ObservableCollection<TaskItemViewModel> Doing { get; set; }
        public ObservableCollection<TaskItemViewModel> Done { get; set; }
        
        //Ejemplo de comando en un get
        public ICommand AddTaskCommand
        {
            get
            {
                return new Command(() =>
                {
                    navigationService.Navigate(NavigationConstants.NewTask);
                });
            }
        }

        public MainPageViewModel()
        {
            MessagingCenter.Subscribe<string>(this, "ExecuteAction", (actionToExecute) =>
            {
                switch (actionToExecute)
                {
                    case "Clean":
                        ToDo.Clear();
                        Doing.Clear();
                        Done.Clear();
                        break;
                    case "Reset":
                        break;
                    case "OtherPage":
                    case "AboutPage":
                        navigationService.Navigate(actionToExecute);
                        break;
                }
            });

            navigationService = new NavigationService();
            apiService = new ApiService();

            ToDo = new ObservableCollection<TaskItemViewModel>();
            Doing = new ObservableCollection<TaskItemViewModel>();
            Done = new ObservableCollection<TaskItemViewModel>();

            LoadTasks();
        }

        internal async Task RefreshTasks()
        {
            ToDo.Clear();
            Doing.Clear();
            Done.Clear();

            await LoadTasks();
        }

        private async Task LoadTasks()
        {
            var result = await apiService.GetAllTasks();

            if (result.HttpResponse.IsSuccessStatusCode)
            {
                foreach (var item in result.Data)
                {
                    switch (item.Status)
                    {
                        case 0:
                            ToDo.Add(ViewModelHelper.Get(item));
                            break;
                        case 1:
                            Doing.Add(ViewModelHelper.Get(item));
                            break;
                        case 2:
                            Done.Add(ViewModelHelper.Get(item));
                            break;
                    }
                }
            } 
        }
    }
}
