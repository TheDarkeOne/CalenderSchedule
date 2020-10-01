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
    [Route("[controller]")]
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
            return await dataService.GetSchedule();
        }

        [HttpGet("[action]/{id}")]
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
