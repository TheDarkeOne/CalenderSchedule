using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalenderSchedule.Shared;
using CalenderScheduleAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalenderScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        private readonly IDataService dataService;

        public CalenderController(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpGet]
        public async Task<IEnumerable<Schedule>> Get()
        {
            return await dataService.GetSchedules();
        }

        [HttpGet("[action]/{dateTime}")]
        public async Task<IEnumerable<Schedule>> GetScheduleByDay(DateTime dateTime)
        {
            var Day = dateTime.Day;
            return await dataService.GetSchedulesByDay(Day);
        }

        [HttpGet("[action]/{dateTime}")]
        public async Task<IEnumerable<Schedule>> GetScheduleByMonth(DateTime dateTime)
        {
            var Month = dateTime.Month;
            return await dataService.GetSchedulesByMonth(Month);
        }

        [HttpGet("[action]/{dateTime}")]
        public async Task<IEnumerable<Schedule>> GetScheduleByYear(DateTime dateTime)
        {
            var Year = dateTime.Year;
            return await dataService.GetSchedulesByYear(Year);
        }

        [HttpGet("[action]/{dateTime}")]
        public async Task<IEnumerable<Schedule>> GetScheduleByDate(DateTime dateTime)
        {
            var Day = dateTime.Day;
            var Month = dateTime.Month;
            var Year = dateTime.Year;
            return await dataService.GetSchedulesByDate(Year,Month,Day);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<Schedule> GetSingle(int Id)
        {
            return await dataService.GetScheduleById(Id);
        }

        [HttpPost("[action]")]
        public async Task AddCalender(Schedule schedule)
        {

            await dataService.Calender(schedule);
        }

        [HttpPost("[action]")]
        public async Task Update(Schedule schedule)
        {
            await dataService.Update(schedule);
        }

        [HttpPost("[action]")]
        public async Task Delete(Schedule schedule)
        {
            await dataService.Delete(schedule);
        }
    }
}
