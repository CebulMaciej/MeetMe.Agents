using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.WebApi;
using MeetAgents.Application;
using MeetMe.Agents.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Open.Serialization.Json.Newtonsoft;

namespace MeetMe.Agents.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddControllers().AddNewtonsoftJson();
                    JsonSerializerSettings defaultOptions = new JsonSerializerSettings();
                    services.TryAddSingleton(new JsonSerializerFactory(defaultOptions).GetSerializer());
                    
                    services
                        .AddConvey()
                        .AddApplication()
                        .AddWebApi()
                        .AddInfrastructure()
                        .Build();
                })
                .Configure(app => app
                    .UseInfrastructure()
                    .UseRouting()
                    .UseEndpoints(c => c.MapControllers()))
                .UseLogging();
    }
}