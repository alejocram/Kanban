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
            switch (pageKey)
            {
                case NavigationConstants.NewTask:
                    App.Navigator.PushAsync(new NewTaskPage());
                    break;
                default:
                    break;
            }
        }
    }
}
