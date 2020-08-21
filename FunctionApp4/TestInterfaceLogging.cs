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
            Logging.LogInformation(new EventId((int)LoggingConstants.EventId.SubmissionSucceeded),
                          LoggingConstants.Template,
                          LoggingConstants.EventId.SubmissionSucceeded.ToString(),
                          LoggingConstants.EntityType.Order.ToString(),
                          "Other Class",
                          LoggingConstants.Status.Succeeded.ToString(),
                          Guid.NewGuid().ToString(),
                          LoggingConstants.CheckPoint.Publisher.ToString(),
                          "");
            Logging.LogDebug("Debug");
            Logging.LogError("Error");
        }
    }
}
