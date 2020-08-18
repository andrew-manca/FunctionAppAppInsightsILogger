using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp4
{
    //Logging to App Insights with other class.
    public class TestInterfaceLogging : ITestInterfaceLogging
    {
        private ILogger<TestInterfaceLogging> Logging;
        public TestInterfaceLogging(ILogger<TestInterfaceLogging> logger)
        {
            Logging = logger;
        }

        public void logStuff()
        {
            Logging.LogInformation("Information");
            Logging.LogDebug("Debug");
            Logging.LogError("Error");
        }
    }
}
