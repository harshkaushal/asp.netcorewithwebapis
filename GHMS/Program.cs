using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace GHMS
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();
        public static void Main(string[] args)
        {
            CreateMSSqlLogger();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()

                .UseConfiguration(Configuration)
                .UseSerilog();


        public static void CreateMSSqlLogger()
        {
            var connectionString = Configuration.GetConnectionString("MasterDbConnection");//@"Server=gboxdev;Database=VMBMaster1.1;user Id=InternalDeveloper;Password=gBox1!2;Trusted_Connection=False;MultipleActiveResultSets=true;";
            var tableName = "Logs";

            var columnOption = new ColumnOptions();
            // columnOption.Store.Remove(StandardColumn.MessageTemplate);
            //IDictionary<string, ColumnWriterBase>
            //columnOption.AdditionalDataColumns = new Collection<DataColumn>
            //{
            //    new DataColumn {DataType = typeof (string), ColumnName = "Project"},
            //    new DataColumn {DataType = typeof (string), ColumnName = "ControllerName"},
            //    new DataColumn {DataType = typeof (string), ColumnName = "ActionName"} 
            //};

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                //.MinimumLevel.Override("SerilogDemo", LogEventLevel.Error)
                .WriteTo.PostgreSQL(connectionString, tableName
                    //columnOptions: columnOption

                )
                .CreateLogger();
        }
    }
}
