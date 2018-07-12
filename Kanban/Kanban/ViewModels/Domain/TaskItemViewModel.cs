using Kanban.Enumerations;
using Kanban.Helpers;
using Kanban.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels.Domain
{
    public class TaskItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Statuses Status { get; set; }

        public DateTime DateTIme
        {
            get
            {
                return Date.Date.Add(Time);
            }
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }

        private readonly ApiService apiService;
        private readonly DialogService dialogService;

        public TaskItemViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();

            DeleteCommand = new Command(async () => await Delete());
            ChangeStatusCommand = new Command(async () => await ChangeStatus());
        }

        private async Task ChangeStatus()
        {
            List<string> options = new List<string>();
            switch (Status)
            {
                case Statuses.ToDo:
                    options.Add("Doing");
                    options.Add("Done");
                    break;
                case Statuses.Doing:
                    options.Add("To Do");
                    options.Add("Done");
                    break;
                case Statuses.Done:
                    options.Add("To Do");
                    options.Add("Doing");
                    break;
            }

            var selectedOption = await dialogService.ShowOptions("Seleccione el nuevo estado", options);

            switch (selectedOption)
            {
                case "To Do":
                    this.Status = Statuses.ToDo;
                    break;
                case "Doing":
                    this.Status = Statuses.Doing;
                    break;
                case "Done":
                    this.Status = Statuses.Done;
                    break;
            }

            var result = await apiService.Update(ViewModelHelper.Get(this));
            var data = await result.HttpResponse.Content.ReadAsStringAsync();
            if (result.HttpResponse.IsSuccessStatusCode)
            {
                await App.Locator.MainPage.RefreshTasks();
            }
            else
                dialogService.ShowMessage("An error has ocurred");
        }

        private async Task Delete()
        {
            await apiService.DeleteTaskById(this.Id);
            await App.Locator.MainPage.RefreshTasks();
            dialogService.ShowMessage("La tarea ha sido eliminada");
        }
    }
}
