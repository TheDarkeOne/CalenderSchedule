using CalenderSchedule.Shared;
using CalenderScheduleMobile.Services;
using CalenderScheduleMobile.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalenderScheduleMobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ICalenderService calenderService;
        private Schedule scheduleItem;
        public MainPageViewModel(INavigationService navigationService, ICalenderService calenderService)
            : base(navigationService)
        {
            Title = "Main Page";
            scheduleItem = new Schedule();
            this.calenderService = calenderService ?? throw new ArgumentNullException(nameof(calenderService));
        }

        public async Task InitializeData() 
        {
            Schedules = await calenderService.GetTutorialsAsync();
        }


        string name;
        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }
        DateTime modelDate;
        public DateTime ModelDate
        {
            get => modelDate;
            set 
            { 
                SetProperty(ref modelDate, value); 
            }
        }
        TimeSpan time;
        public TimeSpan Time
        {
            get => time;
            set { SetProperty(ref time, value); }
        }
        string description;
        public string Description
        {
            get => description;
            set { SetProperty(ref description, value); }
        }

        private IEnumerable<Schedule> schedules;
        public IEnumerable<Schedule> Schedules
        {
            get { return schedules; }
            set { SetProperty(ref schedules, value); }
        }

        private DelegateCommand addSchedule;
        public DelegateCommand AddSchedule =>
            addSchedule ?? (addSchedule = new DelegateCommand(async () =>
            {
                scheduleItem.Name = Name;
                scheduleItem.Day = ModelDate;
                scheduleItem.Time = ModelDate + Time;
                scheduleItem.Description = Description;
                await calenderService.AddSchedule(scheduleItem);
                Name = null;
                ModelDate = DateTime.Now;
                Description = null;
                await InitializeData();
                await NavigationService.NavigateAsync(nameof(ScheduleListPage));
            }));

        private DelegateCommand navigate;
        public DelegateCommand Navigate =>
            navigate ?? (navigate = new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync(nameof(ScheduleListPage));
            }));

    }
}
