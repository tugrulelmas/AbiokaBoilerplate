﻿using AbiokaBoilerplate.ApplicationService.Abstractions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AbiokaBoilerplate.ApplicationService.Implementations
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient client;

        public CustomHttpClient() {
#if DEBUG
            var httpClientHandler = new HttpClientHandler {
                Proxy = new AbiokaProxy(new Uri("http://10.0.7.224:8080")),
                UseProxy = true
            };
            client = new HttpClient(httpClientHandler);

#endif
#if !DEBUG
            client = new HttpClient();
#endif
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri) => client.GetAsync(requestUri);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) => client.SendAsync(request);
    }
}
