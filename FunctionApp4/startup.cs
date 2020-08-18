using FunctionApp4;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyNamespace;

[assembly: FunctionsStartup(typeof(Startup))]

namespace MyNamespace
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddLogging(options =>
            //{
            //    options.AddFilter("FunctionApp4", LogLevel.Information);
            //});

            builder.Services.AddSingleton<ITestInterfaceLogging, TestInterfaceLogging>();
        }
    }
}