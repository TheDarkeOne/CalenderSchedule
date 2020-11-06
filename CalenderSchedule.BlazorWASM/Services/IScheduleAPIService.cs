using CalenderSchedule.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalenderSchedule.BlazorWASM.Services
{
    interface IScheduleAPIService
    {
        Task<IEnumerable<Schedule>> GetSchedulesAsync();
        Task<IEnumerable<Schedule>> GetSchedulesByDayAsync(int day);
        Task<IEnumerable<Schedule>> GetSchedulesByMonthAsync(int month);
        Task<IEnumerable<Schedule>> GetSchedulesByYearAsync(int year);
        Task<IEnumerable<Schedule>> GetSchedulesByDateAsync(DateRequest dateRequest);
        Task<Schedule> GetScheduleAsync(int Id);
        Task UpdateSchedule(Schedule schedule);
        Task DeleteSchedule(Schedule schedule);
        Task AddScheduleAsync(Schedule schedule);
    }
}
