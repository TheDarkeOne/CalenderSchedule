using CalenderSchedule.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalenderScheduleAPI.Data
{
    public class EFCoreService : IDataService
    {
        private readonly ApplicationDBContext applicationDBContext;
        
        public EFCoreService(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext ?? throw new ArgumentNullException(nameof(applicationDBContext));

        }

        public async Task Calender(Schedule schedule)
        {
            applicationDBContext.Schedule.Add(schedule);
            await applicationDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Schedule>> GetSchedule()
        {
            return await applicationDBContext.Schedule.ToListAsync();
        }

        public async Task<Schedule> GetScheduleById(int Id)
        {
            return await applicationDBContext.Schedule.FindAsync(Id);
        }

        public async Task Update(Schedule schedule)
        {
            applicationDBContext.Schedule.Update(schedule);
            await applicationDBContext.SaveChangesAsync();
        }
        public async Task Delete(Schedule schedule)
        {
            applicationDBContext.Schedule.Remove(schedule);
            await applicationDBContext.SaveChangesAsync();
        }

    }
}
