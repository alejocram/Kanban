using Kanban.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services
{
    public class NavigationService
    {
        public void Navigate(string pageKey)
        {
            App.Master.IsPresented = false;

            switch (pageKey)
            {
                case NavigationConstants.NewTask:
                    App.Navigator.PushAsync(new NewTaskPage());
                    break;
                case NavigationConstants.About:
                    App.Navigator.PushAsync(new AboutPage());
                    break;
                default:
                    break;
            }
        }

        internal void GoBack()
        {
            App.Navigator.PopAsync();
        }
    }
}
