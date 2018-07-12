using Kanban.Base;
using Kanban.Models;
using Kanban.Services;
using Kanban.Services.LocalDatabase;
using Kanban.Views;
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
        private readonly LocalDatabaseService localDatabaseService;

        public ObservableCollection<TaskModel> ToDo { get; set; }
        public ObservableCollection<TaskModel> Doing { get; set; }

        public ObservableCollection<TaskModel> Done { get; set; }

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
                    case "AboutPage":
                        navigationService.Navigate(actionToExecute);
                        break;
                    default:
                        break;
                }
            });

            navigationService = new NavigationService();
            localDatabaseService = new LocalDatabaseService();

            InitializeDatabase();

            ToDo = new ObservableCollection<TaskModel>();
            Doing = new ObservableCollection<TaskModel>();
            Done = new ObservableCollection<TaskModel>();

            LoadTask();
        }

        private async void LoadTask()
        {
            var allTasks = await localDatabaseService.GetAllTasks();

            foreach (var item in allTasks)
            {
                switch (item.Status)
                {
                    case 0:
                        ToDo.Add(item);
                        break;
                    case 1:
                        Doing.Add(item);
                        break;
                    case 2:
                        Done.Add(item);
                        break;
                }
            }
        }

        private async void InitializeDatabase()
        {
            await localDatabaseService.Initialize();
        }
    }
}
