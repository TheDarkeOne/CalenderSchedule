using Prism;
using Prism.Ioc;
using CalenderScheduleMobile.ViewModels;
using CalenderScheduleMobile.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Refit;
using CalenderScheduleMobile.Services;

namespace CalenderScheduleMobile
{
    public partial class App
    {
        string scheduleAddress = "http://localhost:5005";
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            var EPService = RestService.For<ICalenderService>(scheduleAddress);
            containerRegistry.RegisterInstance(EPService);
            containerRegistry.RegisterForNavigation<ScheduleListPage, ScheduleListPageViewModel>();
            containerRegistry.RegisterForNavigation<ScheduleDetailPage, ScheduleDetailPageViewModel>();
        }
    }
}
