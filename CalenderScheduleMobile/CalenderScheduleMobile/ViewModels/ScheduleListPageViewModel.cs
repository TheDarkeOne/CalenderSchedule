using CalenderSchedule.Shared;
using CalenderScheduleMobile.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CalenderScheduleMobile.ViewModels
{
    public class ScheduleListPageViewModel : ViewModelBase
    {
        private readonly ICalenderService calenderService;
        private Schedule scheduleItem;
        public ScheduleListPageViewModel(INavigationService navigationService, ICalenderService calenderService)
            : base(navigationService)
        {
            Title = "Main Page";
            scheduleItem = new Schedule();
            Schedules = new ObservableCollection<Schedule>();
            this.calenderService = calenderService ?? throw new ArgumentNullException(nameof(calenderService));
        }

        private IEnumerable<Schedule> schedules;
        public IEnumerable<Schedule> Schedules
        {
            get { return schedules; }
            set { SetProperty(ref schedules, value); }
        }

        private DelegateCommand getSchedules;
        public DelegateCommand GetSchedules =>
            getSchedules ?? (getSchedules = new DelegateCommand(async () =>
            {
                Schedules = await calenderService.GetTutorialsAsync();
            }));
    }
}
