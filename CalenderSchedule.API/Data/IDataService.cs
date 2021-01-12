using CalenderSchedule.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalenderScheduleAPI.Data
{
    public interface IDataService
    {
        Task<IEnumerable<Schedule>> GetSchedules();
        Task<IEnumerable<Schedule>> GetSchedulesByDay(int Day);
        Task<IEnumerable<Schedule>> GetSchedulesByMonth(int Month);
        Task<IEnumerable<Schedule>> GetSchedulesByYear(int Year);
        Task<IEnumerable<Schedule>> GetSchedulesByDate(int Year, int Month, int Day);
        Task<Schedule> GetScheduleById(int Id);
        Task AddSchedule(Schedule schedule);
        Task UpdateSchedule(Schedule schedule);
        Task DeleteSchedule(Schedule schedule);
    }
}
