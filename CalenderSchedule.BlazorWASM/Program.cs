using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CalenderSchedule.BlazorWASM.Services;

namespace CalenderSchedule.BlazorWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = builder.Configuration["HttpClientBaseAddress"];
            builder.Services.AddHttpClient<ScheduleAPIService>(hc => hc.BaseAddress = new Uri(baseAddress));

            await builder.Build().RunAsync();
        }
    }
}
