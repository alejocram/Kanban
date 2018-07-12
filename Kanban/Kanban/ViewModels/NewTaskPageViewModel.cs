using Kanban.Base;
using Kanban.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels
{
    class NewTaskPageViewModel: BindableBase
    {
        private readonly NavigationService navigationService;
        private readonly ApiService apiService;
        private readonly DialogService dialogService;

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public ICommand CreateCommand { get; set; }

        public NewTaskPageViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();
            dialogService = new DialogService();

            CreateCommand = new Command(async() => await Create());
            Date = DateTime.Now;
        }

        private async Task Create()
        {
            var newTask = new Models.TaskModel()
            {
                Name = this.Name,
                DateTime = this.Date.Date.Add(this.Time),
            };

            var result = await apiService.Create(newTask);
            var data = await result.HttpResponse.Content.ReadAsStringAsync();
            if (result.HttpResponse.IsSuccessStatusCode)
            {
                dialogService.ShowMessage("The task has been created.");

                await App.Locator.MainPage.RefreshTasks();

                navigationService.GoBack();
            }
            else
                dialogService.ShowMessage("An error has ocurred");
        }
    }
}
