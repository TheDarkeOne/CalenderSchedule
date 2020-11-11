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

        [HttpGet("[action]/{day}")]
        public async Task<IEnumerable<Schedule>> GetSchedulesByDay(int day)
        {
            return await dataService.GetSchedulesByDay(day);
        }

        [HttpGet("[action]/{month}")]
        public async Task<IEnumerable<Schedule>> GetSchedulesByMonth(int month)
        {
            return await dataService.GetSchedulesByMonth(month);
        }

        [HttpGet("[action]/{year}")]
        public async Task<IEnumerable<Schedule>> GetSchedulesByYear(int year)
        {
            return await dataService.GetSchedulesByYear(year);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Schedule>> GetSchedulesByDate(int year, int month, int day)
        {
            return await dataService.GetSchedulesByDate(year,month,day);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<Schedule> GetSingle(int Id)
        {
            return await dataService.GetScheduleById(Id);
        }

        [HttpPost("[action]")]
        public async Task AddCalender([FromBody] Schedule schedule)
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
