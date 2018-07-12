using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services
{
    class DialogService
    {
        internal void ShowMessage(string message)
        {
            App.Navigator.DisplayAlert("Kanban", message, "OK");
        }
    }
}
