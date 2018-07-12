using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Services
{
    class DialogService
    {
        internal void ShowMessage(string message)
        {
            App.Navigator.DisplayAlert("Kanban", message, "OK");
        }

        internal async Task<string> ShowOptions(string message, List<string> options)
        {
            return await App.Navigator.DisplayActionSheet(message, "Cancelar", null, options.ToArray());
        }
    }
}
