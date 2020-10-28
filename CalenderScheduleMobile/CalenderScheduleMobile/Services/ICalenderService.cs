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
        [Get("/api/calender")]
        Task<IEnumerable<Schedule>> GetTutorialsAsync();
        
        [Get("/api/calender/getsingle/{id}")]
        Task<Schedule> GetTutorialAsync(int id);

        [Post("/api/calender/addcalender")]
        Task AddSchedule(Schedule newSchedule);
        
        [Post("/api/calender/update")]
        Task UpdateSchedule(Schedule schedule);
        
        [Post("/api/calender/delete")]
        Task DeleteSchedule(Schedule schedule);
    }

}
