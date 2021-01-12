using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using CalenderSchedule.Shared;

namespace CalenderSchedule.BlazorWASM.Services
{
    public class ScheduleAPIService : IScheduleAPIService
    {
        private readonly HttpClient client;

        public ScheduleAPIService(HttpClient client)
        {
            this.client = client;
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            await client.PostAsJsonAsync("/api/calender/AddSchedule", schedule);
        }

        public async Task<Schedule> GetScheduleAsync(int Id)
        {
            return await client.GetFromJsonAsync<Schedule>($"/api/calender/getsingleschedule/{Id}");
        }

        public async Task UpdateSchedule(Schedule schedule)
        {
            await client.PostAsJsonAsync("/api/calender/UpdateSchedule", schedule);
        }

        public async Task DeleteSchedule(Schedule schedule)
        {
            await client.PostAsJsonAsync("/api/calender/DeleteSchedule", schedule);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<Schedule>>("/api/calender");
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByDateAsync(DateRequest dateRequest)
        {
            return await client.GetFromJsonAsync<IEnumerable<Schedule>>($"/api/calender/GetSchedulesByDate?year={dateRequest.Year}&month={dateRequest.Month}&day={dateRequest.Day}");
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByDayAsync(int day)
        {
            return await client.GetFromJsonAsync<IEnumerable<Schedule>>($"/api/calender/GetSchedulesByDay/{day}");
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByMonthAsync(int month)
        {
            return await client.GetFromJsonAsync<IEnumerable<Schedule>>($"/api/calender/GetSchedulesByMonth/{month}");
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByYearAsync(int year)
        {
            return await client.GetFromJsonAsync<IEnumerable<Schedule>>($"/api/calender/GetSchedulesByYear/{year}");
        }
    }
}
