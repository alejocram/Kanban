using Kanban.Base;
using Kanban.ViewModels.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kanban.ViewModels
{
    class MenuPageViewModel: BindableBase
    {

        public ObservableCollection<MenuItemViewModel> Items { get; set; }

        public MenuPageViewModel()
        {
            Items = new ObservableCollection<MenuItemViewModel>();

            Items.Add(new MenuItemViewModel()
            {
                Name = "Clean",
                Description = "Delete all elements in the board",
                Picture = "ic_clean.png",
                ActionKey = "Clean"
            });

            Items.Add(new MenuItemViewModel()
            {
                Name = "Reset",
                Description = "Set all task in To Do list",
                Picture = "ic_reset.png",
                ActionKey = "Reset"
            });

            Items.Add(new MenuItemViewModel()
            {
                Name = "About",
                Description = "About the developers",
                Picture = "ic_about.png",
                ActionKey = "AboutPage"
            });


        }
    }
}
