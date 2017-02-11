using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiExample.Test
{
    public class ResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> _responses = new Dictionary<Uri, HttpResponseMessage>();

        public void AddResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            _responses.Add(uri,responseMessage);
        }

        protected override Task<HttpResponseMessage> SendAsync
        (
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            if (_responses.ContainsKey(request.RequestUri))
            {
                return Task.FromResult(_responses[request.RequestUri]);
            }
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request});
        }
    }
}
