using CalenderSchedule.Shared;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalenderScheduleMobile.Services
{
   

    public interface ICalenderService
    {
        [Get("/calender")]
        Task<IEnumerable<Schedule>> GetTutorialsAsync();
        
        [Get("/calender/getsingle/{id}")]
        Task<Schedule> GetTutorialAsync(int id);

        [Post("/calender/addcalender")]
        Task AddSchedule(Schedule newSchedule);
        
        [Post("/calender/update")]
        Task UpdateSchedule(Schedule schedule);
        
        [Post("/calender/delete")]
        Task DeleteSchedule(Schedule schedule);
    }

}
