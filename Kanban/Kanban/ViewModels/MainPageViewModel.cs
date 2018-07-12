using Kanban.Base;
using Kanban.Models;
using Kanban.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels
{
    class MainPageViewModel : BindableBase
    {
        private readonly NavigationService navigationService;

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
            navigationService = new NavigationService();

            ToDo = new ObservableCollection<TaskModel>();
            Doing = new ObservableCollection<TaskModel>();
            Done = new ObservableCollection<TaskModel>();

            ToDo.Add(new TaskModel()
            {
                Id = "1",
                Name = "Task 1",
                DateTime = DateTime.Now,
                Status = 1
            });

            Doing.Add(new TaskModel()
            {
                Id = "2",
                Name = "Task 2",
                DateTime = DateTime.Now,
                Status = 0
            });

            Done.Add(new TaskModel()
            {
                Id = "3",
                Name = "Task 3",
                DateTime = DateTime.Now,
                Status = 1
            });


        }
    }
}
