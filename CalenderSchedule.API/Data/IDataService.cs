using CalenderSchedule.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalenderScheduleAPI.Data
{
    public interface IDataService
    {
        Task<IEnumerable<Schedule>> GetSchedule();
        Task<Schedule> GetScheduleById(int Id);
        Task Calender(Schedule schedule);
        Task Update(Schedule schedule);
        Task Delete(Schedule schedule);
    }
}
