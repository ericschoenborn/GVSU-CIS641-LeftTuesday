using LeftTuesday.Repository;
using LeftTuesday.Services;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System;

namespace LeftTuesday
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var ini = new InitializeService();
            var iniError = ini.InitializeDatabase();
            if (iniError != null) { throw new Exception("Could not initialize database connection."); }

            await new HostBuilder()
            .ConfigureServices(services => services.AddAutofac())
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterType<ConceptService>().AsSelf();
                builder.RegisterType<ConceptRepository>().AsSelf();

                builder.RegisterType<TaskService>().AsSelf();
                builder.RegisterType<TaskRepository>().AsSelf();

                builder.RegisterType<ContentService>().AsSelf();
                builder.RegisterType<ContentRepository>().AsSelf();

                builder.RegisterType<ConceptTaskService>().AsSelf();
                builder.RegisterType<ConceptTaskRepository>().AsSelf();

                builder.RegisterType<TaskContentService>().AsSelf();
                builder.RegisterType<TaskContentRepository>().AsSelf();

                builder.RegisterType<UserService>().AsSelf();
                builder.RegisterType<UserRepository>().AsSelf();

                builder.RegisterType<SessionService>().AsSelf();
                builder.RegisterType<SessionRepository>().AsSelf();
            })
            .UseConsoleLifetime()
            .Build()
            .RunAsync();
        }                   
    }
}
