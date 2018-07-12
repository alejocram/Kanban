using Kanban.Base;
using Kanban.Services;
using Kanban.Services.LocalDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels
{
    public class NewTaskPageViewModel: BindableBase
    {
        private readonly NavigationService navigationService;
        private readonly LocalDatabaseService localDatabaseService;
        private readonly DialogService dialogService;
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public ICommand CreateCommand { get; set; }

        public NewTaskPageViewModel()
        {
            localDatabaseService = new LocalDatabaseService();
            navigationService = new NavigationService();
            dialogService = new DialogService();

            //Realizamos el llamado por un hilo aparte
            CreateCommand = new Command(async() => await Create());
        }

        private async Task Create()
        {
            var newTask = new Models.TaskModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = this.Name,
                DateTime = this.Date.Date.Add(this.Time),
            };
            await localDatabaseService.Create(newTask);
            dialogService.ShowMessage("The task has been created");
            App.Locator.MainPage.ToDo.Add(newTask);

            navigationService.GoBack();
        }
    }
}
