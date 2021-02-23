using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Megaphone.Resources.Tests
{
    public class TestFactory
    {
        public static HttpRequest CreatePostHttpRequest(object body)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;

            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body)));
            return request;
        }
         public static HttpRequest CreateGetHttpRequest()
        {
            var context = new DefaultHttpContext();
            var request = context.Request;

            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}