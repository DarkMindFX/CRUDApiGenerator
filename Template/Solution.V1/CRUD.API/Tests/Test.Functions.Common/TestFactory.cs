using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PPT.Test.Functions.Common
{
    public class TestFactory
    {
        private const string AuthenticationHeaderName = "Authorization";
        private const string BearerPrefix = "Bearer";

        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        public static HttpRequest CreateHttpRequest(string authToken = null)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            AddAuthToken(request, authToken);
            return request;
        }

        public static HttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue, string authToken = null)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            AddAuthToken(request, authToken);
            request.Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue));
            return request;
        }

        public static HttpRequest CreateHttpRequest(object body, string authToken = null)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            AddAuthToken(request, authToken);
            request.Body = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(body));
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

        public static void AddAuthToken(HttpRequest request, string token)
        {
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Add(AuthenticationHeaderName, $"{BearerPrefix} {token}");
            }
        }
    }
}
