using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.ViewModels.Base
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage { get; set; }

        public ViewModelLocator()
        {
            MainPage = new MainPageViewModel();
        }
    }
}
