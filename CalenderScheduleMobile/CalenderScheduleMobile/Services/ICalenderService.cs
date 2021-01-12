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
        Task<IEnumerable<Schedule>> GetSchedulesAsync();
        [Get("/api/calender/GetSchedulesByDay/{day}")]
        Task<IEnumerable<Schedule>> GetSchedulesByDayAsync(int day);
        [Get("/api/calender/GetSchedulesByMonth/{month}")]
        Task<IEnumerable<Schedule>> GetSchedulesByMonthAsync(int month);
        [Get("/api/calender/GetSchedulesByYear/{year}")]
        Task<IEnumerable<Schedule>> GetSchedulesByYearAsync(int year);
        [Get("/api/calender/GetSchedulesByDate?year={year}&month={month}&day={day}")]
        Task<IEnumerable<Schedule>> GetSchedulesByDateAsync(int year, int month, int day);

        [Get("/api/calender/getsingleschedule/{id}")]
        Task<Schedule> GetScheduleAsync(int id);

        [Post("/api/calender/addschedule")]
        Task AddSchedule(Schedule newSchedule);
        
        [Post("/api/calender/updateschedule")]
        Task UpdateSchedule(Schedule schedule);
        
        [Post("/api/calender/deleteschedule")]
        Task DeleteSchedule(Schedule schedule);
    }

}
