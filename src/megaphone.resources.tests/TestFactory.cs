using Microsoft.AspNetCore.Http;
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
    }
}