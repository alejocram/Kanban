using Kanban.ViewModels.Base;
using Kanban.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Kanban
{
	public partial class App : Application
	{
        public static NavigationPage Navigator { get; internal set; }
        public static ViewModelLocator Locator { get; internal set; }
        public static MasterPage Master { get; internal set; }

        public App ()
		{
			InitializeComponent();
            Locator = (ViewModelLocator)this.Resources["Locator"];
			MainPage = new MasterPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
