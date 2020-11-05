using CalenderSchedule.Shared;
using CalenderScheduleMobile.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalenderScheduleMobile.ViewModels
{
    public class ScheduleDetailPageViewModel : ViewModelBase
    {

        private readonly ICalenderService calenderService;
        public ScheduleDetailPageViewModel(INavigationService navigationService, ICalenderService calenderService): base(navigationService)
        {
            this.calenderService = calenderService ?? throw new ArgumentNullException(nameof(calenderService));
        }

        public Schedule Schedule { get; private set; }

        private int id;
        public int Id
        {
            get => id;
            set { SetProperty(ref id, value); }
        }

        private string name;
        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }

        private int day;
        public int Day
        {
            get => day;
            set { SetProperty(ref day, value); }
        }

        private int month;
        public int Month
        {
            get => month;
            set { SetProperty(ref month, value); }
        }

        private int year;
        public int Year
        {
            get => year;
            set { SetProperty(ref year, value); }
        }

        private DateTime time;
        public DateTime Time
        {
            get => time;
            set { SetProperty(ref time, value); }
        }

        private string description;
        public string Description
        {
            get => description;
            set { SetProperty(ref description, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Schedule = (Schedule)parameters["schedule"];

            if (Schedule == null)
            {
                NavigationService.GoBackAsync();
            }
            else
            {
                Id = Schedule.Id;
                Name = Schedule.Name;
                Day = Schedule.Day;
                Month = Schedule.Month;
                Year = Schedule.Year;
                Time = Schedule.Time;
                Description = Schedule.Description;
                
            }
        }

        private DelegateCommand updateSchedule;
        public DelegateCommand UpdateSchedule =>
            updateSchedule ?? (updateSchedule = new DelegateCommand(async () =>
            {
                var date = new DateTime(Schedule.Year, Schedule.Month, Schedule.Day, Schedule.Time.Hour, Schedule.Time.Minute, Schedule.Time.Second);
                Schedule.Time = date;
                await calenderService.UpdateSchedule(Schedule);
                await NavigationService.GoBackAsync();
            }));
    }
}
